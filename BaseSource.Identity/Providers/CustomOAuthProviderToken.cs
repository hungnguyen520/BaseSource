using BaseSource.Common;
using BaseSource.Identity.Entities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BaseSource.Identity.Providers
{
    public class CustomOAuthProviderToken : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var allowedOrigin = Constants.ALLOWED_ORIGIN;

            context.OwinContext.Response.Headers.Add(Constants.ACCESS_CONTROL_ALLOW_ORGIN, new[] { allowedOrigin });

            var userManager = context.OwinContext.GetUserManager<ApplicationUserManagerToken>();

            ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError(Constants.ERR_INVALID_GRANT, Constants.ERR_USERNAME_PASS_INCORRECT);
                return;
            }

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");

            var ticket = new AuthenticationTicket(oAuthIdentity, null);

            context.Validated(ticket);
        }
    }
}