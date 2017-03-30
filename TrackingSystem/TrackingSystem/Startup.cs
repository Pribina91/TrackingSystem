using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrackingSystem.Startup))]
namespace TrackingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
