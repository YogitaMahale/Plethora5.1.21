using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using FreeGeoIPCore;
//using MetOfficeDataPoint;
//using MetOfficeDataPoint.Models;
//using MetOfficeDataPoint.Models.GeoCoordinate;
using plathora.pagination;
using Nest;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WeatherController : Controller
    {
        public IActionResult Index1()
        {
            return View();
        }
         
    }
}
