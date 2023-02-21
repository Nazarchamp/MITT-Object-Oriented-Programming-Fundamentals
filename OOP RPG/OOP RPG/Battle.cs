using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using static System.Console;

namespace OOP_RPG
{

    public enum BattleState
    {
        HeroAttack,
        MonsterAttack,
        Win,
        Lose,
        RunAway
    }
    internal class Battle
    {

        private Hero hero;
        private Monster monster;

        private int turn;

        private BattleState gameState;

        public Battle(Hero hero, Monster monster)
        {
            this.hero = hero;
            this.monster = monster;

            this.turn = 0;

            this.gameState = BattleState.HeroAttack;
        }

        public BattleState Begin()
        {
            while(true)
            {
                switch (gameState)
                {
                    case BattleState.RunAway:
                        MonsterRunsAway();
                        return BattleState.RunAway;
                    case BattleState.HeroAttack:
                        HeroAttack();
                        break;
                    case BattleState.MonsterAttack:
                        MonsterAttack();
                        break;
                    case BattleState.Win:
                        Win();
                        return BattleState.Win;
                    default:
                        Lose();
                        return BattleState.Lose;
                }
                Thread.Sleep(1000);
            }
        }

        private void HeroAttack()
        {
            (bool, string) attackResult = monster.TakeHit(hero.Hit());

            WriteLine($"{hero.name} attacks {monster.name}");
            WriteLine(attackResult.Item2);
            WriteLine();

            if (attackResult.Item1)
                gameState = BattleState.MonsterAttack;
            else
            {
                gameState = BattleState.Win;
            }

            turn++;

            if(turn >= 15)
            {
                gameState = BattleState.RunAway;
            }
        }

        private void MonsterAttack()
        {
            (bool, string) attackResult = hero.TakeHit(monster.Hit());

            WriteLine($"{monster.name} attacks {hero.name}");
            WriteLine(attackResult.Item2);
            WriteLine();

            if (attackResult.Item1)
                gameState = BattleState.HeroAttack;
            else
            {
                gameState = BattleState.Lose;
            }
            turn++;

            if (turn >= 15)
            {
                gameState = BattleState.RunAway;
            }
        }

        private void Win()
        {
            hero.gold += monster.goldValue;
            monster.TakeHeal(monster.maxHealth);
            WriteLine($"{hero.name} felled the {monster.monsterType}: {monster.name} gaining {monster.goldValue} gold!");
        }

        private void Lose()
        {
            monster.TakeHeal(monster.maxHealth);
            WriteLine($"{hero.name} was slain by the {monster.monsterType}: {monster.name}!");
        }

        private void MonsterRunsAway()
        {
            WriteLine($"{monster.monsterType}: {monster.name} ran away. You gained no gold :(");
        }
    }
}
