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
  public class MarketController : Controller
  {
    public int pageSize = Config.CONFIG.PAGESIZE;
    private IERPRepository repository;
    public MarketController(IERPRepository repo)
    {
      this.repository = repo;
      ViewBag.Customers = repository.Customers;
      ViewBag.Products = repository.Products;
      ViewBag.Humans = repository.Humans;

    }
    public ViewResult Create()
    {
      ViewBag.Operate = "create";
      return View("Info", new MarketInfoViewModel());
    }
    public ViewResult Read(int ID)
    {
      Market market = repository.Markets.FirstOrDefault(p => p.ID == ID);
      ViewBag.Operate = "read";
      return View("Info", market);
    }
    public ViewResult List(int page = 1)
    {
      MarketListViewModel model = new MarketListViewModel
      {
        Markets = repository.Markets.OrderBy(s => s.ID).Skip((page - 1) * pageSize).Take(pageSize),
        PagingInfo = new PagingInfo
        {
          CurrentPage = page,
          ItemsPerPage = pageSize,
          TotalItems = repository.Markets.Count()
        },
      };
      return View(model);
    }
    public ViewResult Edit(int ID)
    {
      Market market = repository.Markets.FirstOrDefault(p => p.ID == ID);
      ViewBag.Operate = "update";
      return View("Info", market);
    }
    [HttpPost]
    public ActionResult Edit(Market market)
    {
      Customer customer = null;
      Product product = null;
      if (ModelState.IsValid)
      {
        customer = repository.Customers.FirstOrDefault(p => p.ID == market.CustomerID);
        product = repository.Products.FirstOrDefault(p => p.ID == market.ProductID);
      }
      if (customer != null && product != null)
      {
        //若添加销售单时已完成，则更新产品数量
        if (market.Status == "已完成" && market.Quantity > 0)
        {
          product.Stock -= market.Quantity;
          repository.SaveProduct(product);
        }
        repository.SaveMarket(market);
        return RedirectToAction("List");
      }
      else
      {
        ViewBag.Operate = "create";
        return View("Info", market);
      }
    }
    [HttpPost]
    public void Delete(int ID)
    {
      //关系表不允许删除
      //Market deletedMarket = repository.DeleteMarket(ID);
      //if (deletedMarket != null)
      //{
      //  TempData["message"] = string.Format("{0} was deleted", deletedMarket.ID);
      //}
      //return RedirectToAction("List");
    }
    [HttpPost]
    public ActionResult Expire(int ID)
    {
      Market market = repository.Markets.FirstOrDefault(p => p.ID == ID);
      if (market != null)
      {
        market.Status = "已报废";
        repository.SaveMarket(market);
      }
      return RedirectToAction("List");
    }
    [HttpPost]
    public ActionResult Finish(int ID)
    {
      Market market = repository.Markets.FirstOrDefault(p => p.ID == ID);
      Product product = repository.Products.FirstOrDefault(p => p.ID == market.ProductID);
      if (market.Quantity > 0 && product != null)
      {
        product.Stock -= market.Quantity;
        repository.SaveProduct(product);
        market.Status = "已完成";
        repository.SaveMarket(market);
      }
      return RedirectToAction("List");
    }
  }
}