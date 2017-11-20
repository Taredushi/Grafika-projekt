using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biometria_1
{
    public class Obrazek
    {
        public Bitmap Oryginal { get; set; }
        public Bitmap Kopia { get; set; }
        public Bitmap R { get; set; }
        public Bitmap G { get; set; }
        public Bitmap B { get; set; }

        public Point[] PunktyR = new Point[256];
        public Point[] PunktyG = new Point[256];
        public Point[] PunktyB = new Point[256];
        public Point[] PunktyU = new Point[256];

        public int[] histogram_r = new int[256];
        public int[] histogram_g = new int[256];
        public int[] histogram_b = new int[256];
        public int[] histogram_u = new int[256];

        public int MaxPixeli { get; set; }

        private List<Bitmap> ImagePreviousList = new List<Bitmap>();
        private List<Bitmap> ImageNextList = new List<Bitmap>();
        private int pozycjaP = 0;
        private int pozycjaN = 0;


        public void Clear()
        {
            ImageNextList.Clear();
            ImagePreviousList.Clear();
        }

        public void ClearHistogram()
        {
            histogram_r = new int[256];
            histogram_g = new int[256];
            histogram_b = new int[256];
            histogram_u = new int[256];
        }

        public void ClearNext()
        {
            ImageNextList.Clear();
        }

        public void AddOperation_toList(Bitmap obrazek)
        {
            if (ImagePreviousList.Count < 5)
            {
                if (ImagePreviousList.Count > pozycjaP)
                {
                    for (int i = pozycjaP; i <= ImagePreviousList.Count; i++)
                    {
                        ImagePreviousList.RemoveAt(i);
                    }
                }
                ImagePreviousList.Add(obrazek);
                pozycjaP = ImagePreviousList.Count;
            }
            else
            {
                ImagePreviousList.RemoveAt(0);
                ImagePreviousList.Add(obrazek);
            }
        }

        public void AddNext_toList(Bitmap obrazek)
        {
            if (ImageNextList.Count < 5 && !ImageNextList.Contains(obrazek))
            {
                if (ImageNextList.Count > pozycjaN)
                {
                    int z = ImageNextList.Count - 1;
                    while (z > pozycjaN)
                    {
                        ImageNextList.RemoveAt(z);
                        z--;
                    }
                }
                ImageNextList.Add(obrazek);
 
            }
            else
            {
                ImageNextList.RemoveAt(0);
                ImageNextList.Add(obrazek);
            }
            pozycjaN = ImageNextList.Count;
        }

        public Bitmap ChangeHistory(char kierunek)
        {
            switch (kierunek)
            {
                case 'p':
                    if (pozycjaP > 0 && ImagePreviousList[pozycjaP - 1] != null)
                    {
                        AddNext_toList(Kopia);
                        pozycjaP--;
                        return ImagePreviousList[pozycjaP];
                    }
                    break;
                case 'n':
                    if (pozycjaN > 0 && ImageNextList[pozycjaN-1] != null)
                    {
                        pozycjaN--;
                        pozycjaP++;
                        return ImageNextList[pozycjaN];
                    }
                    break;
            }
            return null;
        }

        public bool Pervous()
        {
            if (ImagePreviousList.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool Next()
        {
            if (ImageNextList.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
