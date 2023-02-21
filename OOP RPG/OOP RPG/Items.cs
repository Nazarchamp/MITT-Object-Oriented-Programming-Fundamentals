using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    abstract class Item
    {
        public string name { get; init; }
        public int power { get; init; }

        public Item(string itemName, int itemPower)
        {
            name = itemName;
            power = itemPower;
        }
    }
    
    class Armour : Item
    {
        public Armour(string armourName, int armourPower):base(armourName, armourPower){}
    }

    class Weapon : Item
    {
        public Weapon(string weaponName, int weaponPower) : base(weaponName, weaponPower) { }
    }

    class Potion : Item
    {
        public Potion(string weaponName, int weaponPower) : base(weaponName, weaponPower) { }
    }

}
