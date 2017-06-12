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

    //IEnumerable<Purchase> Purchases { get; }
    //void SavePurchase(Purchase purchase);
    //Purchase DeletePurchase(int ID);

    IEnumerable<Human> Humans { get; }
    void SaveHuman(Human human);
    Human DeleteHuman(int ID);

    IEnumerable<User> Users { get; }
    void SaveUser(User user);
    User DeleteUser(int ID);

    //IEnumerable<Market> Markets { get; }
    //void SaveMarket(Market market);
    //Market DeleteMarket(int ID);

    IEnumerable<Customer> Customers { get; }
    void SaveCustomer(Customer customer);
    Customer DeleteCustomer(int ID);

    IEnumerable<CG> CGs { get; }
    int SaveCG(CG cg);
    CG DeleteCG(int  iID);

    IEnumerable<CGItem> CGItems { get; }
    void SaveCGItem(CGItem cgItem);
    CGItem DeleteCGItem(int iID);

    IEnumerable<XS> XSs { get; }
    int SaveXS(XS xs);
    XS DeleteXS(int iID);

    IEnumerable<XSItem> XSItems { get; }
    void SaveXSItem(XSItem xsItem);
    XSItem DeleteXSItem(int iID);

    IEnumerable<Item> Items { get; }
    int SaveItem(Item item);
    Item DeleteItem(int iID);

  }
}
