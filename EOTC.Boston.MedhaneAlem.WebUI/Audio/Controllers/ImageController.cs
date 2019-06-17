using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace EOTC.Boston.MedhaneAlem.WebUI.Controllers
{
    public class ImageController : Controller
    {
      
        [HttpGet]
        [ActionName("GetListOfImages")]
        public JsonResult GetListOfImages()
        {
            string[] imageFiles;
            
            try
            {
              var path = Server.MapPath("~/images/2014/12/Large/");        
              imageFiles = Directory.GetFiles(path, "*.jpg");
              string[] files = new string[imageFiles.Length];
              int count = 0;
                if (imageFiles.Length == 0)
                {
                    TempData["message"] = "Sorry, we do  not have images yet. Please visit us next time!";
                    return Json(TempData["message"], JsonRequestBehavior.AllowGet);

                }
                else
                {
                    foreach (string file in imageFiles)
                    {
                        files[count] = file.Remove(0, path.Length);
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