using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Interfaces
{
    internal interface IPlayableArea
    {

        int Width { get; set; }

        int Height { get; set; }

        bool hasEnemies { get; set; }

        bool hasMultipleDoors { get; set; }

        bool isLighted { get; set; }

        List<IEnemy>? ListOfEnemies { get; set; }

        List<IDoor>? ListOfDoors { get; set; }

        int[,] Tiles { get; set;}

        public bool MovementCheck(int x, int y, int toX, int toY);

        public void CreateArea();

        public void DeleteArea();

        public void checkVisibility();
    }
}
