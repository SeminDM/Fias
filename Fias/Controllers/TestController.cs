using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fias.Controllers
{
    [Route("Test")]
    public class TestController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("GetParams", Name = "Params")]
        public IActionResult GetParams(string str, DateTime date)
        {
            var p = str + date.ToLongDateString();
            return View((object)p);
        }
    }
}