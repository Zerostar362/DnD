using DnD.View;
using DnD.ViewModel.System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DnD.ViewModel
{
    internal class MapCreatorVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChangedEvent(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }


        #region commands constructor

        public ICommand SelectTile { get; }
        public ICommand ForceUpdate { get; }

        #region methods
        public void CreateCommands()
        {
            
        }

        private ICommand Cmd(Action<object?> execute, Func<object?, bool>? canExecute = null) => new Command(execute, canExecute);
        #endregion

        #endregion

        public MapCreatorVM()
        {
            //CreateCommands();
            SelectTile = Cmd(p => SetTile());
            ForceUpdate = Cmd(p => forceUpdate());


            //must be last, due to command settings
            CreateGrid();
        }

        private void forceUpdate()
        {
            ItemsToCanvas.Clear();
            Thread.Sleep(100);
            ItemsToCanvas.Add(new CanvasItem(0,0,CreateLine(100,100)));
            Thread.Sleep(1000);
            ItemsToCanvas[0].Left = 100;
            ItemsToCanvas[0].Top = 100;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ItemsToCanvas.Left"));
        }

        private void SetTile()
        {
            
        }

        #region properties
        public ObservableCollection<CanvasItem> _itemsToCanvas = new ObservableCollection<CanvasItem>();

        public ObservableCollection<CanvasItem> ItemsToCanvas 
        {
            get { return _itemsToCanvas; }
            private set { _itemsToCanvas = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ItemsToCanvas")); }
        }

        public ObservableCollection<CanvasItem> _prefabricatedRooms = new ObservableCollection<CanvasItem>();
        public ObservableCollection<CanvasItem> PrefabricatedRoom
        {
            get { return _prefabricatedRooms; }
            private set { _prefabricatedRooms = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PrefabricatedRoom")); }
        }

        private int _mousePosX;
        public int MousePosX 
        {
            get => _mousePosX;
            set { _mousePosX = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MousePosX))); }
        }

        private int _mousePosY;
        public int MousePosY 
        {
            get => _mousePosY;
            set { _mousePosY = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MousePosY))); }
        }


        public int WindowHeight { get; set; } = 810;

        
        public int WindowWidth { get; set; } = 1450;

        private MouseButtonState _MouseButtonState = MouseButtonState.Released;

        private int _DrawMode = 0;

        private int _mapZoom;
        public int MapZoom
        {
            get => _mapZoom;
            private set { _mapZoom = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MapZoom")); }
        }
        #endregion

        private Shape CreateLine(int x, int y)
        {
            Rectangle rec = new Rectangle();
            rec.Width = x;
            rec.Height = y;
            rec.Stroke = Brushes.Gray;
            rec.StrokeThickness = 1;
            rec.Fill = Brushes.White;
            return rec;
        }

        private void CreateGrid()
        {
            for (int i = 0; i < (WindowWidth/20); i++)
            {
                for (int y = 0; y < (WindowHeight/20); y++)
                {
                    var cnvsIt = new CanvasItem(y * 20, i * 20, CreateLine(20, 20));
                    cnvsIt.shape.MouseMove += ContentControl_MouseMove;
                    cnvsIt.shape.MouseLeftButtonDown += ContentControl_MouseClick;
                    cnvsIt.shape.MouseLeftButtonUp += ContentControl_MouseUnClick;
                    cnvsIt.shape.MouseWheel += ContentControl_MouseWheel;
                    _itemsToCanvas.Add(cnvsIt);
                }
            }
            WindowWidth = 5;
            WindowHeight = 50;
        }



        private void ContentControl_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if(e.Delta < 0)
            {
                ZoomMap(0);
            }
            else
            {
                ZoomMap(1);
            }
        }

        private void ZoomMap(int v)
        {
            if (v == 0) MapZoom++;
            else MapZoom--;

            RenderMap(v);
        }

        private void RenderMap(int v)
        {
            foreach (var item in ItemsToCanvas)
            {
                if(v == 0)
                {
                    item.Left = item.Left - 15;
                    item.Top = item.Top - 15;
                }
                else
                {   
                    item.Left = item.Left + 15;
                    item.Top = item.Top + 15;
                }
                item.shape.Height = 20 - MapZoom;
                item.shape.Width = item.shape.Height;
            }
        }


        #region Events
        private void ContentControl_MouseUnClick(object sender, MouseButtonEventArgs e)
        {
            _MouseButtonState = e.ButtonState;
            var shp = (Rectangle)sender;
            shp.Fill = Brushes.Green;
        }

        private void ContentControl_MouseClick(object sender, MouseButtonEventArgs e)
        {
            var shp = (Rectangle)sender;
            shp.Fill = Brushes.Red;
            _MouseButtonState = e.ButtonState;
        }

        private void ContentControl_MouseMove(object sender, MouseEventArgs e)
        {
            var shp = (Shape)sender;
            var item = (CanvasItem)shp.DataContext;
            MousePosX = ((int)item.Left/10)/2;
            MousePosY = ((int)item.Top/10)/2;

            if(_MouseButtonState == MouseButtonState.Pressed)
            {
                shp = (Rectangle)sender;
                if (shp.Fill == Brushes.Red) return;
                shp.Fill = Brushes.BlueViolet;
            }
        }
        #endregion
    }

    public class CanvasItem
    {
        public CanvasItem(double top, double left, Shape sshape, string name = "Test")
        {
            Name = name;
            Top = top;
            Left = left;
            shape = sshape;
        }

        public string Name { get; set; } = "Test";
        public double Top { get; set; }
        public double Left { get; set; }
        public Shape shape { get; set; }
    }
}
