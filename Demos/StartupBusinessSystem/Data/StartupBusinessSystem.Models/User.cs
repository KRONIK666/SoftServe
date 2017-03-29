﻿namespace StartupBusinessSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Campaign> campaigns;
        private ICollection<Participation> participations;

        public User()
        {
            this.campaigns = new HashSet<Campaign>();
            this.participations = new HashSet<Participation>();
        }

        [MinLength(9)]
        [MaxLength(15)]
        public string CompanyIdentityNumber { get; set; }

        [MaxLength(320)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        public virtual ICollection<Campaign> Campaigns
        {
            get
            {
                return this.campaigns;
            }
            set
            {
                this.campaigns = value;
            }
        }

        public virtual ICollection<Participation> Participations
        {
            get
            {
                return this.participations;
            }
            set
            {
                this.participations = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}