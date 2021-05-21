using System.Collections.Generic;
namespace BestRestaurants.Models
{
  public class Restaurant
  {
    public Restaurant()
    {
      this.Images = new HashSet<RestaurantImage>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public int CuisineId { get; set; }
    public virtual Cuisine Cuisine { get; set; }
    public virtual ICollection<RestaurantImage> Images { get; set; }
  }
}