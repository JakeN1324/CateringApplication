using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class PurchaseLog
    {
        public void AddToLog(string logAction, decimal transactionAmount, decimal accountBalance)
        {


            string logDirectory = @"C:\Catering";
            string logFile = "Log.txt";
            string logFullPath = Path.Combine(logDirectory, logFile);

            using (StreamWriter sw = new StreamWriter(logFullPath, true))
            {
                sw.WriteLine($"{DateTime.Now} {logAction} ${transactionAmount} ${accountBalance}");
            }

        }
    }
}
