using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Grafika.Helpers
{
    public class GetSegmentLength
    {
        public static float CalculateSegmentLength(Point one, Point two)
        {
            var podwojonyX = (two.X - one.X) * (two.X- one.X);
            var podwojonyY = (two.Y - one.Y) * (two.Y- one.Y);
            var odcinek = podwojonyX + podwojonyY;
            odcinek = Math.Sqrt(odcinek);
            return (float)Math.Abs(odcinek);
        }
    }
}
