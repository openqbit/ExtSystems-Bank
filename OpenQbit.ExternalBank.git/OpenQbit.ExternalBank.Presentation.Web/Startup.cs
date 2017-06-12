using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenQbit.ExternalBank.Presentation.Web.Startup))]
namespace OpenQbit.ExternalBank.Presentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
