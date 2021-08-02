using System;
using System.IO;

namespace BankApp.Server.Database
{
    public class LiteDbConfig
    {
        public string DatabasePath { get; set; }
        public string AdminCollection { get; set; }
        public string BankAccountCollection { get; set; }
        public string CustomerCollection { get; set; }
        public string TopUpCollection { get; set; }
        public string TransactionCollection { get; set; }
    }
}