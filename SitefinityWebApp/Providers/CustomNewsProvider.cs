using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Lifecycle;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.News;
using Telerik.Sitefinity.News.Model;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Model;

namespace SitefinityWebApp.Providers
{
    public class CustomNewsProvider : NewsDataProvider, ICommonDataProvider
    {
        public override LanguageData CreateLanguageData()
        {
            throw new NotImplementedException();
        }

        public override LanguageData CreateLanguageData(Guid id)
        {
            throw new NotImplementedException();
        }

        public override NewsItem CreateNewsItem()
        {
            throw new NotImplementedException();
        }

        public override NewsItem CreateNewsItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Delete(NewsItem newsItemToDelete)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<LanguageData> GetLanguageData()
        {
            throw new NotImplementedException();
        }

        public override LanguageData GetLanguageData(Guid id)
        {
            throw new NotImplementedException();
        }

        public override NewsItem GetNewsItem(Guid id)
        {
            return this.GetNewsItems().First(n => n.Id == id);
        }

        public override IQueryable<NewsItem> GetNewsItems()
        {
            var item1 = App.WorkWith().NewsItem().CreateNew(Guid.NewGuid()).Get();
            item1.Title = "First news";

            var item2 = App.WorkWith().NewsItem().CreateNew(Guid.NewGuid()).Get();
            item2.Title = "Second news";

            var item3 = new NewsItem(this.ApplicationName, Guid.NewGuid());
            item3.SetString("Title", "Third news item");
            item3.Owner = SecurityManager.GetCurrentUserId();

            return new List<NewsItem>()
            {
                item1,
                item2,
                item3
            }.AsQueryable();
        }

        public override ISecuredObject GetSecurityRoot(bool create)
        {
            var key = String.Concat(this.RootKey, this.Name);
            return new SecurityRoot(this.Name, this.GetNewGuid(), this.SupportedPermissionSets, this.PermissionsetObjectTitleResKeys) { Key = key };
        }
    }
}