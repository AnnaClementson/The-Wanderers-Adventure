using System;
using System.Collections.Generic;
using System.Text;

namespace The_Wanderers_Adventure
{
    public class Player
    {
        //Calling random class
        Random rand = new Random();

        //Inital stats
        public string name;
        public int coins = 30000;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int potion = 5;
        public int weaponValue = 1;

        //Difficulty modifications

        public int mods = 0;

        //Get Stat Function to return random mod stats
        public int GetHealth()
        {
            int upper = (2 * mods + 5);
            int lower = (mods + 2);
            return rand.Next(lower,upper);
        }

        public int GetPower()
        {
            int upper = (2 * mods + 2);
            int lower = (mods + 1);
            return rand.Next(lower, upper);
        }

        public int GetCoins()
        {
            int upper = (15 * mods + 50);
            int lower = (10 * mods + 10);
            return rand.Next(lower, upper);
        }
    }
}
