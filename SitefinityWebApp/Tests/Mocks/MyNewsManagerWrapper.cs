// SitefinityWebApp\Tests\Mocks\MyNewsManagerWrapper.cs

using SitefinityWebApp.Wrappers;
using Telerik.Sitefinity.Modules.News;

namespace SitefinityWebApp.Tests.Mocks
{
    public class MyNewsManagerWrapper : INewsManagerWrapper
    {
        public NewsManager GetManager()
        {
            return new MyNewsManager();
        }
    }
}