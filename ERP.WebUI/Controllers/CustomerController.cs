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
  public class CustomerController : Controller
  {
    public int pageSize = Config.CONFIG.PAGESIZE;
    private IERPRepository repository;
    public CustomerController(IERPRepository repo)
    {
      this.repository = repo;
    }
    public ViewResult Create()
    {
      ViewBag.Operate = "create";
      return View("Info", new Customer());
    }
    public ViewResult Read(int ID)
    {
      Customer customer = repository.Customers.FirstOrDefault(p => p.ID == ID);
      ViewBag.Operate = "read";
      return View("Info", customer);
    }
    public ViewResult List(int page = 1)
    {
      CustomerListViewModel model = new CustomerListViewModel
      {
        Customers = repository.Customers.OrderBy(s => s.ID).Skip((page - 1) * pageSize).Take(pageSize),
        PagingInfo = new PagingInfo
        {
          CurrentPage = page,
          ItemsPerPage = pageSize,
          TotalItems = repository.Customers.Count()
        },
      };
      return View(model);
    }
    public ViewResult Edit(int ID)
    {
      Customer customer = repository.Customers.FirstOrDefault(p => p.ID == ID);
      ViewBag.Operate = "update";
      return View("Info", customer);
    }
    [HttpPost]
    public ActionResult Edit(Customer customer)
    {
      if (ModelState.IsValid)
      {
        repository.SaveCustomer(customer);
        //TempData["message"] = string.Format("{0} has been saved", customer.Name);
        return RedirectToAction("List");
      }
      else
      {
        return View("Info", customer);
      }
    }
    [HttpPost]
    public ActionResult Delete(int ID)
    {
      Customer deletedCustomer = repository.DeleteCustomer(ID);
      if (deletedCustomer != null)
      {
        //TempData["message"] = string.Format("{0} was deleted", deletedCustomer.Name);
      }
      return RedirectToAction("List");
    }
  }
}