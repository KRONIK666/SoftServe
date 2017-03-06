namespace EmployeesDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProjectManager
    {
        public ProjectManager()
        {
            Projects = new HashSet<Project>();
            TeamLeaders = new HashSet<TeamLeader>();
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

        [Column("E-mail")]
        [Required]
        [StringLength(50)]
        public string E_mail { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        public int ManagerID { get; set; }

        public virtual DeliveryDirector DeliveryDirector { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<TeamLeader> TeamLeaders { get; set; }
    }
}