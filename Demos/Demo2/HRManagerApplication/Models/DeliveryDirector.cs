namespace HRManagerApplication.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class DeliveryDirector
    {
        public DeliveryDirector()
        {
            ProjectManagers = new HashSet<ProjectManager>();
        }

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

        [DisplayName("Manager")]
        public int ManagerID { get; set; }

        public virtual CEO CEO { get; set; }

        public virtual ICollection<ProjectManager> ProjectManagers { get; set; }
    }
}