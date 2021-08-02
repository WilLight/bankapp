using System;
using Microsoft.Extensions.Options;
using LiteDB;

namespace BankApp.Server.Database
{
    public class LiteDbContext
    {
        public readonly LiteDatabase Context;
        public LiteDbContext(IOptions<LiteDbConfig> configs)
        {
            try
            {
                var db = new LiteDatabase(configs.Value.DatabasePath);
                if (db != null)
                    Context = db;
            }
            catch (Exception ex)
            {
                throw new Exception("Can find or create LiteDb database.", ex);
            }
        }
    }
}