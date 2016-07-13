// SitefinityWebApp\Tests\BreakingNewsControllerDITests.cs

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SitefinityWebApp.Mvc.Controllers;
using SitefinityWebApp.Mvc.Models;
using SitefinityWebApp.Tests.Mocks;
using System.Linq;
using System.Web.Mvc;

namespace SitefinityWebApp.Tests
{
    [TestClass]
    public class BreakingNewsControllerDITests
    {
        [TestMethod]
        public void IndexAction_CorrectlySetsTitle_ToModel_1()
        {
            // Pass my mocked instance of a news manager wrapper to the controller.
            var myNewsManagerWrapper = new MyNewsManagerWrapper();
            BreakingNewsController controller = new BreakingNewsController(myNewsManagerWrapper);

            ViewResult result = controller.Index() as ViewResult;
            BreakingNewsModel breakingNewsModel = result.Model as BreakingNewsModel;

            string expectedFirstItemTitle = myNewsManagerWrapper.GetManager().GetNewsItems().First().Title;

            Assert.AreEqual<string>(expectedFirstItemTitle, breakingNewsModel.Message);
        }

        //[TestMethod]
        //public void IndexAction_CorrectlySetsTitle_ToModel_2()
        //{
        //    // Pass my mocked instance of a news manager to the controller.
        //    var myNewsManager = new MyNewsManager();
        //    BreakingNewsController controller = new BreakingNewsController(myNewsManager);

        //    ViewResult result = controller.Index() as ViewResult;
        //    BreakingNewsModel breakingNewsModel = result.Model as BreakingNewsModel;

        //    string expectedFirstItemTitle = myNewsManager.GetNewsItems().First().Title;

        //    Assert.AreEqual<string>(expectedFirstItemTitle, breakingNewsModel.Message);
        //}
    }
}