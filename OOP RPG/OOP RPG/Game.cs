using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;
using System.Threading;

namespace OOP_RPG
{
    internal class Game
    {
        private Hero hero;

        private int battlesFought;
        private int battlesWon; 

        private List<Monster> monsters;

        public Game()
        {
            monsters = new List<Monster>(new Monster[] {
                new Monster("Skeleton", MonsterType.Skeleton, 1, 1, 0, 1),
                new Monster("Royal Skeleton Guard", MonsterType.Skeleton, 1, 2, 1, 2),
                new Monster("Royal Chariot Skeleton Guard", MonsterType.Skeleton, 3, 3, 2, 3),

                new Monster("Goblin", MonsterType.Goblin, 1, 1, 1, 1),
                new Monster("Large Goblin", MonsterType.Goblin, 5, 1, 1, 2),

                new Monster("Ghost of Christmas Past", MonsterType.Goblin, 3, 3, 3, 3),
                new Monster("Ghost of Christmas Present", MonsterType.Goblin, 5, 5, 5, 6),
                new Monster("Ghost of Christmas Future", MonsterType.Goblin, 7, 7, 7, 9),

                new Monster("Wolf", MonsterType.Beast, 1, 1, 0, 1),
                new Monster("Bear", MonsterType.Beast, 5, 3, 0, 3),
                new Monster("Killer Bunny", MonsterType.Beast, 2, 100, 0, 1),
                new Monster("Dragon", MonsterType.Beast, 9, 9, 7, 15),
            });
        }

        public void Start()
        {
            StartConfig();

            while (true)
            {
                ShowMenu();
            }
        }

        private void StartConfig()
        {
            Random die = new Random();
            WriteLine("What would you like to be called player?");
            string name = ReadLine();

            if (name == "")
                name = "Player 1";

            WriteLine();
            WriteLine("Rolling a 6 sided die to determine base strength");
            Thread.Sleep(1000);
            int attack = die.Next(1, 6);
            WriteLine($"Your base strength is {attack}");

            Thread.Sleep(1000);

            WriteLine();
            WriteLine("Rolling a 6 sided die to determine base defence");
            Thread.Sleep(1000);
            int defence = die.Next(1, 6);
            WriteLine($"Your base defence is {defence}");

            Thread.Sleep(1000);

            hero = new Hero(name, 5, attack, defence);

            WriteLine();
            WriteLine($"Good Luck {name}!");
        }

        private void ShowMenu()
        {
            WriteLine();
            WriteLine("Main Menu");
            WriteLine("0: Battle");
            WriteLine("1: Show Statistics");
            WriteLine("2: Open Inventory");
            WriteLine("3: Visit the Shop");

            int selection = -1;

            while (!(selection > -1 && selection < 4))
            {
                WriteLine("Please enter a number between 0-3");
                if(!int.TryParse(ReadLine(), out selection))
                {
                    selection = -1;
                }
            }

            switch (selection)
            {
                case 0:
                    Battle();
                    break;
                case 1:
                    ShowStats();
                    break;
                case 2:
                    OpenInventory();
                    break;
                default:
                    OpenShop();
                    break;
            }

        }

        private void Battle()
        {
            int selection = ShowBattleMenu();

            BattleState result;
            Battle battle;

            switch (selection)
            {
                case 0:
                    Random rnd = new Random();
                    battle = new Battle(hero, monsters[rnd.Next(0, monsters.Count - 1)]);
                    WriteLine();
                    result = battle.Begin();
                    break;
                case 1:
                    int maxAttack = monsters.Max(monster => monster.strength);
                    battle = new Battle(hero, monsters[monsters.FindIndex(monster => monster.strength == maxAttack)]);
                    WriteLine();
                    result = battle.Begin();
                    break;
                case 2:
                    int maxDefense = monsters.Max(monster => monster.defense);
                    battle = new Battle(hero, monsters[monsters.FindIndex(monster => monster.defense == maxDefense)]);
                    WriteLine();
                    result = battle.Begin();
                    break;
                default:
                    //OpenInventory();
                    return;
            }

            battlesFought += 1;
            battlesWon += 1;

            if(result == BattleState.Lose)
            {
                battlesWon -= 1;
                WriteLine();
                WriteLine("You died but I like you so here's one health to keep living :)");
                WriteLine(hero.TakeHeal(1));
            }
        }

        private int ShowBattleMenu()
        {
            WriteLine();
            WriteLine("Battle Menu");
            WriteLine("0: Random Battle");
            WriteLine("1: Fight Highest Attack Monster");
            WriteLine("2: Fight Highest Defense Monster");
            WriteLine("3: Exit to Main Menu");

            int selection = -1;

            while (!(selection > -1 && selection < 4))
            {
                WriteLine("Please enter a number between 0-3");
                if(!int.TryParse(ReadLine(), out selection))
                {
                    selection = -1;
                }
            }

            return selection;
        }

        private void OpenInventory()
        {
            while (true)
            {
                WriteLine();
                WriteLine("Inventory Menu");
                WriteLine("0: Show Inventory");
                WriteLine("1: Equip Weapon");
                WriteLine("2: Equip Armor");
                WriteLine("3: Exit");

                int selection = -1;

                while (!(selection > -1 && selection < 4))
                {
                    WriteLine("Please enter a number between 0-3");
                    if(!int.TryParse(ReadLine(), out selection))
                    {
                        selection = -1;
                    }
                }


                switch (selection)
                {
                    case 0:
                        ShowInventory();
                        break;
                    case 1:
                        if (hero.weaponBag.Count == 0)
                        {
                            WriteLine();
                            WriteLine("No Weapon in Inventory");
                            break;
                        }
                        EquipWapon();
                        break;
                    case 2:
                        if (hero.armourBag.Count == 0)
                        {
                            WriteLine();
                            WriteLine("No Armour in Inventory");
                            break;
                        }
                        EquipArmour();
                        break;
                    default:
                        return;
                }
            }
        }

        private void EquipArmour()
        {
            WriteLine();
            WriteLine("Select Armour to Equip");
            for (int i = 0; i < hero.armourBag.Count; i++)
            {
                WriteLine($"{i}: {hero.armourBag[i].name}({hero.armourBag[i].power} protection)");
            }

            WriteLine($"{hero.armourBag.Count}: Exit");

            int selection = -1;

            while (!(selection > -1 && selection < hero.armourBag.Count + 1))
            {
                WriteLine($"Please enter a number between 0-{hero.armourBag.Count}");
                if (!int.TryParse(ReadLine(), out selection))
                {
                    selection = -1;
                }
            }

            if (selection == hero.armourBag.Count)
                return;

            WriteLine();
            WriteLine(hero.EquipArmour(hero.armourBag[selection]));
        }

        private void EquipWapon()
        {
            WriteLine();
            WriteLine("Select Weapon to Equip");
            for (int i = 0; i < hero.weaponBag.Count; i++)
            {
                WriteLine($"{i}: {hero.weaponBag[i].name}({hero.weaponBag[i].power} attack)");
            }

            WriteLine($"{hero.weaponBag.Count}: Exit");

            int selection = -1;

            while (!(selection > -1 && selection < hero.weaponBag.Count + 1))
            {
                WriteLine($"Please enter a number between 0-{hero.weaponBag.Count}");
                if (!int.TryParse(ReadLine(), out selection))
                {
                    selection = -1;
                }
            }

            if (selection == hero.weaponBag.Count)
                return;

            WriteLine();
            WriteLine(hero.EquipWeapon(hero.weaponBag[selection]));
        }
        private void ShowInventory()
        {
            WriteLine();
            Write(hero.ShowInventory());
        }

        private void ShowStats()
        {
            WriteLine();
            WriteLine(hero.ShowStats());
            WriteLine($"Battles: {battlesFought}");
            WriteLine($"Battles Won: {battlesWon}");
            WriteLine($"Battles Lost: {battlesFought - battlesWon}");
        }

        private void OpenShop()
        {
            while (true)
            {
                WriteLine();
                WriteLine("Welcome to the Shop");
                WriteLine("0: Weapons");
                WriteLine("1: Armour");
                WriteLine("2: Health");
                WriteLine("3: Exit");

                int selection = -1;

                while (!(selection > -1 && selection < 4))
                {
                    WriteLine("Please enter a number between 0-3");
                    if (!int.TryParse(ReadLine(), out selection))
                    {
                        selection = -1;
                    }
                }

                switch (selection)
                {
                    case 0:
                        WeaponShop();
                        break;
                    case 1:
                        ArmourShop();
                        break;
                    case 2:
                        HealShop();
                        break;
                    default:
                        return;
                }
            }
        }

        private void ArmourShop()
        {
            while (true)
            {
                WriteLine();
                WriteLine("Armour Shop");
                List<Armour> armours = new List<Armour>(new Armour[]
                {
                new Armour("Light Tunic", 1),
                new Armour("Chain Mail Armour", 3),
                new Armour("Knight's Steel Armour", 5)
                });

                for (int i = 0; i < armours.Count; i++)
                {
                    WriteLine($"{i}: {armours[i].name}({armours[i].power} protection) => {armours[i].power * 3} gold");
                }

                WriteLine($"{armours.Count}: Exit");

                int selection = -1;

                while (!(selection > -1 && selection < armours.Count + 1))
                {
                    WriteLine($"Please enter a number between 0-{armours.Count}");
                    if (!int.TryParse(ReadLine(), out selection))
                    {
                        selection = -1;
                    }
                }

                if (selection == armours.Count)
                    return;

                if (armours[selection].power * 3 > hero.gold)
                {
                    WriteLine();
                    WriteLine("You Don't Have Enough Gold!");
                }
                else
                {
                    hero.armourBag.Add(armours[selection]);
                    hero.gold -= armours[selection].power * 3;
                    WriteLine();
                    WriteLine($"Thanks for your purchase, you now own one new {armours[selection].name}!");
                }
            }
        }

        private void WeaponShop()
        {
            while (true)
            {
                WriteLine();
                WriteLine("Weapon Shop");
                List<Weapon> weapons = new List<Weapon>(new Weapon[]
                {
                    new Weapon("Small Dagger", 1),
                    new Weapon("Axe", 3),
                    new Weapon("Steel Sword", 5),
                    new Weapon("Blade of the Ruined Knight", 7)
                });

                for (int i = 0; i < weapons.Count; i++)
                {
                    WriteLine($"{i}: {weapons[i].name}({weapons[i].power} attack) => {weapons[i].power * 2} gold");
                }

                WriteLine($"{weapons.Count}: Exit");

                int selection = -1;

                while (!(selection > -1 && selection < weapons.Count + 1))
                {
                    WriteLine($"Please enter a number between 0-{weapons.Count}");
                    if (!int.TryParse(ReadLine(), out selection))
                    {
                        selection = -1;
                    }
                }

                if (selection == weapons.Count)
                    return;

                if (weapons[selection].power * 2 > hero.gold)
                {
                    WriteLine();
                    WriteLine("You Don't Have Enough Gold!");
                }
                else
                {
                    hero.weaponBag.Add(weapons[selection]);
                    hero.gold -= weapons[selection].power * 2;
                    WriteLine();
                    WriteLine($"Thanks for your purchase, you now own one new {weapons[selection].name}!");
                }
            }
        }

        private void HealShop()
        {
            while (true)
            {
                WriteLine();
                WriteLine("Heal Potion Shop");
                List<Potion> potions = new List<Potion>(new Potion[]
                {
                    new Potion("Small Heal Potion", 1),
                    new Potion("Medium Heal Potion", 3),
                    new Potion("Full Heal Potion", 5)
                });

                for (int i = 0; i < potions.Count; i++)
                {
                    WriteLine($"{i}: {potions[i].name}({potions[i].power} health) => {potions[i].power * 4} gold");
                }

                WriteLine($"{potions.Count}: Exit");

                int selection = -1;

                while (!(selection > -1 && selection < potions.Count + 1))
                {
                    WriteLine($"Please enter a number between 0-{potions.Count}");
                    if (!int.TryParse(ReadLine(), out selection))
                    {
                        selection = -1;
                    }
                }

                if (selection == potions.Count)
                    return;

                if (potions[selection].power * 4 > hero.gold)
                {
                    WriteLine();
                    WriteLine("You Don't Have Enough Gold!");
                }
                else
                {
                    hero.gold -= potions[selection].power * 4;
                    WriteLine();
                    WriteLine($"Thanks for your purchase, you now own one new {potions[selection].name}!");
                    WriteLine();
                    WriteLine(hero.TakeHeal(potions[selection].power));
                }
            }
        }


    }
}
