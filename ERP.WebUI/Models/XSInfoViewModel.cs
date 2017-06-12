using ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.WebUI.Models
{
  public class XSInfoViewModel
  {
    public XS xs { get; set; }
    public IList<Item> Items { get; set; }
    public IList<XSItem> xsItems { get; set; }
    public XSInfoViewModel()
    {
      xs = new XS();
    }
  }
}