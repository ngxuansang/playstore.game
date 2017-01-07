using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlayStore.Project.Startup))]
namespace PlayStore.Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
