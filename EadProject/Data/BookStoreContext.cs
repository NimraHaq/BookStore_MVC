using Microsoft.EntityFrameworkCore;
using EadProject.Models;

namespace EadProject.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }
        public DbSet<SellerTable> SellerTable { get; set; }
        public DbSet<BuyerTable> BuyerTable { get; set; }
        public DbSet<BookTable> BookTable { get; set; }
        public DbSet<OrderTable> OrderTable { get; set; }

        //now we have to connect it to the database
        //1st way

        public override int SaveChanges()
        {
            var tracker = ChangeTracker;
            foreach (var entry in tracker.Entries())
            {
                if (entry.Entity is BaseClass)
                {
                    var referenceEntity = entry.Entity as BaseClass;
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            referenceEntity.CreatedOn = DateTime.Now;
                            //int id = Convert.ToInt32(HttpContext.Request)
                            //referenceEntity.CreatedBy = 

                            break;
                        case EntityState.Deleted:
                        case EntityState.Modified:
                            referenceEntity.ModifiedOn = DateTime.Now;
                            //referenceEntity.LastModifiedUserId = "1";//hard coded user id
                            break;
                        default:
                            break;
                    }
                }
                if (entry.Entity is BaseClassBook)
                {
                    var referenceEntity = entry.Entity as BaseClassBook;
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            referenceEntity.CreatedOn = DateTime.Now;
                            //int id = Convert.ToInt32(HttpContext.Request)
                            //referenceEntity.CreatedBy = 

                            break;
                        case EntityState.Deleted:
                        case EntityState.Modified:
                            referenceEntity.ModifiedOn = DateTime.Now;
                            //referenceEntity.LastModifiedUserId = "1";//hard coded user id
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

    }
}
