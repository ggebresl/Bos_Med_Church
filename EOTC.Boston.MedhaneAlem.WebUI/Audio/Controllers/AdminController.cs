using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EOTC.Boston.MedhaneAlem.BuisnessLogic.Interfaces;
using EOTC.Boston.MedhaneAlem.Common.Logging;
using EOTC.Boston.MedhaneAlem.DataLayer;
//[assembly: log4net.Config.XmlConfigurator(Watch=true)]
namespace EOTC.Boston.MedhaneAlem.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
       private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      //  private static readonly log4net.ILog log = LogHelper.GetLogger();
        private readonly IMemberRepository repository;
        public AdminController(IMemberRepository repo)
        {
            repository = repo;
        }
         public ActionResult Index()
        {
            //log.Info("This is my info message");
            //log.Debug("This is my info Debug message");
            //log.Warn("This is my info Warnig message");
            //log.Error("This is my info Error message");
          
            return View(repository.Members);
        }
        
        public ViewResult Create()
        {
            return View(new Member());
        }
        //Create a new Member. Please note that you need RoleId from the table Role in order to create a new Member
        [HttpPost]
        public ActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                repository.SaveMember(member);
                TempData["message"] = string.Format("The record Of {0} has been Created!", member.FirstName);
                return RedirectToAction("Index");
            }
            else
            {
                //somethig is wrong with the data values
                return View(member);
            }
        }

        public ViewResult Edit(int memberID)
        {
            Member member = repository.Members.FirstOrDefault(m => m.MemberId == memberID);
            return View(member);
        }

        [HttpPost]
        public ActionResult Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                repository.SaveMember(member);
                TempData["message"] = string.Format(" The record Of {0} has been edited or saved!", member.FirstName);
                return RedirectToAction("Index");
            }
            else
            {
                //somethig is wrong with the data values
                return View(member);
            }
        }

        [HttpPost]
        public ActionResult Delete(int memberId)
        {
            Member deletedMember = repository.DeleteMember(memberId);

            if (deletedMember != null)
            {

                TempData["message"] = string.Format("The record Of {0} has been deleted!", deletedMember.FirstName);
                
            }
            return RedirectToAction("Index");
        }      
    }
}