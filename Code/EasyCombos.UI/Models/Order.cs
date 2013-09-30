using System.Collections.Generic;
using EasyCombos.CodeFirstEntities;

namespace EasyCombos.UI.Models
{
    public partial class OrderModel
    {
        public OrderModel()
        {
            this.FoodItems = new List<FoodItemModel>();
        }

        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public System.DateTime DateTime { get; set; }
        public double AdditionalDiscount { get; set; }
        public virtual List<FoodItemModel> FoodItems { get; set; }

        #region conversion methods

        public Order GetEntity(OrderModel model)
        {
            return new Order()
                       {
                           OrderId = model.OrderId,
                           CustomerName = model.CustomerName,
                           DateTime = model.DateTime,
                           AdditionalDiscount = model.AdditionalDiscount,
                       };
        }

        public List<Order> GetEntity(List<OrderModel> models)
        {
            return models.ConvertAll(x => GetEntity(x));
        }

        public OrderModel GetModel(Order entity)
        {
            return new OrderModel()
                       {
                           OrderId = entity.OrderId,
                           CustomerName = entity.CustomerName,
                           DateTime = entity.DateTime,
                           AdditionalDiscount = entity.AdditionalDiscount,
                       };
        }

        public List<OrderModel> GetModel(List<Order> entity)
        {
            return entity.ConvertAll(x => GetModel(x));
        }

        #endregion
    }
}
