using System.Collections.Generic;

namespace EasyCombos.CodeFirstEntities
{
    public class FoodCategory
    {
        public FoodCategory()
        {
            this.FoodItems = new List<FoodItem>();
        }

        public int FoodCategoryId { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public virtual ICollection<FoodItem> FoodItems { get; set; }
    }
}
