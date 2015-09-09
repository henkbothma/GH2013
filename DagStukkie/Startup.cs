using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DagStukkie.Startup))]
namespace DagStukkie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
