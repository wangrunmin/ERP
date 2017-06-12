using ERP.Domain.Entities;
using System.Data.Entity;

namespace ERP.Domain.Concrete
{
  public class EFDbContext : DbContext
  {
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    //public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Human> Humans { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    //public DbSet<Market> Markets { get; set; }
    public DbSet<CG> CGs { get; set; }
    public DbSet<CGItem> CGItems { get; set; }
    public DbSet<XS> XSs { get; set; }
    public DbSet<XSItem> XSItems { get; set; }
    public DbSet<Item> Items { get; set; }
  }
}
