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
    public ViewResult Login()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Login(LoginViewModel model, string returnUrl)
    {
      if (ModelState.IsValid)
      {
        User user = repository.Users.FirstOrDefault(m => m.Email == model.UserName);
        if (user != null && user.Password == model.Password)
        {
          FormsAuthentication.SetAuthCookie(user.Email, false);
          return Redirect(returnUrl ?? Url.Action("Index", "Home"));
        }
        else
        {
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