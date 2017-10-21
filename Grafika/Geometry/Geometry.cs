using System.Collections.Generic;
using System.Numerics;
using Windows.Devices.AllJoyn;
using Windows.Foundation;
using Grafika.Drawing;
using Grafika.Enums;
using Grafika.Helpers;
using Grafika.Interfaces;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Windows.UI;

namespace Grafika.Geometry
{
    public class Geometry : IGeometry
    {
        public GeometryType GeometryType { get; set; }
        public List<Point> Points { get; set; }

        private int _lockedPoint;
        private bool _drawHighlightPoint;
        private int _highlightPointIndex;

        public Geometry()
        {
            MapController.Instance.PropertyChanged += MapController_PropertyChanged;
        }

        #region Cached Geometry

        private CanvasGeometry _geometry;
        private bool _rebuildGeometry;
        #endregion

        #region Draw
        public void Draw(CanvasDrawingSession session, CanvasVirtualControl device)
        {
            DrawBorderGeometry(session, device);
            DrawPoints(session);
            DrawHighlightPoint(session);
        }

        private void DrawHighlightPoint(CanvasDrawingSession session)
        {
            if (!_drawHighlightPoint) return;
            float size = GetPointHighlightSize();
            session.DrawCircle((float)Points[_highlightPointIndex].X, (float)Points[_highlightPointIndex].Y, MapController.Instance.PointSize * 2f, Colors.LawnGreen, size);
        }

        private void DrawBorderGeometry(CanvasDrawingSession session, CanvasVirtualControl device)
        {
            if (Points == null || Points.Count == 0) return;
            if (_geometry == null || _rebuildGeometry)
            {
                CreateCanvasGeometry(device);
                _rebuildGeometry = false;
            }

            session.DrawGeometry(_geometry, Colors.WhiteSmoke, 1f / MapController.Instance.Zoom);
        }

        private void DrawPoints(CanvasDrawingSession session)
        {
            if (!MapController.Instance.DrawPoints) return;
            if (Points == null || Points.Count == 0) return;
            foreach (var point in Points)
            {
                var x = point.X - (MapController.Instance.PointSize / 2);
                var y = point.Y - (MapController.Instance.PointSize / 2);

                session.FillRectangle(new Rect(new Point(x, y), new Size(MapController.Instance.PointSize, MapController.Instance.PointSize)), Colors.Yellow);
            }
        }
        #endregion

        #region CreateGeometry
        private void CreateCanvasGeometry(CanvasVirtualControl device)
        {
            switch (GeometryType)
            {
                case GeometryType.Rectangle:
                    _geometry = CanvasGeometry.CreateRectangle(device, (float)Points[0].X, (float)Points[0].Y,
                        (float)Points[1].X - (float)Points[0].X, (float)Points[1].Y - (float)Points[0].Y);
                    break;
                case GeometryType.Line:
                    _geometry = CanvasGeometry.CreatePolygon(device,
                        new Vector2[]
                        {
                            new Vector2((float) Points[0].X, (float) Points[0].Y),
                            new Vector2((float) Points[1].X, (float) Points[1].Y)
                        });
                    break;
                case GeometryType.Circle:
                    _geometry = CanvasGeometry.CreateCircle(device, new Vector2((float)Points[0].X, (float)Points[0].Y), GetSegmentLength.CalculateSegmentLength(Points[0], Points[1]));
                    break;
            }
        }

        private float GetPointHighlightSize()
        {
            if (MapController.Instance.Zoom > 10)
            {
                return 0.5f;
            }
            if (MapController.Instance.Zoom > 5)
            {
                return 1f;
            }
            if (MapController.Instance.Zoom > 1)
            {
                return 1.5f;
            }
            return 2f;
        }
        #endregion

        #region Actions
        public bool LockPointToMove(Point point)
        {
            _lockedPoint = -1;
            var index = FindPointCloseToPosition.FindPointIndex(point, Points);
            if (index == -1) return false;
            _lockedPoint = index;
            return true;
        }

        public bool Delete(Point point)
        {
            _lockedPoint = -1;
            var index = FindPointCloseToPosition.FindPointIndex(point, Points);
            if (index == -1) return false;
            _lockedPoint = index;
            return true;
        }

        public void UnlockPointToMove()
        {
            _lockedPoint = -1;
        }

        public void SetPointFromSize(double width, double height)
        {
            Points[1] = new Point(Points[0].X + width, Points[0].Y + height);
            _rebuildGeometry = true;
            MapController.Instance.RerenderMap();
        }

        public bool IsPointInside(Point point)
        {
            return _geometry.FillContainsPoint(new Vector2((float) point.X, (float) point.Y));
        }

        public void Move(Point offset)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i]=new Point(Points[i].X + offset.X, Points[i].Y + offset.Y);
            }
            _rebuildGeometry = true;
            MapController.Instance.RerenderMap();
        }
        #endregion

        #region Highlighting

        private void CheckIfHighlightPoint()
        {
            bool pointfound = false;
            for (int i = 0; i < Points.Count; i++)
            {
                var x = Points[i].X - MapController.Instance.PointSize;
                var y = Points[i].Y - MapController.Instance.PointSize;

                var rect = new Rect(new Point(x, y),
                    new Size(MapController.Instance.PointSize * 1.5f, MapController.Instance.PointSize * 1.5f));

                if (!rect.Contains(MapController.Instance.MousePosition)) continue;

                _highlightPointIndex = i;
                _drawHighlightPoint = true;
                pointfound = true;
                break;
            }

            if (pointfound)
            {
                MapController.Instance.RerenderMap();
                return;
            }
            if (!_drawHighlightPoint) return;
            _drawHighlightPoint = false;
            MapController.Instance.RerenderMap();
        }
        #endregion

        #region MapController PropertyChanged
        private void MapController_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            if (e.PropertyName.Equals("MousePosition"))
            {
                CheckIfHighlightPoint();
                if (_lockedPoint == -1) return;
                Points[_lockedPoint] = MapController.Instance.MousePosition;
                _rebuildGeometry = true;
                MapController.Instance.RerenderMap();
            }
        }
        #endregion
    }
}