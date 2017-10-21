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
        private uint _imageWidth;
        private uint _imageHeight;
        private byte[] _imageBytes;
        private CanvasBitmap _bitmap;

        public ImageGeometry(StorageFile file)
        {
            _sourceFile = file;
            Initialize();
        }

        public ImageGeometry(PpmFile file)
        {
            _imageWidth = (uint)file.Width;
            _imageHeight = (uint)file.Height;
            _imageBytes = file.ByteArray;
        }

        private async void Initialize()
        {
            var prop = await _sourceFile.Properties.GetImagePropertiesAsync();
            _imageWidth = prop.Width;
            _imageHeight = prop.Height;
            _imageBytes = await ImageByteArrayConverter.ScaledImageToByteArray(_sourceFile, _imageWidth, _imageHeight);
        }

        public void Draw(CanvasDrawingSession session, CanvasVirtualControl device)
        {
            if (_bitmap == null)
            {
                _bitmap = CanvasBitmap.CreateFromBytes(device, _imageBytes, (int)_imageWidth, (int)_imageHeight, DirectXPixelFormat.B8G8R8X8UIntNormalized);
            }

            session.DrawImage(_bitmap, new Rect(0, 0, _imageWidth, _imageHeight));
        }
    }
}
