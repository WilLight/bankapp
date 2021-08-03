using Microsoft.Extensions.Options;
using BankApp.Shared.Data;

namespace BankApp.Server.Database
{
    public class LiteDbBankAccountRepo : LiteDbBaseDeletableRepo<BankAccount>
    {
        LiteDbBankAccountRepo(LiteDbContext liteDbContext, IOptions<LiteDbConfig> configs) : base(liteDbContext, configs.Value.BankAccountCollection) { }

        public BankAccount GetOneByNumber(int number)
        {
            return liteDb_.GetCollection<BankAccount>(collection_).FindOne(x => x.Number == number);
        }
    }
}