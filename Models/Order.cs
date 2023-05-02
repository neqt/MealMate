using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mealmate.Models
{
  public class Order
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int order_id { get; set; }
    public int post_id { get; set; }
    public int poster_id { get; set; }
    public string food_name { get; set; }
    public string? notes { get; set; }
    public int quantity { get; set; }
    public int order_owner_id { get; set; }
    public char? status { get; set; }
    public DateTime latest_update { get; set; }
  }
}