using Microsoft.AspNetCore.Mvc;
using WorldDataProgram.Models;
using System.Collections.Generic;

namespace WorldDataProgram.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
          return View();
        }
        [HttpPost("/")]
        public ActionResult GetPopulation()
        {
          int cityPopulation = int.Parse(Request.Form["population"]);
          List<City> newList = City.GetMostPopulous(cityPopulation);
          return View("Index", newList);
        }
    }
}
