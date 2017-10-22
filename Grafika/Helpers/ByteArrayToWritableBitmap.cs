using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace Grafika.Helpers
{
    public enum FileFormat
    {
        Jpeg,
        Png,
        Bmp,
        Tiff,
        Gif
    }

    class ByteArrayToWritableBitmap
    {
        public static async Task WriteableBitmapToStorageFile(WriteableBitmap WB, FileFormat fileFormat, int compression, StorageFile file)
        {
            string FileName = "YourFile.";
            Guid BitmapEncoderGuid = BitmapEncoder.JpegEncoderId;
            switch (fileFormat)
            {
                case FileFormat.Jpeg:
                    FileName += "jpeg";
                    BitmapEncoderGuid = BitmapEncoder.JpegEncoderId;
                    break;
                case FileFormat.Png:
                    FileName += "png";
                    BitmapEncoderGuid = BitmapEncoder.PngEncoderId;
                    break;
                case FileFormat.Bmp:
                    FileName += "bmp";
                    BitmapEncoderGuid = BitmapEncoder.BmpEncoderId;
                    break;
                case FileFormat.Tiff:
                    FileName += "tiff";
                    BitmapEncoderGuid = BitmapEncoder.TiffEncoderId;
                    break;
                case FileFormat.Gif:
                    FileName += "gif";
                    BitmapEncoderGuid = BitmapEncoder.GifEncoderId;
                    break;
            }
            using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                var propertySet = new Windows.Graphics.Imaging.BitmapPropertySet();
                var qualityValue = new Windows.Graphics.Imaging.BitmapTypedValue(
                    1 - (compression/100),
                    Windows.Foundation.PropertyType.Single
                );

                propertySet.Add("ImageQuality", qualityValue);

                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoderGuid, stream, propertySet);
                Stream pixelStream = WB.PixelBuffer.AsStream();
                byte[] pixels = new byte[pixelStream.Length];
                await pixelStream.ReadAsync(pixels, 0, pixels.Length);
                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)WB.PixelWidth, (uint)WB.PixelHeight,
                    96.0,
                    96.0,
                    pixels);

                await encoder.FlushAsync();
            }

        }
    }

}
