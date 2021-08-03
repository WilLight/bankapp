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
            var sourceAccount = accountRepo_.GetOne(dto.SourceAccount);
            if (sourceAccount.Balance < dto.Amount)
                return false;
            sourceAccount.Balance -= dto.Amount;
            var targetAccount = accountRepo_.GetOne(dto.TargetAccount);
            targetAccount.Balance += dto.Amount;
            dto.Applied = true;
            UpdateOne(dto);
            accountRepo_.UpdateOne(sourceAccount);
            accountRepo_.UpdateOne(targetAccount);
            return true;
        }
    }
}