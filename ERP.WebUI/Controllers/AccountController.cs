using ERP.Domain.Abstract;
using ERP.Domain.Entities;
using ERP.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ERP.WebUI.Controllers
{
  public class AccountController : Controller
  {
    private IERPRepository repository;
    public AccountController(IERPRepository repo)
    {
      this.repository = repo;
    }
    //Get方式访问登录动作，直接返回默认的Login视图
    public ViewResult Login()
    {
      return View();
    }
    //Post方式访问登录动作
    [HttpPost]
    public ActionResult Login(LoginViewModel model, string returnUrl)
    {
      //首先进行页面模型的数据验证
      if (ModelState.IsValid)
      {
        //从数据库持久化模型中选择符合条件的用户记录
        User user = repository.Users.FirstOrDefault(m => m.Email == model.UserName);
        if (user != null && user.Password == model.Password)
        {
          //使用cookie保存用户访问期间的身份信息，默认跳转到Home控制器的Index动作
          FormsAuthentication.SetAuthCookie(user.Email, false);
          return Redirect(returnUrl ?? Url.Action("Index", "Home"));
        }
        else
        {
          //提示错误信息
          ModelState.AddModelError("", "Incorrect username or password");
          return View();
        }
      }
      else
      {
        return View();
      }
    }
  }
}