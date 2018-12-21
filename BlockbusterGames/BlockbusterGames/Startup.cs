using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlockbusterGames.Startup))]
namespace BlockbusterGames
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
