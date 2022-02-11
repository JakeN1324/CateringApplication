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

        public int Quantity { get; private set; } = 25;
        public string Code { get; set; }

        

        // This class should contain the definition for one catering item

    }
}
