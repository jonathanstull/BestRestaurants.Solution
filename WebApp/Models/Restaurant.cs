
namespace BestRestaurants.Models
{
  public class Restaurant
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public int cuisineId { get; set; }
    public virtual Cuisine Cuisine { get; set; }
  }
}