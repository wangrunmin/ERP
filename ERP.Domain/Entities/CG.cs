using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
  public class CG
  {
    [Key]
    [Required]
    public int iID { get; set; }
    [Required]
    [Display(Name = "供应商")]
    public string  SupplierName { get; set; }
    [Required]
    [Display(Name = "经办人")]
    public string HumanName { get; set; }
    [Required]
    [Display(Name = "采购时间")]
    public string Time { get; set; }
    [Required]
    [Display(Name = "总金额")]
    public decimal Total { get; set; }
    [Display(Name = "备注")]
    public string Description { get; set; }
  }
}
