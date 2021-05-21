namespace BestRestaurants.Models
{
  public class RestaurantImage
  {
    public int Id { get; set; }
    public int RestaurantId { get; set; }

    public byte[] Image { get; set; }
    public string ImageString { get; set; }
  }
}