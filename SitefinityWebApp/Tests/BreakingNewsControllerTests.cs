// SitefinityWebApp\Tests\BreakingNewsControllerTests.cs

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SitefinityWebApp.Mvc.Controllers;
using SitefinityWebApp.Mvc.Models;
using SitefinityWebApp.Tests.Mocks;
using System.Linq;
using System.Web.Mvc;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Modules.News;

namespace SitefinityWebApp.Tests
{
    [TestClass]
    public class BreakingNewsControllerTests
    {
        [TestMethod]
        public void IndexAction_CorrectlySetsTitle_ToModel()
        {
            // Uncomment if you use service locator in your controller

            //// Creating an empty unity container
            //UnityContainer mockedContainer = new UnityContainer();

            //// Registering mocked implementation of NewsManager
            //mockedContainer.RegisterType<NewsManager, MyNewsManager>(MyNewsManager.ProviderName.ToUpperInvariant());

            //// Run the controller with the empty container we just created
            //ObjectFactory.RunWithContainer(mockedContainer, () =>
            //{
            //    BreakingNewsController controller = new BreakingNewsController();

            //    ViewResult result = controller.Index() as ViewResult;
            //    BreakingNewsModel breakingNewsModel = result.Model as BreakingNewsModel;

            //    var manager = ObjectFactory.Resolve<NewsManager>(MyNewsManager.ProviderName.ToUpperInvariant());
            //    string expectedFirstItemTitle = manager.GetNewsItems().First().Title;

            //    Assert.AreEqual<string>(expectedFirstItemTitle, breakingNewsModel.Message);
            //});
        }        
    }
}