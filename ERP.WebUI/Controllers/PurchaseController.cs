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
  public class PurchaseController : Controller
  {
    public int pageSize = Config.CONFIG.PAGESIZE;
    private IERPRepository repository;
    public PurchaseController(IERPRepository repo)
    {
      this.repository = repo;
      ViewBag.Suppliers = repository.Suppliers;
      ViewBag.Products = repository.Products;
      ViewBag.Humans = repository.Humans;

    }
    public ViewResult Create()
    {
      ViewBag.Operate = "create";
      return View("Info", new Purchase());
    }
    public ViewResult Read(int ID)
    {
      Purchase purchase = repository.Purchases.FirstOrDefault(p => p.ID == ID);
      ViewBag.Operate = "read";
      return View("Info", purchase);
    }
    public ViewResult List(int page = 1)
    {
      PurchaseListViewModel model = new PurchaseListViewModel
      {
        Purchases = repository.Purchases.OrderBy(s => s.ID).Skip((page - 1) * pageSize).Take(pageSize),
        PagingInfo = new PagingInfo
        {
          CurrentPage = page,
          ItemsPerPage = pageSize,
          TotalItems = repository.Purchases.Count()
        },
      };
      return View(model);
    }
    public ViewResult Edit(int ID)
    {
      Purchase purchase = repository.Purchases.FirstOrDefault(p => p.ID == ID);
      ViewBag.Operate = "update";
      return View("Info", purchase);
    }
    [HttpPost]
    public ActionResult Edit(Purchase purchase)
    {
      Supplier supplier = null;
      Product product = null;
      if (ModelState.IsValid)
      {
        supplier = repository.Suppliers.FirstOrDefault(p => p.ID == purchase.SupplierID);
        product = repository.Products.FirstOrDefault(p => p.ID == purchase.ProductID);
      }
      if (supplier != null && product != null)
      {
        //若添加采购单时已完成，则更新产品数量
        if (purchase.Status == "已完成" && purchase.Quantity > 0)
        {
          product.Stock += purchase.Quantity;
          repository.SaveProduct(product);
        }
        repository.SavePurchase(purchase);
        return RedirectToAction("List");
      }
      else
      {
        ViewBag.Operate = "create";
        return View("Info", purchase);
      }
    }
    [HttpPost]
    public void Delete(int ID)
    {
      //购买关系表不允许删除
      //Purchase deletedPurchase = repository.DeletePurchase(ID);
      //if (deletedPurchase != null)
      //{
      //  TempData["message"] = string.Format("{0} was deleted", deletedPurchase.ID);
      //}
      //return RedirectToAction("List");
    }
    [HttpPost]
    public ActionResult Expire(int ID)
    {
      Purchase purchase = repository.Purchases.FirstOrDefault(p => p.ID == ID);
      if (purchase != null)
      {
        purchase.Status = "已报废";
        repository.SavePurchase(purchase);
      }
      return RedirectToAction("List");
    }
    [HttpPost]
    public ActionResult Finish(int ID)
    {
      Purchase purchase = repository.Purchases.FirstOrDefault(p => p.ID == ID);
      Product product = repository.Products.FirstOrDefault(p => p.ID == purchase.ProductID);
      if (purchase.Quantity > 0 && product != null)
      {
        product.Stock += purchase.Quantity;
        repository.SaveProduct(product);
        purchase.Status = "已完成";
        repository.SavePurchase(purchase);
      }
      return RedirectToAction("List");
    }
  }
}