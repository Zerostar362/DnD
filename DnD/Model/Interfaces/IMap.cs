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

        List<IDoor> Doors { get; set; }
        List<IEnemy> Enemies { get; set; }
        List<IInvestigationSpace> InvestigationSpaces { get; set; }
        List<IObstacle> Obstacle { get; set; }
        List<IPlayableArea> PlayableAres { get; set; }
    }
}
