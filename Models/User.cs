using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mealmate.Models
{
  public class User
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int user_id { get; set; }
    public string user_name { get; set; }
    public string user_password { get; set; }
    public string user_telephone { get; set; }
    public string? user_img { get; set; }
    public DateTime? user_created_date { get; set; }
    public DateTime? user_updated_date { get; set; }
  }
}