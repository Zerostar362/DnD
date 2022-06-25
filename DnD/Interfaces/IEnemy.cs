using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Interfaces
{
    interface IEnemy
    {
        int Armor { get; set; }
        int MagicResist { get; set; }
        int HP { get; set; }
        int Endurance { get; set; }
        int Strength { get; set; }
        int Dexterity { get; set; }
        int Investigation { get; set; }
        int CriticalStrikeChance { get; set; }
        int AbilityPower { get; set; }
        int Mana { get; set; }
        public void Attack();

        public void Move();

        public void RunAway();

        public void Evade();

        public void CastSpell();

    }
}
