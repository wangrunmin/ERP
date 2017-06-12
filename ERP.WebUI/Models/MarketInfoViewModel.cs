using ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.WebUI.Models
{
  public class MarketInfoViewModel
  {
    public Market market { get; set; }
    public IList<Item> Items { get; set; }
    public IList<CGItem> cgItems { get; set; }
    public MarketInfoViewModel()
    {
      market = new Market();
    }
  }
}