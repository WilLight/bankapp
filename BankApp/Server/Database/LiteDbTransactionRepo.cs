using Microsoft.Extensions.Options;
using BankApp.Shared.Data;

namespace BankApp.Server.Database
{
    public class LiteDbTransactionRepo : LiteDbTopUpRepo<Transaction>
    {
        LiteDbTransactionRepo(LiteDbContext liteDbContext, IOptions<LiteDbConfig> configs) : base(liteDbContext, configs.Value.TransactionCollection)
        {
            configs_ = configs;
        }

        public override bool Apply(Transaction dto)
        {
            if (dto.Applied == true)
                return false;
            var sourceAccount = GetAccount(dto.SourceAccount);
            if (sourceAccount.Balance < dto.Amount)
                return false;
            sourceAccount.Balance -= dto.Amount;
            var targetAccount = GetAccount(dto.TargetAccount);
            targetAccount.Balance += dto.Amount;
            dto.Applied = true;
            UpdateOne(dto);
            UpdateAccount(sourceAccount);
            UpdateAccount(targetAccount);
            return true;
        }
    }
}