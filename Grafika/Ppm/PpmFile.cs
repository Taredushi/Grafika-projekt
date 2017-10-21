using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Grafika.Helpers;

namespace Grafika.Ppm
{
    public class PpmFile
    {
        public string Format { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }
        public byte[] ByteArray { get; private set; }


        public async Task ReadPpmFile(StorageFile file)
        {
            using (FileRandomAccessStream stream = (FileRandomAccessStream)await file.OpenAsync(FileAccessMode.Read))
            {
                using (BinaryReader reader = new BinaryReader(stream.AsStream()))
                {
                    var format = reader.ReadBytes(2);
                    Format = ((char)format[0]).ToString() + ((char)format[1]);
                    if (Format.Equals("P3"))
                    {
                        await ReadTextImage(stream.AsStream());
                    }
                    else if (Format.Equals("P6"))
                    {
                        ReadBinaryImage(reader);
                    }
                }
            }
        }

        private async Task ReadTextImage(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                reader.ReadLine();
                ByteArray = ReadAllNumbers(reader);
            }
        }

        private byte[] ReadAllNumbers(StreamReader reader)
        {
            byte[] array = null;
            List<int> values = new List<int>();
            int mainCounter = 0;
            var counter = 0;

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrEmpty(line)) continue;
                line = line.Replace("\t", " ");
                var words = line.Split(' ');
                foreach (var word in words)
                {
                    if (word.Contains("#")) break;
                    if (IsWhiteSpace(word)) continue;

                    try
                    {
                        var number = Int32.Parse(word);
                        switch (counter)
                        {
                            case 0:
                                Width = number;
                                counter++;
                                break;
                            case 1:
                                Height = number;
                                counter++;
                                break;
                            case 2:
                                Depth = number;
                                counter++;
                                break;
                            default:
                                if (array == null)
                                {
                                    array = new byte[Width * Height * 4];
                                }
                                if (values.Count == 3)
                                {
                                    array[mainCounter] = (byte)((values[2] * 255) / Depth);
                                    array[mainCounter + 1] = (byte)((values[1] * 255) / Depth);
                                    array[mainCounter + 2] = (byte)((values[0] * 255) / Depth);
                                    array[mainCounter + 3] = 255;

                                    values.Clear();
                                    mainCounter += 4;
                                }
                                values.Add(number);
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }

            return array;
        }


        private void ReadBinaryImage(BinaryReader reader)
        {
            ReadWhitespace(reader);
            Width = ValueReader(reader);
            ReadWhitespace(reader);
            Height = ValueReader(reader);
            ReadWhitespace(reader);
            Depth = ValueReader(reader);

            ByteArray = ReadByteArray(reader);
        }

        private byte[] ReadByteArray(BinaryReader reader)
        {
            byte[] array = new byte[Width * Height * 4];
            try
            {
                byte[] tmp;
                uint r16, g16, b16;
                for (int i = 0; i < array.Length; i += 4)
                {
                    if (Depth > 255)
                    {
                        tmp = reader.ReadBytes(6);
                        r16 = BitConverter.ToUInt16(tmp, 0);
                        g16 = BitConverter.ToUInt16(tmp, 2);
                        b16 = BitConverter.ToUInt16(tmp, 4);
                    }
                    else
                    {
                        tmp = reader.ReadBytes(3);
                        r16 = tmp[0];
                        g16 = tmp[1];
                        b16 = tmp[2];
                    }
                    array[i] = (byte)((b16 * 255) / Depth);
                    array[i + 1] = (byte)((g16 * 255) / Depth);
                    array[i + 2] = (byte)((r16 * 255) / Depth);
                    array[i + 3] = 255;
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return array;
        }

        private bool IsWhiteSpace(char c)
        {
            return (c == ' ' || c == '\t' || c == '\n' || c == '\0' || c == '#');
        }

        private bool IsWhiteSpace(string text)
        {
            return text.Contains(" ") || text == "" || text.Contains("\t") || text.Contains("\0") ||
                   text.Contains("\n");
        }

        private void ReadWhitespace(BinaryReader reader)
        {
            char c = reader.ReadChar();

            while (IsWhiteSpace(c))
            {
                if (c == '#')
                {
                    reader.ReadChar();
                    while (c != '\n')
                    {
                        try
                        {
                            c = reader.ReadChar();
                        }
                        catch (Exception e)
                        {
                            reader.BaseStream.Seek(1, SeekOrigin.Current);
                        }
                    }
                }
                c = reader.ReadChar();
            }
            reader.BaseStream.Seek(-1, SeekOrigin.Current);
        }

        private int ValueReader(BinaryReader reader)
        {
            var text = "";
            char c = reader.ReadChar();

            while (!IsWhiteSpace(c))
            {
                text += c;
                c = reader.ReadChar();
            }

            return int.Parse(text);
        }

    }
}
