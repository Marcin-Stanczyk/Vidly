using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly_Correct.Startup))]
namespace Vidly_Correct
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
