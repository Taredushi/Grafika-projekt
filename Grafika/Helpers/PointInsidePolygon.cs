using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Grafika.Helpers
{
    public class PointInsidePolygon
    {
        public static bool IsInside(List<Point> geometryPoints, Point checkPoint)
        {
            bool inside = false;
            int j = geometryPoints.Count - 1;

            for (int i = 0; i < geometryPoints.Count; i++)
            {
                if ((geometryPoints[i].Y < checkPoint.Y && geometryPoints[j].Y >= checkPoint.Y ||
                     geometryPoints[j].Y < checkPoint.Y && geometryPoints[i].Y >= checkPoint.Y) &&
                    (geometryPoints[i].X <= checkPoint.X || geometryPoints[j].X <= checkPoint.X))
                {
                    var value = geometryPoints[i].X +
                                (checkPoint.Y - geometryPoints[i].Y) /
                                (geometryPoints[j].Y - geometryPoints[i].Y) *
                                (geometryPoints[j].X - geometryPoints[i].X);
                    if (value < checkPoint.X)
                    {
                        inside = !inside;
                    }
                }
                j = i;
            }

            return inside;
        }
    }
}
