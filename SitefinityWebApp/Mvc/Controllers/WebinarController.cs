// SitefinityWebapp\Mvc\Controllers\WebinarController.cs

using SitefinityWebApp.Mvc.Models;
using System;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Title = "Webinar", Name = "Webinar", SectionName = "CustomMvcWidgets")]
    public class WebinarController : Controller
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string SelectedItem { get; set; }

        public ActionResult Index()
        {
            WebinarModel model = new WebinarModel();
            model.Title = this.Title;
            model.Description = this.Description;
            model.Start = this.Start;
            model.End = this.End;

            return View(model);
        }
    }
}