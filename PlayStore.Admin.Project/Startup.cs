using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlayStore.Admin.Project.Startup))]
namespace PlayStore.Admin.Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
