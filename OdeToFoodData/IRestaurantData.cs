using OdeToFood_ClassLib;
using System;
using System.Collections.Generic;

namespace OdeToFoodData
{
    public interface IRestaurantData
    {
        List<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);

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
    }
}
