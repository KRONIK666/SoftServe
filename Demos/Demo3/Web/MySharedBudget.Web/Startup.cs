using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySharedBudget.Web.Startup))]
namespace MySharedBudget.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}