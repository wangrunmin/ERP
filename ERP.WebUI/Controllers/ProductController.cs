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
  public class ProductController : Controller
  {
    private IERPRepository repository;
    public int pageSize = Config.CONFIG.PAGESIZE;
    public ProductController(IERPRepository repo)
    {
      this.repository = repo;
    }

    public ViewResult List(string category, int page = 1)
    {
      ProductListViewModel model = new ProductListViewModel
      {
        Products = repository.Products.OrderBy(p => p.ID).Skip((page - 1) * pageSize).Take(pageSize),
        PagingInfo = new PagingInfo
        {
          CurrentPage = page,
          ItemsPerPage = pageSize,
          TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(e => e.Category == category).Count()
        },
        CurrentCategory = category
      };
      return View(model);
    }
    public ViewResult Create()
    {
      ViewBag.Operate = "create";
      return View("Info", new Product());
    }
    public ViewResult Read(int ID)
    {
      Product product = repository.Products.FirstOrDefault(p => p.ID == ID);
      ViewBag.Operate = "read";
      return View("Info", product);
    }
    public ViewResult Edit(int ID)
    {
      Product product = repository.Products.FirstOrDefault(p => p.ID == ID);
      ViewBag.Operate = "update";
      return View("Info", product);
    }
    [HttpPost]
    public ActionResult Edit(Product product, HttpPostedFileBase image = null)
    {
      if (ModelState.IsValid)
      {
        if (image != null)
        {
          product.ImageMimeType = image.ContentType;
          product.ImageData = new byte[image.ContentLength];
          image.InputStream.Read(product.ImageData, 0, image.ContentLength);
        }
        repository.SaveProduct(product);
        TempData["message"] = string.Format("{0} has been saved", product.Name);
        return RedirectToAction("List");
      }
      else
      {
        return View("Info", product);
      }
    }
    [HttpPost]
    public ActionResult Delete(int ID)
    {
      Product deletedProduct = repository.DeleteProduct(ID);
      if (deletedProduct != null)
      {
        TempData["message"] = string.Format("{0} was deleted", deletedProduct.Name);
      }
      return RedirectToAction("List");
    }
    public FileContentResult GetImage(int ID)
    {
      Product product = repository.Products.FirstOrDefault(p => p.ID == ID);
      if (product != null)
      {
        return File(product.ImageData, product.ImageMimeType);
      }
      else
      {
        return null;
      }
    }

  }
}