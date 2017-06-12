using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
  public class CGItem
  {
    [Key]
    [Required]
    public int iID { get; set; }
    [Required]
    public int CGiID { get; set; }
    [Required]
    public int ItemiID { get; set; }
  }
}
