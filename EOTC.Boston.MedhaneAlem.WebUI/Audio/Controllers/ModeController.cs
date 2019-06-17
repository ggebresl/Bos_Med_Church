using EOTC.Boston.MedhaneAlem.Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//http://www.aspnetmvcninja.com/views/asp-net-mvc-select-list-example
namespace EOTC.Boston.MedhaneAlem.WebUI.Controllers
{
    public class ModeController : Controller
    {

        private string GetServiceTyep(string serviceTypes)
        {
            string service = string.Empty;
            switch (serviceTypes)
            {
                case "1":
                    service = "Audio";
                    break;
                case "2":
                    service = "Kidase";
                    break;
                case "3":
                    service = "Kebero";
                    break;
                case "4":
                    service = "Mezmur";
                    break;
                case "5":
                    service = "Sibket";
                    break;
                case "6":
                    service = "Wereb";
                    break;
                case "7":
                    service = "Zmare";
                    break;
                default:
                    service = "Video";
                    break;
            }
            return service;
        }
        public ActionResult Index()
        {
            //You can get this from Db, but this is demo, so use hard code values for the time being
            //List<Mediatype> mediaTypes  = new List<Mediatype>
            //{
            // new Mediatype() { Id = 1, Flag ="Audio"},
            // new Mediatype() { Id = 2, Flag = "Video"}
            //};
            //ViewBag.MedaTypeNames = mediaTypes;
           
            return View();
        }
        [HttpPost]
        public ActionResult Play(string ServiceTypes)
        {
            //string.string service = string.Empty;
            Mediatype service = new Mediatype();
            
            service.Flag = GetServiceTyep(ServiceTypes);
            if (!string.IsNullOrEmpty(service.Flag))
            {
                if (service.Flag.Equals("Video"))
                {
                    return RedirectToAction("GetListOfMemberVideos", "Account");
                }
                else
                {
                    return RedirectToAction("GetListOfMemberAudios", "Account", service);
                }
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
