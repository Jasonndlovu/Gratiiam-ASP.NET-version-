using Gratiiam_ASP.NET_version_.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Gratiiam_ASP.NET_version_.Models.Gratiiam_ASP.NET_version_.Models;

namespace Gratiiam_ASP.NET_version_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        string baseURL = "https://rest-api-cyyo.onrender.com/api/v1/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
			//callinig the web API and populating the data in view using data table
			
			using (var client = new  HttpClient())
            {
                client.BaseAddress=new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage getcategories = await client.GetAsync("categories");
				HttpResponseMessage getfeatured = await client.GetAsync("products/get/featured/4");

                if(getfeatured.IsSuccessStatusCode && getcategories.IsSuccessStatusCode)
                {
                    Console.WriteLine("API call sucsessfull");

                    string featuredResults = getfeatured.Content.ReadAsStringAsync().Result;
					string categoriesResults = getcategories.Content.ReadAsStringAsync().Result;


					List<featuredProduct> featuredProducts = JsonConvert.DeserializeObject<List<featuredProduct>>(featuredResults);
					List<Models.Category> categories = JsonConvert.DeserializeObject<List<Models.Category>>(categoriesResults);

					var viewModel = new homePageClasses { Categories = categories, FeaturedProducts = featuredProducts };
					return View(viewModel);
                }
                else
                {
                    Console.WriteLine("Error when calling API");
                }

            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}