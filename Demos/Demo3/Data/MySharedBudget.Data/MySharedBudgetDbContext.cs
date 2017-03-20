namespace MySharedBudget.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using MySharedBudget.Models;

    public class MySharedBudgetDbContext : IdentityDbContext<User>
    {
        public MySharedBudgetDbContext()
            : base("MySharedBudget")
        {
        }

        public virtual IDbSet<FundingCampaign> FundingCampaigns { get; set; }

        public virtual IDbSet<Contribution> Contributions { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public static MySharedBudgetDbContext Create()
        {
            return new MySharedBudgetDbContext();
        }
    }
}