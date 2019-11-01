using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exam70_486Framework.Startup))]
namespace Exam70_486Framework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
