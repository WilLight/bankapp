using System.Linq;
using LiteDB;
using BankApp.Shared.Data;


namespace BankApp.Server.Database
{
    public abstract class LiteDbBaseRepo<DataT> where DataT : ICountable
    {
        protected LiteDatabase liteDb_ { get; set; }
        protected string collection_ { get; }

        public LiteDbBaseRepo(LiteDbContext liteDbContext, string collection)
        {
            liteDb_ = liteDbContext.Context;
            collection_ = collection;
        }

        public DataT GetOne(int dtoId)
        {
            return liteDb_.GetCollection<DataT>(collection_).FindOne(x => x.Id == dtoId);
        }

        public bool Insert(DataT dto)
        {
            return liteDb_.GetCollection<DataT>(collection_).Insert(dto);
        }

        public bool UpdateOne(DataT dto)
        {
            return liteDb_.GetCollection<DataT>(collection_).Update(dto);
        }

        public virtual bool Delete(int dtoId)
        {
            return liteDb_.GetCollection<DataT>(collection_).Delete(dtoId);
        }
    }
}