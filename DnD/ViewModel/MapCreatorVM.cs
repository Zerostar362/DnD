using DnD.ViewModel.System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        ICommand SelectTile { get; }

        #region methods
        public void CreateCommands()
        {
            
        }

        private ICommand Cmd(Action<object?> execute, Func<object?, bool>? canExecute = null) => new Command(execute, canExecute);
        #endregion

        #endregion

        public MapCreatorVM()
        {
            CreateCommands();
            CreateGrid();
            SelectTile = Cmd(p => RemapRectangle(MousePosX, MousePosY));
        }

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

        public int MousePosX { get; set; } = 5;

        public int MousePosY { get; set; }


        public int WindowHeight { get; set; } = 810;

        
        public int WindowWidth { get; set; } = 1450;




        private Shape CreateLine(int x, int y)
        {
            Rectangle rec = new Rectangle();
            rec.Width = x;
            rec.Height = y;
            rec.Stroke = Brushes.Gray;
            rec.StrokeThickness = 1;
            return rec;
        }

        private void CreateGrid()
        {
            for (int i = 0; i < WindowWidth; i=i+20)
            {
                for (int y = 0; y < WindowHeight; y=y+20)
                {
                    _itemsToCanvas.Add(new CanvasItem(y, i, CreateLine(20, 20)));
                }
            }
            WindowWidth = 50;
            WindowHeight = 500;
        }

        public void RemapRectangle(int top, int left)
        {

        }


    }

    public class CanvasItem
    {
        public CanvasItem(double top, double left,Shape sshape, string name = "Test")
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
