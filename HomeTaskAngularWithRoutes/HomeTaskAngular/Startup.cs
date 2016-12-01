using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeTaskAngular.Startup))]
namespace HomeTaskAngular
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
         
        }
    }
}
