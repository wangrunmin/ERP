using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
  [Table("XSs")]
  public class XS
  {
    [Key]
    [Required]
    public int iID { get; set; }
    [Required]
    [Display(Name = "顾客")]
    public string CustomerName { get; set; }
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
