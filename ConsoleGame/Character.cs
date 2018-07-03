using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Character
    {



        public string Name { get; set; }
        public int Level { get; set; }
        public int Luck { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }



        public Character(string name)
        {
            Name = name;
            Level = 10;
            Luck = 5;
            MaxHealth = 100;
            CurrentHealth = 100;
        }



        public int Attack(Character defender)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            double attackMultiplier = rnd.NextDouble() + 1;
            double damage = Level * attackMultiplier;
            int critChance = rnd.Next(101);

            if (Luck > critChance)
            {
                damage *= 2;
                Console.WriteLine("Critical Hit!");
            }

            int finalDam = (int)Math.Round(damage);
            defender.CurrentHealth -= finalDam;

            return finalDam;
        }

 

        public bool IsAlive()
        {
            if (CurrentHealth > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public void Rest()
        {
            CurrentHealth = MaxHealth;
        }



        public void Defeat(Character defender)
        {
            double dExp = defender.Level / 10;
            int experience = (int)Math.Round(dExp);
            Level += experience;
            Luck++;
            Console.WriteLine($"You have gained {experience} experience, placing you at level {Level}");
        }

        

    }
}
