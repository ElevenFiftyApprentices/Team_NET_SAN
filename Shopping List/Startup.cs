using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shopping_List.Startup))]
namespace Shopping_List
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
