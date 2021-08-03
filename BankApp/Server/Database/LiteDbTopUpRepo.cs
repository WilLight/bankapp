using Microsoft.Extensions.Options;
using BankApp.Shared.Data;

namespace BankApp.Server.Database
{
    public abstract class LiteDbTopUpRepo<DataT> : LiteDbBaseDeletableRepo<DataT> where DataT : TopUp
    {
        protected LiteDbBankAccountRepo accountRepo_;
        protected IOptions<LiteDbConfig> configs_;
        public LiteDbTopUpRepo(LiteDbContext liteDbContext, LiteDbBankAccountRepo accountRepo, IOptions<LiteDbConfig> configs) : base(liteDbContext, configs.Value.TopUpCollection)
        {
            accountRepo_ = accountRepo;
            configs_ = configs;
        }

        public LiteDbTopUpRepo(LiteDbContext liteDbContext, string collection) : base(liteDbContext, collection) { }

        public virtual bool Apply(DataT dto)
        {
            if (dto.Applied == true)
                return false;
            var account = accountRepo_.GetOne(dto.TargetAccount);
            account.Balance += dto.Amount;
            dto.Applied = true;
            UpdateOne(dto);
            return accountRepo_.UpdateOne(account);

        }
    }
}