namespace HRManagementSystem.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Intermediate
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Position { get; set; }

        public double Salary { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Column("Email")]
        [DisplayName("E-mail")]
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        public int ProjectID { get; set; }

        [DisplayName("Team Leader")]
        public int? ManagerID { get; set; }

        public virtual Project Project { get; set; }

        public virtual TeamLeader TeamLeader { get; set; }
    }
}