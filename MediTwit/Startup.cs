using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediTwit.Startup))]
namespace MediTwit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();

        }
    }
}
