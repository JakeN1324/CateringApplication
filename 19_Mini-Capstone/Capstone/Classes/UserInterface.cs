using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {        
        private Catering catering = new Catering();
        string productCodesDisplay = "Product Codes";
        string descriptionDisplay = "Description";
        string quantityDisplay = "Qty";
        string priceDisplay = "Price";
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
        private void DisplayItems() 
        {           
            try
            {
                Console.WriteLine(productCodesDisplay + descriptionDisplay.PadLeft(18) + quantityDisplay.PadLeft(16) + priceDisplay.PadLeft(12));
                foreach (CateringItem item in catering.items)
                {
                    Console.WriteLine();
                    if (item.Quantity == 0)
                    {
                        Console.WriteLine($"{item.Code} {item.Name.PadLeft((item.Name.Length + 17))}         SOLD OUT {item.Price.ToString().PadLeft(12)}");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Code} {item.Name.PadLeft((item.Name.Length + 17))} {item.Quantity.ToString().PadLeft(25 - item.Name.Length)} {item.Price.ToString().PadLeft(12)}");
                    }                    
                    
                    Console.WriteLine();
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
                return;
            }
        }

        private void AddToAccount() 
        {
            decimal moneyToAdd = decimal.Parse(Console.ReadLine());

            if (moneyToAdd != 1 && moneyToAdd != 5 && moneyToAdd != 10 && moneyToAdd != 20 && moneyToAdd != 50 && moneyToAdd != 100)
            {
                Console.WriteLine("Invalid Bill Amount");
                return;
            }
            
            if (catering.accountBalance + moneyToAdd > 1500)
            {
                Console.WriteLine("Balance cannot exceed $1500");
                return;
            }
            
            try
            {
                catering.AddMoney(moneyToAdd);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error adding to balance: " + ex.Message);
                return;
            }
        }

        private void SelectAProduct()
        {
            Console.WriteLine("Select a product code");
            string codeChoice = Console.ReadLine();
            
            bool validChoice = false;
            CateringItem itemChoice = new CateringItem();
            foreach (CateringItem item in catering.items)
            {
                if (codeChoice == item.Code)
                {
                    validChoice = true;
                    itemChoice = item;
                }

            }

            if (validChoice == false)
            {
                Console.WriteLine("Invalid item selection");
                return;
            }

            Console.WriteLine("Select the quantity of products");
            int quantityChoice = int.Parse(Console.ReadLine());

            if (itemChoice.Quantity < 1)
            {
                Console.WriteLine("Item is sold out");
                return;
            }
            else if (quantityChoice > itemChoice.Quantity)
            {
                Console.WriteLine("Insufficient stock");
                return;
            }
            else if (itemChoice.Price * quantityChoice > catering.accountBalance)
            {
                Console.WriteLine("Insufficient funds");
                return;
            }

            try
            {
                catering.SelectProduct(codeChoice, quantityChoice);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error selecting product: " + ex.Message);
                return;
            }
        }

        private void CompleteAPayment() //todo Add try catch block
        {
            try
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
            catch (IOException ex)
            {
                Console.WriteLine("Error completing purchase: " + ex.Message);
                return;
            }
        }
    }
}

