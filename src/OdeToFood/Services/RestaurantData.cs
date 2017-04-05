using OdeToFood.Entities;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant newRestaurant);
        void Commit();
        Task<IEnumerable<Restaurant>> SearchByName(string searchString);
    }

    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _context.Add(newRestaurant);
            return newRestaurant;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants;
        }

        public async Task<IEnumerable<Restaurant>> SearchByName(string searchString)
        {
            var restaurants = from r in _context.Restaurants
                              select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                restaurants = restaurants.Where(r => r.Name.Contains(searchString));
            }
            return await restaurants.ToListAsync();
        }
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        static List<Restaurant> _restaurants;

        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name="Chipotle" },
                new Restaurant {Id = 2, Name="Swensons" },
                new Restaurant {Id = 3, Name="Winking Lizard" }
            };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public void Commit()
        {
            // no op
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public async Task<IEnumerable<Restaurant>> SearchByName(string searchString)
        {
            return null;
        }
    }
}
