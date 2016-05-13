using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "BreakingNews", Title = "BreakingNews", SectionName = "CustomMvcWidgets")]
    public class BreakingNewsController : Controller
    {
        public string Date { get; set; }

        public string Message { get; set; }

        public string BreakingNewsMessage { get; set; }

        // GET: BreakingNews
        public ActionResult Index()
        {
            var model = new BreakingNewsModel();
            model.BreakingNewsMessage = this.BreakingNewsMessage;

            return View(model);
        }
    }
}