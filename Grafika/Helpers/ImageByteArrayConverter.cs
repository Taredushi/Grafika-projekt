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
    public class ImageByteArrayConverter
    {
        public static async Task<byte[]> ImageToByteArray(StorageFile file)
        {
            byte[] fileBytes = null;
            using (IRandomAccessStreamWithContentType stream = await file.OpenReadAsync())
            {
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                PixelDataProvider pixelData = await decoder.GetPixelDataAsync();

                fileBytes = pixelData.DetachPixelData();
            }

            return fileBytes;
        }

        public static async Task<byte[]> ScaledImageToByteArray(StorageFile file, uint width, uint height)
        {
            byte[] fileBytes = null;
            using (IRandomAccessStreamWithContentType stream = await file.OpenReadAsync())
            {
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                PixelDataProvider pixelData = await decoder.GetPixelDataAsync(
                    BitmapPixelFormat.Bgra8,
                    BitmapAlphaMode.Straight,
                    new BitmapTransform() { ScaledWidth = width, ScaledHeight = height },
                    ExifOrientationMode.IgnoreExifOrientation,
                    ColorManagementMode.DoNotColorManage);

                fileBytes = pixelData.DetachPixelData();
            }

            return fileBytes;
        }

        public static async Task<WriteableBitmap> ByteArrayToImage(byte[] bytes, int width, int height)
        {
            var image = new WriteableBitmap(width, height);
            using (Stream stream = image.PixelBuffer.AsStream())
            {
                await stream.WriteAsync(bytes, 0, bytes.Length);
            }
            return image;
        }

        public static async Task<byte[]> WritableBitmapToByteArray(WriteableBitmap wb)
        {
            Stream pixelStream = wb.PixelBuffer.AsStream();
            byte[] pixels = new byte[pixelStream.Length];
            await pixelStream.ReadAsync(pixels, 0, pixels.Length);
            return pixels;
        }
    }
}
