using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Grafika.Drawing
{
    public class MapController : INotifyPropertyChanged
    {
        #region Instance
        private static MapController _instance = new MapController();
        public static MapController Instance { get { return _instance; } }

        private MapController() { }
        #endregion

        #region Zoom
        private float _zoom;
        public float Zoom
        {
            get { return _zoom; }
            set
            {
                _zoom = value;
                SetPointSize();
                OnPropertyChanged();
            }
        }
        #endregion

        #region Mouse Position
        private Point _mousePosition;
        public Point MousePosition
        {
            get { return _mousePosition; }
            set
            {
                _mousePosition = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Draw related
        public float PointSize { get; private set; }

        public Rect VisibleRegion { get; set; }

        public event Action InvalidateMap = delegate { };


        public void RerenderMap()
        {
            InvalidateMap();
        }

        private void SetPointSize()
        {
            if (_zoom < 4.5)
            {
                PointSize = 1.5f;
            }
            else if (_zoom < 10)
            {
                PointSize = 1f;
            }
            else if (_zoom < 15)
            {
                PointSize = 0.7f;
            }
            else
            {
                PointSize = 0.4f;
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
