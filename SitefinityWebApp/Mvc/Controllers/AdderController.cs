// SitefinityWebapp\Mvc\Controllers\AdderController.cs

using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "Adder", Title = "Adder", SectionName = "CustomMvcWidgets")]
    public class AdderController : Controller
    {
        // GET: Adder
        public ActionResult Index()
        {
            int sum = 2 + 3;

            return View("Index", sum);
        }
        
        protected override void HandleUnknownAction(string actionName)
        {
            this.Index().ExecuteResult(this.ControllerContext);
        }
    }
}