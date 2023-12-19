using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(S_me.Startup))]
namespace S_me
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
