using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EOTC.Boston.MedhaneAlem.Common.Common;
namespace EOTC.Boston.MedhaneAlem.WebUI.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Send(string RoleTypes)
        {
            string dirToUpload = string.Empty;
            RoleType m = new RoleType();

            if (RoleTypes == "1")
            {
                dirToUpload = "MemberAudio";
            }
            else if (RoleTypes == "2")
            {
                dirToUpload = "MemberVideo";
            }
            else
            {
                dirToUpload = "Default";
            }

            if (!string.IsNullOrEmpty(dirToUpload))
            {
                if (dirToUpload.Equals("MemberAudio"))
                {
                    return RedirectToAction("FileUploadMemberAudios", "Account"); 
                                            
                }
                else if (dirToUpload.Equals("MemberVideo"))
                {
                    return RedirectToAction("FileUploadMemberVideos", "Account");
                }
                else
                { //default
                    return RedirectToAction("FileUpload","Account");
                }
            }
            return RedirectToAction("Login", "Account");
        }
    }
}