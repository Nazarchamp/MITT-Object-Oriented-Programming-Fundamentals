using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG   
{
    internal class Hero : Character
    {
        public override CharacterClass characterClass { get { return CharacterClass.Hero; } }
        public Weapon equippedWeapon { get; set; }
        public List<Weapon> weaponBag { get; set; }
        public Armour equippedArmour { get; set; }
        public List<Armour> armourBag { get; set; }
        public override int attackModifier { get; set; }
        public override int defenseModifier { get; set; }
        public int gold { get; set; }

        public string EquipArmour(Armour armour)
        {
            if (equippedArmour == armour)
            {
                return $"{name} already has {armour.name} equipped";
            }
            if (!armourBag.Contains(armour))
            {
                armourBag.Add(armour);
            }
            defenseModifier = armour.power;
            equippedArmour = armour;
            return $"{name} equipped {armour.name}";
        }

        public string EquipWeapon(Weapon weapon)
        {
            if (equippedWeapon == weapon)
            {
                return $"{name} already has {weapon.name} equipped";
            }
            if (!weaponBag.Contains(weapon))
            {
                weaponBag.Add(weapon);
            }
            attackModifier = weapon.power;
            equippedWeapon = weapon;
            return $"{name} equipped {weapon.name}";
        }

        public Hero(string heroName, int baseHeroHealth, int baseHeroAttack, int baseHeroDefense)
            : base(heroName, baseHeroHealth, baseHeroAttack, baseHeroDefense)
        {
            equippedWeapon = new Weapon("None", 0);
            equippedArmour = new Armour("None", 0);
            weaponBag = new List<Weapon>();
            armourBag = new List<Armour>();
        }

        public string ShowStats()
        {
            return $"{name}\n" +
                  $"Health: {base.CurHealth}/{base.maxHealth}\n" +
                  $"Gold: {gold}\n" +
                  $"Base Attack: {base.strength}\n" +
                  $"Base Defense: {base.defense}\n" +
                  $"Equipped Weapon: {equippedWeapon.name} gives {equippedWeapon.power} extra attack damage\n" +
                  $"Equipped Armour: {equippedArmour.name} gives {equippedArmour.power} extra defense";

        }

        public string ShowInventory()
        {
            string outPutStr = "Weapons:";
            if (weaponBag.Count == 0)
                outPutStr += "\nNone";
            outPutStr += "\n";

            foreach(Weapon weapon in weaponBag)
            {
                outPutStr += $"{weapon.name}({weapon.power} Attack)\n";
            }

            outPutStr += "\nArmour:";

            if (armourBag.Count == 0)
                outPutStr += "\nNone";
            outPutStr += "\n";

            foreach (Armour armour in armourBag)
            {
                outPutStr += $"{armour.name}({armour.power} protection)\n";
            }

            return outPutStr;
        }

    }
}
