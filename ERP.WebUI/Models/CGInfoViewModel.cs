using ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.WebUI.Models
{
  public class CGInfoViewModel
  {
    public CG cg { get; set; }
    public IList<Item> Items { get; set; }
    public IList<CGItem> cgItems { get; set; }
    public CGInfoViewModel()
    {
      cg = new CG();
    }
  }
}