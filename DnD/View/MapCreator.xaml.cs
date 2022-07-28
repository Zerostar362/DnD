using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DnD.View
{
    /// <summary>
    /// Interaction logic for MapCreator.xaml
    /// </summary>
    /// 
    public partial class MapCreator : Window, INotifyPropertyChanged
    {
        private double _MousePosX;
        public double MousePosX 
        { 
            get { return _MousePosX; }
            set { _MousePosX = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MousePosX")); }
        }
        private double _MousePosY;
        public double MousePosY 
        { 
            get { return _MousePosY; }
            set { _MousePosY = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MousePosY")); }
        }
        public MapCreator()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void ContentControl_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.GetPosition(e.Device.Target);
            MousePosX = pos.X;
            MousePosY = pos.Y;
        }
    }
}
