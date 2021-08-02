using Microsoft.Extensions.Options;
using BankApp.Shared.Data;

namespace BankApp.Server.Database
{
    public abstract class LiteDbTopUpRepo<DataT> : LiteDbBaseDeletableRepo<DataT> where DataT : TopUp
    {
        protected IOptions<LiteDbConfig> configs_;
        public LiteDbTopUpRepo(LiteDbContext liteDbContext, IOptions<LiteDbConfig> configs) : base(liteDbContext, configs.Value.TopUpCollection)
        {
            configs_ = configs;
        }

        public LiteDbTopUpRepo(LiteDbContext liteDbContext, string collection) : base(liteDbContext, collection) { }

        protected BankAccount GetAccount(int dtoId)
        {
            var account = liteDb_.GetCollection<BankAccount>(configs_.Value.BankAccountCollection).FindById(dtoId);
            if (account != null)
                return account;
            else
                return null;
        }

        protected bool UpdateAccount(BankAccount dto)
        {
            return liteDb_.GetCollection<BankAccount>(configs_.Value.BankAccountCollection).Update(dto);
        }

        public virtual bool Apply(DataT dto)
        {
            if (dto.Applied == true)
                return false;
            var account = GetAccount(dto.TargetAccount);
            account.Balance += dto.Amount;
            dto.Applied = true;
            UpdateOne(dto);
            return UpdateAccount(account);

        }
    }
}