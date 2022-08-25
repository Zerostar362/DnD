using DnD.Interfaces;
using DnD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Models.MapRelated
{
    internal class Map : IMap
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public int NumberOfCorridors { get; private set; }

        public int NumberOfRooms { get; private set; }

        public string MapLore { get; private set; }
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }
        public List<IDoor> Doors { get; set; }
        public List<IEnemy> Enemies { get; set; }
        public List<IInvestigationSpace> InvestigationSpaces { get; set; }
        public List<IObstacle> Obstacle { get; set; }
        public List<IPlayableArea> PlayableAres { get; set; }

        public Map(int width, int height, int numberOfCorridors, int numberOfRooms, string mapLore)
        {
            Width = width;
            Height = height;
            NumberOfCorridors = numberOfCorridors;
            NumberOfRooms = numberOfRooms;
            MapLore = mapLore;
        }

        public Map(List<CanvasItem> items)
        {
            for (int i = 0; i < 4; i++)
            {
                ResolveDoors(items);
                ResolveEnemies(items);
                ResolveInvestigationSpaces(items);
                ResolveObstacles(items);
                ResolvePlayableAreas(items);
            }
        }

        private void ResolveDoors(List<CanvasItem> items)
        {

        }
    }
}
