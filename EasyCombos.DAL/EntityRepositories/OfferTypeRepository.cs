using EasyCombos.CodeFirstEntities;
using EasyCombos.DAL.DBInteractions;

namespace EasyCombos.DAL.EntityRepositories
{
    public class OfferTypeRepository : EntityRepositoryBase<OfferType>, IOfferTypeRepository
    {
        public OfferTypeRepository(IDBFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

}