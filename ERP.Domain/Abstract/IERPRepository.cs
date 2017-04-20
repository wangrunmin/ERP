using ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Abstract
{
  public interface IERPRepository
  {
    IEnumerable<Menu> Menus { get; }

    IEnumerable<Product> Products { get; }
    void SaveProduct(Product product);
    Product DeleteProduct(int productID);

    IEnumerable<Supplier> Suppliers { get; }
    void SaveSupplier(Supplier supplier);
    Supplier DeleteSupplier(int ID);

    IEnumerable<Purchase> Purchases { get; }
    void SavePurchase(Purchase purchase);
    Purchase DeletePurchase(int ID);

    IEnumerable<Human> Humans { get; }
    void SaveHuman(Human human);
    Human DeleteHuman(int ID);

    IEnumerable<User> Users { get; }
    void SaveUser(User user);
    User DeleteUser(int ID);
  }
}
