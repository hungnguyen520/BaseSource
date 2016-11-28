using BaseSource.Identity.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BaseSource.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base(BaseSource.Common.Constants.CONNECTION_STRING, throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}