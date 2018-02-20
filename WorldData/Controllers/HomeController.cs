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
          List<City> newList = City.GetAll();
          return View(newList);
        }
    }
}
