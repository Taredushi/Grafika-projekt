using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Grafika.Drawing;

namespace Grafika.Helpers
{
    public class FindPointCloseToPosition
    {
        public static int FindPointIndex(Point point, List<Point> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                var x = points[i].X - MapController.Instance.PointSize;
                var y = -points[i].Y - MapController.Instance.PointSize;

                var rect = new Rect(new Point(x, y),
                    new Size(MapController.Instance.PointSize * 1.5f, MapController.Instance.PointSize * 1.5f));

                if (rect.Contains(new Point(point.X, -point.Y))) return i;
            }
            return -1;
        }
    }
}
