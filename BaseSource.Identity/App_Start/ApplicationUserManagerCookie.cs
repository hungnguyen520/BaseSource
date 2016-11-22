using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using BaseSource.Identity.Entities;
using System;
using BaseSource.Common;

namespace BaseSource.Identity
{
    public class ApplicationUserManagerCookie : UserManager<ApplicationUser>
    {
        public ApplicationUserManagerCookie(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }
       
        public static ApplicationUserManagerCookie Create(IdentityFactoryOptions<ApplicationUserManagerCookie> options, IOwinContext context)
        {
            ApplicationUserManagerCookie manager = new ApplicationUserManagerCookie(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));

            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = Common.Constants.PASSWORD_MIN_LENGHT,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(Common.Constants.ACCOUNT_LOCKOUT_TIMESPAN_MINUTES);
            manager.MaxFailedAccessAttemptsBeforeLockout = Common.Constants.MAX_FAILED_ACCESS_ATTEMPTS_BEFORE_LOCKOUT;

            //manager.EmailService = new EmailService();
            IDataProtectionProvider dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
