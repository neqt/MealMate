using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mealmate.Models
{
  public class Post
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int post_id { get; set; }
    public int poster_id { get; set; }
    public int quantity { get; set; }
    public string start_date { get; set; }
    public string? end_date { get; set; }
    public string status { get; set; }
  }
}