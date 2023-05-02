using System.ComponentModel.DataAnnotations;

namespace mealmate.Models
{
  public class UserLogin
  {
    [Key]
    public int userLogin_id { get; set; }
    public string userLogin_name { get; set; }
    public string userLogin_password { get; set; }
  }
}