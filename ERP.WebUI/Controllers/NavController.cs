using ERP.Domain.Abstract;
using ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.WebUI.Controllers
{
  [Authorize]
  public class NavController : Controller
  {
    private IERPRepository repository;
    public NavController(IERPRepository repo)
    {
      repository = repo;
    }

    public PartialViewResult Menu()
    {
      IEnumerable<Menu> menus = repository.Menus;
      return PartialView(menus);
    }
  }
}