using Microsoft.Extensions.Options;
using BankApp.Shared.Data;

namespace BankApp.Server.Database
{
    public class LiteDbAdminRepo : LiteDbBaseRepo<Admin>
    {
        public LiteDbAdminRepo(LiteDbContext liteDbContext, IOptions<LiteDbConfig> configs) : base(liteDbContext, configs.Value.AdminCollection) { }
    }
}