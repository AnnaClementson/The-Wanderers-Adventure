using System;
using System.Collections.Generic;
using System.Text;

namespace The_Wanderers_Adventure
{
    public class Encounters
    {
        static Random rand = new Random();
        //Encounter Generic 


        //Encounters

        //First Encounter
        public static void FirstEncounter()
        {
            Console.WriteLine("You push open the door");
            Console.ReadKey();
            Console.WriteLine("Grab a rusty metal sword and charge towards your capter");
            Console.ReadKey();
            Console.WriteLine("He turns...");
            Console.ReadKey();
            //Enemy stats
            Combat(false, "Human Rogue", 1, 4);
        }

        //Basic Fight Encounter
        public static void BasicFightEncounter()
        {
            Console.Clear();
            Console.WriteLine("You turn the corner and there you see another enemy...");
            Console.ReadKey();
            Combat(true, "", 0, 0);

        }

        //Wizard Encounter 

         public static void WizardEncounter()
        {
            Console.Clear();
            Console.WriteLine("The door slowly creaks open as you peer into the dark room");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You see a tall man with a long beard looking at a large tome");
            Console.ReadKey();
            Console.Clear();
            //Preset enemy type so it does not call random enemy
            Combat(false, "Dark Wizard", 4, 2);
        }


        //Encounter Tools

        public static void randomEncounter()
        {
            switch (rand.Next(0,1))
            {
                case 0:
                    BasicFightEncounter();
                    //add more encounters here
                    break;
            }
        }

        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;

            if(random)
            {
                //Enemies stats calling from the getPower/getHealth mod function
                n = GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();

            } else {
                n = name;
                p = power;
                h = health;
            }

            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n + " Stats: ");
                Console.WriteLine("Power: " + p + " / Health: " + h);
                Console.WriteLine("-------------------------");
                Console.WriteLine("|  (A)ttack   (D)efend  |");
                Console.WriteLine("|  (R)un      (H)eal    |");
                Console.WriteLine("-------------------------");
                //Show player stats
                Console.WriteLine( "Player's Stats: ");
                Console.WriteLine("Potions: " + Program.currentPlayer.potion + " Health: " +Program.currentPlayer.health );
                Console.WriteLine("What do you want to do?");
                string input = Console.ReadLine();
                input = input.ToUpper();

                if (input == "ATTACK" || input == "A")
                {
                    //Attack
                    Console.WriteLine("With haste you surge forward, your sword flying in your hands!");
                    Console.WriteLine("As you pass the " + n + " strikes you");
                    //Damage taken from opponent 
                    int damage = p - Program.currentPlayer.armorValue;
                    //Checking no negative damage is done
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    //Damage done to opponent
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4);
                    Console.WriteLine("You loose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input == "DEFEND" || input == "D")
                {
                    //Defend
                    Console.WriteLine("As the "+n+ " prepares to strike, you ready your sword to block his attack");
                    //Damage blocked  
                    int damage = (p/4) - Program.currentPlayer.armorValue;
                    //Checking to negative damage is given
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    //Damage done to opponent
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) /2;
                    Console.WriteLine("You loose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input == "RUN" || input == "R")
                {
                    //Run
                    if (rand.Next(0,2) == 0)
                    {
                        Console.WriteLine("As you sprint away from the " + n + " its strike catches you in the back");
                        Console.WriteLine("Sending you sprawling onto the ground");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine("You loose " +damage+ " health and are unable to escape");
                        Console.ReadKey();
                    } else
                    {
                        Console.WriteLine("You were super fast, you evade the " + n + " and you escape");
                        Console.ReadKey();
                        //Loading shop on running away
                        Shop.LoadShop(Program.currentPlayer);
                    }
                } else if (input == "HEAL" || input == "H")
                {
                    //Heal
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("You desperately grasp for a potion in your bag");
                        Console.WriteLine("All that you can find is empty potion bottles!");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine("The "+n+" strikes you with a mighty blow and you loose " +damage+ " health!");
                    } else  {
                        Console.WriteLine("You reach into your bag and pull out a glowing purple flask!");
                        Console.WriteLine("You take a long refreshing drink");
                        int potionValue = 5;
                        Console.WriteLine("You gain " +potionValue+ " health");
                        Program.currentPlayer.health += potionValue;
                        Console.WriteLine("But you were occupied, the " + n + " advanced and struck");
                        int damage = (p / 2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                            Console.WriteLine("You loose " + damage + " health");
                        }
                        
                        Console.ReadKey();
                    }
                    //Health check at the end of the encounter 
                    if (Program.currentPlayer.health <= 0)
                    {
                        //Death
                        Console.WriteLine("As the " + n + " stands tall and comes down to strike");
                        Console.WriteLine("You have been slayn by the mighty " + n);
                        Console.ReadKey();
                        Console.WriteLine("GAME OVER");
                        System.Environment.Exit(0);
                    }
                    
                    
                }
                Console.ReadKey();
            }
            //Reward of coins on defeat
            //Call get coins to call the function 
            int c = Program.currentPlayer.GetCoins();
            Console.WriteLine("As you stand victorious over the " + n + " its body dissolves into " + c + " of gold coins!");
            Program.currentPlayer.coins += c;
            Console.ReadKey();
        }

        public static string GetName()
        {
            switch (rand.Next(0, 4))
            {
                case 0:
                    return "Skeleton";
                case 1:
                    return "Zombie";
                case 2:
                    return "Human Cultist";
                case 3:
                    return "Grave Robber";
                default:
                    break;
            }
            //Default if no other name is trigged
            return "Human";
        }
    }
}
