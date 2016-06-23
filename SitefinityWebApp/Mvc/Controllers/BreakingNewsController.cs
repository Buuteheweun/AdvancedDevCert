using SitefinityWebApp.Mvc.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Modules.News;
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

            if(this.BreakingNewsMessage.IsNullOrEmpty())
            {
                var newsManager = ObjectFactory.Resolve<ManagerFactory<NewsManager>>().GetManager();
                var newsItem = newsManager.GetNewsItems().FirstOrDefault();
                model.BreakingNewsMessage = newsItem.Title;
            }
            else
            {
                model.BreakingNewsMessage = this.BreakingNewsMessage;
            }            

            return View(model);
        }
    }
}