using ERP.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain.Entities;
using System.Data.Entity.Validation;

namespace ERP.Domain.Concrete
{
  public class EFProductRepository : IERPRepository
  {
    private EFDbContext context = new EFDbContext();
    public IEnumerable<Menu> Menus
    {
      get
      {
        return context.Menus;
      }
    }
    public IEnumerable<Product> Products
    {
      get
      {
        return context.Products;
      }
    }
    public IEnumerable<Supplier> Suppliers
    {
      get
      {
        return context.Suppliers;
      }
    }

    //public IEnumerable<Purchase> Purchases
    //{
    //  get
    //  {
    //    return context.Purchases;
    //  }
    //}
    public IEnumerable<Human> Humans
    {
      get
      {
        return context.Humans;
      }
    }
    public IEnumerable<User> Users
    {
      get
      {
        return context.Users;
      }
    }
    public IEnumerable<Customer> Customers
    {
      get
      {
        return context.Customers;
      }
    }
    //public IEnumerable<Market> Markets
    //{
    //  get
    //  {
    //    return context.Markets;
    //  }
    //}
    public IEnumerable<CG> CGs
    {
      get
      {
        return context.CGs;
      }
    }
    public IEnumerable<CGItem> CGItems
    {
      get
      {
        return context.CGItems;
      }
    }
    public IEnumerable<XS> XSs
    {
      get
      {
        return context.XSs;
      }
    }
    public IEnumerable<XSItem> XSItems
    {
      get
      {
        return context.XSItems;
      }
    }
    public IEnumerable<Item> Items
    {
      get
      {
        return context.Items;
      }
    }

    public void SaveProduct(Product product)
    {
      if (product.ID == 0)
      {
        context.Products.Add(product);
      }
      else
      {
        Product dbEntry = context.Products.Find(product.ID);
        if (dbEntry != null)
        {
          dbEntry.Name = product.Name;
          dbEntry.Brand = product.Brand;
          dbEntry.Category = product.Category;
          if (product.ImageData != null)
          {
            dbEntry.ImageData = product.ImageData;
            dbEntry.ImageMimeType = product.ImageMimeType;
          }
          dbEntry.Price = product.Price;
          dbEntry.Stock = product.Stock;
          dbEntry.StockFloor = product.StockFloor;
          dbEntry.Description = product.Description;
        }
      }
      context.SaveChanges();
    }
    public Product DeleteProduct(int productID)
    {
      Product dbEntry = context.Products.Find(productID);
      if (dbEntry != null)
      {
        context.Products.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }

    public void SaveSupplier(Supplier supplier)
    {
      if (supplier.ID == 0)
      {
        context.Suppliers.Add(supplier);
      }
      else
      {
        Supplier dbEntry = context.Suppliers.Find(supplier.ID);
        if (dbEntry != null)
        {
          dbEntry.Name = supplier.Name;
          dbEntry.Phone = supplier.Phone;
          dbEntry.Fax = supplier.Fax;
          dbEntry.Description = supplier.Description;
        }
      }
      context.SaveChanges();
    }
    public Supplier DeleteSupplier(int ID)
    {
      Supplier dbEntry = context.Suppliers.Find(ID);
      if (dbEntry != null)
      {
        context.Suppliers.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }

    //public void SavePurchase(Purchase purchase)
    //{
    //  if (purchase.ID == 0)
    //  {
    //    context.Purchases.Add(purchase);
    //  }
    //  else
    //  {
    //    Purchase dbEntry = context.Purchases.Find(purchase.ID);
    //    if (dbEntry != null)
    //    {
    //      dbEntry.SupplierID = purchase.SupplierID;
    //      dbEntry.ProductID = purchase.ProductID;
    //      dbEntry.HumanID = purchase.HumanID;
    //      dbEntry.Quantity = purchase.Quantity;
    //      dbEntry.Price = purchase.Price;
    //      dbEntry.Total = purchase.Total;
    //      dbEntry.Time = purchase.Time;
    //      dbEntry.Status = purchase.Status;
    //      dbEntry.Description = purchase.Description;
    //    }
    //  }
    //  context.SaveChanges();
    //}
    //public Purchase DeletePurchase(int ID)
    //{
    //  Purchase dbEntry = context.Purchases.Find(ID);
    //  if (dbEntry != null)
    //  {
    //    context.Purchases.Remove(dbEntry);
    //    context.SaveChanges();
    //  }
    //  return dbEntry;
    //}
    //public void SaveMarket(Market market)
    //{
    //  if (market.ID == 0)
    //  {
    //    context.Markets.Add(market);
    //  }
    //  else
    //  {
    //    Market dbEntry = context.Markets.Find(market.ID);
    //    if (dbEntry != null)
    //    {
    //      dbEntry.CustomerID = market.CustomerID;
    //      dbEntry.ProductID = market.ProductID;
    //      dbEntry.HumanID = market.HumanID;
    //      dbEntry.Quantity = market.Quantity;
    //      dbEntry.Price = market.Price;
    //      dbEntry.Total = market.Total;
    //      dbEntry.Time = market.Time;
    //      dbEntry.Status = market.Status;
    //      dbEntry.Description = market.Description;
    //    }
    //  }
    //  context.SaveChanges();
    //}
    //public Market DeleteMarket(int ID)
    //{
    //  Market dbEntry = context.Markets.Find(ID);
    //  if (dbEntry != null)
    //  {
    //    context.Markets.Remove(dbEntry);
    //    context.SaveChanges();
    //  }
    //  return dbEntry;
    //}

    public void SaveHuman(Human human)
    {
      if (human.ID == 0)
      {
        context.Humans.Add(human);
      }
      else
      {
        Human dbEntry = context.Humans.Find(human.ID);
        if (dbEntry != null)
        {
          dbEntry.Name = human.Name;
          dbEntry.Birth = human.Birth;
          dbEntry.Sex = human.Sex;
          dbEntry.IDCard = human.IDCard;
          dbEntry.Phone = human.Phone;
          dbEntry.Email = human.Email;
          dbEntry.WorkPlace = human.WorkPlace;
          dbEntry.Job = human.Job;
          dbEntry.BankAccount = human.BankAccount;
          dbEntry.BankName = human.BankName;
          dbEntry.Description = human.Description;
        }
      }
      context.SaveChanges();
    }
    public Human DeleteHuman(int ID)
    {
      Human dbEntry = context.Humans.Find(ID);
      if (dbEntry != null)
      {
        context.Humans.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }

    public void SaveUser(User user)
    {
      if (user.ID == 0)
      {
        context.Users.Add(user);
      }
      else
      {
        User dbEntry = context.Users.Find(user.ID);
        if (dbEntry != null)
        {
          dbEntry.Email = user.Email;
          dbEntry.Phone = user.Phone;
          dbEntry.Password = user.Password;
          dbEntry.Role = user.Role;
          dbEntry.Question = user.Question;
          dbEntry.Answer = user.Answer;
        }
      }
      context.SaveChanges();
    }
    public User DeleteUser(int ID)
    {
      User dbEntry = context.Users.Find(ID);
      if (dbEntry != null)
      {
        context.Users.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }


    public void SaveCustomer(Customer customer)
    {
      if (customer.ID == 0)
      {
        context.Customers.Add(customer);
      }
      else
      {
        Customer dbEntry = context.Customers.Find(customer.ID);
        if (dbEntry != null)
        {
          dbEntry.Name = customer.Name;
          dbEntry.Phone = customer.Phone;
          dbEntry.Description = customer.Description;
        }
      }
      context.SaveChanges();
    }
    public Customer DeleteCustomer(int ID)
    {
      Customer dbEntry = context.Customers.Find(ID);
      if (dbEntry != null)
      {
        context.Customers.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }

    public int SaveCG(CG cg)
    {
      //try
      //{
      if (cg.iID == 0)
      {
        context.CGs.Add(cg);
      }
      else
      {
        CG dbEntry = context.CGs.Find(cg.iID);
        if (dbEntry != null)
        {
          dbEntry.SupplierName = cg.SupplierName;
          dbEntry.HumanName = cg.HumanName;
          dbEntry.Total = cg.Total;
          dbEntry.Time = cg.Time;
          dbEntry.Description = cg.Description;
        }
      }
      context.SaveChanges();
      var last = context.CGs.ToList().LastOrDefault();
      return last.iID;
      //}
      //catch (DbEntityValidationException dbEx)
      //{

      //}
    }
    public CG DeleteCG(int iID)
    {
      CG dbEntry = context.CGs.Find(iID);
      if (dbEntry != null)
      {
        context.CGs.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }
    public void SaveCGItem(CGItem cgItem)
    {
      if (cgItem.iID == 0)
      {
        context.CGItems.Add(cgItem);
      }
      else
      {
        CGItem dbEntry = context.CGItems.Find(cgItem.iID);
        if (dbEntry != null)
        {
          dbEntry.CGiID = cgItem.CGiID;
          dbEntry.ItemiID = cgItem.ItemiID;
        }
      }
      context.SaveChanges();
    }
    public CGItem DeleteCGItem(int iID)
    {
      CGItem dbEntry = context.CGItems.Find(iID);
      if (dbEntry != null)
      {
        context.CGItems.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }

    public int SaveXS(XS xs)
    {
      //try
      //{
      if (xs.iID == 0)
      {
        context.XSs.Add(xs);
      }
      else
      {
        XS dbEntry = context.XSs.Find(xs.iID);
        if (dbEntry != null)
        {
          dbEntry.CustomerName = xs.CustomerName;
          dbEntry.HumanName = xs.HumanName;
          dbEntry.Total = xs.Total;
          dbEntry.Time = xs.Time;
          dbEntry.Description = xs.Description;
        }
      }
      context.SaveChanges();
      var last = context.XSs.ToList().LastOrDefault();
      return last.iID;
      //}
      //catch (DbEntityValidationException dbEx)
      //{

      //}
    }
    public XS DeleteXS(int iID)
    {
      XS dbEntry = context.XSs.Find(iID);
      if (dbEntry != null)
      {
        context.XSs.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }
    public void SaveXSItem(XSItem xsItem)
    {
      if (xsItem.iID == 0)
      {
        context.XSItems.Add(xsItem);
      }
      else
      {
        XSItem dbEntry = context.XSItems.Find(xsItem.iID);
        if (dbEntry != null)
        {
          dbEntry.XSiID = xsItem.XSiID;
          dbEntry.ItemiID = xsItem.ItemiID;
        }
      }
      context.SaveChanges();
    }
    public XSItem DeleteXSItem(int iID)
    {
      XSItem dbEntry = context.XSItems.Find(iID);
      if (dbEntry != null)
      {
        context.XSItems.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }

    public int SaveItem(Item item)
    {
      if (item.iID == 0)
      {
        context.Items.Add(item);
      }
      else
      {
        Item dbEntry = context.Items.Find(item.iID);
        if (dbEntry != null)
        {
          dbEntry.ProductName = item.ProductName;
          dbEntry.Quantity = item.Quantity;
          dbEntry.Price = item.Price;
          dbEntry.Cost = item.Cost;
        }
      }
      context.SaveChanges();
      var last= context.Items.ToList().LastOrDefault();
      return last.iID;
    }
    public Item DeleteItem(int iID)
    {
      Item dbEntry = context.Items.Find(iID);
      if (dbEntry != null)
      {
        context.Items.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }
  }
}
