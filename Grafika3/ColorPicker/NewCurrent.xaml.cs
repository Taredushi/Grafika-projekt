using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ColorPicker.ExtensionMethods;

namespace ColorPicker
{
    /// <summary>
    /// Interaction logic for NewCurrent.xaml
    /// </summary>
    public partial class NewCurrent : UserControl
    {
        public static Type ClassType
        {
            get { return typeof(NewCurrent); }
        }

        public NewCurrent()
        {
            InitializeComponent();
        }

        #region NewColor

        public static DependencyProperty NewColorProperty = DependencyProperty.Register("NewColor", typeof(Color), ClassType, 
            new FrameworkPropertyMetadata(Colors.Gray, new PropertyChangedCallback(OnNewColorChanged)));
         [Category("ColorPicker")]
        public Color NewColor
        {
            get
            {
                return (Color)GetValue(NewColorProperty);
            }
            set
            {
                SetValue(NewColorProperty, value);
            }
        }

        private static void OnNewColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var nc = (NewCurrent)d;
            nc.rNew.Fill = new SolidColorBrush(((Color)e.NewValue).WithAlpha(255));

        }

        #endregion
        
    }
}
