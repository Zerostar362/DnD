using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Interfaces
{
    internal interface IPlayer
    {
        public void Attack();

        public void Move();

        public void RunAway();

        public void Evade();

        public void CastSpell();
    }
}
