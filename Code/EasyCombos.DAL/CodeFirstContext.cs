using System.Data.Entity;
using EasyCombos.CodeFirstEntities;

namespace EasyCombos.DAL
{
    public class CodeFirstContext : DbContext
    {
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<OfferType> OfferTypes { get; set; }
        public DbSet<Order> Orders { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
