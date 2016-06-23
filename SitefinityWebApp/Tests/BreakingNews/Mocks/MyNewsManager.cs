using System.Collections.Generic;
using System.Linq;
using Telerik.Sitefinity.Modules.News;
using Telerik.Sitefinity.News.Model;

namespace SitefinityWebApp.Tests.BreakingNews.Mocks
{
    public class MyNewsManager : NewsManager
    {
        public MyNewsManager() : base (MyNewsManager.ProviderName)
        {
            // do nothing
        }

        protected override void Initialize()
        {
           // do nothing
        }

        protected override void SetProvider(string providerName, string transactionName)
        {
            // do nothing
        }

        public override IQueryable<NewsItem> GetNewsItems()
        {
            return new List<NewsItem>()
            {
               new MyNewsItem() { Title = "Test: First news" },
               new MyNewsItem() { Title = "Test: Second news" },
               new MyNewsItem() { Title = "Test: Third news" }
            }.AsQueryable();
        }

        private const string ProviderName = "TestProviderName";
    }
}
