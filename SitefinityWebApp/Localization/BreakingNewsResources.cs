// SitefinityWebApp\Localization\BreakingNewsResources.cs

using Telerik.Sitefinity.Localization;

namespace SitefinityWebApp.Localization
{
    public class BreakingNewsResources : Resource
    {
        [ResourceEntry("StaticMessage", Value = "This is the static message", Description = "Static message on the BreakingNews view.", LastModified = "2016/07/12")]
        public string StaticMessage { get; set; }
    }
}