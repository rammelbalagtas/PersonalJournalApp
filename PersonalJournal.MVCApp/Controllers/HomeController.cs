using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PersonalJournal.Models.Models;
using PersonalJournal.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PersonalJournal.MVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            string baseUrl = "https://nodejs-quoteapp.herokuapp.com/quote/3";
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(baseUrl);
                var jsonString = response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null;
                var quoteList = JsonConvert.DeserializeObject<Quote>(jsonString);
                return View(quoteList);
            }
            catch
            {
                return null;
            }
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
