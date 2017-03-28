namespace HRManagementSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CEOs")]
    public partial class CEO
    {
        public CEO()
        {
            DeliveryDirectors = new HashSet<DeliveryDirector>();
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

        public virtual ICollection<DeliveryDirector> DeliveryDirectors { get; set; }
    }
}