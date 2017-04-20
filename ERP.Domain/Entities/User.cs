using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
  public class User
  {
    public int ID { get; set; }
    [Required]
    public string Email { get; set; }
    public string Phone { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Role { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
  }
}
