using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BestRestaurants.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;



namespace BestRestaurants.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public RestaurantsController(BestRestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Restaurant> model = _db.Restaurants.Include(restaurant => restaurant.Cuisine).ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {

      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Upload", new { id = restaurant.Id });
    }

    public ActionResult Upload(int id)
    {

      ViewBag.thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.Id == id);
      return View();
    }

    [HttpPost]
    public ActionResult Upload(IFormFile file, int id)
    {
      Console.Write(id);
      using (var ms = new MemoryStream())
      {
        file.CopyTo(ms);
        var fileBytes = ms.ToArray();
        RestaurantImage newImage = new RestaurantImage();
        string s = Convert.ToBase64String(fileBytes);
        newImage.ImageString = s;
        newImage.RestaurantId = id;
        _db.Images.Add(newImage);
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }


    public ActionResult Details(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.Id == id);
      ViewBag.Cuisine = thisRestaurant.Cuisine;
      return View(thisRestaurant);
    }

    public ActionResult Edit(int id)
    {
      var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.Id == id);
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant)
    {
      _db.Entry(restaurant).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.Id == id);
      return View(thisRestaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.Id == id);
      _db.Restaurants.Remove(thisRestaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }

}



