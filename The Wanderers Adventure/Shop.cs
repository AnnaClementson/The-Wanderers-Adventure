using System;
using System.Collections.Generic;
using System.Text;

namespace The_Wanderers_Adventure
{
    public class Shop
    {
        static int armorMod;
        static int weaponMod;
        static int difficultyMod;
        public static void LoadShop(Player p)
        {
            RunShop(p);
        }

        public static void RunShop(Player p)
        {
            int potionPrice;
            int armorPrice;
            int weaponPrice;
            int difficultyPrice;

            while(true)
            {
                potionPrice = 20 + 10 * p.mods;
                armorPrice = 100 * (p.armorValue + 1);
                weaponPrice = 100 * p.weaponValue;
                difficultyPrice = 100 + p.mods;

                Console.Clear();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("|              Shop                  |");
                Console.WriteLine("| (P)otion: " + potionPrice + "      |");
                Console.WriteLine("| (W)eapon: " + weaponPrice + "      |");
                Console.WriteLine("| (A)rmor: " +armorPrice + "         |");
                Console.WriteLine("| (D)ifficulty: " +difficultyPrice+" |");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("(E)xit");
                Console.WriteLine();
                Console.WriteLine();
                //Player stats update
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("|"+ Program.currentPlayer.name + "'s Stat    |");
                Console.WriteLine("|  Health:             " +p.health +"|");
                Console.WriteLine("|  Coin:              " + p.coins + "|");
                Console.WriteLine("| (P)otion: " + p.potion + "         |");
                Console.WriteLine("| (W)eapon: " +p.weaponValue + "     |");
                Console.WriteLine("| (A)rmor: " + p.armorValue + "      |");
                Console.WriteLine("| (D)ifficulty: " + p.mods  + "      |");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("What would you like to buy? Enter the prompt key now: ");
                //User input
                string input = Console.ReadLine().ToUpper();
                    
                    //Check for player input and pass in item price and player information
                    if(input == "P" || input == "POTION")
                    {
                        TryBuy("POTION", potionPrice, p);
                    } 
                    else if (input == "W" || input == "WEAPON")
                    {
                        TryBuy("WEAPON", weaponPrice, p);
                    } 
                    else if (input == "A" || input == "ARMOR")
                    {
                        TryBuy("ARMOR", armorPrice, p);
                    }
                    else if (input == "D" || input == "DIFFICULTY")
                    {
                        TryBuy("DIFFICULTY", difficultyPrice, p);
                    } 
                    else if (input == "E" || input == "EXIT")
                    {
                    break;  
                    }
            }
           
        }

        static void TryBuy(string item, int cost, Player p)
        {
            //Purchase function adding the item to players stats 
            if (p.coins >= cost)
            {
                    if(item == "POTION")
                    {
                        p.potion++;
                    } else if (item == "WEAPON")
                    {
                        p.weaponValue++;
                    } else if (item == "ARMOR")
                    {
                        p.armorValue++;
                    } else if (item == "DIFFICULTY")
                    {
                        p.mods++;
                    }

                p.coins -= cost;

            } else
            {
                Console.WriteLine( p.name + "you do not have enough for this purchase");
                Console.ReadKey();
            }
        }
    }
}
