using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering

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
   
    }
}
