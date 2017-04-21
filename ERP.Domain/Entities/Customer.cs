using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
  public class Customer
  {
    public int ID { get; set; }
    [Required]
    [Display(Name = "名称")]
    public string Name { get; set; }
    [Display(Name = "手机")]
    public string Phone { get; set; }
    [Display(Name = "备注")]
    public string Description { get; set; }
  }
}
