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
        decimal accountBalance = 0.00M;
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
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddMoney();
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



            void OrderMenu()
            {
                Console.WriteLine("(1) Add Money");
                Console.WriteLine("(2) Select Products");
                Console.WriteLine("(3) Compplete Transaction");
                Console.WriteLine("Current Account Balance: " + accountBalance);

            }

            decimal AddMoney()
            {

                
                Console.WriteLine("Enter the amount to add in a whole dollar amount: ");
                decimal moneyToAdd = decimal.Parse(Console.ReadLine());
                if (moneyToAdd == 1 || moneyToAdd == 5 || moneyToAdd == 10 || moneyToAdd == 20 || moneyToAdd == 50 || moneyToAdd == 100)
                {
                    accountBalance += moneyToAdd;
                    
                    if (accountBalance <= 1500)
                    {
                        return accountBalance;
                    }
                    else
                    {
                        accountBalance -= moneyToAdd;
                        Console.WriteLine("Balance cannot exceed $1500");
                    }

                }
                else
                {
                    
                    Console.WriteLine("Invalid Bill Amount");
                    
                }

                return accountBalance;

            }
        }
    }
}
