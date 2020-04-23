using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace The_Wanderers_Adventure
{
    public class Program
    {
        //Setting player class to name entered
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;

   
        static void Main(string[] args)
        {
            Start();
            Encounters.FirstEncounter();
            while(mainLoop)
            {
                Encounters.randomEncounter();
            }

        }

        //New Charecter start
        static void Start()
        {
            Player p = new Player();
            Console.WriteLine("The Wanderer's Adventure");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("What is your name: ");
            p.name = Console.ReadLine();
            //Set player id on player create

            Console.Clear();
            Console.WriteLine("You awake in a cold, stone, dark room.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You feel dazed and are having trouble remembering anything about your past.");
            Console.ReadKey();
            Console.Clear();

            if (p.name == "")
            {
                Console.WriteLine("You cant remember your own name...");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("You think long and hard and it comes back to you. Start again...");
            }
             else
            {
                Console.WriteLine("One thing you can remember, you know your name is " + p.name);
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("You cannot see or hear anything");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("You dont know where you are, or how you got here");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("You stand up in the darkness");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Panicking you start to move forward and you come to a wall");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("You feel around the wall and come to a door");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Reaching down for the door handle, you turn it, but the door handle is stuck");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("You turn it harder but there is some resistance");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("The rusty lock and handle breaks away in your hand");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("You hear a noise");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("The door has creaked open");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("You see your captor standing infront of you with his back facing the door");
                Console.ReadKey();
                Console.Clear();
            }
  
        }
    }
}
