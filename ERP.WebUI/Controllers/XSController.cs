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
  public class XSController : Controller
  {
    public int pageSize = Config.CONFIG.PAGESIZE;
    private IERPRepository repository;
    public XSController(IERPRepository repo)
    {
      this.repository = repo;
      ViewBag.Suppliers = repository.Suppliers;
      ViewBag.Products = repository.Products;
      ViewBag.Humans = repository.Humans;

    }

    public ViewResult List(int page = 1)
    {
      XSListViewModel model = new XSListViewModel
      {
        XSs = repository.XSs.OrderBy(s => s.iID).Skip((page - 1) * pageSize).Take(pageSize),
        PagingInfo = new PagingInfo
        {
          CurrentPage = page,
          ItemsPerPage = pageSize,
          TotalItems = repository.XSs.Count()
        },
      };
      return View(model);
    }
    public ViewResult Create()
    {
      ViewBag.Operate = "create";
      return View("Info", new XSInfoViewModel());
    }
    public ViewResult Read(int iID = 0)
    {
      XSInfoViewModel model = new XSInfoViewModel();
      model.xs = repository.XSs.FirstOrDefault(p => p.iID == iID);
      model.xsItems = repository.XSItems.Where(p => p.XSiID == iID).ToList();
      model.Items = new List<Item>();
      foreach (var item in model.xsItems)
      {
        model.Items.Add(repository.Items.FirstOrDefault(p => p.iID == item.ItemiID));
      }
      ViewBag.Operate = "read";
      return View("Read", model);
    }
    [HttpPost]
    public ActionResult Edit(XSInfoViewModel model)
    {
      if (ModelState.IsValid)
      {
        int XSiID = repository.SaveXS(model.xs);
        List<int> ItemiID = new List<int>();
        foreach (var item in model.Items)
        {
          ItemiID.Add(repository.SaveItem(item));
        }
        foreach (var item in ItemiID)
        {
          repository.SaveXSItem(new XSItem() { iID = 0, XSiID = XSiID, ItemiID = item });
        }
        return RedirectToAction("List");
      }
      else
      {
        return View("Info", model);
      }
    }
  }
}