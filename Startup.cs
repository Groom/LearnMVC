using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearnMVC.Startup))]
namespace LearnMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
