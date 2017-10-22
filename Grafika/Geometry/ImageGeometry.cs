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
            session.DrawImage(_bitmap, new Rect(0, 0, ImageWidth, ImageHeight));
        }

        public void Dispose()
        {
            _bitmap = null;
            ImageBytes = null;
        }
    }
}
