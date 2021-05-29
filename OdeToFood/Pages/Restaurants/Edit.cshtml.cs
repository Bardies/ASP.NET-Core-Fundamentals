using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood_ClassLib;
using OdeToFoodData;

namespace OdeToFood.Pages
{
    public class EditModel : PageModel
    {
        public IRestaurantData RestaurantData { get; set; }
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        [TempData]
        public string Message { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public IHtmlHelper htmlHelper { get; set; }
        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper1)
        {
            RestaurantData = restaurantData;
            htmlHelper = htmlHelper1;
        }


        //On editing we will make req. to server as get req to fetch restaurant data we want to edit
        //And the 2nd one will post request to edit the data
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<Cuisine>();
            if (restaurantId != null)
            {
                Restaurant = RestaurantData.GetRestaurantById((int)restaurantId);
            }
            else
            {
                Restaurant = new Restaurant();
                Restaurant.Id = 9;
            }
            if (Restaurant == null) { return RedirectToPage("./NotFound"); }
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) {
                //If the data isn't valid we won't update the data but we will render the page..
                //To populate the dropdowm list again after we submit the form
                Cuisines = htmlHelper.GetEnumSelectList<Cuisine>();
                return Page();
            }
            if (Restaurant.Id != 9)
            {
                //As Restaurant is binding prop. => 2 way binding
                Restaurant = RestaurantData.Update(Restaurant);
                TempData["Message"] = "Restaurant Updated";
            }else if (Restaurant.Id == 9)
            {
                RestaurantData.Add(Restaurant);
                TempData["Message"] = "Restaurant Added";
            }
            return RedirectToPage("./Details", new { restaurantId = Restaurant.Id });
        }
    }
}
