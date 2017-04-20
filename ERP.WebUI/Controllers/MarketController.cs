using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.WebUI.Controllers
{
  [Authorize]
  public class MarketController : Controller
  {
    // GET: Market
    public ViewResult List()
    {
      return View();
    }
  }
}