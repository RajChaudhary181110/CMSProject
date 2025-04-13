using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CollegeManagementSystem.Startup))]
namespace CollegeManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
