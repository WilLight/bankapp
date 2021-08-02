using BankApp.Shared.Data;

namespace BankApp.Server.Database
{
    public abstract class LiteDbBaseDeletableRepo<DataT> : LiteDbBaseRepo<DataT> where DataT : ICountable, IDeletable
    {
        public LiteDbBaseDeletableRepo(LiteDbContext liteDbContext, string collection) : base(liteDbContext, collection) { }

        public override bool Delete(int dtoId)
        {
            var dto = GetOne(dtoId);
            dto.Deleted = true;
            return UpdateOne(dto);
        }
    }
}