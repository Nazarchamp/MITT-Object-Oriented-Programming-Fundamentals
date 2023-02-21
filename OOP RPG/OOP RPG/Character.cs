using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public enum CharacterClass
    {
        Hero,
        Monster
    }
    internal abstract class Character
    {
        public string name { get; }
        public int strength { get; set; }
        public  int defense { get; set; }
        public int maxHealth { get; set; }

        private int curHealth;

        public int CurHealth { get { return curHealth; } }

        public abstract CharacterClass characterClass { get; }

        public abstract int attackModifier { get; set; }
        public abstract int defenseModifier { get; set; }

        public Character(string characterName, int initialHealth, int initialStrength, int initialDefense)
        {
            name = characterName;
            curHealth = initialHealth;
            maxHealth = curHealth;
            strength = initialStrength;
            defense = initialDefense;
        }

        public int Hit()
        {
            return attackModifier + strength;
        }

        public (bool, string) TakeHit(int hitStrength)
        {
            int takenDmg = hitStrength - defense - defenseModifier;

            if (takenDmg < 0)
                takenDmg = 0;

            curHealth -= takenDmg;

            if (takenDmg == 0)
                return (true, $"{name} deflected all damage and has {curHealth} health");

            if (curHealth <= 0)
            {
                curHealth = 0;
                return (false, $"{name} died after being hit for {hitStrength} and deflecting {defense+defenseModifier} damage, taking a net of {takenDmg} damage!");
            }

            return (true, $"{name} has {curHealth} health after being hit for {hitStrength} damage and deflecting {defense+defenseModifier} damage, taking a net of {takenDmg} damage!");
        }

        public string TakeHeal(int healStrength)
        {
            if(maxHealth == curHealth)
            {
                return $"{name} is already full health ({maxHealth} health)!";
            }

            int newHealth = curHealth + healStrength;
            if(newHealth > maxHealth)
            {
                curHealth = maxHealth; 
                return $"{name} healed to full health ({maxHealth} health)!";
            }
            curHealth = newHealth;

            return $"{name} healed for {healStrength} health to {curHealth} health!";
        }
    }
}
