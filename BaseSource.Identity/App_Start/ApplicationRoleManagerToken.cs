using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using BaseSource.Identity.Entities;

namespace BaseSource.Identity
{
    public class ApplicationRoleManagerToken : RoleManager<IdentityRole>
    {
        public ApplicationRoleManagerToken(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManagerToken Create(IdentityFactoryOptions<ApplicationRoleManagerToken> options, IOwinContext context)
        {
            var appRoleManager = new ApplicationRoleManagerToken(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));

            return appRoleManager;
        }
    }
}
