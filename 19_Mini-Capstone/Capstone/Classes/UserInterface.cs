using System;
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




            bool mainMenuDone = false;
            bool orderMenuDone = false;

            while (!mainMenuDone)
            {
                MainMenu();
                string Input = Console.ReadLine();

                switch (Input)
                {
                    case "1":
                        DisplayItems();
                        break;
                    case "2":
                        mainMenuDone = true;
                        break;

                }

            }

            while (!orderMenuDone)
            {

                OrderMenu();
                catering.OrderMenuBalance();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter the amount to add in a whole dollar amount: ");
                        catering.AddMoney(); //use user input as parameter

                        break;
                    case "2":
                        DisplayItems();
                        
                        Console.WriteLine("Select a product code");
                        catering.SelectProduct();
                        break;
                    case "3":
                        catering.CompleteTransaction();
                        orderMenuDone = true;
                        break;

                }
            }

            void MainMenu()
            {
                Console.WriteLine("(1) Display Menu Items");
                Console.WriteLine("(2) Order");
                Console.WriteLine("(3) Quit");
                Console.WriteLine();
            }

            void OrderMenu()
            {
                Console.WriteLine("(1) Add Money");
                Console.WriteLine("(2) Select Products");
                Console.WriteLine("(3) Complete Transaction");
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
