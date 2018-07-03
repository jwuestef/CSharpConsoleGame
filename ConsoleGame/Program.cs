using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create the player character
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.Clear();

            Character player = new Character(name);

            // Determine if the player is experienced, tough, or lucky
            bool stayMenuLoop = true;
            Console.WriteLine($"{name}, eh? Tell me, {name}, are you experienced, tough, or lucky?");
            do
            {
                Console.WriteLine(" 1: Experienced \n 2. Tough \n 3. Lucky");
                string entry = Console.ReadLine();

                switch (entry)
                {
                    case "1":
                        player.Level += 5;
                        stayMenuLoop = false;
                        break;
                    case "2":
                        player.MaxHealth += 25;
                        stayMenuLoop = false;
                        break;
                    case "3":
                        player.Luck += 10;
                        stayMenuLoop = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("I didn't catch that, can you repeat yourself? Are you...");
                        break;
                }

            } while (stayMenuLoop);

            // Create the giantRat character
            Character giantRat = new Character("Giant Rat");
            Console.WriteLine("A giant rat appears!");
            Console.WriteLine(". . . Press Enter to continue . . .");
            Console.ReadLine();

            bool stayBattleLoop = true;
            do
            {

                // Player moves first, handle the player's action
                stayMenuLoop = true;
                Console.Clear();
                do
                {
                    Console.WriteLine($"You have {player.CurrentHealth} HP remaining.");
                    // If the rat has max health
                    if (giantRat.CurrentHealth == giantRat.MaxHealth)
                    {
                        Console.WriteLine("The giant rat is uninjured.");
                    }
                    // If the rat has less than 1/3 of it's life remaining
                    else if (Math.Round((double)giantRat.MaxHealth / giantRat.CurrentHealth) >= 3)
                    {
                        Console.WriteLine("The rat is on death's doorstep.");
                    }
                    // If the rat has less than 1/2 of it's life remaining
                    else if (Math.Round((double)giantRat.MaxHealth / giantRat.CurrentHealth) >= 2)
                    {
                        Console.WriteLine("The rat is bloodied and wheezing");
                    }
                    // If the rat has less than full health
                    else if (Math.Round((double)giantRat.MaxHealth / giantRat.CurrentHealth) >= 1)
                    {
                        Console.WriteLine("The rat has taken a few wounds");
                    }
                    // If the rat has somehow gotten more health than the max
                    else
                    {
                        Console.WriteLine("The rat has somehow gained health in excess of it's max?!?? What arcane magic is this??");
                        Console.WriteLine(Math.Round((double)giantRat.MaxHealth / giantRat.CurrentHealth));
                    }
                    Console.WriteLine($"The rat has {giantRat.CurrentHealth} HP remaining.");

                    Console.WriteLine("\n What would you like to do? \n 1: Attack \n 2. Run Away \n");
                    string entry = Console.ReadLine();
                    switch (entry)
                    {
                        case "1":
                            // Player has chosen to attack the giant rat
                            Console.WriteLine();
                            Console.WriteLine($"You attack {giantRat.Name} for {player.Attack(giantRat)} damage!");

                            if (!giantRat.IsAlive())
                            {
                                // Player has killed the rat
                                player.Defeat(giantRat);
                                stayBattleLoop = false;
                            }

                            stayMenuLoop = false;
                            break;
                        case "2":
                            // Player has chosen to run away
                            stayMenuLoop = false;
                            stayBattleLoop = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Please choose to fight or run.");
                            break;
                    }

                } while (stayMenuLoop);

                // The player has completed his/her action, now it is the giant rat's turn!
                // If the player hasn't run away...
                if (stayBattleLoop)
                {
                    Console.WriteLine($"The rat attacks you for {giantRat.Attack(player)} damage!");
                    Console.WriteLine(". . . Press Enter to continue . . .");
                    Console.ReadLine();
                }

                // After the rat's turn, check if the player is still alive
                if (!player.IsAlive())
                    stayBattleLoop = false;


            } while (stayBattleLoop);

            // The battle has ended, 

            if (!player.IsAlive())
            {
                // Player died
                Console.WriteLine("You have been killed, the battle is over.");
            }
            else if (giantRat.IsAlive())
            {
                // The giant rat is alive - the player must have run away
                Console.WriteLine("You have run away, the battle is over.");
            }
            else
            {
                // The playuer killed the rat
                Console.WriteLine("You have killed the rat, the battle is over.");
            }
            //Console.ReadLine();

        }
    }
}
