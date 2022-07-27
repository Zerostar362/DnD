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
    public partial class MapCreator : Window
    {
        private double MousePosX { get; set; }
        private double MousePosY { get; set; }
        public MapCreator()
        {
            InitializeComponent();
        }

        public void MousePosChangedEvent(object sender, MouseEventArgs e)
        {
            var point = e.GetPosition(e.Device.Target);
            MousePosX = point.X;
            MousePosY = point.Y;
        }
    }
}
