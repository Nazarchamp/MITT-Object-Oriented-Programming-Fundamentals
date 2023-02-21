using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public enum MonsterType
    {
        Ghost,
        Goblin,
        Beast,
        Skeleton
    }

    internal class Monster : Character
    {
        public override CharacterClass characterClass
        {
            get { return CharacterClass.Monster; }
        }

        public MonsterType monsterType { get; init; }

        public int goldValue { get; set; }

        public override int attackModifier { get; set; }
        public override int defenseModifier { get; set; }

        public Monster(string monsterName, MonsterType monsterType, int baseMonsterHealth, int baseMonsterAttack, int baseMonsterDefense, int goldValue)
            : base(monsterName, baseMonsterHealth, baseMonsterAttack, baseMonsterDefense)
        {
            this.monsterType = monsterType;
            this.attackModifier = 0;
            this.defenseModifier = 0;
            this.goldValue = goldValue;
        }

    }
}
