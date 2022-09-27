using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FactProd.Startup))]
namespace FactProd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
