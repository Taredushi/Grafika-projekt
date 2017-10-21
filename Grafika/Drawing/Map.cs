using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using Grafika.Enums;
using Grafika.Geometry;
using Grafika.Interfaces;
using Grafika.Ppm;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;

namespace Grafika.Drawing
{
    public class Map
    {
        public Rect BoundingBox { get; private set; }
        public List<IGeometry> Geometrys { get; }

        public TemporaryGeometry TemporaryGeometry { get; private set; }

        private IGeometry _lockedGeometry;
        private ImageGeometry _image;

        public Map()
        {
            Geometrys = new List<IGeometry>();
            BoundingBox = new Rect();
            MapController.Instance.Zoom = 1;
        }

        #region TemporaryGeometry

        public void CreateGeometry(Point point, GeometryType type)
        {
            if (TemporaryGeometry == null)
            {
                TemporaryGeometry = new TemporaryGeometry(point, type);
            }
            else
            {
                TemporaryGeometry = null;
                TemporaryGeometry = new TemporaryGeometry(point, type);
                TemporaryGeometry.Points.Add(point);
            }
        }

        public void TemporaryGeometry_End(Point point)
        {
            if (TemporaryGeometry == null) return;
            TemporaryGeometry.Points.Add(point);

            var geo = new Geometry.Geometry()
            {
                GeometryType = TemporaryGeometry.GeometryType,
                Points = TemporaryGeometry.Points
            };
            Geometrys.Add(geo);
            TemporaryGeometry = null;
        }

        public void LastGeometry_ChangeSize(double width, double height)
        {
            if (Geometrys.Count == 0) return;
            if (_lockedGeometry == null)
            {
                Geometrys[Geometrys.Count - 1].SetPointFromSize(width, height);
            }
            else
            {
                _lockedGeometry.SetPointFromSize(width, height);
            }
        }
        #endregion

        #region Action Geometry ex1
        public bool LockGeometry(Point point)
        {
            _lockedGeometry = null;
            foreach (var geo in Geometrys)
            {
                if (geo.IsPointInside(point))
                {
                    _lockedGeometry = geo;
                    return true;
                }
            }
            return false;
        }

        public void MoveLockedGeometry(Point offset)
        {
            if (_lockedGeometry == null) return;
            _lockedGeometry.Move(offset);
        }

        public void UnlockAll()
        {
            _lockedGeometry = null;
            foreach (var geo in Geometrys)
            {
                geo.UnlockPointToMove();
            }
        }

        public void LockPointToMove(Point point)
        {
            foreach (var geo in Geometrys)
            {
                var result = geo.LockPointToMove(point);
                if (result) return;
            }
        }
        #endregion

        #region Image

        public void CreateImage(StorageFile file)
        {
            _image = new ImageGeometry(file);
        }

        public void CreateImage(PpmFile file)
        {
            _image = new ImageGeometry(file);
        }

        public void DeleteImage()
        {
            _image = null;
        }
        #endregion
        public void Draw(CanvasDrawingSession session, CanvasVirtualControl device)
        {
            foreach (var geo in Geometrys)
            {
                geo.Draw(session, device);
            }
            TemporaryGeometry?.Draw(session, device);
            _image?.Draw(session, device);
        }
    }
}
