using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Capstone.Classes
{
    public class FileAccess
    {
        // all files for this application should in this directory
        // you will likley need to create it on your computer
        public string filePath = @"C:\Catering\cateringsystem.csv";

        public List<CateringItem> GetCateringItems()
        {
            List<CateringItem> cateringItems = new List<CateringItem>();         

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] split = line.Split('|');
                    CateringItem item = new CateringItem();
                    item.Type = split[0];
                    if (item.Type == "A")
                    {
                        item.Type = "Appetizer";
                    }
                    else if (item.Type == "B")
                    {
                        item.Type = "Beverage";
                    }
                    else if (item.Type == "D")
                    {
                        item.Type = "Dessert";
                    }
                    else
                    {
                        item.Type = "Entree";
                    }
                    item.Code = split[1];
                    item.Name = split[2];
                    item.Price = Decimal.Parse(split[3]);

                    cateringItems.Add(item);

                }
            }
            

            List<CateringItem> sortedList = cateringItems.OrderBy(cateringItems => cateringItems.Code).ToList();
            return sortedList;


            

        }


        // This class should contain any and all details of access to files
    }
}
