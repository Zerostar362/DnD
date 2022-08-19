using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Interfaces
{
    internal interface IMap
    {
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }
    }
}
