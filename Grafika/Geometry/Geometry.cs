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

        #region Cached Geometry

        private CanvasGeometry _geometry;
        private bool _rebuildGeometry;
        #endregion


        public void Draw(CanvasDrawingSession session, CanvasVirtualControl device)
        {
            DrawBorderGeometry(session, device);
            DrawPoints(session);
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
            if (Points == null || Points.Count == 0) return;
            if (GeometryType == GeometryType.Circle) return;
            foreach (var point in Points)
            {
                var x = point.X - (MapController.Instance.PointSize / 2);
                var y = -point.Y - (MapController.Instance.PointSize / 2);

                session.FillRectangle(new Rect(new Point(x, y), new Size(MapController.Instance.PointSize, MapController.Instance.PointSize)), Colors.WhiteSmoke);
            }
        }

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

        public bool LockPointToMove(Point point)
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

    }
}