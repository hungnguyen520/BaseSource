﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BaseSource.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [EmailAddress(ErrorMessage = "Your email looks incorrect. Please check and try again.")]
        [MinLength(8)]
        [Index("UserNameIndex", IsUnique = true)]
        public override string UserName { get; set; }

        public override string Id { get; set; }

        //[Required]
        public override string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        public bool ChangePassword { get; set; }

        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<RoleGroup> RoleGroups { get; set; }

        //public virtual ICollection<AppClaim> AppClaims { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
}