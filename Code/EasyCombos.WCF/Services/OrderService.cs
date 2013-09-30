using System.Collections.Generic;
using EasyCombos.CodeFirstEntities;
using EasyCombos.DAL.DBInteractions;
using EasyCombos.DAL.EntityRepositories;
using EasyCombos.WCF.Interfaces;

namespace EasyCombos.WCF.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService()
        {
        }

        public OrderService(IOrderRepository OrderRepository, IUnitOfWork unitOfWork)
        {
            this._OrderRepository = OrderRepository;
            this._unitOfWork = unitOfWork;
        }
        #region IOrderService Members

        public IEnumerable<Order> GetOrder()
        {
            var foodCategories = _OrderRepository.GetAll();
            return foodCategories;
        }

        public Order GetOrderById(int id)
        {
            var Order = _OrderRepository.GetById(id);
            return Order;
        }

        public void CreateOrder(Order Order)
        {
            _OrderRepository.Add(Order);
            _unitOfWork.Commit();
        }

        public void DeleteOrder(int id)
        {
            var Order = _OrderRepository.GetById(id);
            _OrderRepository.Delete(Order);
            _unitOfWork.Commit();
        }

        public void UpdateOrder(Order Order)
        {
            _OrderRepository.Update(Order);
            _unitOfWork.Commit();
        }

        public void SaveOrder()
        {
            _unitOfWork.Commit();
        }

        #endregion
    }
}
