namespace BankApp.Shared.Data
{
    public class TopUp : ITopUp
    {
        public int Id { get; set; }
        public int TargetAccount { get; set; }
        public double Amount { get; set; }
        public bool Applied { get; set; }
        public bool Deleted { get; set; }
    }
}