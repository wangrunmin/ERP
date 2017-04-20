using ERP.Domain.Abstract;
using ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.WebUI.Models
{
  public class PurchaseInfoViewModel
  {
    private IERPRepository repository;
    public PurchaseInfoViewModel(IERPRepository repo)
    {
      repository = repo;
    }
    public PurchaseInfoViewModel()
    {

    }
    public Purchase purchase { get; set; }

    private IEnumerable<Supplier> suppliers = null;
    private IEnumerable<Product> products = null;
    private IEnumerable<Human> humans = null;
    public IEnumerable<Supplier> Suppliers
    {
      get
      {
        return repository.Suppliers;
      }
      set
      {
        suppliers = repository.Suppliers;
      }
    }
    public IEnumerable<Product> Products
    {
      get
      {
        return repository.Products;
      }
      set
      {
        products = repository.Products;
      }
    }
    public IEnumerable<Human> Humans
    {
      get
      {
        return repository.Humans;
      }
      set
      {
        humans = repository.Humans;
      }
    }

  }
}