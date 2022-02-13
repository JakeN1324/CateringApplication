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
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayItems();
                        break;
                    case "2":
                        mainMenuDone = true;
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a valid selection");
                        break;


                }

            }

           

            while (!orderMenuDone)
            {

                OrderMenu();
                Console.WriteLine("Current Account Balance: " + catering.accountBalance);
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter the amount to add in a whole dollar amount: ");
                        AddToAccount();

                        break;
                    case "2":
                        DisplayItems();
                        SelectAProduct(); 
                        break;
                    case "3":
                        CompleteAPayment();
                        orderMenuDone = true;
                        
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a valid selection");
                        break;


                }
            }
            
        }
        private void MainMenu()
        {
            Console.WriteLine("(1) Display Menu Items");
            Console.WriteLine("(2) Order");
            Console.WriteLine("(3) Quit");
            Console.WriteLine();
        }

        private void OrderMenu()
        {
            Console.WriteLine("(1) Add Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Transaction");
        }
        private void DisplayItems() //todo Add try catch block
        {

            List<CateringItem> items = catering.GetItems();


            foreach (CateringItem item in items)
            {

                Console.WriteLine();
                Console.WriteLine($"{item.Code} {item.Name} {item.Quantity} {item.Price}");
                Console.WriteLine();
            }
        }

        private void AddToAccount() //todo Add try catch block
        {
            catering.AddMoney(decimal.Parse(Console.ReadLine()));
        }

        private void SelectAProduct()
        {
            Console.WriteLine("Select a product code");
            string codeChoice = Console.ReadLine();
            
            Console.WriteLine("Select the quantity of products");
            int quantityChoice = int.Parse(Console.ReadLine());

            catering.SelectProduct(codeChoice, quantityChoice);
        }

        private void CompleteAPayment() //todo Add try catch block
        {
            catering.CompleteTransaction();
            
            foreach (CateringItem item in catering.ShoppingCart)
            {
                Console.WriteLine($"{item.AmountInCart} {item.Type} {item.Name} {item.Price} {(item.Price * item.AmountInCart)}");
                if (item.Type == "Appetizer")
                {
                    Console.Write("You might need extra plates.");
                }
                else if (item.Type == "Beverage")
                {
                    Console.Write("Don't forget ice.");
                }
                else if (item.Type == "Dessert")
                {
                    Console.Write("Coffee goes with dessert.");
                }
                else
                {
                    Console.Write("Did you remember dessert?");
                }

                Console.WriteLine();
                Console.WriteLine();
            }

            
            Console.WriteLine($"Total: ${catering.TotalOrderCost}");
            Console.WriteLine();
            Console.Write("You received");
            foreach (KeyValuePair<string, int> kvp in catering.BillTypes)
            {
                if (kvp.Value > 0)
                {
                    Console.Write($" ({kvp.Value}) {kvp.Key},");
                }
            }
            Console.WriteLine(" in change");
            Console.WriteLine();

            


        }







    }
}

