using Microsoft.Extensions.Options;
using BankApp.Shared.Data;

namespace BankApp.Server.Database
{
    public class LiteDbCustomerRepo : LiteDbBaseDeletableRepo<Customer>
    {
        protected IOptions<LiteDbConfig> configs_;
        LiteDbCustomerRepo(LiteDbContext liteDbContext, IOptions<LiteDbConfig> configs) : base(liteDbContext, configs.Value.CustomerCollection) { }

        public Customer GetByUserName(string name)
        {
            return liteDb_.GetCollection<Customer>(collection_).FindOne(x => x.Credentials.UserName == name);
        }
    }
}