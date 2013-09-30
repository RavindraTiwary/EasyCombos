using System.Collections.Generic;

namespace EasyCombos.CodeFirstEntities
{
    public class OfferType
    {
        public OfferType()
        {
            this.FoodItems = new List<FoodItem>();
        }

        public int OfferTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<FoodItem> FoodItems { get; set; }
    }
}
