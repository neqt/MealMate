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
    public DateTime start_date { get; set; }
    public DateTime? end_date { get; set; }
    public char? status { get; set; }
  }
}