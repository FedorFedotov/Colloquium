using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SISPU.Models;

namespace SISPU.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// Returns all FeebackFields.
        /// </summary>
        /// <returns>Json file with all difficulties</returns>
        [HttpGet("/api/we")]
        public string[] GetAllInterviews()
        {           

            return new string[] { "2", "2"};
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "1111111111111111111111111111111111111111111111111111111111";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
