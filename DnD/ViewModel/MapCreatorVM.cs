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
using System.Windows;
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

        public ICommand SetCorridor { get; }
        public ICommand SetRoom { get; }
        public ICommand SetDoor { get; }
        public ICommand SetInvestigationSpaces { get; }
        public ICommand SetEnemy { get; }
        public ICommand Delete { get; }

        #region methods
        private ICommand Cmd(Action<object?> execute, Func<object?, bool>? canExecute = null) => new Command(execute, canExecute);

        private void SetCorridorCmd()
        {
            EntityName = "";
            brushes = Brushes.Gray;
        }

        private void SetRoomCmd()
        {
            EntityName = "";
            brushes = Brushes.Blue;
        }

        private void SetDoorCmd()
        {
            EntityName = "";
            brushes = Brushes.Brown;
        }

        private void SetInvestigationSpacesCmd()
        {
            EntityName = "";
            brushes = Brushes.Green;
        }

        private void PerformSetEnemy(object? btn)
        {
            if (btn is not Button button) return;
            EntityName = button.Name;
            brushes = Brushes.Red;
        }

        private void PerformDelete()
        {
            EntityName = "";
            brushes = Brushes.White;
        }

        #endregion

        #endregion

        public MapCreatorVM()
        {
            //CreateCommands();
            SetCorridor = Cmd(p => SetCorridorCmd());
            SetRoom = Cmd(p => SetRoomCmd());
            SetDoor = Cmd(p => SetDoorCmd());
            SetInvestigationSpaces = Cmd(p => SetInvestigationSpacesCmd());
            SetEnemy = Cmd(p => PerformSetEnemy(p));
            Delete = Cmd(p => PerformDelete());

            //must be last, due to command settings
            CreateGrid();
        }

        

        #region properties
        public ObservableCollection<CanvasItem> _itemsToCanvas = new ObservableCollection<CanvasItem>();

        public ObservableCollection<CanvasItem> ItemsToCanvas 
        {
            get { return _itemsToCanvas; }
            set { _itemsToCanvas = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ItemsToCanvas")); }
        }

        public ObservableCollection<CanvasItem> _prefabricatedRooms = new ObservableCollection<CanvasItem>();
        public ObservableCollection<CanvasItem> PrefabricatedRoom
        {
            get { return _prefabricatedRooms; }
            set { _prefabricatedRooms = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PrefabricatedRoom")); }
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

        private SolidColorBrush brushes { get; set; }
        private string EntityName;


        public int WindowHeight { get; set; } = 810;

        
        public int WindowWidth { get; set; } = 1450;

        private MouseButtonState _MouseButtonState = MouseButtonState.Released;


        /* DrawMode 0 - No Draw
         * DrawMode 1 - Corridor
         * DrawMode 2 - Room
         * DrawMode 3 - Door
         * DrawMode 4 - InvestigationSpaces
         */
        //private int _DrawMode = 0;

        private int _mapZoom;
        public int MapZoom
        {
            get => _mapZoom;
            private set { _mapZoom = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MapZoom")); }
        }
        #endregion

        private Shape CreateLine(int x, int y)
        {
            //DrawingVisual drawingVisual = new DrawingVisual();

            //DrawingContext drawingContext = drawingVisual.RenderOpen();

            //Rect rec = new Rect();

            Rectangle rec = new Rectangle();

            
            rec.Width = x;
            rec.Height = y;

            rec.Fill = Brushes.White;
            rec.StrokeThickness = 1;
            rec.Stroke =  Brushes.Black;
            return rec;
        }

        private void CreateGrid()
        {
            RenderFirstQuadrant();
            RenderSecondQuadrant();
            RenderThirdQuadrant();
            RenderFourthQuadrant();
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

            //1 kolecko nahoru
            //0 kolecko dolu
            if (v == 0) MapZoom++;
            else MapZoom--;

            RenderMap(v);
        }

        private async void RenderMap(int v)
        {
            int indicator;
            if (v == 0) indicator = 1;
            else indicator = -1;

            foreach (var item in ItemsToCanvas)
            {
                if (item.shape.Height + MapZoom < 0) break;
                
                item.shape.Height = (item.shape.Height + indicator);
                item.shape.Width = (item.shape.Width + indicator);

               
                var x = (item.Left / item.shape.Width);
                var y = (item.Top / item.shape.Height);

                item.Left = x * (item.shape.Width + indicator);
                item.Top = y * (item.shape.Height + indicator);
            }

            await Task.Factory.StartNew(() => Thread.Sleep(0));
        }

        private async void RenderFirstQuadrant()
        {
            for (int i = 0; i < ((WindowWidth / 20)/2); i++)
            {
                for (int y = 0; y < ((WindowHeight / 20)/2); y++)
                {
                    var cnvsIt = new CanvasItem(y * (20 - MapZoom), i * (20 - MapZoom), CreateLine(20 - MapZoom, 20 - MapZoom));
                    cnvsIt.shape.MouseMove += ContentControl_MouseMove;
                    cnvsIt.shape.MouseLeftButtonDown += ContentControl_MouseClick;
                    cnvsIt.shape.MouseLeftButtonUp += ContentControl_MouseUnClick;
                    cnvsIt.shape.MouseWheel += ContentControl_MouseWheel;
                    ItemsToCanvas.Add(cnvsIt);
                }
            }
            await Task.Factory.StartNew(() => Thread.Sleep(0));
        }

        private async void RenderSecondQuadrant()
        {
            for (int i = 0; i < ((WindowWidth / 20) / 2); i++)
            {
                for (int y = ((WindowHeight / 20) / 2); y < ((WindowHeight / 20)); y++)
                {
                    var cnvsIt = new CanvasItem(y * (20 - MapZoom), i * (20 - MapZoom), CreateLine(20 - MapZoom, 20 - MapZoom));
                    cnvsIt.shape.MouseMove += ContentControl_MouseMove;
                    cnvsIt.shape.MouseLeftButtonDown += ContentControl_MouseClick;
                    cnvsIt.shape.MouseLeftButtonUp += ContentControl_MouseUnClick;
                    cnvsIt.shape.MouseWheel += ContentControl_MouseWheel;
                    ItemsToCanvas.Add(cnvsIt);
                }
            }
            await Task.Factory.StartNew(() => Thread.Sleep(0));
        }

        private async void RenderThirdQuadrant()
        {
            for (int i = ((WindowWidth / 20) / 2); i < (WindowWidth / 20); i++)
            {
                for (int y = 0; y < ((WindowHeight / 20) /2); y++)
                {
                    var cnvsIt = new CanvasItem(y * (20 - MapZoom), i * (20 - MapZoom), CreateLine(20 - MapZoom, 20 - MapZoom));
                    cnvsIt.shape.MouseMove += ContentControl_MouseMove;
                    cnvsIt.shape.MouseLeftButtonDown += ContentControl_MouseClick;
                    cnvsIt.shape.MouseLeftButtonUp += ContentControl_MouseUnClick;
                    cnvsIt.shape.MouseWheel += ContentControl_MouseWheel;
                    ItemsToCanvas.Add(cnvsIt);
                }
            }
            await Task.Factory.StartNew(() => Thread.Sleep(0));
        }

        private async void RenderFourthQuadrant()
        {
            for (int i = ((WindowWidth / 20) / 2); i < (WindowWidth / 20); i++)
            {
                for (int y = ((WindowHeight / 20) / 2); y < (WindowHeight / 20); y++)
                {
                    var cnvsIt = new CanvasItem(y * (20 - MapZoom), i * (20 - MapZoom), CreateLine(20 - MapZoom, 20 - MapZoom));
                    cnvsIt.shape.MouseMove += ContentControl_MouseMove;
                    cnvsIt.shape.MouseLeftButtonDown += ContentControl_MouseClick;
                    cnvsIt.shape.MouseLeftButtonUp += ContentControl_MouseUnClick;
                    cnvsIt.shape.MouseWheel += ContentControl_MouseWheel;
                    ItemsToCanvas.Add(cnvsIt);
                }
            }
            await Task.Factory.StartNew(() => Thread.Sleep(0));
        }


        #region Events
        private void ContentControl_MouseUnClick(object sender, MouseButtonEventArgs e)
        {
            _MouseButtonState = e.ButtonState;
        }

        private void ContentControl_MouseClick(object sender, MouseButtonEventArgs e)
        {
            _MouseButtonState = e.ButtonState;
            var shp = (Shape)sender;
            var item = (CanvasItem)shp.DataContext;
            if (_MouseButtonState == MouseButtonState.Pressed)
            {
                shp = (Rectangle)sender;
                if (brushes == Brushes.Red || brushes == Brushes.White) item.Name = EntityName;
                shp.Fill = brushes;
            }
        }

        private void ContentControl_MouseMove(object sender, MouseEventArgs e)
        {
            var shp = (Shape)sender;
            var item = (CanvasItem)shp.DataContext;
            MousePosX = ((int)item.Left / 10) / 2;
            MousePosY = ((int)item.Top / 10) / 2;

            if (_MouseButtonState == MouseButtonState.Pressed)
            {
                shp = (Rectangle)sender;
                if (brushes == Brushes.Red || brushes == Brushes.White) item.Name = EntityName;
                shp.Fill = brushes;
            }
        }
        #endregion
    }

    public class CanvasItem : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;


        public CanvasItem(double top, double left, Shape sshape, string name = "Test")
        {
            Name = name;
            Top = top;
            Left = left;
            shape = sshape;
        }

        public string Name { get; set; } = "Test";

        private double _top;
        public double Top 
        {
            get => _top; 
            set { _top = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Top")); }
        }

        private double _left;
        public double Left 
        {
            get => _left;
            set { _left = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Left")); }
        }

        private Shape _shape;
        public Shape shape 
        {
            get => _shape;
            set { _shape = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("shape")); }
        }

        public void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("shape"));
        }
    }
}
