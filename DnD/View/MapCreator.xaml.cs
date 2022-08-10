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
        /*private string _MousePosX = "0";
        public string MousePositionX
        { 
            get { return _MousePosX; }
            set { _MousePosX = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MousePosX")); }
        }
        private string _MousePosY = "0";
        public string MousePositionY 
        { 
            get { return _MousePosY; }
            set { _MousePosY = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MousePosY")); }
        }*/


        public MapCreator()
        {
            InitializeComponent();
            //Application.Current.MainWindow = this;
        }

        //public event PropertyChangedEventHandler? PropertyChanged;

        /*private void ContentControl_MouseMove(object sender, MouseEventArgs e)
        {
            var shp = (Shape)sender;
            var pos = e.GetPosition(Application.Current.MainWindow);
            MousePositionX = Math.Floor((((pos.X - 150) / 20) + 1)).ToString();
            MousePositionY = Math.Floor((((pos.Y - 50) / 20) + 1)).ToString();
        }*/
    }
}
