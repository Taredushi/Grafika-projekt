using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Graphics.DirectX;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Grafika.Drawing;
using Grafika.Helpers;
using Grafika.Ppm;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;

namespace Grafika.Geometry
{
    public class ImageGeometry
    {
        private StorageFile _sourceFile;
        public uint ImageWidth { get; private set; }
        public uint ImageHeight { get; private set; }
        public byte[] ImageBytes { get; private set; }
        private CanvasBitmap _bitmap;

        public ImageGeometry(StorageFile file)
        {
            _sourceFile = file;
            Initialize();
        }

        public ImageGeometry(PpmFile file)
        {
            ImageWidth = (uint)file.Width;
            ImageHeight = (uint)file.Height;
            ImageBytes = file.ByteArray;
        }

        private async void Initialize()
        {
            var prop = await _sourceFile.Properties.GetImagePropertiesAsync();
            ImageWidth = prop.Width;
            ImageHeight = prop.Height;
            ImageBytes = await ImageByteArrayConverter.ScaledImageToByteArray(_sourceFile, ImageWidth, ImageHeight);
        }

        public void Draw(CanvasDrawingSession session, CanvasVirtualControl device)
        {
            if (_bitmap == null && ImageWidth != 0 && ImageHeight != 0 && (ImageBytes != null && ImageBytes.Length > 0))
            {
                _bitmap = CanvasBitmap.CreateFromBytes(device, ImageBytes, (int)ImageWidth, (int)ImageHeight, DirectXPixelFormat.B8G8R8X8UIntNormalized);
            }
            if (_bitmap == null) return;
            session.DrawImage(_bitmap, new Rect(0, 0, ImageWidth, ImageHeight), new Rect(0, 0, ImageWidth, ImageHeight), 100, CanvasImageInterpolation.NearestNeighbor);
        }

        public void Dispose()
        {
            _bitmap = null;
            ImageBytes = null;
        }

        private void CheckValues(ref decimal r, ref decimal g, ref decimal b)
        {
            if (r > 255)
            {
                r = 255;
            }
            else if (r < 0)
            {
                r = 0;
            }

            if (g > 255)
            {
                g = 255;
            }
            else if (g < 0)
            {
                g = 0;
            }

            if (b > 255)
            {
                b = 255;
            }
            else if (b < 0)
            {
                b = 0;
            }
        }

        public void AddValue(decimal param)
        {
            for (int i = 0; i < ImageBytes.Length; i += 4)
            {
                var r = ImageBytes[i + 2] + param;
                var g = ImageBytes[i + 1] + param;
                var b = ImageBytes[i] + param;

                CheckValues(ref r, ref g, ref b);

                ImageBytes[i + 2] = (byte) r;
                ImageBytes[i + 1] = (byte) g;
                ImageBytes[i] = (byte) b;
            }
            _bitmap = null;
        }

        public  void SubstractValue(decimal param)
        {
            for (int i = 0; i < ImageBytes.Length; i += 4)
            {
                var r = ImageBytes[i + 2] - param;
                var g = ImageBytes[i + 1] - param;
                var b = ImageBytes[i] - param;

                CheckValues(ref r, ref g, ref b);

                ImageBytes[i + 2] = (byte)r;
                ImageBytes[i + 1] = (byte)g;
                ImageBytes[i] = (byte)b;
            }
            _bitmap = null;
        }

        public void MultiplyValue(decimal param)
        {
            for (int i = 0; i < ImageBytes.Length; i += 4)
            {
                var r = ImageBytes[i + 2] * param;
                var g = ImageBytes[i + 1] * param;
                var b = ImageBytes[i] * param;

                CheckValues(ref r, ref g, ref b);

                ImageBytes[i + 2] = (byte)r;
                ImageBytes[i + 1] = (byte)g;
                ImageBytes[i] = (byte)b;
            }
            _bitmap = null;
        }

        public void DivideValue(decimal param)
        {
            for (int i = 0; i < ImageBytes.Length; i += 4)
            {
                var r = ImageBytes[i + 2] / param;
                var g = ImageBytes[i + 1] / param;
                var b = ImageBytes[i] / param;

                CheckValues(ref r, ref g, ref b);

                ImageBytes[i + 2] = (byte)r;
                ImageBytes[i + 1] = (byte)g;
                ImageBytes[i] = (byte)b;
            }
            _bitmap = null;
        }

        public void LUT(byte[] array)
        {
            for (int i = 0; i < ImageBytes.Length; i += 4)
            {
                double r = array[ImageBytes[i + 2]];
                double g = array[ImageBytes[i + 1]];
                double b = array[ImageBytes[i]];

                ImageBytes[i + 2] = (byte)r;
                ImageBytes[i + 1] = (byte)g;
                ImageBytes[i] = (byte)b;
            }
            _bitmap = null;
        }

        public void AverageGrayscale()
        {
            for (int i = 0; i < ImageBytes.Length; i += 4)
            {
                double y = (double)(ImageBytes[i + 2] + ImageBytes[i + 1] + ImageBytes[i]) / 3;
                var r = y;
                var g = y;
                var b = y;

                ImageBytes[i + 2] = (byte)r;
                ImageBytes[i + 1] = (byte)g;
                ImageBytes[i] = (byte)b;
            }
            _bitmap = null;
        }

        public void LuminocityGrayscale()
        {
            for (int i = 0; i < ImageBytes.Length; i += 4)
            {
                double y = (0.21 * ImageBytes[i + 2]) + (0.72 * ImageBytes[i + 1]) + (0.07 * ImageBytes[i]);
                var r = y;
                var g = y;
                var b = y;

                ImageBytes[i + 2] = (byte)r;
                ImageBytes[i + 1] = (byte)g;
                ImageBytes[i] = (byte)b;
            }
            _bitmap = null;
        }

        #region Filters

        public void MedianFilter()
        {
            byte[] displayingArray = ImageBytes;
            int bitmapWidth = (int)ImageWidth;
            int bitmapHeight = (int)ImageHeight;
            double newR, newG, newB;
            int tableWidth = bitmapWidth * 4, i;
            int[] maskTab = new int[9];
            byte[] tmp = new byte[displayingArray.Length];
            displayingArray.CopyTo(tmp, 0);
            for (int h = 1; h < bitmapHeight - 1; h++)
            {
                for (int j = 4; j < tableWidth - 5; j += 4)
                {
                    i = j + tableWidth * h;

                    maskTab[0] = displayingArray[i - 4];
                    maskTab[1] = displayingArray[i];
                    maskTab[2] = displayingArray[i + 4];
                    maskTab[3] = displayingArray[i - 4 - tableWidth];
                    maskTab[4] = displayingArray[i - tableWidth];
                    maskTab[5] = displayingArray[i + 4 - tableWidth];
                    maskTab[6] = displayingArray[i - 4 + tableWidth];
                    maskTab[7] = displayingArray[i + tableWidth];
                    maskTab[8] = displayingArray[i + 4 + tableWidth];
                    newB = Mediana(maskTab);

                    maskTab[0] = displayingArray[i - 3];
                    maskTab[1] = displayingArray[i + 1];
                    maskTab[2] = displayingArray[i + 5];
                    maskTab[3] = displayingArray[i - 3 - tableWidth];
                    maskTab[4] = displayingArray[i + 1 - tableWidth];
                    maskTab[5] = displayingArray[i + 5 - tableWidth];
                    maskTab[6] = displayingArray[i - 3 + tableWidth];
                    maskTab[7] = displayingArray[i + 1 + tableWidth];
                    maskTab[8] = displayingArray[i + 5 + tableWidth];
                    newG = Mediana(maskTab);

                    maskTab[0] = displayingArray[i - 2];
                    maskTab[1] = displayingArray[i + 2];
                    maskTab[2] = displayingArray[i + 6];
                    maskTab[3] = displayingArray[i - 2 - tableWidth];
                    maskTab[4] = displayingArray[i + 2 - tableWidth];
                    maskTab[5] = displayingArray[i + 6 - tableWidth];
                    maskTab[6] = displayingArray[i - 2 + tableWidth];
                    maskTab[7] = displayingArray[i + 2 + tableWidth];
                    maskTab[8] = displayingArray[i + 6 + tableWidth];
                    newR = Mediana(maskTab);

                    tmp[i] = (byte)newB;
                    tmp[i + 1] = (byte)newG;
                    tmp[i + 2] = (byte)newR;
                }
            }
            ImageBytes = tmp;
            _bitmap = null;
        }

        private double Mediana(int[] maskTab)
        {
            int buf;
            for (int i = 0; i < maskTab.Length - 1; i++)
            {
                for (int j = 0; j < maskTab.Length - 1; j++)
                {
                    if (maskTab[j] > maskTab[j + 1])
                    {
                        buf = maskTab[j];
                        maskTab[j] = maskTab[j + 1];
                        maskTab[j + 1] = buf;
                    }
                }
            }

            return maskTab[maskTab.Length / 2];
        }

        public void SmoothFilter()
        {
            byte[] displayingArray = ImageBytes;
            int bitmapWidth = (int)ImageWidth;
            int bitmapHeight = (int)ImageHeight;
            double newR, newG, newB;
            int tableWidth = bitmapWidth * 4, i;
            byte[] tmp = new byte[displayingArray.Length];
            displayingArray.CopyTo(tmp, 0);
            for (int h = 1; h < bitmapHeight - 1; h++)
            {
                for (int j = 4; j < tableWidth - 5; j += 4)
                {
                    i = j + tableWidth * h;
                    newB = (displayingArray[i - 4] + displayingArray[i] + displayingArray[i + 4] +
                            displayingArray[i - 4 - tableWidth] + displayingArray[i - tableWidth] + displayingArray[i + 4 - tableWidth] +
                            displayingArray[i - 4 + tableWidth] + displayingArray[i + tableWidth] + displayingArray[i + 4 + tableWidth]) / 9;

                    newG = (displayingArray[i - 3] + displayingArray[i + 1] + displayingArray[i + 5] +
                            displayingArray[i - 3 - tableWidth] + displayingArray[i + 1 - tableWidth] + displayingArray[i + 5 - tableWidth] +
                            displayingArray[i - 3 + tableWidth] + displayingArray[i + 1 + tableWidth] + displayingArray[i + 5 + tableWidth]) / 9;

                    newR = (displayingArray[i - 2] + displayingArray[i + 2] + displayingArray[i + 6] +
                            displayingArray[i - 2 - tableWidth] + displayingArray[i + 2 - tableWidth] + displayingArray[i + 6 - tableWidth] +
                            displayingArray[i - 2 + tableWidth] + displayingArray[i + 2 + tableWidth] + displayingArray[i + 6 + tableWidth]) / 9;

                    tmp[i] = (byte)newB;
                    tmp[i + 1] = (byte)newG;
                    tmp[i + 2] = (byte)newR;
                }
            }
            ImageBytes = tmp;
            _bitmap = null;
        }

        public void SobelFilter()
        {
            byte[] displayingArray = ImageBytes;
            int bitmapWidth = (int)ImageWidth;
            int bitmapHeight = (int)ImageHeight;
            double newR, newG, newB;
            byte[] tmp = new byte[displayingArray.Length];
            displayingArray.CopyTo(tmp, 0);
            int tableWidth = bitmapWidth * 4, i;

            for (int h = 1; h < bitmapHeight - 1; h++)
            {
                for (int j = 4; j < tableWidth - 5; j += 4)
                {
                    i = j + tableWidth * h;
                    newB = ((-1) * displayingArray[i - 4] + 2 * displayingArray[i + 4] +
                            (-1) * displayingArray[i - 4 - tableWidth] + displayingArray[i + 4 - tableWidth] +
                            (-1) * displayingArray[i - 4 + tableWidth] + displayingArray[i + 4 + tableWidth]);

                    newG = ((-1) * displayingArray[i - 3] + 2 * displayingArray[i + 5] +
                            (-1) * displayingArray[i - 3 - tableWidth] + displayingArray[i + 5 - tableWidth] +
                            (-1) * displayingArray[i - 3 + tableWidth] + displayingArray[i + 5 + tableWidth]);

                    newR = ((-1) * displayingArray[i - 2] + 2 * displayingArray[i + 6] +
                            (-1) * displayingArray[i - 2 - tableWidth] + displayingArray[i + 6 - tableWidth] +
                            (-1) * displayingArray[i - 2 + tableWidth] + displayingArray[i + 6 + tableWidth]);

                    tmp[i] = (byte)((newB >= 0) ? newB : 0);
                    tmp[i + 1] = (byte)((newG >= 0) ? newG : 0);
                    tmp[i + 2] = (byte)((newR >= 0) ? newR : 0);
                }
            }
            ImageBytes = tmp;
            _bitmap = null;
        }

        public void SharpeningFilter()
        {

            double newR, newG, newB;
            double d1 = 0.0625; // 1/16
            double d2 = 0.125;  // 2/16
            double d3 = 0.25;   // 4/16
            byte[] displayingArray = ImageBytes;
            int bitmapWidth = (int)ImageWidth;
            int bitmapHeight = (int)ImageHeight;
            int tableWidth = bitmapWidth * 4, i;
            byte[] tmp = new byte[displayingArray.Length];
            displayingArray.CopyTo(tmp, 0);
            for (int h = 1; h < bitmapHeight - 1; h++)
            {
                for (int j = 4; j < tableWidth - 5; j += 4)
                {
                    i = j + tableWidth * h;
                    newB = ((-1) * displayingArray[i - 4] + 9 * displayingArray[i] + (-1) * displayingArray[i + 4] +
                            (-1) * displayingArray[i - 4 - tableWidth] + (-1) * displayingArray[i - tableWidth] + (-1) * displayingArray[i + 4 - tableWidth] +
                            (-1) * displayingArray[i - 4 + tableWidth] + (-1) * displayingArray[i + tableWidth] + (-1) * displayingArray[i + 4 + tableWidth]);

                    newG = ((-1) * displayingArray[i - 3] + 9 * displayingArray[i + 1] + (-1) * displayingArray[i + 5] +
                            (-1) * displayingArray[i - 3 - tableWidth] + (-1) * displayingArray[i + 1 - tableWidth] + (-1) * displayingArray[i + 5 - tableWidth] +
                            (-1) * displayingArray[i - 3 + tableWidth] + (-1) * displayingArray[i + 1 + tableWidth] + (-1) * displayingArray[i + 5 + tableWidth]);

                    newR = ((-1) * displayingArray[i - 2] + 9 * displayingArray[i + 2] + (-1) * displayingArray[i + 6] +
                            (-1) * displayingArray[i - 2 - tableWidth] + (-1) * displayingArray[i + 2 - tableWidth] + (-1) * displayingArray[i + 6 - tableWidth] +
                            (-1) * displayingArray[i - 2 + tableWidth] + (-1) * displayingArray[i + 2 + tableWidth] + (-1) * displayingArray[i + 6 + tableWidth]);

                    tmp[i] = (byte)((newB > 0) ? newB : 0);
                    tmp[i + 1] = (byte)((newG > 0) ? newG : 0);
                    tmp[i + 2] = (byte)((newR > 0) ? newR : 0);
                }
            }
            ImageBytes = tmp;
            _bitmap = null;
        }

        public void GaussFilter()
        {
            byte[] displayingArray = ImageBytes;
            int bitmapWidth = (int)ImageWidth;
            int bitmapHeight = (int)ImageHeight;
            double newR, newG, newB;
            double d1 = 0.0625; // 1/16
            double d2 = 0.125; // 2/16
            double d3 = 0.25; // 4/16
            int tableWidth = bitmapWidth * 4, i;
            byte[] tmp = new byte[displayingArray.Length];
            displayingArray.CopyTo(tmp, 0);
            for (int h = 1; h < bitmapHeight - 1; h++)
            {
                for (int j = 4; j < tableWidth - 5; j += 4)
                {
                    i = j + tableWidth * h;
                    newB = (2 * displayingArray[i - 4] + 4 * displayingArray[i] + 2 * displayingArray[i + 4] +
                            displayingArray[i - 4 - tableWidth] + 2 * displayingArray[i - tableWidth] +
                            displayingArray[i + 4 - tableWidth] +
                            displayingArray[i - 4 + tableWidth] + 2 * displayingArray[i + tableWidth] +
                            displayingArray[i + 4 + tableWidth]) / 16;

                    newG = (2 * displayingArray[i - 3] + 4 * displayingArray[i + 1] + 2 * displayingArray[i + 5] +
                            displayingArray[i - 3 - tableWidth] + 2 * displayingArray[i + 1 - tableWidth] +
                            displayingArray[i + 5 - tableWidth] +
                            displayingArray[i - 3 + tableWidth] + 2 * displayingArray[i + 1 + tableWidth] +
                            displayingArray[i + 5 + tableWidth]) / 16;

                    newR = (2 * displayingArray[i - 2] + 4 * displayingArray[i + 2] + 2 * displayingArray[i + 6] +
                            displayingArray[i - 2 - tableWidth] + 2 * displayingArray[i + 2 - tableWidth] +
                            displayingArray[i + 6 - tableWidth] +
                            displayingArray[i - 2 + tableWidth] + 2 * displayingArray[i + 2 + tableWidth] +
                            displayingArray[i + 6 + tableWidth]) / 16;

                    tmp[i] = (byte)newB;
                    tmp[i + 1] = (byte)newG;
                    tmp[i + 2] = (byte)newR;
                }
            }
            ImageBytes = tmp;
            _bitmap = null;
        }

        #endregion
    }
}
