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
        // defining List<NameModel> to be accessable over all methods in the controller
        private List<NameModel> nameList = new List<NameModel>();
        // definig variables to be accessable over all methods to store the choices of gender, type, and limit
        private static NameGender ctrlGender;
        private static NameType ctrlType;
        private static int ctrlLimit;

        // GET: Name
        [HttpGet]
        public ActionResult Index()
        {
            // starting limit of 10 names with NameType=Both and NameGender=Both
            int limit = 10;
            // Getting the list from the NameAPI library
            nameList = NameService.GetNameList(limit);
            return View(nameList);
        }

        // Reload action method to retrun list of names with specified params
        [HttpPost]
        public ActionResult Reload(NameGender gender, NameType type, int limit)
        {
            // storing the choises in the predefined variables
            ctrlGender = gender;
            ctrlType = type;
            ctrlLimit = limit;
            
            // Getting the list from the NameAPI library
            nameList = NameService.GetNameList(type, gender, limit);
            return View("Index",nameList);
        }
        // Method to handle the data from the variables and adding new partial views with Ajax
        [HttpPost]
        public ActionResult AjaxReload()
        {
            nameList = NameService.GetNameList(ctrlType, ctrlGender, ctrlLimit);
            return PartialView("_AjaxView", nameList);
        }
    }
}