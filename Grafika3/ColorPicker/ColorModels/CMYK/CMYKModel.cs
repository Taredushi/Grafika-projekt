using System;
using System.Diagnostics;
using System.Windows.Media;
using ColorPicker.ExtensionMethods;

namespace ColorPicker.ColorModels.CMYK
{
    public class CMYKModel
    {
        #region Color

        public enum ECMYKComponent
        {
            Cyan = 0,
            Magenta = 1,
            Yellow = 2,
            Black = 3
        }
        
        public Color Color(double cyan, double magenta, double yellow, double black)
        {
            var c = cyan / 100;
            var m = magenta / 100;
            var y = yellow / 100;
            var b = black / 100;

            var red = 1 - Math.Min(1, c * (1 - b) + b);
            red = red * 255;
            var green = 1 - Math.Min(1, m * (1 - b) + b);
            green = green * 255;
            var blue = 1 - Math.Min(1, y * (1 - b) + b);
            blue = blue * 255;
            return System.Windows.Media.Color.FromRgb(red.RestrictToByte(), green.RestrictToByte(),
                blue.RestrictToByte());
        }

        #endregion

        #region components

        private double MinComponent(Color color)
        {
            double red = (double)color.R / 255;
            double green = (double)color.G / 255;
            double blue = (double)color.B / 255;
            double c = 1 - red;
            double m = 1 - green;
            double y = 1 - blue;

            return Math.Min(c, Math.Min(m, y));
        }

        public double CComponent(Color color)
        {
            var min = MinComponent(color);
            var red = (double) color.R / 255;
            var c = (1 - red - min) / (1 - min);
            Debug.WriteLine("c: " + c);
            return Math.Round(c * 100);
        }

        public double MComponent(Color color)
        {
            var min = MinComponent(color);
            double green = (double)color.G/255;
            var m = (1 - green - min) / (1 - min);
            Debug.WriteLine("m: " + m);
            return Math.Round(m * 100);
        }


        public double YComponent(Color color)
        {
            var min = MinComponent(color);
            double blue = (double)color.B / 255;
            var y = (1 - blue - min) / (1 - min);
            Debug.WriteLine("y: " + y);
            return Math.Round(y * 100);
        }


        public double KComponent(Color color)
        {
            var min = MinComponent(color);
            return Math.Round(min * 100);
        }

        #endregion
    }
}