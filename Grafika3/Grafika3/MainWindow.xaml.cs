using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace Grafika3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Drawing.Point _mouseStart;
        private bool _mouseCaptured;
        private Form _form;
        private Vector3 _activeRotation;
        private Vector3 _initialRotation;
        float mousemult = 1;
        float mouseYMult = 1;

        private Renderer _renderer;
        private GLControl _glControl;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            this._renderer = new Renderer();


            this._glControl = new GLControl();
            this._glControl.Paint += this.GlcontrolOnPaint;
            this._glControl.Dock = DockStyle.Fill;
            this.Host.Child = this._glControl;
            _glControl.MouseDown += GlControlOnMouseDown;
            _glControl.MouseUp += GlControlOnMouseUp;
            _glControl.MouseMove += GlControlOnMouseMove;
        }
        private void MainWindow_OnUnloaded(object sender, RoutedEventArgs e)
        {
            _form.Dispose();
        }

        #region GL Control

        private void GlControlOnMouseMove(object sender, MouseEventArgs e)
        {
            if (!_mouseCaptured) return;

            var current = e.Location;
            float multiplier = 200;
            Vector3 delta = new Vector3();
            delta.Y = ((float)current.X - (float)_mouseStart.X) * multiplier / _glControl.ClientSize.Width;
            delta.X = ((float)current.Y - (float)_mouseStart.Y) * mouseYMult * multiplier / _glControl.ClientSize.Height * mousemult;

            var newRotation = _initialRotation + (delta);
            newRotation.X = (newRotation.X + 720) % 360;
            newRotation.Y = (newRotation.Y + 720) % 360;

            var input = new Vector3(newRotation.X, newRotation.Y, newRotation.Z);
            var newVal = _renderer.Rotation;
            if (input.X != -1000)
                newVal.X = input.X;
            if (input.Y != -1000)
                newVal.Y = input.Y;
            if (input.Z != -1000)
                newVal.Z = input.Z;
            _renderer.Rotation = newVal;
            _activeRotation = newVal;
            _glControl.Invalidate();
        }

        private void GlControlOnMouseUp(object sender, MouseEventArgs e)
        {
            if (!_mouseCaptured) return;
            _mouseCaptured = false;
        }

        private void GlControlOnMouseDown(object sender, MouseEventArgs e)
        {
            _mouseStart = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                _initialRotation = _activeRotation;
                if (_activeRotation.Y > 90 && _activeRotation.Y < 270)
                    mousemult = -1;
                else
                    mousemult = 1;
                _mouseCaptured = true;
            }
        }

        private void GlcontrolOnPaint(object sender, PaintEventArgs e)
        {
            this._glControl.MakeCurrent();

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            float halfWidth = (float)(this._glControl.Width / 2);
            float halfHeight = (float)(this._glControl.Height / 2);
            GL.Ortho(-halfWidth, halfWidth, halfHeight, -halfHeight, 1000, -1000);
            GL.Viewport(this._glControl.Size);
            this._renderer.Render();

            GL.Finish();

            this._glControl.SwapBuffers();
        }

        #endregion

    }
}
