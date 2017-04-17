using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TecoBerBP.Models.Test;

namespace TecoBerBP.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            var IndexVM = new IndexVM();
            return View(IndexVM);
        }
    }
}