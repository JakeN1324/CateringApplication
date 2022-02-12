using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering
        decimal accountBalance = 0.00M;
        private List<CateringItem> items = new List<CateringItem>();
        private FileAccess data = new FileAccess();
        List<CateringItem> shoppingCart = new List<CateringItem>();
        CateringItem selecteditem = new CateringItem();
        //populate items with data.GetCateringItems

        public Catering()
        {
            
        }

        

        public List<CateringItem> GetItems()
        {

            items = data.GetCateringItems();
            foreach (CateringItem item in items)
            {
                if (selecteditem.Name == item.Name)
                {
                    item.Quantity -= selecteditem.AmountInCart;

                }

            }
            return items;
        }

        public void OrderMenuBalance()
        {
            Console.WriteLine("Current Account Balance: " + accountBalance);

        }

        public decimal AddMoney() //take moneyToAdd as parameter
        {
            decimal moneyToAdd = decimal.Parse(Console.ReadLine());
            if (moneyToAdd == 1 || moneyToAdd == 5 || moneyToAdd == 10 || moneyToAdd == 20 || moneyToAdd == 50 || moneyToAdd == 100)
            {
                

                if (accountBalance + moneyToAdd <= 1500)
                {
                    accountBalance += moneyToAdd;
                    return accountBalance;
                }
                else
                {
                    
                    Console.WriteLine("Balance cannot exceed $1500");
                }

            }
            else
            {

                Console.WriteLine("Invalid Bill Amount");

            }


            return accountBalance;



        }

        public List<CateringItem> SelectProduct()
        {

            


            string codeChoice = Console.ReadLine();
           

            bool validChoice = false;
            foreach (CateringItem item in items)
            {
                if (codeChoice == item.Code)
                {
                    validChoice = true;
                    selecteditem = item;
                    
                }
                
            }

            if (validChoice == false)
            {
                Console.WriteLine("Invalid item selection");
                
            }

            Console.WriteLine("Select the quantity of products");
            int quantityChoice = int.Parse(Console.ReadLine());
            

            if (selecteditem.Quantity < 1)
            {
                Console.WriteLine("Item is sold out");
            }
            else if (quantityChoice > selecteditem.Quantity)
            {
                Console.WriteLine("Insufficient stock");
            }

            if (selecteditem.Price * quantityChoice <= accountBalance)
            {
                selecteditem.AmountInCart = quantityChoice;
                shoppingCart.Add(selecteditem);
                accountBalance -= selecteditem.Price * quantityChoice;
                
                
            }

            
            
            return shoppingCart;


        }

        public List<CateringItem> UpdateList()
        {
            foreach (CateringItem item in items)
            {
                if (selecteditem.Name == item.Name)
                {
                    item.Quantity -= selecteditem.Quantity;
                    
                }
                
            }
            return items;
        }

        public void CompleteTransaction()
        {
            decimal totalOrderCost = 0.00M;
            foreach (CateringItem item in shoppingCart)
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

                totalOrderCost += (item.Price * item.AmountInCart);
            }

            Console.WriteLine($"Total: ${totalOrderCost}");

            decimal changeDue = accountBalance;

            Dictionary<string, int> billTypes = new Dictionary<string, int>();
            billTypes["Fifties"] = 0;
            billTypes["Twenties"] = 0;
            billTypes["Tens"] = 0;
            billTypes["Fives"] = 0;
            billTypes["Ones"] = 0;
            billTypes["Quarters"] = 0;
            billTypes["Dimes"] = 0;
            billTypes["Nickels"] = 0;

            while (changeDue > 0.00M)
            {
                if (changeDue - 50 >= 0)
                {
                    billTypes["Fifties"] += 1;
                    changeDue -= 50;
                    continue;
                }
                else if (changeDue - 20 >= 0)
                {
                    billTypes["Twenties"] += 1;
                    changeDue -= 20;
                    continue;
                }
                else if (changeDue - 10 >= 0)
                {
                    billTypes["Tens"] += 1;
                    changeDue -= 10;
                    continue;
                }
                else if (changeDue - 5 >= 0)
                {
                    billTypes["Fives"] += 1;
                    changeDue -= 5;
                    continue;
                }
                else if (changeDue - 1 >= 0)
                {
                    billTypes["Ones"] += 1;
                    changeDue -= 1;
                    continue;
                }
                else if (changeDue - 0.25M >= 0)
                {
                    billTypes["Quarters"] += 1;
                    changeDue -= 0.25M;
                    continue;
                }
                else if (changeDue - 0.10M >= 0)
                {
                    billTypes["Dimes"] += 1;
                    changeDue -= 0.10M;
                    continue;
                }
                else if (changeDue - 0.05M >= 0)
                {
                    billTypes["Nickels"] += 1;
                    changeDue -= 0.05M;
                    continue;
                }
            }

            Console.WriteLine("You received");
            foreach (KeyValuePair<string, int> kvp in billTypes)
            {
                if (kvp.Value > 0)
                {
                    Console.Write($" ({kvp.Value}) {kvp.Key},");
                }
            }
            Console.Write(" in change");

        }


    }
}
