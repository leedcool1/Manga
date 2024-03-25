using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Manga.Startup))]
namespace Manga
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
