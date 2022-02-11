﻿using System;
using System.Collections.Generic;
using System.IO;

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
            //List<string> sortedItems = new List<string>();

            //using (StreamReader sr = new StreamReader(filePath))
            //{
            //    while (!sr.EndOfStream)
            //    {
            //        string line = sr.ReadLine();
            //        string[] split = line.Split('|');
            //        CateringItem item = new CateringItem();
            //        item.Code = split[1];
            //        sortedItems.Add(item.Code);
            //    }
                
            //}
            
            //foreach(CateringItem item in cateringItems)
            //{
                
            //}

            //foreach(string code in sortedItems)
            //{
            //    using (StreamReader sr = new StreamReader(filePath))
            //    {
            //        while (!sr.EndOfStream)
            //        {
            //            string line = sr.ReadLine();
            //            string[] split = line.Split('|');
            //            CateringItem item = new CateringItem();
            //            if (line.Contains(code))
            //            {
                            
            //            }
            //        }
            //    }
            //}

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] split = line.Split('|');
                    CateringItem item = new CateringItem();
                    item.Code = split[1];
                    item.Name = split[2];
                    item.Price = Decimal.Parse(split[3]);

                    cateringItems.Add(item);

                }
            }
            return cateringItems;
        }


        // This class should contain any and all details of access to files
    }
}
