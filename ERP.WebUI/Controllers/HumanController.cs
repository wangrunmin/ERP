using ERP.Domain.Abstract;
using ERP.Domain.Entities;
using ERP.WebUI.Config;
using ERP.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.WebUI.Controllers
{
  [Authorize]
  public class HumanController : Controller
  {
    private int pageSize = CONFIG.PAGESIZE;
    private IERPRepository repository;
    public HumanController(IERPRepository repo)
    {
      repository = repo;
    }

    public ViewResult List(int page = 1)
    {
      HumanListViewModel model = new HumanListViewModel
      {
        Humans = repository.Humans.OrderBy(s => s.ID).Skip((page - 1) * pageSize).Take(pageSize),
        PagingInfo = new PagingInfo
        {
          CurrentPage = page,
          ItemsPerPage = pageSize,
          TotalItems = repository.Humans.Count()
        },
      };
      return View(model);
    }
    public ViewResult Create()
    {
      ViewBag.Operate = "create";
      return View("Info", new Human());
    }
    public ViewResult Read(int ID)
    {
      Human human = repository.Humans.FirstOrDefault(p => p.ID == ID);
      ViewBag.Operate = "read";
      return View("Info", human);
    }
    public ViewResult Edit(int ID)
    {
      Human human = repository.Humans.FirstOrDefault(p => p.ID == ID);
      ViewBag.Operate = "update";
      return View("Info", human);
    }
    [HttpPost]
    public ActionResult Edit(Human human)
    {
      if (ModelState.IsValid)
      {
        repository.SaveHuman(human);
        //TempData["message"] = string.Format("{0} has been saved", human.Name);
        return RedirectToAction("List");
      }
      else
      {
        return View("Info", human);
      }
    }
    [HttpPost]
    public ActionResult Delete(int ID)
    {
      Human deletedHuman = repository.DeleteHuman(ID);
      if (deletedHuman != null)
      {
        //TempData["message"] = string.Format("{0} was deleted", deletedHuman.Name);
      }
      return RedirectToAction("List");
    }
  }
}