using System.Collections.Generic;

namespace EasyCombos.CodeFirstEntities
{
    public partial class FoodItem
    {
        public FoodItem()
        {
            this.Orders = new List<Order>();
        }

        public int FoodItemId { get; set; }
        public string Name { get; set; }
        public int FoodCategoryId { get; set; }
        public double PricePerUnit { get; set; }
        public int QunatityOnHand { get; set; }
        public string Description { get; set; }
        public double OfferedDiscount { get; set; }
        public int OfferTypeId { get; set; }
        public virtual FoodCategory FoodCategory { get; set; }
        public virtual OfferType OfferType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
