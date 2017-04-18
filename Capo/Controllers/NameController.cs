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
        private static NameGender ctrlGender;
        private static NameType ctrlType;
        private static int ctrlLimit;

        // GET: Name
        [HttpGet]
        public ActionResult Index()
        {
            int limit = 10;
            nameList = NameService.GetNameList(limit);
            return View(nameList);
        }

        // Reload action method to retrun list of names with specified params
        [HttpPost]
        public ActionResult Reload(NameGender gender, NameType type, int limit)
        {
            ctrlGender = gender;
            ctrlType = type;
            ctrlLimit = limit;
            nameList = NameService.GetNameList(type, gender, limit);
            return View("Index",nameList);
        }

        [HttpPost]
        public ActionResult AjaxReload()
        {
            nameList = NameService.GetNameList(ctrlType, ctrlGender, ctrlLimit);
            return PartialView("_AjaxView", nameList);
        }
    }
}