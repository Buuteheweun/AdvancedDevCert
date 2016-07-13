// SitefinityWebApp\Wrappers\NewsManagerWrapper.cs

using Telerik.Sitefinity.Modules.News;

namespace SitefinityWebApp.Wrappers
{
    public class NewsManagerWrapper : INewsManagerWrapper
    {
        public NewsManager GetManager()
        {
            return NewsManager.GetManager();
        }
    }
}