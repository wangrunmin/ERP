using ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.WebUI.Models
{
  public class HumanListViewModel
  {
    public IEnumerable<Human> Humans { get; set; }
    public PagingInfo PagingInfo { get; set; }
  }
}