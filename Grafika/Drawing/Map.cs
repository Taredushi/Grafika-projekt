using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Grafika.Enums;
using Grafika.Geometry;
using Grafika.Interfaces;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;

namespace Grafika.Drawing
{
    public class Map
    {
        public Rect BoundingBox { get; private set; }
        public List<IGeometry> Geometrys { get; }

        private TemporaryGeometry _temporaryGeometry;

        public Map()
        {
            Geometrys = new List<IGeometry>();
            BoundingBox = new Rect();
            MapController.Instance.Zoom = 1;
        }

        #region TemporaryGeometry

        public void CreateGeometry(Point point, GeometryType type)
        {
            if (_temporaryGeometry == null)
            {
                _temporaryGeometry = new TemporaryGeometry(point, type);
            }
            else
            {
                _temporaryGeometry.Points.Add(point);
            }
        }

        public void TemporaryGeometry_End(Point point)
        {
            if (_temporaryGeometry == null) return;
            _temporaryGeometry.Points.Add(point);

            var geo = new Geometry.Geometry()
            {
                GeometryType = _temporaryGeometry.GeometryType,
                Points = _temporaryGeometry.Points
            };
            Geometrys.Add(geo);
            _temporaryGeometry = null;
        }

        #endregion

        public void Draw(CanvasDrawingSession session, CanvasVirtualControl device)
        {
            foreach (var geo in Geometrys)
            {
                geo.Draw(session, device);
            }
            _temporaryGeometry?.Draw(session, device);
        }
    }
}
