using ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.WebUI.Models
{
  public class IndexListViewModel
  {
    public IEnumerable<Product> Products { get; set; }
    public IEnumerable<CG> CGs { get; set; }
    public IEnumerable<XS> XSs { get; set; }
    public PagingInfo PagingInfo { get; set; }
  }
}