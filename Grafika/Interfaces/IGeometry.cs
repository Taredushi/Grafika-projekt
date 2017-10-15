using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Grafika.Enums;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;

namespace Grafika.Interfaces
{
    public interface IGeometry
    {
        GeometryType GeometryType { get; set; }
        List<Point> Points { get; set; }

        void Draw(CanvasDrawingSession session, CanvasVirtualControl device);
        bool LockPointToMove(Point point);
        void UnlockPointToMove();
        void SetPointFromSize(double width, double height);
        bool IsPointInside(Point point);
        void Move(Point offset);
    }
}
