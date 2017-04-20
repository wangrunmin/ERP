using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
  [Table("Humans")]
  public class Human
  {
    public int ID { get; set; }
    [Required]
    [Display(Name ="姓名")]
    public string Name { get; set; }
    [Display(Name = "性别")]
    public string Sex { get; set; }
    [Display(Name = "出生年月")]
    public string Birth { get; set; }
    [Display(Name = "身份证号")]
    public string IDCard { get; set; }
    [Display(Name = "手机")]
    public string Phone { get; set; }
    [Display(Name = "邮箱")]
    public string Email { get; set; }
    [Display(Name = "工作地点")]
    public string WorkPlace { get; set; }
    [Required]
    [Display(Name = "职位")]
    public string Job { get; set; }
    [Display(Name = "银行账号")]
    public string BankAccount { get; set; }
    [Display(Name = "开户银行")]
    public string BankName { get; set; }
    [Display(Name = "备注")]
    public string Description { get; set; }
  }
}
