using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering
       public decimal accountBalance = 0.00M;
        private List<CateringItem> items = new List<CateringItem>();
        private FileAccess data = new FileAccess();
        List<CateringItem> shoppingCart = new List<CateringItem>();
        CateringItem selecteditem = new CateringItem();
        //populate items with data.GetCateringItems
        PurchaseLog purchaseLog = new PurchaseLog();

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

        public decimal AddMoney()
        {
            decimal moneyToAdd = decimal.Parse(Console.ReadLine());
            if (moneyToAdd == 1 || moneyToAdd == 5 || moneyToAdd == 10 || moneyToAdd == 20 || moneyToAdd == 50 || moneyToAdd == 100)
            {
                

                if (accountBalance + moneyToAdd <= 1500)
                {
                    accountBalance += moneyToAdd;
                    purchaseLog.AddToLog("ADD MONEY: ", moneyToAdd, accountBalance);
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

            CateringItem selecteditem = new CateringItem();


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
                purchaseLog.AddToLog($"{quantityChoice} {selecteditem.Name} {selecteditem.Code}", selecteditem.Price * quantityChoice, accountBalance);
                
            }


            return shoppingCart;


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
            decimal changedue = accountBalance;


            Dictionary<string, int> billTypes = new Dictionary<string, int>();
            billTypes["Fifties"] = 0;
            billTypes["Twenties"] = 0;
            billTypes["Tens"] = 0;
            billTypes["Fives"] = 0;
            billTypes["Ones"] = 0;
            billTypes["Quarters"] = 0;
            billTypes["Dimes"] = 0;
            billTypes["Nickels"] = 0;

            while (accountBalance > 0.00M)
            {
                if (accountBalance - 50 >= 0)
                {
                    billTypes["Fifties"] += 1;
                    accountBalance -= 50;
                    continue;
                }
                else if (accountBalance - 20 >= 0)
                {
                    billTypes["Twenties"] += 1;
                    accountBalance -= 20;
                    continue;
                }
                else if (accountBalance - 10 >= 0)
                {
                    billTypes["Tens"] += 1;
                    accountBalance -= 10;
                    continue;
                }
                else if (accountBalance - 5 >= 0)
                {
                    billTypes["Fives"] += 1;
                    accountBalance -= 5;
                    continue;
                }
                else if (accountBalance - 1 >= 0)
                {
                    billTypes["Ones"] += 1;
                    accountBalance -= 1;
                    continue;
                }
                else if (accountBalance - 0.25M >= 0)
                {
                    billTypes["Quarters"] += 1;
                    accountBalance -= 0.25M;
                    continue;
                }
                else if (accountBalance - 0.10M >= 0)
                {
                    billTypes["Dimes"] += 1;
                    accountBalance -= 0.10M;
                    continue;
                }
                else if (accountBalance - 0.05M >= 0)
                {
                    billTypes["Nickels"] += 1;
                    accountBalance -= 0.05M;
                    continue;
                }
               
            }
            purchaseLog.AddToLog("GIVE CHANGE:", changedue, accountBalance);
            Console.Write("You received");
            foreach (KeyValuePair<string, int> kvp in billTypes)
            {
                if (kvp.Value > 0)
                {
                    Console.Write($" ({kvp.Value}) {kvp.Key},");
                }
            }
            Console.WriteLine(" in change");

        }


}
}
