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
  public class CGController : Controller
  {
    public int pageSize = Config.CONFIG.PAGESIZE;
    private IERPRepository repository;
    public CGController(IERPRepository repo)
    {
      this.repository = repo;
      ViewBag.Suppliers = repository.Suppliers;
      ViewBag.Products = repository.Products;
      ViewBag.Humans = repository.Humans;

    }

    public ViewResult List(int page = 1)
    {
      CGListViewModel model = new CGListViewModel
      {
        CGs = repository.CGs.OrderBy(s => s.iID).Skip((page - 1) * pageSize).Take(pageSize),
        PagingInfo = new PagingInfo
        {
          CurrentPage = page,
          ItemsPerPage = pageSize,
          TotalItems = repository.CGs.Count()
        },
      };
      return View(model);
    }
    public ViewResult Create()
    {
      ViewBag.Operate = "create";
      return View("Info", new CGInfoViewModel());
    }
    public ViewResult Read(int iID = 0)
    {
      ViewBag.Operate = "read";
      CGInfoViewModel model = new CGInfoViewModel();
      model.cg = repository.CGs.FirstOrDefault(p => p.iID == iID);
      model.cgItems = repository.CGItems.Where(p => p.CGiID == iID).ToList();
      model.Items = new List<Item>();
      foreach (var item in model.cgItems)
      {
        model.Items.Add(repository.Items.FirstOrDefault(p => p.iID == item.ItemiID));
      }
      return View("Read", model);
    }
    //不允许修改和删除
    //public ViewResult Edit(int iID)
    //{
    //  CG cg = repository.CGs.FirstOrDefault(p => p.iID == iID);
    //  ViewBag.Operate = "update";
    //  return View("Info", cg);
    //}
    [HttpPost]
    public ActionResult Edit(CGInfoViewModel model)
    {
      if (ModelState.IsValid)
      {
        int CGiID = repository.SaveCG(model.cg);
        List<int> ItemiID = new List<int>();
        foreach (var item in model.Items)
        {
          ItemiID.Add(repository.SaveItem(item));
        }
        foreach (var item in ItemiID)
        {
          repository.SaveCGItem(new CGItem() { iID = 0, CGiID = CGiID, ItemiID = item });
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