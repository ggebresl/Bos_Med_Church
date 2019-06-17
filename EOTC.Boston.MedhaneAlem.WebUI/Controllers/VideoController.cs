using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
//using System.Web.Script.Serialization;
namespace EOTC.Boston.MedhaneAlem.WebUI.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        [ActionName("GetListOfVideos")]
        public JsonResult GetListOfVideos()
        {
            string[] videoFiles;

            try
            {
                var path = Server.MapPath("~/Video/");
               // videoFiles = Directory.GetFiles(path, "*.MOV");
                videoFiles = Directory.GetFiles(path, "*.mp4");
                string[] files = new string[videoFiles.Length];
                int count = 0;

                if (videoFiles.Length == 0)
                {
                    TempData["message"] = "Sorry, we do  not have Video recordings yet. Please visit us next time!";
                    return Json(TempData["message"], JsonRequestBehavior.AllowGet);
                }
                else
                {
                    foreach (string file in videoFiles)
                    {
                        //files[count] = file.Remove(0, path.Length);
                        files[count] = file.Remove(0, path.Length - 6);
                        count++;
                    }
                    return Json(files, JsonRequestBehavior.AllowGet);
                   
                }
            }
            catch (Exception ex)
            {
                //log error to database or send email about error to admin
                TempData["message"] = "ERROR:" + ex.Message.ToString();
                return Json(TempData["message"], JsonRequestBehavior.AllowGet);
            }
        }

    }
}