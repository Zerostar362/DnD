using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Models.MapRelated
{
    internal class Map
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public int NumberOfCorridors { get; private set; }

        public int NumberOfRooms { get; private set; }

        private List<Room> ListOfRooms { get; set; }

        private List<Corridor> ListOfCorridors { get; set; }

        public string MapLore { get; private set; }

        public Map(int width, int height, int numberOfCorridors, int numberOfRooms, List<Room> listOfRooms, List<Corridor> listOfCorridors, string mapLore)
        {
            Width = width;
            Height = height;
            NumberOfCorridors = numberOfCorridors;
            NumberOfRooms = numberOfRooms;
            ListOfRooms = listOfRooms;
            ListOfCorridors = listOfCorridors;
            MapLore = mapLore;
        }   
    }
}
