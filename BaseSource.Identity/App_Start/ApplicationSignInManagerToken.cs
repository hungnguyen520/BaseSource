using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using BaseSource.Identity.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BaseSource.Identity
{
    public class ApplicationSignInManagerToken : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManagerToken(ApplicationUserManagerToken userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManagerToken)UserManager);
        }

        public static ApplicationSignInManagerToken Create(IdentityFactoryOptions<ApplicationSignInManagerToken> options, IOwinContext context)
        {
            return new ApplicationSignInManagerToken(context.GetUserManager<ApplicationUserManagerToken>(), context.Authentication);
        }

        
    }
}
