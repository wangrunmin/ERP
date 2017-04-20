using ERP.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain.Entities;

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

    public IEnumerable<Purchase> Purchases
    {
      get
      {
        return context.Purchases;
      }
    }
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

    public void SavePurchase(Purchase purchase)
    {
      if (purchase.ID == 0)
      {
        context.Purchases.Add(purchase);
      }
      else
      {
        Purchase dbEntry = context.Purchases.Find(purchase.ID);
        if (dbEntry != null)
        {
          dbEntry.SupplierID = purchase.SupplierID;
          dbEntry.ProductID = purchase.ProductID;
          dbEntry.HumanID = purchase.HumanID;
          dbEntry.Quantity = purchase.Quantity;
          dbEntry.Price = purchase.Price;
          dbEntry.Total = purchase.Total;
          dbEntry.Time = purchase.Time;
          dbEntry.Status = purchase.Status;
          dbEntry.Description = purchase.Description;
        }
      }
      context.SaveChanges();
    }
    public Purchase DeletePurchase(int ID)
    {
      Purchase dbEntry = context.Purchases.Find(ID);
      if (dbEntry != null)
      {
        context.Purchases.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }

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
  }
}
