using Microsoft.VisualStudio.TestTools.UnitTesting;
using SitefinityWebApp.Mvc.Controllers;
using SitefinityWebApp.Mvc.Models;
using SitefinityWebApp.Tests.BreakingNews.Mocks;
using System.Linq;
using System.Web.Mvc;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Modules.News;

namespace SitefinityWebApp.Tests.BreakingNews
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void IndexAction_ProperlySetsMessage_ToModel()
        {
            // Creating an empty unity container
            UnityContainer mockedContainer = new UnityContainer();

            // Registering mocked implementation of NewsManager
            mockedContainer.RegisterType<NewsManager, MyNewsManager>();

            // Run the controller with the empty container we just created
            ObjectFactory.RunWithContainer(mockedContainer, () =>
            {
                BreakingNewsController controller = new BreakingNewsController();

                ViewResult result = controller.Index() as ViewResult;
                BreakingNewsModel breakingNewsModel = result.Model as BreakingNewsModel;

                var manager = ObjectFactory.Resolve<ManagerFactory<NewsManager>>().GetManager();
                string expectedFirstItemTitle = manager.GetNewsItems().First().Title;

                Assert.AreEqual<string>(expectedFirstItemTitle, breakingNewsModel.BreakingNewsMessage);
            });            
        }
    }
}