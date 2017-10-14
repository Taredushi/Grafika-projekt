using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Grafika.Drawing;
using Grafika.Enums;
using Microsoft.Graphics.Canvas.UI.Xaml;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Grafika
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MouseHandlingMode _mouseMode;
        private Map _map;

        public MainPage()
        {
            this.InitializeComponent();
            SetTheme();
            _map = new Map();
            MapController.Instance.PropertyChanged += Instance_PropertyChanged;
        }

        private void Instance_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("MousePosition"))
            {
                InstanceOnInvalidateMap();
            }
        }

        private void SetTheme()
        {
            var frameworkElement = Window.Current.Content as FrameworkElement;
            if (frameworkElement != null)
            {
                frameworkElement.RequestedTheme = ElementTheme.Dark;
            }
        }

        #region TopToolbar
        private void MoveButton_OnChecked(object sender, RoutedEventArgs e)
        {
            UncheckTopToolbarButtons(MoveButton);
            _mouseMode = MouseHandlingMode.Move;
        }

        private void LineButton_OnChecked(object sender, RoutedEventArgs e)
        {
            UncheckTopToolbarButtons(LineButton);
            _mouseMode = MouseHandlingMode.Line;
        }

        private void RectangleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            UncheckTopToolbarButtons(RectangleButton);
            _mouseMode = MouseHandlingMode.Rectangle;
        }

        private void CircleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            UncheckTopToolbarButtons(CircleButton);
            _mouseMode = MouseHandlingMode.Circle;
        }

        private void UncheckTopToolbarButtons(AppBarToggleButton button)
        {
            foreach (var item in TopToolbarMenu.PrimaryCommands)
            {
                var btn = item as AppBarToggleButton;
                if (btn != null && btn != button)
                {
                    btn.IsChecked = false;
                }
            }
        }
        #endregion

        private void MapScrollViewer_OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            MapScrollViewer.CapturePointer(e.Pointer);
            if (e.GetCurrentPoint(MapScrollViewer).Properties.IsLeftButtonPressed)
            {
                InstanceOnInvalidateMap();
                switch (_mouseMode)
                {
                    case MouseHandlingMode.Move:
                        break;
                    case MouseHandlingMode.Line:
                        _map.CreateGeometry(MapController.Instance.MousePosition, GeometryType.Line);
                        break;
                    case MouseHandlingMode.Rectangle:
                        _map.CreateGeometry(MapController.Instance.MousePosition, GeometryType.Rectangle);
                        break;
                    case MouseHandlingMode.Circle:
                        _map.CreateGeometry(MapController.Instance.MousePosition, GeometryType.Circle);
                        break;
                }
            }
            e.Handled = true;
        }

        private void MapScrollViewer_OnPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            PositionCanvas_OnPointerMoved(null, e);
            if (_mouseMode == MouseHandlingMode.Move)
            {
            }
        }

        private void MapScrollViewer_OnPointerCanceled(object sender, PointerRoutedEventArgs e)
        {
            _map.TemporaryGeometry_End(MapController.Instance.MousePosition);
            MapScrollViewer.ReleasePointerCapture(e.Pointer);
            e.Handled = true;
            InstanceOnInvalidateMap();
        }

        private void MapCanvas_OnRegionsInvalidated(CanvasVirtualControl sender, CanvasRegionsInvalidatedEventArgs args)
        {
            var visible = args.InvalidatedRegions[0];
            for (int i = 1; i < args.InvalidatedRegions.Length; i++)
            {
                visible.Union(args.InvalidatedRegions[i]);
            }

            using (var drawingSession = sender.CreateDrawingSession(visible))
            {
                _map.Draw(drawingSession, sender);
            }
        }

        private void PositionCanvas_OnPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            var point = e.GetCurrentPoint(MapCanvas).Position;
            MapController.Instance.MousePosition = new Point(point.X, point.Y);
        }

        private void InstanceOnInvalidateMap()
        {
            if (MapCanvas == null) return;
            MapCanvas.Invalidate();
        }
    }
}
