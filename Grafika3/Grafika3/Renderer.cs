using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Grafika3
{
    public class Renderer
    {
        private int displayList;
        public Vector3 Rotation = new Vector3();

        public void Render()
        {
            if (this.displayList <= 0)
            {
                this.displayList = GL.GenLists(1);
                GL.NewList(this.displayList, ListMode.Compile);

                GL.Begin(BeginMode.Triangles);

                GL.Color3(1.0f, 0.0f, 0.0f);
                GL.Vertex3(-100.0f, -100.0f, -100.0f);    // Front
                GL.Color3(1.0f, 0.0f, 1.0f);
                GL.Vertex3(-100.0f, 100.0f, -100.0f);
                GL.Color3(1.0f, 1.0f, 1.0f);
                GL.Vertex3(100.0f, 100.0f, -100.0f);

                GL.Color3(1.0f, 0.0f, 0.0f);
                GL.Vertex3(-100.0f, -100.0f, -100.0f);
                GL.Color3(1.0f, 1.0f, 1.0f);
                GL.Vertex3(100.0f, 100.0f, -100.0f);
                GL.Color3(1.0f, 1.0f, 0.0f);
                GL.Vertex3(100.0f, -100.0f, -100.0f);

                GL.Color3(0.0f, 0.0f, 0.0f);
                GL.Vertex3(-100.0f, -100.0f, 100.0f);     // BACK
                GL.Color3(0.0f, 1.0f, 1.0f);
                GL.Vertex3(100.0f, 100.0f, 100.0f);
                GL.Color3(0.0f, 0.0f, 1.0f);
                GL.Vertex3(-100.0f, 100.0f, 100.0f);

                GL.Color3(0.0f, 0.0f, 0.0f);
                GL.Vertex3(-100.0f, -100.0f, 100.0f);
                GL.Color3(0.0f, 1.0f, 0.0f);
                GL.Vertex3(100.0f, -100.0f, 100.0f);
                GL.Color3(0.0f, 1.0f, 1.0f);
                GL.Vertex3(100.0f, 100.0f, 100.0f);

                GL.Color3(1.0f, 0.0f, 1.0f);
                GL.Vertex3(-100.0f, 100.0f, -100.0f);     // Top
                GL.Color3(0.0f, 0.0f, 1.0f);
                GL.Vertex3(-100.0f, 100.0f, 100.0f);
                GL.Color3(0.0f, 1.0f, 1.0f);
                GL.Vertex3(100.0f, 100.0f, 100.0f);

                GL.Color3(1.0f, 0.0f, 1.0f);
                GL.Vertex3(-100.0f, 100.0f, -100.0f);
                GL.Color3(0.0f, 1.0f, 1.0f);
                GL.Vertex3(100.0f, 100.0f, 100.0f);
                GL.Color3(1.0f, 1.0f, 1.0f);
                GL.Vertex3(100.0f, 100.0f, -100.0f);

                GL.Color3(1.0f, 0.0f, 0.0f);
                GL.Vertex3(-100.0f, -100.0f, -100.0f);    // Botto
                GL.Color3(0.0f, 1.0f, 0.0f);
                GL.Vertex3(100.0f, -100.0f, 100.0f);
                GL.Color3(0.0f, 0.0f, 0.0f);
                GL.Vertex3(-100.0f, -100.0f, 100.0f);

                GL.Color3(1.0f, 0.0f, 0.0f);
                GL.Vertex3(-100.0f, -100.0f, -100.0f);
                GL.Color3(1.0f, 1.0f, 0.0f);
                GL.Vertex3(100.0f, -100.0f, -100.0f);
                GL.Color3(0.0f, 1.0f, 0.0f);
                GL.Vertex3(100.0f, -100.0f, 100.0f);

                GL.Color3(1.0f, 0.0f, 0.0f);
                GL.Vertex3(-100.0f, -100.0f, -100.0f);    // Left
                GL.Color3(0.0f, 0.0f, 0.0f);
                GL.Vertex3(-100.0f, -100.0f, 100.0f);
                GL.Color3(0.0f, 0.0f, 1.0f);
                GL.Vertex3(-100.0f, 100.0f, 100.0f);

                GL.Color3(1.0f, 0.0f, 0.0f);
                GL.Vertex3(-100.0f, -100.0f, -100.0f);
                GL.Color3(0.0f, 0.0f, 1.0f);
                GL.Vertex3(-100.0f, 100.0f, 100.0f);
                GL.Color3(1.0f, 0.0f, 1.0f);
                GL.Vertex3(-100.0f, 100.0f, -100.0f);

                GL.Color3(1.0f, 1.0f, 0.0f);
                GL.Vertex3(100.0f, -100.0f, -100.0f);     // Right
                GL.Color3(0.0f, 1.0f, 1.0f);
                GL.Vertex3(100.0f, 100.0f, 100.0f);
                GL.Color3(0.0f, 1.0f, 0.0f);
                GL.Vertex3(100.0f, -100.0f, 100.0f);

                GL.Color3(1.0f, 1.0f, 0.0f);
                GL.Vertex3(100.0f, -100.0f, -100.0f);
                GL.Color3(1.0f, 1.0f, 1.0f);
                GL.Vertex3(100.0f, 100.0f, -100.0f);
                GL.Color3(0.0f, 1.0f, 1.0f);
                GL.Vertex3(100.0f, 100.0f, 100.0f);

                GL.End();

                GL.EndList();
            }

            GL.Enable(EnableCap.DepthTest);

            GL.ClearColor(Color.FromArgb(200, Color.LightBlue));
            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Rotate(Rotation.Z, Vector3.UnitZ);
            GL.Rotate(Rotation.Y, Vector3.UnitY);
            GL.Rotate(Rotation.X, Vector3.UnitX);

            GL.CallList(this.displayList);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.End();
        }
    }
}
