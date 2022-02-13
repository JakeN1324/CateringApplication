using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering
        public decimal accountBalance { get; set; } = 0.00M;
        public List<CateringItem> ShoppingCart { get; set; } = new List<CateringItem>();
        public decimal TotalOrderCost { get; set; }
        public Dictionary<string, int> BillTypes { get; set; } = new Dictionary<string, int>();
        public List<CateringItem> items { get; set; } = new List<CateringItem>();
        private FileAccess data = new FileAccess();
        CateringItem selecteditem = new CateringItem();
        PurchaseLog purchaseLog = new PurchaseLog();

        public Catering()
        {
            items = data.GetCateringItems();
            
        }

        

        

        

        public decimal AddMoney(decimal moneyToAdd)
        {
            accountBalance += moneyToAdd;
            purchaseLog.AddToLog("ADD MONEY: ", moneyToAdd, accountBalance);
            return accountBalance;          
        }

        public List<CateringItem> SelectProduct(string codeChoice, int quantityChoice)
        {

            CateringItem selecteditem = new CateringItem();


            



            foreach (CateringItem item in items)
            {
                if (codeChoice == item.Code)
                {
                    
                    selecteditem = item;
                    
                }
                
            }

            

            
            

            

            if (selecteditem.Price * quantityChoice <= accountBalance)
            {
                selecteditem.AmountInCart = quantityChoice;
                ShoppingCart.Add(selecteditem);
                accountBalance -= selecteditem.Price * quantityChoice;
                purchaseLog.AddToLog($"{quantityChoice} {selecteditem.Name} {selecteditem.Code}", selecteditem.Price * quantityChoice, accountBalance);
                foreach (CateringItem item in items)
                {
                    if (selecteditem.Name == item.Name)
                    {
                        item.Quantity -= quantityChoice;
                        //if (item.Quantity == 0)
                        //{
                        //    item.Quantity.ToString("Sold Out");
                        //    return items;
                        //}


                    }

                }

            }


            return ShoppingCart;


        }

        public void CompleteTransaction()
        {
            TotalOrderCost = 0.00M;
            foreach (CateringItem item in ShoppingCart)
            {               
                TotalOrderCost += (item.Price * item.AmountInCart);
            }

            
            decimal changedue = accountBalance;


            
            BillTypes["Fifties"] = 0;
            BillTypes["Twenties"] = 0;
            BillTypes["Tens"] = 0;
            BillTypes["Fives"] = 0;
            BillTypes["Ones"] = 0;
            BillTypes["Quarters"] = 0;
            BillTypes["Dimes"] = 0;
            BillTypes["Nickels"] = 0;

            while (accountBalance > 0.00M)
            {
                if (accountBalance - 50 >= 0)
                {
                    BillTypes["Fifties"] += 1;
                    accountBalance -= 50;
                    continue;
                }
                else if (accountBalance - 20 >= 0)
                {
                    BillTypes["Twenties"] += 1;
                    accountBalance -= 20;
                    continue;
                }
                else if (accountBalance - 10 >= 0)
                {
                    BillTypes["Tens"] += 1;
                    accountBalance -= 10;
                    continue;
                }
                else if (accountBalance - 5 >= 0)
                {
                    BillTypes["Fives"] += 1;
                    accountBalance -= 5;
                    continue;
                }
                else if (accountBalance - 1 >= 0)
                {
                    BillTypes["Ones"] += 1;
                    accountBalance -= 1;
                    continue;
                }
                else if (accountBalance - 0.25M >= 0)
                {
                    BillTypes["Quarters"] += 1;
                    accountBalance -= 0.25M;
                    continue;
                }
                else if (accountBalance - 0.10M >= 0)
                {
                    BillTypes["Dimes"] += 1;
                    accountBalance -= 0.10M;
                    continue;
                }
                else if (accountBalance - 0.05M >= 0)
                {
                    BillTypes["Nickels"] += 1;
                    accountBalance -= 0.05M;
                    continue;
                }
               
            }
            purchaseLog.AddToLog("GIVE CHANGE:", changedue, accountBalance);
            

        }


}
}
