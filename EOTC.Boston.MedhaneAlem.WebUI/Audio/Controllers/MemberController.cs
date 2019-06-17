using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using EOTC.Boston.MedhaneAlem.Common.Common;
using System.Web.Hosting;
using EOTC.Boston.MedhaneAlem.DataLayer;
namespace EOTC.Boston.MedhaneAlem.WebUI.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        [ActionName("GetListOfMemberVideos")]
        public ActionResult GetListOfMemberVideos(UserLogin model)
        // public JsonResult GetListOfVideos()
        {
            string[] videoFiles;
           
           
            List<VideoFile> videoLists = new List<VideoFile>();
             
            try
            {
                if (model.UserID != null && model.Password != null)
                {
                   // var videoFilePath = HostingEnvironment.MapPath("~/MemberVideo/IMG_0031.mp4"); 
                    var path = Server.MapPath("~/MemberVideo/");
                    // videoFiles = Directory.GetFiles(path, "*.MOV");
                    videoFiles = Directory.GetFiles(path, "*");
                    string[] files = new string[videoFiles.Length];
                    int count = 0;

                    if (videoFiles.Length == 0)
                    {
                        TempData["message"] = "Sorry, we do  not have video recordings yet. Please visit next time!";
                        return Json(TempData["message"], JsonRequestBehavior.AllowGet);
                        // return View(TempData["message"]);
                    }
                    else
                    {
                        foreach (string file in videoFiles)
                        {
                            VideoFile videoFile = new VideoFile();
                            videoFile.FileName = file.Remove(0, path.Length - 12);

                            videoLists.Add(videoFile);
                          
                            count++;
                        }
                        TempData["message"] = videoLists;
                        return View(videoLists);      
                    }
                }
                else
                {

                    return RedirectToAction("Login", "Account");

                   // return RedirectToAction("GetListOfVideos", "Member", model);
                }
            }
            catch (Exception ex)
            {
                //log error to database or send email about error to admin
                TempData["message"] = "ERROR:" + ex.Message.ToString();
               // return Json(TempData["message"], JsonRequestBehavior.AllowGet);
                 return View(TempData["message"]);
            }
        }

    }
}
    