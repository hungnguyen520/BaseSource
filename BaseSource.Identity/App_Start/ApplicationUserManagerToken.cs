using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using BaseSource.Identity.Entities;
using System;

namespace BaseSource.Identity
{
    public class ApplicationUserManagerToken : UserManager<ApplicationUser>
    {
        public ApplicationUserManagerToken(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManagerToken Create(IdentityFactoryOptions<ApplicationUserManagerToken> options, IOwinContext context)
        {
            var appDbContext = context.Get<ApplicationDbContext>();
            var appUserManager = new ApplicationUserManagerToken(new UserStore<ApplicationUser>(appDbContext));

            appUserManager.UserValidator = new UserValidator<ApplicationUser>(appUserManager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            appUserManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = Common.Constants.PASSWORD_MIN_LENGHT,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            //appUserManager.EmailService = new EmailService();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                appUserManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"))
                {
                    TokenLifespan = TimeSpan.FromMinutes(Common.Constants.TOKEN_LIFESPAN_MINUTES)
                };
            }

            return appUserManager;
        }
    }
}
