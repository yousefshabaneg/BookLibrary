using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryProject_.Startup))]
namespace LibraryProject_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
