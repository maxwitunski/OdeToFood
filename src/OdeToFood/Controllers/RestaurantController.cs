using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Services;
using OdeToFood.ViewModels;
using OdeToFood.Entities;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OdeToFood.Controllers
{
    public class RestaurantController : Controller
    {

        private IRestaurantData _restaurantData;

        public RestaurantController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public async Task<IActionResult> Index(string id)
        {
            var model = new RestaurantViewModel();

            if (!String.IsNullOrEmpty(id))
            {
                model.Restaurants = await _restaurantData.SearchByName(id);
            }
            else
            {
                model.Restaurants = _restaurantData.GetAll();
            }
            string msg = String.Format("{0} results found.", model.Restaurants.Count());
            model.CurrentMessage = msg;
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RestaurantEditViewModel model)
        {
            var restaurant = _restaurantData.Get(id);
            if (ModelState.IsValid)
            {
                restaurant.Cuisine = model.Cuisine;
                restaurant.Name = model.Name;
                _restaurantData.Commit();

                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant();
                newRestaurant.Cuisine = model.Cuisine;
                newRestaurant.Name = model.Name;
                newRestaurant = _restaurantData.Add(newRestaurant);
                _restaurantData.Commit();

                return RedirectToAction("Details", new { id = newRestaurant.Id });
            }
            return View();
        }
    }
}
