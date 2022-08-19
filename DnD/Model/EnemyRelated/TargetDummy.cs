using DnD.Interfaces;
using DnD.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Models.EnemyRelated
{
    public class TargetDummy : IEnemy
    {

        private int _armor = 0;
        private int _magicResist = 0;
        private int _hp = 0;
        private int _endurance = 1;
        private int _strength = 0;
        private int _dexterity = 0;
        private int _investigation = 0;
        private int _criticalStrikeChance = 0;
        private int _abilityPower = 0;
        private int _mana = 0;
        private List<ISpell> _spellList = new List<ISpell>();

        public int Armor { get => _armor; set =>  _armor = value; }
        public int MagicResist { get => _magicResist; set => _magicResist = value; }
        public int HP { get => _hp; set => _hp = value; }
        public int Endurance { get => _endurance; set => _endurance = value; }
        public int Strength { get => _strength; set => _strength = value; }
        public int Dexterity { get => _dexterity; set => _dexterity = value; }
        public int Investigation { get => _investigation; set => _investigation = value; }
        public int CriticalStrikeChance { get => _criticalStrikeChance; set => _criticalStrikeChance = value; }
        public int AbilityPower { get => _abilityPower; set => _abilityPower = value; }
        public int Mana { get => _mana; set => _mana = value; }
        public List<ISpell> SpellList {get => _spellList; set => _spellList = value; }

        public virtual void Attack()
        {
            throw new NotImplementedException();
        }

        public virtual void CastSpell()
        {
            throw new NotImplementedException();
        }

        public virtual void Evade()
        {
            throw new NotImplementedException();
        }

        public virtual void Move()
        {
            throw new NotImplementedException();
        }

        public virtual void RunAway()
        {
            throw new NotImplementedException();
        }
    }
}
