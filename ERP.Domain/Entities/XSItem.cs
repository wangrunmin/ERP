using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
  public class XSItem
  {
    [Key]
    [Required]
    public int iID { get; set; }
    [Required]
    public int XSiID { get; set; }
    [Required]
    public int ItemiID { get; set; }
  }
}
