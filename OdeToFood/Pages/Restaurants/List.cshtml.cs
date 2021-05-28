using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood_ClassLib;
using OdeToFoodData;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        //Responds to http get request
        public string Msg { get; set; }

        [BindProperty(SupportsGet =true )]
        public string SearchTerm { get; set; }
        public List<Restaurant> Restaurants { get; set; }
        public IRestaurantData RestaurantData { get; }

        private IConfiguration Configuration;
        public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
        {
            //to use configuration outside the ctor we will use prop.
            Configuration = configuration;
            RestaurantData = restaurantData;
        }

        //get request to this razor page

        public void OnGet()
        {
            Msg = "Hello from the response of get Req.";
            //Msg = Configuration["Message"];
            Restaurants = RestaurantData.GetRestaurantsByName(SearchTerm); 
        }
    }
}
