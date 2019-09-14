using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndividualInfo.Startup))]
namespace IndividualInfo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
