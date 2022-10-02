using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication4.Models;
using System.Text.Json;
using System.Web.Helpers;
using System.IO;

namespace WebApplication4.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
       
        public ActionResult Result(int number)
        {
            string[] resultString;
            StreamReader sr = new StreamReader("textPage.txt");
            List<Number> numbers = new List<Number>();
            for (int i = 0; i <= number; i++)
            {
                resultString = sr.ReadLine().Split(' ');
                numbers.Add(new Number(resultString[0], resultString[1], resultString[2], Convert.ToInt64(resultString[3]), resultString[4], resultString[5]));

            }

            sr.Close();
            StreamWriter srt = new StreamWriter("textPage1.txt");
            srt.WriteLine(numbers[number]);
            srt.Close();
            
           

            return Json(numbers[number].ReturnArray());
        }
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ConcreateId()
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
