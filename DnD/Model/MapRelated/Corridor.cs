using DnD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Models.MapRelated
{
    internal class Corridor : IPlayableArea
    {
        private int _width;
        private int _height;
        private bool _hasEnemies;
        private bool _hasMultipleDoors;
        private bool _isLighted;
        private List<IEnemy>? _listOfEnemies;
        private List<IDoor>? _listOfDoors;
        public int Width { get => _width;  set => _width = value; }

        public int Height { get => _height;  set => _height = value; }

        public bool hasEnemies { get => _hasEnemies; set => _hasEnemies = value; }

        public bool hasMultipleDoors { get => _hasMultipleDoors; set => _hasMultipleDoors = value; }

        public bool isLighted { get => _isLighted; set => _isLighted = value; }

        public List<IEnemy>? ListOfEnemies { set => _listOfEnemies?.Add((IEnemy)value); }

        public List<IDoor>? ListOfDoors { set => _listOfDoors?.Add((IDoor)value); }

        public IEnemy getEnemy(int index) => _listOfEnemies[index];

        public IDoor getDoor(int index) => _listOfDoors[index];

        public Corridor(int width, int height, bool hasEnemies, bool hasMultipleDoors, bool isLighted, List<IEnemy>? listOfEnemies, List<IDoor>? listOfDoors)
        {
            Width = width;
            Height = height;
            this.hasEnemies = hasEnemies;
            this.hasMultipleDoors = hasMultipleDoors;
            this.isLighted = isLighted;
            ListOfEnemies = listOfEnemies;
            ListOfDoors = listOfDoors;
        }

        public void checkVisibility()
        {
            throw new NotImplementedException();
        }

        public void CreateArea()
        {
            throw new NotImplementedException();
        }

        public void DeleteArea()
        {
            throw new NotImplementedException();
        }

        public bool MovementCheck(int x, int y, int toX, int toY)
        {
            throw new NotImplementedException();
        }
    }
}
