using OdeToFood.Entities;
using System.Collections.Generic;

namespace OdeToFood.ViewModels
{
    public class RestaurantViewModel
    {
        public string CurrentMessage { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
