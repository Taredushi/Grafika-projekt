using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace biometria_1
{
    public static class Tools
    {

        #region Rozne
        //Rozne
        public static int[] GetHistogramUsredniony(Bitmap obrazek)
        {
            Bitmap bmp = new Bitmap(obrazek);
            int[] histogram = new int[256];
            float max = 0;
            
            unsafe
            {
                BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite,
                    bmp.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int oldBlue = currentLine[x];
                        int oldGreen = currentLine[x + 1];
                        int oldRed = currentLine[x + 2];

                        //usredniony
                        int tmp = 0;
                        tmp += oldRed;
                        tmp += oldGreen;
                        tmp += oldBlue;
                        tmp = tmp / 3;
                        histogram[tmp]++;
                    }
                }
                bmp.UnlockBits(bitmapData);
            }
            return histogram;
        }

        private static int[] GetHistogramKolor(Bitmap obrazek, char kolor)
        {
            Bitmap bmp = new Bitmap(obrazek);
            float max = 0;
            int[] histogram = new int[256];
            unsafe
            {
                BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite,
                    bmp.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int oldBlue = currentLine[x];
                        int oldGreen = currentLine[x + 1];
                        int oldRed = currentLine[x + 2];

                        switch (kolor)
                        {
                            case 'r':
                                histogram[oldRed]++;
                                if (max < histogram[oldRed])
                                {
                                    max = histogram[oldRed];
                                }
                                break;
                            case 'g':
                                histogram[oldGreen]++;
                                if (max < histogram[oldGreen])
                                {
                                    max = histogram[oldGreen];
                                }
                                break;
                            case 'b':
                                histogram[oldBlue]++;
                                if (max < histogram[oldBlue])
                                {
                                    max = histogram[oldBlue];
                                }
                                break;
                        }
                    }
                }
                bmp.UnlockBits(bitmapData);
                bmp.Dispose();
            }
            return histogram;
        }

        public static void GetRGBHistogramPoints(Bitmap obrazek, Obrazek obiektObrazek)
        {
            Bitmap bmp = new Bitmap(obrazek);
            float max = 0;
            obiektObrazek.MaxPixeli = obrazek.Width * obrazek.Height;
            unsafe
            {
                BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite,
                    bmp.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int oldBlue = currentLine[x];
                        int oldGreen = currentLine[x + 1];
                        int oldRed = currentLine[x + 2];

                        obiektObrazek.histogram_r[oldRed]++;
                        obiektObrazek.histogram_g[oldGreen]++;
                        obiektObrazek.histogram_b[oldBlue]++;
                        if (max < obiektObrazek.histogram_r[oldRed])
                        {
                            max = obiektObrazek.histogram_r[oldRed];
                        }
                        if (max < obiektObrazek.histogram_g[oldGreen])
                        {
                            max = obiektObrazek.histogram_g[oldGreen];
                        }
                        if (max < obiektObrazek.histogram_b[oldBlue])
                        {
                            max = obiektObrazek.histogram_b[oldBlue];
                        }

                        //usredniony
                        int tmp = 0;
                        tmp += oldRed;
                        tmp += oldGreen;
                        tmp += oldBlue;
                        tmp = tmp / 3;
                        obiektObrazek.histogram_u[tmp]++;
                    }
                }
                bmp.UnlockBits(bitmapData);
            }

            int histHeight = 128;
            for (int i = 0; i < 256; i++)
            {
                //Red
                float pct = obiektObrazek.histogram_r[i] / max;
                obiektObrazek.PunktyR[i] = new Point(i, (int)(pct * histHeight));


                //Green
                pct = obiektObrazek.histogram_g[i] / max;
                obiektObrazek.PunktyG[i] = new Point(i, (int)(pct * histHeight));

                //Blue
                pct = obiektObrazek.histogram_b[i] / max;
                obiektObrazek.PunktyB[i] = new Point(i, (int)(pct * histHeight));

                //Usredniony
                pct = obiektObrazek.histogram_u[i] / max;
                obiektObrazek.PunktyU[i] = new Point(i, (int)(pct * histHeight));
            }
        }

        public static void DisplayHistogram(Point[] punkty, Chart chart)
        {
            foreach (var arg in punkty)
            {
                chart.Series[0].Points.AddXY(arg.X, arg.Y);
            }   
        }

        public static Bitmap RozciagnijHistogram(int[] lut, Bitmap obrazek, char warstwa)
        {
            Bitmap rozciagniety = new Bitmap(obrazek);
            int R, G, B;
            Color nowy;
            for (int x = 0; x < obrazek.Width; x++)
            {
                for (int y = 0; y < obrazek.Height; y++)
                {
                    Color pixel = obrazek.GetPixel(x, y);
                    switch (warstwa)
                    {
                        case 'r':
                            R = lut[pixel.R];
                            nowy = Color.FromArgb(R, pixel.G, pixel.B);
                            break;
                        case 'g':
                            G = lut[pixel.G];
                            nowy = Color.FromArgb(pixel.R, G, pixel.B);
                            break;
                        case 'b':
                            B = lut[pixel.B];
                            nowy = Color.FromArgb(pixel.R, pixel.G, B);
                            break;
                        default:
                            R = lut[pixel.R];
                            G = lut[pixel.G];
                            B = lut[pixel.B];
                            nowy = Color.FromArgb(R, G, B);
                            break;
                    }
                    rozciagniety.SetPixel(x, y, nowy);
                }
            }
            return rozciagniety;
        }

        public static int[] GetLUTRozciaganie(double min, double max)
        {
            int[] lut = new int[256];

            for (int i = 0; i < 256; i++)
            {
                double wartosc = (255.0 / (max - min)) * ((double)i - min);
                if (wartosc > 255)
                {
                    lut[i] = 255;
                }
                else if (wartosc < 0)
                {
                    lut[i] = 0;
                }
                else
                {
                    lut[i] = (int)Math.Round(wartosc, 0, MidpointRounding.AwayFromZero);
                }
            }
            return lut;
        }

        public static void ZamienObraz_CzarnoBialy(Bitmap processedBitmap)
        {
            unsafe
            {
                BitmapData bitmapData =
                    processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height),
                        ImageLockMode.ReadWrite, processedBitmap.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat)/8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width*bytesPerPixel;
                byte* ptrFirstPixel = (byte*) bitmapData.Scan0;

                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y*bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int oldBlue = currentLine[x];
                        int oldGreen = currentLine[x + 1];
                        int oldRed = currentLine[x + 2];
                        int s = (int)Math.Round(((oldBlue + oldGreen + oldRed) / 3.0), 0, MidpointRounding.AwayFromZero);
                        // calculate new pixel value
                        currentLine[x] = (byte) s;
                        currentLine[x + 1] = (byte) s;
                        currentLine[x + 2] = (byte) s;
                    }
                }
                processedBitmap.UnlockBits(bitmapData);
            }

        }

        public static void PobierzWarstweKoloru(Bitmap processedBitmap, char warstwa)
        {
            unsafe
            {
                BitmapData bitmapData =
                    processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height),
                        ImageLockMode.ReadWrite, processedBitmap.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        switch (warstwa)
                        {
                            case 'r':
                                int oldRed = currentLine[x + 2];
                                currentLine[x] = 0;
                                currentLine[x + 1] = 0;
                                currentLine[x + 2] = (byte) oldRed;
                                break;
                            case 'g':
                                int oldGreen = currentLine[x + 1];
                                currentLine[x] = 0;
                                currentLine[x + 1] = (byte)oldGreen;
                                currentLine[x + 2] = 0;
                                break;
                            case 'b':
                                int oldBlue = currentLine[x];
                                currentLine[x] = (byte)oldBlue;
                                currentLine[x + 1] = 0;
                                currentLine[x + 2] = 0;
                                break;
                        }
                       
                    }
                }
                processedBitmap.UnlockBits(bitmapData);
            }
        }

        private static int SearchMedian(List<int> tablica)
        {
            tablica.Sort();
            int srodek = (tablica.Count - 1) / 2;
            srodek += 1;
            return tablica[srodek];
        }

        //Zoom
        public static Bitmap Zoom(Bitmap obrazek, int zoomValue)
        {
            int szerokosc = (obrazek.Width * zoomValue) / 100;
            int wysokosc = (obrazek.Height * zoomValue) / 100;
            Size newSize = new Size(szerokosc, wysokosc);
            Bitmap image = new Bitmap(obrazek, newSize);

            return image;
        }

        //Czy obraz kolorowy
        public static bool ObrazKolor(Bitmap obrazek)
        {
            Bitmap test = new Bitmap(obrazek);

            unsafe
            {
                BitmapData data = test.LockBits(new Rectangle(0, 0, test.Width, test.Height), ImageLockMode.ReadOnly,
                    test.PixelFormat);
                int byteperpixel = Bitmap.GetPixelFormatSize(test.PixelFormat) / 8;
                int heightinpixel = data.Height;
                int widthinbytes = data.Width * byteperpixel;
                byte* firstPixel = (byte*)data.Scan0;

                for (int y = 0; y < heightinpixel; y++)
                {
                    byte* currentLine = firstPixel + (y * data.Stride);
                    for (int x = 0; x < widthinbytes; x = x + byteperpixel)
                    {
                        int oldBlue = currentLine[x];
                        int oldGreen = currentLine[x + 1];
                        int oldRed = currentLine[x + 2];

                        if (oldRed != oldBlue || oldRed != oldGreen || oldBlue != oldGreen)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        #endregion

        #region Wyrownanie histogramu
        //Wyrownanie histogramu

        public static double[] GetDystrybuanta(int[] histogram, int max)
        {
            double suma = 0;
            double[] dystrybuanta = new double[histogram.Length];
            for (int i = 0; i < histogram.Length; i++)
            {
                suma += histogram[i];
                dystrybuanta[i] = suma / max;
            }
            return dystrybuanta;
        }

        public static int[] GetLUTWyrownanie(double[] dystrybuanta, int max)
        {
            int i = 0;
            while (dystrybuanta[i] == 0)
            {
                i++;
            }
            double niezerowy = dystrybuanta[i];
            int[] lut = new int[256];
            for (i = 0; i < 256; i++)
            {
                lut[i] = (int)(((dystrybuanta[i] - niezerowy) / (1 - niezerowy)) * (max - 1));
                if (lut[i] > 255)
                {
                    lut[i] = 255;
                }
                if (lut[i] < 0)
                {
                    lut[i] = 0;
                }
            }
            return lut;
        }

        public static Bitmap WyrownajHistogram(int[] LutR, int[] LutG, int[] LutB, Bitmap obrazek)
        {
            Bitmap wyrownany = new Bitmap(obrazek);
            unsafe
            {
                BitmapData bitmapData =
                    wyrownany.LockBits(new Rectangle(0, 0, wyrownany.Width, wyrownany.Height),
                        ImageLockMode.ReadWrite, wyrownany.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(wyrownany.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int oldBlue = currentLine[x];
                        int oldGreen = currentLine[x + 1];
                        int oldRed = currentLine[x + 2];
                        currentLine[x] = (byte)LutB[oldBlue];
                        currentLine[x + 1] = (byte)LutG[oldGreen];
                        currentLine[x + 2] = (byte)LutR[oldRed];
                    }
                }
                wyrownany.UnlockBits(bitmapData);
            }
            return wyrownany;
        }
        #endregion

        #region Binaryzacja
        //Binaryzacja
        public static Bitmap BinaryzacjaReczna(Bitmap obrazek, int treshold)
        {
            Bitmap image = new Bitmap(obrazek);
            unsafe
            {
                BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                    ImageLockMode.ReadWrite, image.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(image.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int old = currentLine[x];
                        int value;
                        if (old <= treshold)
                        {
                            value = 0;
                        }
                        else
                        {
                            value = 255;
                        }
                        // calculate new pixel value
                        currentLine[x] = (byte)value;
                        currentLine[x + 1] = (byte)value;
                        currentLine[x + 2] = (byte)value;
                    }
                }
                image.UnlockBits(bitmapData);
            }
            return image;
        }

        public static int[] GetTablicaWartosciPixela(Bitmap obrazek)
        {
            int[] tablica = new int[256];
            unsafe
            {
                BitmapData bitmapData = obrazek.LockBits(new Rectangle(0, 0, obrazek.Width, obrazek.Height),
                    ImageLockMode.ReadOnly, obrazek.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(obrazek.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int value = currentLine[x];
                        tablica[value]++;
                    }
                }
                obrazek.UnlockBits(bitmapData);
            }
            return tablica;
        }
        public static double GetWaga(int[] wartoscPixela, int maxPixeli, int start, int end)
        {
            double suma = 0;
            for (int i = start; i < end; i++)
            {
                suma += wartoscPixela[i];
            }
            return suma/maxPixeli;
        }

        public static double GetSrednia(int[] wartoscPixela, int start, int end)
        {
            double max = 0;
            double suma = 0;
            for (int i = start; i < end; i++)
            {
                suma += wartoscPixela[i]*i;
                max += wartoscPixela[i];
            }
            return suma/max;
        }

        public static double GetOdchylenie(int[] histogram, double srednia)
        {
            double temp = 0;
            double max = 0;
            for (int k = 0; k < histogram.Length; k++)
            {
                temp += histogram[k]* Math.Pow(k - srednia, 2.0);
                max += histogram[k];
            }
            return Math.Sqrt(temp / max);
        }
        private static double GetWariancja(int[] histogram, double srednia, double max)
        {
            double temp = 0;
            for (int k = 0; k < histogram.Length; k++)
            {
                temp += histogram[k] * Math.Pow(k - srednia, 2.0);
            }
            return temp / max;
        }
        private static double GetSrednia(double[,] tablica, double max)
        {
            double suma = 0;
            foreach (var arg in tablica)
            {
                suma += arg;
            }
            return suma / max;
        }

        private static double GetWariancja(double[,] tablica, double max, double srednia)
        {
            double suma = 0;
            foreach (var arg in tablica)
            {
                suma += Math.Pow((arg - srednia), 2);
            }
            return suma / max;
        }

        public static Bitmap BinaryzacjaPercent(Bitmap obrazek, double tresh)
        {
            int[] H = GetTablicaWartosciPixela(obrazek);

            double percent = tresh / 100;
            int N = obrazek.Height * obrazek.Width, sum = 0, threshold = 0;
            double x = N * percent;
            for (int i = 0; i < 256; i++)
            {
                sum += H[i];
                if (sum >= x)
                {
                    threshold = i;
                    break;
                }
            }

            Bitmap image = new Bitmap(obrazek);
            unsafe
            {
                BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                    ImageLockMode.ReadWrite, image.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(image.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;


                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int z = 0; z < widthInBytes; z = z + bytesPerPixel)
                    {
                        int old = currentLine[z];
                        int value = (old >= threshold ? 255 : 0);
                        // calculate new pixel value
                        currentLine[z] = (byte)value;
                        currentLine[z + 1] = (byte)value;
                        currentLine[z + 2] = (byte)value;
                    }
                }
                image.UnlockBits(bitmapData);
            }
            return image;
        }

        public static Bitmap BinaryzacjaFuzzy(Bitmap obrazek)
        {
            int[] historgram = GetTablicaWartosciPixela(obrazek);

            var threshold = GetFuzzyThreshold(historgram);

            Bitmap image = new Bitmap(obrazek);
            unsafe
            {
                BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                    ImageLockMode.ReadWrite, image.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(image.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;


                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int z = 0; z < widthInBytes; z = z + bytesPerPixel)
                    {
                        int old = currentLine[z];
                        int value;
                        if (old > threshold)
                        {
                            currentLine[z] = (byte) 255;
                            currentLine[z + 1] = (byte) 255;
                            currentLine[z + 2] = (byte) 255;
                        }
                        else
                        {
                            currentLine[z] = (byte)0;
                            currentLine[z + 1] = (byte)0;
                            currentLine[z + 2] = (byte)0;
                        }
                    }
                }
                image.UnlockBits(bitmapData);
            }
            return image;
        }


        private static int GetFuzzyThreshold(int[] data)
        {
            int threshold;
            int ih, it;
            int firstBin;
            int lastBin;
            double sumPix;
            double numPix;
            double term;
            double ent;  // entropy 
            double minEnt; // min entropy 
            double muX;

            /* Determine the first non-zero bin */
            firstBin = 0;
            for (ih = 0; ih < 256; ih++)
            {
                if (data[ih] != 0)
                {
                    firstBin = ih;
                    break;
                }
            }

            /* Determine the last non-zero bin */
            lastBin = 255;
            for (ih = 255; ih >= firstBin; ih--)
            {
                if (data[ih] != 0)
                {
                    lastBin = ih;
                    break;
                }
            }
            term = 1.0 / (double)(lastBin - firstBin);
            double[] mu0 = new double[256];
            sumPix = numPix = 0;
            for (ih = firstBin; ih < 256; ih++)
            {
                sumPix += (double)ih * data[ih];
                numPix += data[ih];
                /* NUM_PIX cannot be zero ! */
                mu0[ih] = sumPix / numPix;
            }

            double[] mu1 = new double[256];
            sumPix = numPix = 0;
            for (ih = lastBin; ih > 0; ih--)
            {
                sumPix += (double)ih * data[ih];
                numPix += data[ih];
                /* NUM_PIX cannot be zero ! */
                mu1[ih - 1] = sumPix / numPix;
            }

            /* Determine the threshold that minimizes the fuzzy entropy */
            threshold = -1;
            minEnt = Double.MaxValue;
            for (it = 0; it < 256; it++)
            {
                ent = 0.0;
                for (ih = 0; ih <= it; ih++)
                {
                    /* Equation (4) in Ref. 1 */
                    muX = 1.0 / (1.0 + term * Math.Abs(ih - mu0[it]));
                    if (!((muX < 1e-06) || (muX > 0.999999)))
                    {
                        /* Equation (6) & (8) in Ref. 1 */
                        ent += data[ih] * (-muX * Math.Log(muX) - (1.0 - muX) * Math.Log(1.0 - muX));
                    }
                }

                for (ih = it + 1; ih < 256; ih++)
                {
                    /* Equation (4) in Ref. 1 */
                    muX = 1.0 / (1.0 + term * Math.Abs(ih - mu1[it]));
                    if (!((muX < 1e-06) || (muX > 0.999999)))
                    {
                        /* Equation (6) & (8) in Ref. 1 */
                        ent += data[ih] * (-muX * Math.Log(muX) - (1.0 - muX) * Math.Log(1.0 - muX));
                    }
                }
                /* No need to divide by NUM_ROWS * NUM_COLS * LOG(2) ! */
                if (ent < minEnt)
                {
                    minEnt = ent;
                    threshold = it;
                }
            }
            return threshold;
        }
        #endregion

        #region Otsu + Niblack
        //Otsu + Niblack
        public static int GetWariancjaMiedzyklasowa(Bitmap obrazek)
        {
            int[] tablicaPixeli = GetTablicaWartosciPixela(obrazek);

            double[] bgWeight = new double[256];
            double[] bgMean = new double[256];


            double[] fgWeight = new double[256];
            double[] fgMean = new double[256];

            int max = obrazek.Width * obrazek.Height;
            for (int i = 0; i < 256; i++)
            {
                bgWeight[i] = GetWaga(tablicaPixeli, max, 0, i);
                bgMean[i] = GetSrednia(tablicaPixeli, 0, i);

                fgWeight[i] = GetWaga(tablicaPixeli, max, i + 1, 256);
                fgMean[i] = GetSrednia(tablicaPixeli, i + 1, 256);
            }

            double maximum = 0;
            int pozycja = 0;
            for (int j = 0; j < 256; j++)
            {
                double wynik = bgWeight[j] * fgWeight[j] * (bgMean[j] - fgMean[j]) * (bgMean[j] - fgMean[j]);
                if (wynik > maximum)
                {
                    maximum = wynik;
                    pozycja = j;
                }
            }
            return pozycja;
        }

        public static async Task<Bitmap> PerformNiblack(Bitmap obrazek, double k, int rozmiarOkna, IProgress<int> progress)
        {
            Bitmap image = new Bitmap(obrazek);
            Bitmap image2 = new Bitmap(obrazek);
            List<int> tresholdList1 = new List<int>();
            List<int> tresholdList2 = new List<int>();
            int r = (rozmiarOkna - 1) / 2;
            int width = obrazek.Width;
            int z = 1;
            int v = 1;
            Size obrazekSize = new Size(obrazek.Width, obrazek.Height);

            int pierwszaWysokosc = obrazek.Height/2;
            
            await Task.Run(() =>
            {
                Parallel.Invoke(
                    () =>
                    {
                        for (int y = 0; y < pierwszaWysokosc; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                int prog = NiblackPart(obrazekSize, image, r, k, rozmiarOkna,
                                    new Point(x, y));
                                tresholdList1.Add(prog);
                                if (progress != null)
                                {

                                    progress.Report(z);
                                }
                                z++;
                            }
                        }
                        
                    },
                    () =>
                    {
                        for (int y = pierwszaWysokosc + 1; y <= obrazek.Height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                int prog = NiblackPart(obrazekSize, image2, r, k, rozmiarOkna,
                                    new Point(x, y));
                                tresholdList2.Add(prog);
                                if (progress != null)
                                {

                                    progress.Report(v);
                                }
                                v++;
                            }
                        }
                    }
                    );
                tresholdList1.AddRange(tresholdList2);
                unsafe
                {
                    BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                        ImageLockMode.ReadWrite, image.PixelFormat);
                    int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(image.PixelFormat) / 8;
                    int heightInPixels = bitmapData.Height;
                    int widthInBytes = bitmapData.Width * bytesPerPixel;
                    byte* ptrFirstPixel = (byte*)bitmapData.Scan0;
                    int i = 0;
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                        for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                        {
                            int old = currentLine[x];
                            int value;
                            if (old <= tresholdList1[i])
                            {
                                value = 0;
                            }
                            else
                            {
                                value = 255;
                            }
                            // calculate new pixel value
                            currentLine[x] = (byte)value;
                            currentLine[x + 1] = (byte)value;
                            currentLine[x + 2] = (byte)value;
                            i++;
                        }
                    }
                    image.UnlockBits(bitmapData);
                }
            });
            image2.Dispose();
            return image;
        }

        private static int NiblackPart(Size wymiary, Bitmap image, int r, double k, int rozmiarOkna, Point punkt)
        {
            int X1 = punkt.X - r;
            int X2 = punkt.X + r;
            int Y1 = punkt.Y - r;
            int Y2 = punkt.Y + r;

            if (X1 < 0)
            {
                X1 = 0;
            }
            if (X2 > wymiary.Width)
            {
                X2 = wymiary.Width;
            }
            if (Y1 < 0)
            {
                Y1 = 0;
            }
            if (Y2 > wymiary.Height)
            {
                Y2 = wymiary.Height;
            }


            Bitmap okno = new Bitmap(X2 - X1, Y2 - Y1);
            using (Graphics g = Graphics.FromImage(okno))
            {
                Rectangle kwadrat = new Rectangle(X1, Y1, X2 - X1, Y2 - Y1);
                g.DrawImage(image, 0, 0, kwadrat, GraphicsUnit.Pixel);
            }

            int[] histogram = Tools.GetHistogramUsredniony(okno);
            if (okno.Width * okno.Height < rozmiarOkna * rozmiarOkna)
            {
                int roznica = (rozmiarOkna * rozmiarOkna) - (okno.Width * okno.Height);
                histogram[0] += roznica;
            }

            double srednia = Tools.GetSrednia(histogram, 0, histogram.Length);
            double odchylenie = Tools.GetOdchylenie(histogram, srednia);

            int prog = (int)Math.Round((srednia + (k * odchylenie)), 0, MidpointRounding.AwayFromZero);
            okno.Dispose();
            return prog;
        }
        #endregion

        #region Maska reczna
        //Maska ręczna

        public static Bitmap PerformMaska(Bitmap obrazek, int[,] maska, int wielkosc)
        {

            return CalculatePixelValue_Mask(wielkosc, maska, obrazek);
        }

        private static Bitmap CalculatePixelValue_Mask(int wielkosc, int[,] maska, Bitmap sourceBitmap)
        {
            Bitmap image = new Bitmap(sourceBitmap);

            int offset = (wielkosc - 1) / 2;
            int max = 0;
            for (int i = 0; i < wielkosc; i++)
            {
                for (int j = 0; j < wielkosc; j++)
                {
                    max += maska[i, j];
                }
            }
            max = max == 0 ? 1 : max;
            unsafe
            {
                //oryginal
                BitmapData bitmapData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                    ImageLockMode.ReadOnly, sourceBitmap.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(sourceBitmap.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = (bitmapData.Width) * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                //kopia
                BitmapData cData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                    ImageLockMode.WriteOnly, image.PixelFormat);
                byte* FirstPixel = (byte*)cData.Scan0;

                int pixelR = 0;
                int pixelG = 0;
                int pixelB = 0;
                int v = 0;
                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine1 = FirstPixel + (y * cData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int t = y - offset;
                        byte* currentLine;

                        for (int i = 0; i < wielkosc; i++)
                        {
                            if (t < 0)
                            {
                                currentLine = ptrFirstPixel + (0*bitmapData.Stride);
                            }
                            else
                            {
                                currentLine = t > (heightInPixels - 1)
                                ? ptrFirstPixel + ((heightInPixels - 1) * bitmapData.Stride)
                                : ptrFirstPixel + (t * bitmapData.Stride);
                            }

                            int nx = x - (offset * bytesPerPixel);
                            
                            for (int j = 0; j < wielkosc; j++)
                            {
                                if (nx < 0)
                                {
                                    nx = x;
                                }
                                else
                                {
                                    nx = nx > (widthInBytes - bytesPerPixel) ? (widthInBytes - bytesPerPixel) : nx;
                                }
                                pixelB += currentLine[nx] * maska[i, j];
                                pixelG += currentLine[nx + 1] * maska[i, j];
                                pixelR += currentLine[nx + 2] * maska[i, j];
                                nx += bytesPerPixel;
                            }
                            t++;
                        }
                        pixelB = pixelB/max;
                        pixelG = pixelG/max;
                        pixelR = pixelR/max;
                        if (pixelB > 255 || pixelB < 0)
                        {
                            pixelB = pixelB > 255 ? 255 : 0;
                        }
                        if (pixelG > 255 || pixelG < 0)
                        {
                            pixelG = pixelG > 255 ? 255 : 0;
                        }
                        if (pixelR > 255 || pixelR < 0)
                        {
                            pixelR = pixelR > 255 ? 255 : 0;
                        }
                        currentLine1[x] = (byte)(pixelB);
                        currentLine1[x + 1] = (byte)(pixelG);
                        currentLine1[x + 2] = (byte)(pixelR);
                        v++;
                        pixelB = 0;
                        pixelG = 0;
                        pixelR = 0;

                    }
                }
                sourceBitmap.UnlockBits(bitmapData);
                image.UnlockBits(cData);

                return image;
            }
        }

        public static async Task<Bitmap> PerformMask_Kuwahar(int wielkosc, Bitmap sourceBitmap, IProgress<int> progress)
        {
            Bitmap image = new Bitmap(sourceBitmap);

            int offset = (wielkosc - 1) / 2;
            int max = 0;
            int maksimum = sourceBitmap.Width*sourceBitmap.Height;
            await Task.Run(() =>
            {
                unsafe
                {
                    //oryginal
                    BitmapData bitmapData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                        ImageLockMode.ReadOnly, sourceBitmap.PixelFormat);
                    int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(sourceBitmap.PixelFormat) / 8;
                    int heightInPixels = bitmapData.Height;
                    int widthInBytes = (bitmapData.Width) * bytesPerPixel;
                    byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                    //kopia
                    BitmapData cData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                        ImageLockMode.WriteOnly, image.PixelFormat);
                    byte* FirstPixel = (byte*)cData.Scan0;
                    int i = 0;
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine1 = FirstPixel + (y * cData.Stride);
                        for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                        {
                            byte* currentLine;

                            int x1 = x - (offset * bytesPerPixel);
                            int y1 = y - offset;

                            int x2 = x;
                            int y2 = y - offset;

                            int x3 = x;
                            int y3 = y;

                            int x4 = x - (offset * bytesPerPixel);
                            int y4 = y;

                            double maxR = Int32.MaxValue;
                            double sredniaR = 0;
                            double maxG = Int32.MaxValue;
                            double sredniaG = 0;
                            double maxB = Int32.MaxValue;
                            double sredniaB = 0;

                            double srednia = 0;
                            double wariancja = 0;

                            double maxPixeli = Math.Pow((offset + 1), 2);
                            double[,] rValue = new double[offset + 1, offset + 1];
                            double[,] gValue = new double[offset + 1, offset + 1];
                            double[,] bValue = new double[offset + 1, offset + 1];

                            int t = 0;
                            if (x1 >= 0 && y1 >= 0)
                            {
                                t = y - offset;
                                for (int n = 0; n <= offset; n++)
                                {
                                    currentLine = ptrFirstPixel + (t * bitmapData.Stride);
                                    for (int m = 0; m <= offset; m++)
                                    {
                                        int poz = x1 + (m * bytesPerPixel);
                                        bValue[n, m] = currentLine[poz];
                                        gValue[n, m] = currentLine[poz + 1];
                                        rValue[n, m] = currentLine[poz + 2];
                                    }
                                    t++;
                                }

                                var r = KuwaharPart(rValue, maxPixeli, maxR, sredniaR);
                                maxR = r[0];
                                sredniaR = r[1];
                                var g = KuwaharPart(gValue, maxPixeli, maxG, sredniaG);
                                maxG = g[0];
                                sredniaG = g[1];
                                var b = KuwaharPart(bValue, maxPixeli, maxB, sredniaB);
                                maxB = b[0];
                                sredniaB = b[1];
                            }
                            if ((x2 + (offset * bytesPerPixel) <= (widthInBytes - bytesPerPixel)) && y2 >= 0)
                            {
                                t = y - offset;
                                for (int n = 0; n <= offset; n++)
                                {
                                    currentLine = ptrFirstPixel + (t * bitmapData.Stride);
                                    for (int m = 0; m <= offset; m++)
                                    {
                                        int poz = x2 + (m * bytesPerPixel);
                                        bValue[n, m] = currentLine[poz];
                                        gValue[n, m] = currentLine[poz + 1];
                                        rValue[n, m] = currentLine[poz + 2];
                                    }
                                    t++;
                                }

                                var r = KuwaharPart(rValue, maxPixeli, maxR, sredniaR);
                                maxR = r[0];
                                sredniaR = r[1];
                                var g = KuwaharPart(gValue, maxPixeli, maxG, sredniaG);
                                maxG = g[0];
                                sredniaG = g[1];
                                var b = KuwaharPart(bValue, maxPixeli, maxB, sredniaB);
                                maxB = b[0];
                                sredniaB = b[1];
                            }
                            if ((x3 + (offset * bytesPerPixel) <= (widthInBytes - bytesPerPixel))
                                && (y3 + offset <= heightInPixels - 1))
                            {
                                t = y;
                                for (int n = 0; n <= offset; n++)
                                {
                                    currentLine = ptrFirstPixel + (t * bitmapData.Stride);
                                    for (int m = 0; m <= offset; m++)
                                    {
                                        int poz = x3 + (m * bytesPerPixel);
                                        bValue[n, m] = currentLine[poz];
                                        gValue[n, m] = currentLine[poz + 1];
                                        rValue[n, m] = currentLine[poz + 2];
                                    }
                                    t++;
                                }

                                var r = KuwaharPart(rValue, maxPixeli, maxR, sredniaR);
                                maxR = r[0];
                                sredniaR = r[1];
                                var g = KuwaharPart(gValue, maxPixeli, maxG, sredniaG);
                                maxG = g[0];
                                sredniaG = g[1];
                                var b = KuwaharPart(bValue, maxPixeli, maxB, sredniaB);
                                maxB = b[0];
                                sredniaB = b[1];
                            }
                            if ((x4 >= 0) && (y4 + offset <= heightInPixels - 1))
                            {
                                t = y;
                                for (int n = 0; n <= offset; n++)
                                {
                                    currentLine = ptrFirstPixel + (t * bitmapData.Stride);
                                    for (int m = 0; m <= offset; m++)
                                    {
                                        int poz = x4 + (m * bytesPerPixel);
                                        bValue[n, m] = currentLine[poz];
                                        gValue[n, m] = currentLine[poz + 1];
                                        rValue[n, m] = currentLine[poz + 2];
                                    }
                                    t++;
                                }

                                var r = KuwaharPart(rValue, maxPixeli, maxR, sredniaR);
                                maxR = r[0];
                                sredniaR = r[1];
                                var g = KuwaharPart(gValue, maxPixeli, maxG, sredniaG);
                                maxG = g[0];
                                sredniaG = g[1];
                                var b = KuwaharPart(bValue, maxPixeli, maxB, sredniaB);
                                maxB = b[0];
                                sredniaB = b[1];
                            }

                            sredniaR = Math.Round(sredniaR, 0, MidpointRounding.AwayFromZero);
                            sredniaG = Math.Round(sredniaG, 0, MidpointRounding.AwayFromZero);
                            sredniaB = Math.Round(sredniaB, 0, MidpointRounding.AwayFromZero);

                            if (sredniaR > 255 || sredniaR < 0)
                            {
                                sredniaR = sredniaR > 255 ? 255 : 0;
                            }
                            if (sredniaG > 255 || sredniaG < 0)
                            {
                                sredniaG = sredniaG > 255 ? 255 : 0;
                            }
                            if (sredniaB > 255 || sredniaB < 0)
                            {
                                sredniaB = sredniaB > 255 ? 255 : 0;
                            }

                            // calculate new pixel value
                            currentLine1[x] = (byte)sredniaB;
                            currentLine1[x + 1] = (byte)sredniaG;
                            currentLine1[x + 2] = (byte)sredniaR;

                            if (progress != null)
                            {
                                int value = (i * 100) / maksimum;
                                progress.Report(value);
                            }
                            i++;

                        }
                    }
                    sourceBitmap.UnlockBits(bitmapData);
                    image.UnlockBits(cData);
                    if (progress != null)
                    {
                        progress.Report(100);
                    }
                }
            });
            return image;
        }

        private static double[] KuwaharPart(double[,] colorValue, double maxPixeli, double max, double srednia)
        {
            double tmpSrednia = GetSrednia(colorValue, maxPixeli);
            double tmpWar = GetWariancja(colorValue, maxPixeli, tmpSrednia);
            double[] wynik = new double[2];

            if (max > tmpWar)
            {
                wynik[0] = tmpWar;
                wynik[1] = tmpSrednia;
            }
            else
            {
                wynik[0] = max;
                wynik[1] = srednia;
            }
            return wynik;
        }

        public static async Task<Bitmap> PerformMask_Median(int wielkosc, Bitmap sourceBitmap, IProgress<int> progress)
        {
            Bitmap image = new Bitmap(sourceBitmap);

            int offset = (wielkosc - 1) / 2;
            int max = sourceBitmap.Width*sourceBitmap.Height;
            await Task.Run(() =>
            {
                unsafe
                {
                    //oryginal
                    BitmapData bitmapData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                        ImageLockMode.ReadOnly, sourceBitmap.PixelFormat);
                    int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(sourceBitmap.PixelFormat) / 8;
                    int heightInPixels = bitmapData.Height;
                    int widthInBytes = (bitmapData.Width) * bytesPerPixel;
                    byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                    //kopia
                    BitmapData cData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                        ImageLockMode.WriteOnly, image.PixelFormat);
                    byte* FirstPixel = (byte*)cData.Scan0;

                    List<int> pixelR = new List<int>();
                    List<int> pixelG = new List<int>();
                    List<int> pixelB = new List<int>();
                    int v = 0;
                    for (int y = 0; y < heightInPixels; y++)
                    {
                        byte* currentLine1 = FirstPixel + (y * cData.Stride);
                        for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                        {
                            int t = y - offset;
                            byte* currentLine;

                            for (int i = 0; i < wielkosc; i++)
                            {
                                if (t < 0)
                                {
                                    currentLine = ptrFirstPixel + (0 * bitmapData.Stride);
                                }
                                else
                                {
                                    currentLine = t > (heightInPixels - 1)
                                    ? ptrFirstPixel + ((heightInPixels - 1) * bitmapData.Stride)
                                    : ptrFirstPixel + (t * bitmapData.Stride);
                                }

                                int nx = x - (offset * bytesPerPixel);

                                for (int j = 0; j < wielkosc; j++)
                                {
                                    if (nx < 0)
                                    {
                                        nx = x;
                                    }
                                    else
                                    {
                                        nx = nx > (widthInBytes - bytesPerPixel) ? (widthInBytes - bytesPerPixel) : nx;
                                    }
                                    pixelB.Add(currentLine[nx]);
                                    pixelG.Add(currentLine[nx + 1]);
                                    pixelR.Add(currentLine[nx + 2]);
                                    nx += bytesPerPixel;
                                }
                                t++;
                            }
                            currentLine1[x] = (byte)SearchMedian(pixelB);
                            currentLine1[x + 1] = (byte)SearchMedian(pixelG);
                            currentLine1[x + 2] = (byte)SearchMedian(pixelR);
                            v++;
                            pixelB.Clear();
                            pixelG.Clear();
                            pixelR.Clear();
                            if (progress != null)
                            {
                                progress.Report((v*100)/max);
                            }
                        }
                    }
                    sourceBitmap.UnlockBits(bitmapData);
                    image.UnlockBits(cData);
                    if (progress != null)
                    {
                        progress.Report(100);
                    }
                }
            });
            return image;
        }
        #endregion

        public static Bitmap cann(Bitmap sourceBitmap)
        {
            Bitmap image = new Bitmap(sourceBitmap);

            int offset = (3 - 1) / 2;

            unsafe
            {
                //oryginal
                BitmapData bitmapData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                    ImageLockMode.ReadOnly, sourceBitmap.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(sourceBitmap.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = (bitmapData.Width) * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                //kopia
                BitmapData cData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                    ImageLockMode.WriteOnly, image.PixelFormat);
                byte* FirstPixel = (byte*)cData.Scan0;

                int pixelxR = 0;
                int pixelxG = 0;
                int pixelxB = 0;
                int pixelyR = 0;
                int pixelyG = 0;
                int pixelyB = 0;
                int v = 0;
                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine1 = FirstPixel + (y * cData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int t = y - offset;
                        byte* currentLine;

                        for (int i = 0; i < 3; i++)
                        {
                            if (t < 0)
                            {
                                currentLine = ptrFirstPixel + (0*bitmapData.Stride);
                            }
                            else
                            {
                                currentLine = t > (heightInPixels - 1)
                                ? ptrFirstPixel + ((heightInPixels - 1) * bitmapData.Stride)
                                : ptrFirstPixel + (t * bitmapData.Stride);
                            }

                            int nx = x - (offset * bytesPerPixel);
                            
                            for (int j = 0; j < 3; j++)
                            {
                                if (nx < 0)
                                {
                                    nx = x;
                                }
                                else
                                {
                                    nx = nx > (widthInBytes - bytesPerPixel) ? (widthInBytes - bytesPerPixel) : nx;
                                }
                                pixelxB += currentLine[nx] * MaskTables.SobelVertical[i, j];
                                pixelxG += currentLine[nx + 1] * MaskTables.SobelVertical[i, j];
                                pixelxR += currentLine[nx + 2] * MaskTables.SobelVertical[i, j];

                                pixelyB += currentLine[nx] * MaskTables.SobelHorizontal[i, j];
                                pixelyG += currentLine[nx + 1] * MaskTables.SobelHorizontal[i, j];
                                pixelyR += currentLine[nx + 2] * MaskTables.SobelHorizontal[i, j];
                                nx += bytesPerPixel;
                            }
                            t++;
                        }

                        int valR = (int)Math.Sqrt((pixelxR * pixelxR) + (pixelyR * pixelyR));
                        int valG = (int)Math.Sqrt((pixelxG * pixelxG) + (pixelyG * pixelyG));
                        int valB = (int)Math.Sqrt((pixelxB * pixelxB) + (pixelyB * pixelyB));


                        if (valB > 255 || valB < 0)
                        {
                            valB = valB > 255 ? 255 : 0;
                        }
                        if (valG > 255 || valG < 0)
                        {
                            valG = valG > 255 ? 255 : 0;
                        }
                        if (valR > 255 || valR < 0)
                        {
                            valR = valR > 255 ? 255 : 0;
                        }
                        currentLine1[x] = (byte)(valB);
                        currentLine1[x + 1] = (byte)(valG);
                        currentLine1[x + 2] = (byte)(valR);
                        v++;
                        pixelxB = 0;
                        pixelxG = 0;
                        pixelxR = 0;
                        pixelyB = 0;
                        pixelyG = 0;
                        pixelyR = 0;

                    }
                }
                sourceBitmap.UnlockBits(bitmapData);
                image.UnlockBits(cData);

                
            }
            return image;
        }
    }
}
