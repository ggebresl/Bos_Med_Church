using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EOTC.Boston.MedhaneAlem.WebUI.Models
{
    public class Files
    {
        public IEnumerable<HttpPostedFileBase> FilesToLoad { get; set; }
    }
}