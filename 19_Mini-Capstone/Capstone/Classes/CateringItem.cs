using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class CateringItem  
    {
        public CateringItem (string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public CateringItem() 
        {

        }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get;  set; } = 25;
        public string Code { get; set; }
        public string Type { get; set; }
        public int AmountInCart { get; set; } = 0;
    }
}
