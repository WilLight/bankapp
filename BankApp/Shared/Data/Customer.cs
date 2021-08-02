using System;
using System.Collections.Generic;

namespace BankApp.Shared.Data
{
    public class Customer : ICountable, IDeletable
    {
        public int Id { get; set; }
        public Credentials Credentials { get; set; }
        public string Name { get; set; }
        public List<int> BankAccountIds { get; set; }
        public bool Deleted { get; set; }
    }
}