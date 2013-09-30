using System.Collections.Generic;
using EasyCombos.CodeFirstEntities;

namespace CodeFirstServices.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrder();

        Order GetOrderById(int id);

        void CreateOrder(Order Order);

        void UpdateOrder(Order Order);

        void DeleteOrder(int id);

        void SaveOrder();
    }
}
