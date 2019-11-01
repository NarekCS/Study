using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebRoleExam.Startup))]
namespace WebRoleExam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
