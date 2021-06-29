using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(THWebTuan3.Startup))]
namespace THWebTuan3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
