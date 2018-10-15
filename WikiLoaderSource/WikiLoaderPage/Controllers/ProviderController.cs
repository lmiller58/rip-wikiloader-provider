using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WikiLoaderPage.Controllers
{
    public class ProviderController : Controller
    {
        // GET: WikiLoaderProvider
        public ActionResult Settings()
        {
            return View();
        }
    }
}