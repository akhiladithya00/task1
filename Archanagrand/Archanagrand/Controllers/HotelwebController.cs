using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Net.Mail;
using System.IO;

using Archanagrand.Models;

namespace Archanagrand.Controllers
{
   
    public class HotelwebController : Controller
    {
        System.Web.Script.Serialization.JavaScriptSerializer jser = new JavaScriptSerializer();
        // GET: Hotelweb
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult about()
        {
            return View();
        }
        public ActionResult data()
        {
            return View();
        }

        public ActionResult data1()
        {
            return View();
        }
        
        public ActionResult Rooms()
        {
            return View();
        }
        [HttpGet]
        public JsonResult getroomslist()
        {
            string URI = connection.getconfigvalue("akhil") + "archanadapi/getrooms";
            var result = connection.HttpGet(URI,"");
            dynamic variable = jser.Deserialize(result, typeof(List<rooms>));
            List<rooms> plst = new List<rooms>();
            if (variable != null)
            {

                plst = variable;

            }
            return Json(plst, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Roominout(string roomnumber)
        {
            Session["roomnumber"]=roomnumber;
            return View();
        }
    }
}