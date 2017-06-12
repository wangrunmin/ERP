using ERP.Domain.Abstract;
using ERP.WebUI.Models;
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
    //默认的强类型视图
    public ViewResult Index()
    {
      //使用视图模型传递首页所需要的产品、销售、采购数据
      IndexListViewModel model = new IndexListViewModel()
      {
        Products = repository.Products,
        CGs = repository.CGs,
        XSs = repository.XSs,
      };
      return View(model);
    }
  }
}