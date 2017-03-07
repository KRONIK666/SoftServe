namespace HRManagerApplication.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Project
    {
        public Project()
        {
            Intermediates = new HashSet<Intermediate>();
            Juniors = new HashSet<Junior>();
            Seniors = new HashSet<Senior>();
            TeamLeaders = new HashSet<TeamLeader>();
            Trainees = new HashSet<Trainee>();
        }

        public int ID { get; set; }

        [Column("Project Name")]
        [DisplayName("Project")]
        [Required]
        [StringLength(50)]
        public string Project_Name { get; set; }

        [DisplayName("Managed By")]
        public int? ManagerID { get; set; }

        public virtual ICollection<Intermediate> Intermediates { get; set; }

        public virtual ICollection<Junior> Juniors { get; set; }

        public virtual ProjectManager ProjectManager { get; set; }

        public virtual ICollection<Senior> Seniors { get; set; }

        public virtual ICollection<TeamLeader> TeamLeaders { get; set; }

        public virtual ICollection<Trainee> Trainees { get; set; }
    }
}