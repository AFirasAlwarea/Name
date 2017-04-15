using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NameAPI.Models;
using NameAPI;

namespace Capo.Controllers
{
    public class NameController : Controller
    {
        private List<NameModel> nameList = new List<NameModel>();
        // GET: Name
        public ActionResult Index()
        {
            int limit = 1;
            nameList = NameService.GetNameList(limit);
            return View(nameList);
        }

        // POST: Name
        public ActionResult Reload()
        {
            return View();
        }
    }
}