using BaseSource.Identity.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace BaseSource.Identity
{
    public class ApplicationRoleManagerCookie : RoleManager<IdentityRole>
    {
        public ApplicationRoleManagerCookie(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManagerCookie Create(IdentityFactoryOptions<ApplicationRoleManagerCookie> options, IOwinContext context)
        {
            var appRoleManager = new ApplicationRoleManagerCookie(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));

            return appRoleManager;
        }
    }
}
