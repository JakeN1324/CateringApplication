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
        
        
        public Catering()
        {
            
        }
        
        public List<CateringItem> GetItems()
        {
            items = data.GetCateringItems();
            return items;
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


}
}
