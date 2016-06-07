using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseWebSite.Controllers
{
    public class CommonController : Controller
    {
        //
        // GET: /Common/

      

		 
		public ActionResult ShowValidateCode()
		{
			EnterpriseWebSite.Tools.ValidateCode validateCode = new Tools.ValidateCode();
			string code = validateCode.CreateValidateCode(4);
			Session["code"] = code;
			byte[] buffer = validateCode.CreateValidateGraphic(code);
			return File(buffer, "image/jpeg");

		}

    }
}
