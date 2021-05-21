using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System;
namespace BestRestaurants.Controllers
{
  public class RestaurantImageController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public RestaurantImageController(BestRestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Create(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.Id == id);
      return View(thisRestaurant);
    }

    [HttpPost]
    public IActionResult Upload(IFormFile file)
    {
      Console.WriteLine(file);
      return Ok();
    }

  }
}