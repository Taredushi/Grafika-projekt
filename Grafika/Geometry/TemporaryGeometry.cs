using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Maps;
using Grafika.Drawing;
using Grafika.Enums;
using Grafika.Helpers;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Graphics.Canvas.UI.Xaml;

namespace Grafika.Geometry
{
    public class TemporaryGeometry 
    {
        public List<Point> Points { get; private set; }
        public GeometryType GeometryType { get; private set; }


        public TemporaryGeometry(Point point, GeometryType type)
        {
            Points = new List<Point>();
            Points.Add(point);
            GeometryType = type;
            MapController.Instance.PropertyChanged += MapController_PropertyChanged;
        }

        public void Draw(CanvasDrawingSession session, CanvasVirtualControl device)
        {
            var _geometry = CreateCanvasGeometry(device);
            session.DrawGeometry(_geometry, Colors.WhiteSmoke, 1f / MapController.Instance.Zoom);

        }

        private CanvasGeometry CreateCanvasGeometry(CanvasVirtualControl device)
        {
            switch (GeometryType)
            {
                case GeometryType.Rectangle:
                    return CanvasGeometry.CreateRectangle(device, (float)Points[0].X, (float)Points[0].Y,
                        (float)MapController.Instance.MousePosition.X - (float)Points[0].X, (float)MapController.Instance.MousePosition.Y - (float)Points[0].Y);
                case GeometryType.Line:
                    CanvasPathBuilder pathBuilder = new CanvasPathBuilder(device);
                    pathBuilder.SetSegmentOptions(CanvasFigureSegmentOptions.ForceRoundLineJoin);
                    pathBuilder.BeginFigure((float)Points[0].X, (float)Points[0].Y);
                    pathBuilder.AddLine(new Vector2((float)MapController.Instance.MousePosition.X, (float)MapController.Instance.MousePosition.Y));
                    pathBuilder.EndFigure(CanvasFigureLoop.Open);
                    return CanvasGeometry.CreatePath(pathBuilder);
                case GeometryType.Circle:
                    return CanvasGeometry.CreateCircle(device, new Vector2((float)Points[0].X, (float)Points[0].Y), GetSegmentLength.CalculateSegmentLength(Points[0], MapController.Instance.MousePosition));
            }
            return null;
        }

        private void MapController_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("MousePosition"))
            {
                MapController.Instance.RerenderMap();
            }
        }

        
    }
}
