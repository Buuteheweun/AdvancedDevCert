// SitefinityWebApp\Wrappers\INewsManagerWrapper.cs

using Telerik.Sitefinity.Modules.News;

namespace SitefinityWebApp.Wrappers
{
    public interface INewsManagerWrapper
    {
        NewsManager GetManager();
    }
}