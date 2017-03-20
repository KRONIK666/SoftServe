namespace MySharedBudget.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class FundingCampaign
    {
        private ICollection<Contribution> contributions;
        private ICollection<Comment> comments;

        public FundingCampaign()
        {
            this.contributions = new HashSet<Contribution>();
            this.comments = new HashSet<Comment>();
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public decimal GoalPrice { get; set; }

        public decimal CurrentPrice { get; set; }

        public DateTime CreatedOn { get; private set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

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
    }
}