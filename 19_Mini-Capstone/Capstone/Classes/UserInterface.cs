﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        // This class provides all user communications, but not much else.
        // All the "work" of the application should be done elsewhere

        // ALL instances of Console.ReadLine and Console.WriteLine should 
        // be in this class.
        // NO instances of Console.ReadLine or Console.WriteLIne should be
        // in any other class.

        private Catering catering = new Catering();

        public void RunInterface()
        {
             void MainMenu()
            {
                Console.WriteLine("(1) Display Menu Items");
                Console.WriteLine("(2) Order");
                Console.WriteLine( "(3) Quit");
                Console.WriteLine();
            }

            

            bool done = false;
            while (!done)
            {
                MainMenu();
                string Input = Console.ReadLine();

                switch(Input)
                {
                    case "1":
                        DisplayItems();
                        break;


                }
                
            }

            void DisplayItems()
            {
                List<CateringItem> items = catering.GetItems();
              
                
                foreach (CateringItem item in items)
                {

                    Console.WriteLine();
                    Console.WriteLine($"{item.Code} {item.Name} {item.Quantity} {item.Price}");
                    Console.WriteLine();
                }
            }

        }
    }
}