using EasyCombos.CodeFirstEntities;
using EasyCombos.DAL.DBInteractions;

namespace EasyCombos.DAL.EntityRepositories
{
    public class OrderRepository : EntityRepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDBFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

}