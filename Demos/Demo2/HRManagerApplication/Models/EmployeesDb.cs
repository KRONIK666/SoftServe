namespace HRManagerApplication.Models
{
    using System.Data.Entity;

    public partial class EmployeesDb : DbContext
    {
        public EmployeesDb()
            : base("name=EmployeesDb")
        {
        }

        public virtual DbSet<CEO> CEOs { get; set; }
        public virtual DbSet<DeliveryDirector> DeliveryDirectors { get; set; }
        public virtual DbSet<Intermediate> Intermediates { get; set; }
        public virtual DbSet<Junior> Juniors { get; set; }
        public virtual DbSet<ProjectManager> ProjectManagers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Senior> Seniors { get; set; }
        public virtual DbSet<TeamLeader> TeamLeaders { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CEO>()
                .HasMany(e => e.DeliveryDirectors)
                .WithRequired(e => e.CEO)
                .HasForeignKey(e => e.ManagerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DeliveryDirector>()
                .HasMany(e => e.ProjectManagers)
                .WithRequired(e => e.DeliveryDirector)
                .HasForeignKey(e => e.ManagerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectManager>()
                .HasMany(e => e.Projects)
                .WithOptional(e => e.ProjectManager)
                .HasForeignKey(e => e.ManagerID);

            modelBuilder.Entity<ProjectManager>()
                .HasMany(e => e.TeamLeaders)
                .WithOptional(e => e.ProjectManager)
                .HasForeignKey(e => e.ManagerID);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Intermediates)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Juniors)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Seniors)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.TeamLeaders)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Trainees)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TeamLeader>()
                .HasMany(e => e.Intermediates)
                .WithOptional(e => e.TeamLeader)
                .HasForeignKey(e => e.ManagerID);

            modelBuilder.Entity<TeamLeader>()
                .HasMany(e => e.Juniors)
                .WithOptional(e => e.TeamLeader)
                .HasForeignKey(e => e.ManagerID);

            modelBuilder.Entity<TeamLeader>()
                .HasMany(e => e.Seniors)
                .WithOptional(e => e.TeamLeader)
                .HasForeignKey(e => e.ManagerID);

            modelBuilder.Entity<TeamLeader>()
                .HasMany(e => e.Trainees)
                .WithOptional(e => e.TeamLeader)
                .HasForeignKey(e => e.ManagerID);
        }
    }
}