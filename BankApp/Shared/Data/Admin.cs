namespace BankApp.Shared.Data
{
    public class Admin : ICountable
    {
        public int Id { get; set; }
        public Credentials Credentials { get; set; }
    }
}