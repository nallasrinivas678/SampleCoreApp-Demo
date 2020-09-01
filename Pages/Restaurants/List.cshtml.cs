using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Restaurant.Core.Data;
using Service = Restaurant.Core.Services;

namespace SampleCoreApp.Pages.Restaurant
{
    public class ListModel : PageModel
    {
       
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        public string Message { get; set; }
        public string ConfigurationMessage { get; set; }
        public IEnumerable<Service.Restaurant> Restaurants { get; set; }

        //Injecting & using configuration services
        public ListModel(IConfiguration config,
                           IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            Message = "Enjoy your meal at these restaurants!!";
            ConfigurationMessage = config["Message"];
            Restaurants = restaurantData.GetAll();
        }
    }
}
