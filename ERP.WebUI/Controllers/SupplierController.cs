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
  public class SupplierController : Controller
  {
    public int pageSize = Config.CONFIG.PAGESIZE;
    private IERPRepository repository;
    public SupplierController(IERPRepository repo)
    {
      this.repository = repo;
    }
    public ViewResult Create()
    {
      ViewBag.Operate = "create";
      return View("Info", new Supplier());
    }
    public ViewResult Read(int ID)
    {
      Supplier supplier = repository.Suppliers.FirstOrDefault(p => p.ID == ID);
      ViewBag.Operate = "read";
      return View("Info", supplier);
    }
    public ViewResult List(int page = 1)
    {
      SupplierListViewModel model = new SupplierListViewModel
      {
        Suppliers = repository.Suppliers.OrderBy(s => s.ID).Skip((page - 1) * pageSize).Take(pageSize),
        PagingInfo = new PagingInfo
        {
          CurrentPage = page,
          ItemsPerPage = pageSize,
          TotalItems = repository.Suppliers.Count()
        },
      };
      return View(model);
    }
    public ViewResult Edit(int ID)
    {
      Supplier supplier = repository.Suppliers.FirstOrDefault(p => p.ID == ID);
      ViewBag.Operate = "update";
      return View("Info", supplier);
    }
    [HttpPost]
    public ActionResult Edit(Supplier supplier)
    {
      if (ModelState.IsValid)
      {
        repository.SaveSupplier(supplier);
        //TempData["message"] = string.Format("{0} has been saved", supplier.Name);
        return RedirectToAction("List");
      }
      else
      {
        return View("Info", supplier);
      }
    }
    [HttpPost]
    public ActionResult Delete(int ID)
    {
      Supplier deletedSupplier = repository.DeleteSupplier(ID);
      if (deletedSupplier != null)
      {
        //TempData["message"] = string.Format("{0} was deleted", deletedSupplier.Name);
      }
      return RedirectToAction("List");
    }
  }
}