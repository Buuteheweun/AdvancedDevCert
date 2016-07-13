// Global.asax.cs

using SitefinityWebApp.DI;
using SitefinityWebApp.Mvc.Models;
using System;
using System.Web;
using System.Web.Mvc;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Blogs.Model;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Data.Events;
using Telerik.Sitefinity.Frontend;
using Telerik.Sitefinity.Frontend.Navigation.Mvc.Models;
using Telerik.Sitefinity.Modules.Blogs;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Bootstrapper.Initialized += this.Bootstrapper_Initialized;
            Bootstrapper.Bootstrapped += this.Bootstrapper_Bootstrapped;            
        }

        private void OnBlogPostCreated(IDataEvent @event)
        {
            if (@event.ItemType == typeof(BlogPost) && @event.Action == "New")
            {
                var blogsManager = BlogsManager.GetManager(@event.ProviderName);
                var currentBlogPost = blogsManager.GetBlogPost(@event.ItemId);

                currentBlogPost.Content = currentBlogPost + "<br/><i>This is the disclaimer!</i>";
            }
        }

        private void Bootstrapper_Initialized(object sender, ExecutedEventArgs e)
        {
            if (e.CommandName == "Bootstrapped")
            {
                FrontendModule.Current.DependencyResolver.Rebind<INavigationModel>().To<CustomNavigationModel>();
                EventHub.Subscribe<IDataEvent>(this.OnBlogPostCreated);
            }
        }

        private void Bootstrapper_Bootstrapped(object sender, EventArgs e)
        {
            // Use Service Locator mechanism to register our NinjectController factory which will provide DI for controller dependencies.
            ObjectFactory.Container.RegisterType<ISitefinityControllerFactory, NinjectControllerFactory>(new ContainerControlledLifetimeManager());

            var factory = ObjectFactory.Resolve<ISitefinityControllerFactory>();

            // Set our factory as a default controller factory
            ControllerBuilder.Current.SetControllerFactory(factory);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            EventHub.Unsubscribe<IDataEvent>(this.OnBlogPostCreated);
        }
    }
}