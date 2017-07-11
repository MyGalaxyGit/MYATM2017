using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MYATM2017.Startup))]
namespace MYATM2017
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
