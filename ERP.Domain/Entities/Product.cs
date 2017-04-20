using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
  public class Product
  {
    public int ID { get; set; }
    [Required]
    [Display(Name ="名称")]
    public string Name { get; set; }
    [Display(Name = "品牌")]
    public string Brand { get; set; }
    [Display(Name = "分类")]
    public string Category { get; set; }
    [Display(Name = "图片数据")]
    public byte[] ImageData { get; set; }
    [Display(Name = "图片格式")]
    public string ImageMimeType { get; set; }
    [Display(Name = "价格")]
    public decimal Price { get; set; }
    [Required]
    [Display(Name = "库存量")]
    public int Stock { get; set; }
    [Required]
    [Display(Name = "最低库存")]
    public int StockFloor { get; set; }
    [Display(Name = "备注")]
    public string Description { get; set; }
  }
}
