using EOTC.Boston.MedhaneAlem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EOTC.Boston.MedhaneAlem.BuisnessLogic.Interfaces;
using System.Web.Security;
using System.Web.Security.Cryptography;
using System.IO;
using EOTC.Boston.MedhaneAlem.Common.Common;
using System.Web.Hosting;
using EOTC.Boston.MedhaneAlem.DataLayer;
//using System.Web.Script.Serialization;
namespace EOTC.Boston.MedhaneAlem.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private string GetDirecotryName(string service)
        {
            string pathName = string.Empty;
            if (!string.IsNullOrEmpty(service))
                {
                    if (service.Equals("Kidase"))
                    {
                        pathName = Server.MapPath("~/MemberKidase/");
                    }
                    else if (service.Equals("Kebero"))
                    {
                        pathName = Server.MapPath("~/MemberKebero/");
                    }
                    else if (service.Equals("Mezmur"))
                    {
                        pathName = Server.MapPath("~/MemberMezmur/");
                    }
                    else if (service.Equals("Sibket"))
                    {
                        pathName = Server.MapPath("~/MemberSibket/");
                    }
                    else if (service.Equals("Wereb"))
                    {
                        pathName = Server.MapPath("~/MemberWereb/");
                    }
                    else if (service.Equals("Zmare"))
                    {
                        pathName = Server.MapPath("~/MemberZmare/");
                    }
                    else
                    {
                        pathName = Server.MapPath("~/MemberAudio/");
                    }
                }
            return pathName;
        }

        IAuthentication athentication;
        public AccountController(IAuthentication authentication)
        {
            this.athentication = authentication;
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserLogin model, string returnUrl, string Flag)
        {
            var userID = model.UserID;
            var passWord = model.Password;
            UserLogin returnedResult;
            Member memResult;
            Role roleRsult;

            if (ModelState.IsValid)
            {
                try
                {
                    if (athentication.Authenticate(model.UserID, model.Password, out returnedResult, out memResult, out roleRsult))
                    {
                        if (returnedResult.UserID.Equals(model.UserID) &&
                            returnedResult.Password.Equals(model.Password) && roleRsult.Name.Equals("Upload"))
                        {
                            //Determine role type (member or public/default)
                            FormsAuthentication.SetAuthCookie(model.UserID, false);
                            return RedirectToAction("Index", "Role");
                          //  return RedirectToAction("FileUpload");
                        }
                            //Check if user is allowed to view restricted  data
                        else if (returnedResult.UserID.Equals(model.UserID) &&
                            returnedResult.Password.Equals(model.Password) && roleRsult.Name.Equals("Default"))
                         {
                            FormsAuthentication.SetAuthCookie(model.UserID, false);
                            //If Member is logged in to learn Ethiopian Liturgy using Audio/Video them check mediaFlag 
                            return RedirectToAction("Index", "Mode");
                         }

                        else
                        {
                            FormsAuthentication.SetAuthCookie(model.UserID, false);
                            return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect UserName or Password");
                        return View();
                    }
                }
                catch (Exception ex)
                {
                    TempData["message"] = "ERROR:" + ex.Message.ToString();
                    return View();
                }
            }
            else
            {
                return View();
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
          //  return RedirectToAction("Index", "Admin");
            //return Redirect("http://localhost/bostonmedhanealem/Index.html");
            return Redirect("http://localhost:59816/Index.html");
            
        }
         
        public ActionResult ChangePassword()
        {
            return View();
        }
         
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ChangePassword(UserLogin model)
        {
            return View(model);
        }
        public ActionResult FileUpload()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
       
        public ActionResult FileUpload(Files files)
        {
            string path = string.Empty;
            int filesCount = 0;
            foreach (var file in files.FilesToLoad)
            {
                if (file != null && file.ContentLength > 0)
                {
                    try
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        if (fileName.Trim().ToUpper().StartsWith("AUDIO")) 
                        {
                           path = Path.Combine(Server.MapPath("~/Audio"), fileName);
                        }
                        if (fileName.Trim().ToUpper().StartsWith("KEBERO")) 
                        {
                           path = Path.Combine(Server.MapPath("~/Kebero"), fileName);
                        }
                        if (fileName.Trim().ToUpper().StartsWith("KIDASE")) 
                        {
                           path = Path.Combine(Server.MapPath("~/Kidase"), fileName);
                        }
                        if (fileName.Trim().ToUpper().StartsWith("MEZMUR")) 
                        {
                           path = Path.Combine(Server.MapPath("~/Mezmur"), fileName);
                        }
                        if (fileName.Trim().ToUpper().StartsWith("SIBKET")) 
                        {
                           path = Path.Combine(Server.MapPath("~/Sibket"), fileName);
                        }
                        if (fileName.Trim().ToUpper().StartsWith("VIDEO")) 
                        {
                           path = Path.Combine(Server.MapPath("~/Video"), fileName);
                        }
                        if (fileName.Trim().ToUpper().StartsWith("WEREB")) 
                        {
                           path = Path.Combine(Server.MapPath("~/Wereb"), fileName);
                        }
                        if (fileName.Trim().ToUpper().StartsWith("ZMARE")) 
                        {
                           path = Path.Combine(Server.MapPath("~/Zmare"), fileName);
                        }
                        file.SaveAs(path);
                        filesCount++;
                    }
                    catch (Exception ex)
                    {
                        TempData["message"] = "ERROR:" + ex.Message.ToString();
                    }
                }
                else
                {
                    TempData["message"] = "You have not specified a file.";
                }
             }

            TempData["message"] = string.Format("{0} Files has been successfully uploaded to the Server!", filesCount);
            return View();
        }

        public ActionResult FileUploadMemberAudios()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        
        public ActionResult FileUploadMemberAudios(Files files)
        {
            string path = string.Empty;
            int filesCount = 0;
            foreach (var file in files.FilesToLoad)
            {
                if (file != null && file.ContentLength > 0)
                {
                    try
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        if (fileName.Trim().ToUpper().StartsWith("AUDIO"))
                        {
                            path = Path.Combine(Server.MapPath("~/MemberAudio"), fileName);
                        }
                        if (fileName.Trim().ToUpper().StartsWith("KEBERO"))
                        {
                            path = Path.Combine(Server.MapPath("~/MemberKebero"), fileName);
                        }
                        if (fileName.Trim().ToUpper().StartsWith("KIDASE"))
                        {
                            path = Path.Combine(Server.MapPath("~/MemberKidase"), fileName);
                        }
                        if (fileName.Trim().ToUpper().StartsWith("MEZMUR"))
                        {
                            path = Path.Combine(Server.MapPath("~/MemberMezmur"), fileName);
                        }
                        if (fileName.Trim().ToUpper().StartsWith("SIBKET"))
                        {
                            path = Path.Combine(Server.MapPath("~/MemberSibket"), fileName);
                        }
                        if (fileName.Trim().ToUpper().StartsWith("WEREB"))
                        {
                            path = Path.Combine(Server.MapPath("~/MemberWereb"), fileName);
                        }
                        if (fileName.Trim().ToUpper().StartsWith("ZMARE"))
                        {
                            path = Path.Combine(Server.MapPath("~/MemberZmare"), fileName);
                        }
                        file.SaveAs(path);
                        filesCount++;
                    }
                    catch (Exception ex)
                    {
                        TempData["message"] = "ERROR:" + ex.Message.ToString();
                    }
                }
                else
                {
                    TempData["message"] = "You have not specified a file.";
                }
            }

            TempData["message"] = string.Format("{0} Files has been successfully uploaded to the Server!", filesCount);
            return View();
        }

        public ActionResult FileUploadMemberVideos()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult FileUploadMemberVideos(Files files)
        {
            string path = string.Empty;
            int filesCount = 0;
            foreach (var file in files.FilesToLoad)
            {
                if (file != null && file.ContentLength > 0)
                {
                    try
                    {
                        var fileName = Path.GetFileName(file.FileName);
       
                        path = Path.Combine(Server.MapPath("~/MemberVideo"), fileName);
                        file.SaveAs(path);
                        filesCount++;
                    }
                    catch (Exception ex)
                    {
                        TempData["message"] = "ERROR:" + ex.Message.ToString();
                    }
                }
                else
                {
                    TempData["message"] = "You have not specified a file.";
                }
            }

            TempData["message"] = string.Format("{0} Files has been successfully uploaded to the Server!", filesCount);
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetListOfMemberAudios(Mediatype  service)
        {
            string[] audioFiles;
            List<AudioFile> audioLists = new List<AudioFile>();

            try
            {
                
                   // var path = Server.MapPath("~/MemberAudio/");
                    var path = GetDirecotryName(service.Flag);
                    audioFiles = Directory.GetFiles(path, "*.mp3");
                    string[] files = new string[audioFiles.Length];
                    int count = 0;

                    if (audioFiles.Length == 0)
                    {
                        TempData["message"] = "Sorry, we do  not have audio recordings yet. Please visit us next time!";
                        return Json(TempData["message"], JsonRequestBehavior.AllowGet);
                        // return View(TempData["message"]);
                    }
                    else
                    {
                        foreach (string file in audioFiles)
                        {
                            AudioFile audioFile = new AudioFile();
                         //   audioFile.FileName = file.Remove(0, path.Length - 13);
                           audioFile.FileName = file;
                            audioLists.Add(audioFile);    
                            count++;
                        }
                       // TempData["message"] = audioLists;
                        return View(audioLists);
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

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetListOfMemberVideos()
        {
            string[] videoFiles;

            List<VideoFile> videoLists = new List<VideoFile>();

            try
            {
                    var path = Server.MapPath("~/MemberVideo/");
                    // videoFiles = Directory.GetFiles(path, "*.MOV");
                    videoFiles = Directory.GetFiles(path, "*.mp4");
                    string[] files = new string[videoFiles.Length];
                    int count = 0;

                    if (videoFiles.Length == 0)
                    {
                        TempData["message"] = "Sorry, we do  not have video recordings yet. Please visit us next time!";
                        return Json(TempData["message"], JsonRequestBehavior.AllowGet);
                        // return View(TempData["message"]);
                    }
                    else
                    {
                        foreach (string file in videoFiles)
                        {
                            VideoFile videoFile = new VideoFile();
                            videoFile.FileName =   file.Remove(0, path.Length - 0);
                         
                            videoLists.Add(videoFile);
                           
                            count++;
                        }
       
                        return View(videoLists);    
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
        public JsonResult GetListOfVideos()
        {
            string[] videoFiles;

            try
            {
                var path = Server.MapPath("~/Video");
                videoFiles = Directory.GetFiles(path, "*.MOV");

                if (videoFiles.Length == 0)
                {
                    TempData["message"] = "Sorry, we do  not have video recordings yet. Please visit is next time!";
                    return Json(TempData["message"], JsonRequestBehavior.AllowGet);
                }
                else
                {
                    TempData["message"] = videoFiles;
                    return Json(TempData["message"], JsonRequestBehavior.AllowGet);
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