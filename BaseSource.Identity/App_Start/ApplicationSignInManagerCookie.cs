using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using BaseSource.Identity.Entities;

namespace BaseSource.Identity
{
    public class ApplicationSignInManagerCookie : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManagerCookie(ApplicationUserManagerCookie userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManagerCookie)UserManager);
        }

        public static ApplicationSignInManagerCookie Create(IdentityFactoryOptions<ApplicationSignInManagerCookie> options, IOwinContext context)
        {
            return new ApplicationSignInManagerCookie(context.GetUserManager<ApplicationUserManagerCookie>(), context.Authentication);
        }

        
    }
}
