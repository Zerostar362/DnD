using DnD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Models.MapRelated
{
    internal class Room : IPlayableArea
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public string RoomLore { get; private set; }

        public bool hasEnemies { get; private set; }

        public bool hasMultipleDoors { get; private set; }

        public bool hasInvestigationSpace { get; private set; }

        public bool isLighted { get; private set; }

        private List<IEnemy>? ListOfEnemies {get; set; }

        private List<IDoor>? ListOfDoors { get; set; }

        private List<IInvestigationSpace>? ListOfInvestigationPlaces { get; set; }


        private int[,] Map { get; set; }
        int IPlayableArea.Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IPlayableArea.Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        bool IPlayableArea.hasEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        bool IPlayableArea.hasMultipleDoors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        bool IPlayableArea.isLighted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        List<IEnemy>? IPlayableArea.ListOfEnemies { set => throw new NotImplementedException(); }
        List<IDoor>? IPlayableArea.ListOfDoors { set => throw new NotImplementedException(); }

        public Room(int width, int height, string roomLore, bool hasenemies, bool hasMultipledoors,
            bool hasInvestigationspace, ICollection<IEnemy> enemies, ICollection<IDoor> doors, ICollection<IInvestigationSpace> spaces)
        {
            Width = width;
            Height = height;
            RoomLore = roomLore;
            hasEnemies = hasenemies;
            hasMultipleDoors = hasMultipledoors;
            hasInvestigationSpace = hasInvestigationspace;
            ListOfEnemies = enemies.ToList();
            ListOfDoors = doors.ToList();
            ListOfInvestigationPlaces = spaces.ToList();
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
