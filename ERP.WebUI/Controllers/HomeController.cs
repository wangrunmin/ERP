using ERP.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.WebUI.Controllers
{
  [Authorize]
  public class HomeController : Controller
  {
    private IERPRepository repository;
    public HomeController(IERPRepository repo)
    {
      this.repository = repo;
    }
    public ViewResult Index()
    {
      return View();
    }
  }
}