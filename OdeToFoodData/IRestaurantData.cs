using OdeToFood_ClassLib;
using System;
using System.Collections.Generic;

namespace OdeToFoodData
{
    public interface IRestaurantData
    {
        List<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant Update(Restaurant updatedRes);
        Restaurant Add(Restaurant addedRestaurant);
        int Commit();
    }
    public class InMemoData : IRestaurantData
    {
        List<Restaurant> restaurants;
       
        public InMemoData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant() {Id=1, Name="Pizza Hot", Location="Maadi", Cuisine=Cuisine.Egyption},
                new Restaurant() {Id=2, Name="Chanihai", Location="yokhani", Cuisine=Cuisine.Chineese},
                new Restaurant() {Id=1, Name="Pizza", Location="Maadi", Cuisine=Cuisine.Egyption}

            };
        }

        public Restaurant Add(Restaurant addedRestaurant)
        {
            restaurants.Add(addedRestaurant);
            return addedRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.Find(res => res.Id == id);
        }

        public List<Restaurant> GetRestaurantsByName(string name)
        {
            if (name != null)
                return restaurants.FindAll(res => res.Name.StartsWith(name));
            else return restaurants;
        }

        public Restaurant Update(Restaurant updatedRes)
        {
            Restaurant restaurant = restaurants.Find(res => res.Id == updatedRes.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRes.Name;
                restaurant.Location = updatedRes.Location;
                restaurant.Cuisine = updatedRes.Cuisine;
            }
            return restaurant;
        }
    }
}
