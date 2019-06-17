﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace EOTC.Boston.MedhaneAlem.WebUI.Controllers
{
    public class KidaseController : Controller
    {
        // GET: Kidase
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [ActionName("GetListOfKidases")]
        public JsonResult GetListOfKidases()
        {
            string[] audioFiles;

            try
            {
                var path = Server.MapPath("~/Kidase/");

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
                        //files[count] = file.Remove(0, path.Length);
                        files[count] = file.Remove(0, path.Length - 7);
                        count++;
                    }
                    return Json(files, JsonRequestBehavior.AllowGet);
                    //TempData["message"] = videoFiles;
                    //return Json(audioFiles, JsonRequestBehavior.AllowGet);

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