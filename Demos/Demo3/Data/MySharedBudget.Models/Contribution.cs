namespace MySharedBudget.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Contribution
    {
        public Contribution()
        {
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public decimal PriceOffer { get; set; }

        public bool IsAccepted { get; set; }

        public DateTime CreatedOn { get; private set; }

        public int FundingCampaignId { get; set; }

        public virtual FundingCampaign FundingCampaign { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}