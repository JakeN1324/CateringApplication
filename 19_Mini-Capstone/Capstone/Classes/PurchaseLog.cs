using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class PurchaseLog
    {
        public string logDirectory = @"C:\Catering";
        public string logFile = "Log.txt";
        string logFullPath = Path.Combine(logDirectory, logFile);

    }
}
