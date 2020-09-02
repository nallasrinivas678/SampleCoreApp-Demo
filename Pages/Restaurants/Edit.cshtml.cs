using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.Core.Data;
using Restaurant.Core.Services;
using Service = Restaurant.Core.Services;

namespace SampleCoreApp.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;


        [BindProperty]
        public Service.Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IRestaurantData restaurantData,
                          IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CusineType>();
            Restaurant = restaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null) RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Restaurant = restaurantData.Update(Restaurant);
                restaurantData.Commit();
            }
            Cuisines = htmlHelper.GetEnumSelectList<CusineType>();
            return Page();
        }
    }
}
