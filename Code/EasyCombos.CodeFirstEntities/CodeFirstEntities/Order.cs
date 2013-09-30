using System.Collections.Generic;

namespace EasyCombos.CodeFirstEntities
{
    public partial class Order
    {
        public Order()
        {
            this.FoodItems = new List<FoodItem>();
        }

        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public System.DateTime DateTime { get; set; }
        public double AdditionalDiscount { get; set; }
        public virtual ICollection<FoodItem> FoodItems { get; set; }
    }
}
