using BaseSource.Common;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BaseSource.Identity.Entities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base(Constants.CONNECTION_STRING, throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}