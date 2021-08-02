namespace BankApp.Shared.Data
{
    public interface ITopUp : ICountable, IDeletable
    {
        int TargetAccount { get; set; }
        double Amount { get; set; }
        bool Applied { get; set; }
    }
}