using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EOTC.Boston.MedhaneAlem.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

           // Application["Totaluser"] = 0;
            
        }
        //protected void Session_Start()
        //{
        //    Application.Lock();
        //    Application["Totaluser"] = (int)Application["Totaluser"] + 1;
        //    Application.UnLock();
        //} 
      }
  //  <p>Total Number of visitors: @ApplicationInstance.Application["Totaluser"]</p>
}
