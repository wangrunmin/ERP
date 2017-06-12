using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
  public class Item
  {
    [Key]
    [Required]
    public int iID { get; set; }
    [Display(Name = "商品名称")]
    public string ProductName { get; set; }
    [Display(Name = "数量")]
    [Range(1, int.MaxValue, ErrorMessage = "数量必须大于等于1")]
    public int Quantity { get; set; }
    [Display(Name = "单价")]
    public decimal Price { get; set; }
    [Display(Name = "小计")]
    public decimal Cost { get; set; }
  }
}
