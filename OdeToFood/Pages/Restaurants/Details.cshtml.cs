using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood_ClassLib;
using OdeToFoodData;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        public Restaurant Restaurant { get; set; }
        private IRestaurantData RestaurantData {get; set;}
        public DetailsModel(IRestaurantData restaurantData)
        {
            RestaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = RestaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null) return RedirectToPage("./NotFound");
            else return Page();

        }
    }
}
