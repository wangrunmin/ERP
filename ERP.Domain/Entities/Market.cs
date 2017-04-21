using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
  public class Market
  {
    public int ID { get; set; }
    [Required]
    [Display(Name = "客户")]
    public int CustomerID { get; set; }
    [Required]
    [Display(Name = "产品")]
    public int ProductID { get; set; }
    [Required]
    [Display(Name = "经办人")]
    public int HumanID { get; set; }
    [Required]
    [Display(Name = "数量")]
    [Range(1, int.MaxValue, ErrorMessage = "数量必须大于等于1")]
    public int Quantity { get; set; }
    [Required]
    [Display(Name = "单价")]
    public decimal Price { get; set; }
    [Required]
    [Display(Name = "总额")]
    public decimal Total { get; set; }
    [Required]
    [Display(Name = "时间")]
    public string Time { get; set; }
    [Required]
    [Display(Name = "状态")]
    public string Status { get; set; }
    [Display(Name = "备注")]
    public string Description { get; set; }

  }
}
