using ERP.Domain.Abstract;
using ERP.Domain.Entities;
using ERP.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.WebUI.Controllers
{
  [Authorize]
  public class CKController : Controller
  {
    public int pageSize = Config.CONFIG.PAGESIZE;
    private IERPRepository repository;
    public CKController(IERPRepository repo)
    {
      this.repository = repo;
      ViewBag.Suppliers = repository.Suppliers;
      ViewBag.Products = repository.Products;
      ViewBag.Humans = repository.Humans;

    }
    public ViewResult Read(int ID = 0)
    {
      Product product = repository.Products.FirstOrDefault(p => p.ID == ID);
      ViewBag.Operate = "read";
      return View("Info", product);
    }
    public ViewResult List(int page = 1)
    {
      ProductListViewModel model = new ProductListViewModel
      {
        Products = repository.Products.OrderBy(s => s.ID).Skip((page - 1) * pageSize).Take(pageSize),
        PagingInfo = new PagingInfo
        {
          CurrentPage = page,
          ItemsPerPage = pageSize,
          TotalItems = repository.Products.Count()
        },
      };
      return View(model);
    }
  }
}