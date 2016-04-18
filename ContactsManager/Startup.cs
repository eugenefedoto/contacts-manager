using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContactsManager.Startup))]
namespace ContactsManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
