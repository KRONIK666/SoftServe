namespace MySharedBudget.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Contribution> contributions;
        private ICollection<Comment> comments;

        public User()
        {
            this.contributions = new HashSet<Contribution>();
            this.comments = new HashSet<Comment>();
        }

        public virtual ICollection<Contribution> Contributions
        {
            get
            {
                return this.contributions;
            }
            set
            {
                this.contributions = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}