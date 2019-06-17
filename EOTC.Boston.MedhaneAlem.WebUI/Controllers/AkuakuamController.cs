using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace EOTC.Boston.MedhaneAlem.WebUI.Controllers
{
    public class AkuakuamController : Controller
    {
        // GET: Akuakuam
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [ActionName("GetListOfAkuakuams")]
        public JsonResult GetListOfAkuakuams()
        {
            string[] audioFiles;
            try
            {
                var path = Server.MapPath("~/Akuakuam/");
                audioFiles = Directory.GetFiles(path, "*.mp3");

                string[] files = new string[audioFiles.Length];
                int count = 0;

                if (audioFiles.Length == 0)
                {
                    TempData["message"] = "Sorry, we do  not have Kidase recordings yet. Please visit next time!";
                    return Json(TempData["message"], JsonRequestBehavior.AllowGet);
                }
                else
                {
                    foreach (string file in audioFiles)
                    { 
                        files[count] = file.Remove(0, path.Length - 9);
                        count++;
                    }
                    return Json(files, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "ERROR:" + ex.Message.ToString();
                return Json(TempData["message"], JsonRequestBehavior.AllowGet);
            }
        }
    }
}