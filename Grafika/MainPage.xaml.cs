using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Grafika.Drawing;
using Grafika.Enums;
using Grafika.Geometry;
using Grafika.Ppm;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Toolkit.Uwp.Helpers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Grafika
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private MouseHandlingMode _mouseMode;
        private Map _map;
        private float _displayDpi;
        private Point _mouseStart;

        public MainPage()
        {
            this.InitializeComponent();
            _map = new Map();
            MapController.Instance.PropertyChanged += Instance_PropertyChanged;
        }

        #region Map zoom DependencyProperty
        public static readonly DependencyProperty ZoomProperty =
            DependencyProperty.Register("MapZoom", typeof(float), typeof(MapControl), new PropertyMetadata("MapZoom"));

        public float MapZoom
        {
            get { return (float)GetValue(ZoomProperty); }
            set
            {
                SetValue(ZoomProperty, value);
                MapController.Instance.Zoom = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region PropertyChanged
        private void Instance_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("MousePosition"))
            {
                InstanceOnInvalidateMap();
            }
        }
        #endregion

        #region Loaded page
        private void MainPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            var display = DisplayInformation.GetForCurrentView();
            display.DpiChanged += Display_DpiChanged;
            Display_DpiChanged(display, null);
            MapCanvas.Focus(FocusState.Programmatic);
            SetTheme();
        }

        private void MainPage_OnUnloaded(object sender, RoutedEventArgs e)
        {
            this.MapCanvas.RemoveFromVisualTree();
            this.MapCanvas = null;
            DisplayInformation.GetForCurrentView().DpiChanged -= Display_DpiChanged;
        }

        private void SetTheme()
        {
            var frameworkElement = Window.Current.Content as FrameworkElement;
            if (frameworkElement != null)
            {
                frameworkElement.RequestedTheme = ElementTheme.Dark;
            }
        }
        #endregion

        #region ScrollViewer Zoom

        // When the ScrollViewer zooms in or out, we update DpiScale on our CanvasVirtualControl
        // to match. This adjusts its pixel density to match the current zoom level. But its size
        // in dips stays the same, so layout and scroll position are not affected by the zoom.
        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            // Cancel out the display DPI, so our fractal always renders at 96 DPI regardless of display
            // configuration. This boosts performance on high DPI displays, at the cost of visual quality.
            // For even better performance (but lower quality) this value could be further reduced.
            float dpiAdjustment = 96 / _displayDpi;

            // Adjust DPI to match the current zoom level.
            float dpiScale = dpiAdjustment * MapScrollViewer.ZoomFactor;

            // To boost performance during pinch-zoom manipulations, we only update DPI when it has
            // changed by more than 20%, or at the end of the zoom (when e.IsIntermediate reports false).
            // Smaller changes will just scale the existing bitmap, which is much faster than recomputing
            // the fractal at a different resolution. To trade off between zooming perf vs. smoothness,
            // adjust the thresholds used in this ratio comparison.
            var ratio = MapCanvas.DpiScale / dpiScale;

            if (e == null || !e.IsIntermediate || ratio <= 0.8 || ratio >= 1.25)
            {
                MapCanvas.DpiScale = dpiScale;
            }

            MapZoom = MapScrollViewer.ZoomFactor;
        }


        private void Display_DpiChanged(DisplayInformation sender, object args)
        {
            _displayDpi = sender.LogicalDpi;

            // Manually call the ViewChanged handler to update DpiScale.
            ScrollViewer_ViewChanged(null, null);
        }

        private void FitContent(int width, int height)
        {
            var currentZoom = MapScrollViewer.ZoomFactor;
            double scaleX = MapScrollViewer.ActualWidth / width;
            double scaleY = MapScrollViewer.ActualHeight / height;

            var newZoom = (float)(currentZoom * Math.Min(scaleX, scaleY));

            newZoom = Math.Max(newZoom, MapScrollViewer.MinZoomFactor);
            newZoom = Math.Min(newZoom, MapScrollViewer.MaxZoomFactor);

            var currentPan = new Vector2((float)MapScrollViewer.HorizontalOffset,
                (float)MapScrollViewer.VerticalOffset);

            var centerOffset = new Vector2((float)MapScrollViewer.ViewportWidth,
                                   (float)MapScrollViewer.ViewportHeight) / 2;

            var newPan = ((currentPan + centerOffset) * newZoom / currentZoom) - centerOffset;

            if (double.IsNaN(newPan.X) || double.IsNaN(newPan.Y) || double.IsNaN(newZoom)) return;
            MapScrollViewer.ChangeView(newPan.X, newPan.Y, newZoom);
        }

        #endregion

        #region TopToolbar
        private void MoveButton_OnChecked(object sender, RoutedEventArgs e)
        {
            UncheckTopToolbarButtons(MoveButton);
            _mouseMode = MouseHandlingMode.Move;
            MapController.Instance.DrawPoints = false;
        }

        private void ResizeButton_OnChecked(object sender, RoutedEventArgs e)
        {
            UncheckTopToolbarButtons(ResizeButton);
            _mouseMode = MouseHandlingMode.Resize;
            MapController.Instance.DrawPoints = true;
        }

        private void LineButton_OnChecked(object sender, RoutedEventArgs e)
        {
            UncheckTopToolbarButtons(LineButton);
            _mouseMode = MouseHandlingMode.Line;
            MapController.Instance.DrawPoints = false;
        }

        private void RectangleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            UncheckTopToolbarButtons(RectangleButton);
            _mouseMode = MouseHandlingMode.Rectangle;
            MapController.Instance.DrawPoints = false;
        }

        private void CircleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            UncheckTopToolbarButtons(CircleButton);
            _mouseMode = MouseHandlingMode.Circle;
            MapController.Instance.DrawPoints = false;
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

        #region ScrollViewer MouseEvents
        private void MapScrollViewer_OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            MapScrollViewer.CapturePointer(e.Pointer);
            if (e.GetCurrentPoint(MapScrollViewer).Properties.IsRightButtonPressed)
            {
                _mouseMode = MouseHandlingMode.Panning;
                _mouseStart = e.GetCurrentPoint(MapCanvas).Position;
            }
            else if (e.GetCurrentPoint(MapScrollViewer).Properties.IsLeftButtonPressed)
            {
                InstanceOnInvalidateMap();
                switch (_mouseMode)
                {
                    case MouseHandlingMode.Move:
                        _map.LockGeometry(MapController.Instance.MousePosition);
                        _mouseStart = e.GetCurrentPoint(MapCanvas).Position;
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
                    case MouseHandlingMode.Resize:
                        _map.LockPointToMove(MapController.Instance.MousePosition);
                        break;
                }
            }
            e.Handled = true;
        }

        private void MapScrollViewer_OnPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            PositionCanvas_OnPointerMoved(null, e);
            if (_mouseMode == MouseHandlingMode.Panning)
            {
                Point curContentMousePoint = e.GetCurrentPoint(MapCanvas).Position;
                Pan(curContentMousePoint);
            }
            else if (_mouseMode == MouseHandlingMode.Move)
            {
                Point curContentMousePoint = e.GetCurrentPoint(MapCanvas).Position;
                Point offset = new Point((curContentMousePoint.X - _mouseStart.X) * MapController.Instance.Zoom,
                    (curContentMousePoint.Y - _mouseStart.Y) * MapController.Instance.Zoom);
                _mouseStart = curContentMousePoint;
                _map.MoveLockedGeometry(offset);
            }
        }

        private void MapScrollViewer_OnPointerCanceled(object sender, PointerRoutedEventArgs e)
        {
            _map.TemporaryGeometry_End(MapController.Instance.MousePosition);
            MapScrollViewer.ReleasePointerCapture(e.Pointer);
            e.Handled = true;
            _map.UnlockAll();
            if (_mouseMode == MouseHandlingMode.Panning)
            {
                _mouseMode = MouseHandlingMode.None;
                UncheckTopToolbarButtons(null);
            }
            InstanceOnInvalidateMap();
        }

        private void Pan(Point curContentMousePoint)
        {
            Vector2 dragOffset = new Vector2((float)curContentMousePoint.X - (float)_mouseStart.X,
                (float)curContentMousePoint.Y - (float)_mouseStart.Y);

            var dragOffsetX = MapScrollViewer.HorizontalOffset - dragOffset.X * MapController.Instance.Zoom;
            var dragOffsetY = MapScrollViewer.VerticalOffset - dragOffset.Y * MapController.Instance.Zoom;
            MapScrollViewer.ChangeView(dragOffsetX, dragOffsetY, null);
        }

        #endregion

        #region MapCanvas Draw
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

        private void InstanceOnInvalidateMap()
        {
            if (MapCanvas == null) return;
            MapCanvas.Invalidate();
        }

        private void AssignSizeButton_OnClick(object sender, RoutedEventArgs e)
        {
            var width = double.Parse(GeometryWidth.Text);
            var height = double.Parse(GeometryHeight.Text);
            _map.LastGeometry_ChangeSize(width, height);
        }

        #endregion

        private void PositionCanvas_OnPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            var point = e.GetCurrentPoint(MapCanvas).Position;
            MapController.Instance.MousePosition = new Point(point.X, point.Y);
        }

        #region Load Image Files
        private async void LoadImageFile_OnClick(object sender, RoutedEventArgs e)
        {
            var filePicker = new FileOpenPicker();
            filePicker.FileTypeFilter.Add(".jpg");
            filePicker.FileTypeFilter.Add(".jpeg");
            filePicker.FileTypeFilter.Add(".ppm");

            var result = await filePicker.PickSingleFileAsync();
            if (result != null)
            {
                MapScrollViewer.ChangeView(0, 0, 1);
                if (result.FileType.Equals(".ppm"))
                {
                    var ppm = new PpmFile();
                    await ppm.ReadPpmFile(result);
                    _map.CreateImage(ppm);
                }
                else
                {
                    _map.CreateImage(result);
                }
            }
        }

        #endregion
    }
}
