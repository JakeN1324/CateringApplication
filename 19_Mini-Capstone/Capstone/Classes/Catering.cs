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


        public Catering()
        {

        }

        public List<CateringItem> GetItems()
        {
            items = data.GetCateringItems();
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
                Console.WriteLine("Invalid selection");
                
            }

            Console.WriteLine("Select the quantity of products");
            int quantityChoice = int.Parse(Console.ReadLine());

            if (selecteditem.Quantity < 1)
            {
                Console.WriteLine("Sold out");
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


    }
}
