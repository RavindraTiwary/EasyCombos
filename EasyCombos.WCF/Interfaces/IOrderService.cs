using System.Collections.Generic;
using System.ServiceModel;
using EasyCombos.CodeFirstEntities;

namespace EasyCombos.WCF.Interfaces
{
     [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        IEnumerable<Order> GetOrder();

        [OperationContract]
        Order GetOrderById(int id);

        [OperationContract]
        void CreateOrder(Order order);

        [OperationContract]
        void UpdateOrder(Order order);

        [OperationContract]
        void DeleteOrder(int id);

        [OperationContract]
        void SaveOrder();
    }
}
