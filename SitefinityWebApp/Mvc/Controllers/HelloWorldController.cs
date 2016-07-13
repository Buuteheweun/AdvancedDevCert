// SitefinityWebapp\Mvc\Controllers\HelloWorldController.cs

using SitefinityWebApp.Mvc.Models;
using System;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "HelloWorld", Title = "Hello World", SectionName = "CustomMvcWidgets")]
    public class HelloWorldController : Controller
    {
        public ActionResult Index()
        {
            HelloWorldModel model = new HelloWorldModel();
            model.Message = "Hello World!!!";

            return View("Index", model);
        }

        public ActionResult RandomNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next();

            HelloWorldModel model = new HelloWorldModel();
            model.RandomNumber = randomNumber;

            return View("RandomNumber", model);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.Index().ExecuteResult(this.ControllerContext);
        }
    }
}