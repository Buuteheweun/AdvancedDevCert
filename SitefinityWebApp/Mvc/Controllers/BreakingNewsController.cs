// SitefinityWebapp\Mvc\Controllers\BreakingNewsController.cs

using SitefinityWebApp.Localization;
using SitefinityWebApp.Mvc.Models;
using SitefinityWebApp.Wrappers;
using System.Linq;
using System.Web.Mvc;
//using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Modules.News;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [Localization(typeof(BreakingNewsResources))]
    [ControllerToolboxItem(Title = "Breaking News", Name = "BreakingNews", SectionName = "CustomMvcWidgets")]
    public class BreakingNewsController : Controller
    {
        public BreakingNewsController(INewsManagerWrapper newsManagerWrapper)
        {
            this.newsManager = newsManagerWrapper.GetManager();
        }

        // Directrly injecting a manager - not the best practice
        //public BreakingNewsController(NewsManager newsManager)
        //{
        //    this.newsManager = newsManager;
        //}

        // Default constructor, used with service locator pattern
        //public BreakingNewsController()
        //{
        //}

        public string Date { get; set; }

        public string Message { get; set; }        

        public string BreakingNewsMessage { get; set; }

        public string SelectedItem { get; set; }

        public ActionResult Index()
        {
            // Service Locator pattern
            // NewsManager newsManager = ObjectFactory.Resolve<NewsManager>("OpenAccessDataProvider".ToUpperInvariant());
            // var firstNewsItem = newsManager.GetNewsItems().FirstOrDefault();

            var firstNewsItem = this.newsManager.GetNewsItems().FirstOrDefault();

            BreakingNewsModel model = new BreakingNewsModel();
            model.Message = firstNewsItem.Title;

            return View(model);
        }

        private NewsManager newsManager;
    }
}