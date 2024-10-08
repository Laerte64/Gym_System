using Microsoft.EntityFrameworkCore;

namespace Data 
{
    internal class GymContext : DbContext
    {
        public DbSet<UserData> Users { get; set; }
        public DbSet<MemberData> Members { get; set; }
        public DbSet<CoachData> Coaches { get; set; }
        public DbSet<EmployeeData> Employees { get; set; }
        public DbSet<ManagerData> Managers { get; set; }
        public DbSet<PaymentData> Payments { get; set; }
        public DbSet<ExerciseData> Exercises { get; set; }
        public DbSet<WorkoutDayData> WorkoutDays { get; set; }
        public DbSet<SplitData> Splits { get; set; }
        public DbSet<CheckInDayData> CheckInDays { get; set; }
        public DbSet<ProgressCheckData> ProgressChecks { get; set; }
        public DbSet<ScheduleData> Schedules { get; set; }
        public DbSet<TimeSlotData> TimeSlots { get; set; }

        public GymContext() {}
        public GymContext(DbContextOptions<GymContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=db_gym;user=root;Password=admin123;", 
                new MySqlServerVersion(new Version(8, 0, 28)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberData>()
                .HasMany(m => m.Coaches)
                .WithMany(c => c.Members)
                .UsingEntity(t => t.ToTable("tb_member_coach"));
            modelBuilder.Entity<MemberData>()
                .HasOne(m => m.Schedule)
                .WithMany(s => s.Members)
                .IsRequired(); 
            modelBuilder.Entity<MemberData>()
                .HasOne(m => m.Split)
                .WithMany()
                .HasForeignKey(m => m.SplitId)
                .IsRequired(); 

            modelBuilder.Entity<CoachData>()
                .HasOne(m => m.Schedule)
                .WithMany(s => s.Coaches)
                .IsRequired(); 

            modelBuilder.Entity<EmployeeData>()
                .HasMany(e => e.WorkDays)
                .WithMany()
                .UsingEntity(t => t.ToTable("tb_employee_workdays"));

            modelBuilder.Entity<ManagerData>()
                .HasMany(m => m.WorkDays)
                .WithMany()
                .UsingEntity(t => t.ToTable("tb_manager_workdays"));

            modelBuilder.Entity<PaymentData>()
                .HasOne(p => p.Member)
                .WithMany(m => m.Payments)
                .IsRequired(); 
            modelBuilder.Entity<PaymentData>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.Payments)
                .IsRequired(); 
            modelBuilder.Entity<PaymentData>()
                .HasOne(p => p.Schedule)
                .WithMany()
                .IsRequired(); 
            
            modelBuilder.Entity<WorkoutDayData>()
                .HasMany(w => w.Exercises)
                .WithMany()
                .UsingEntity(t => t.ToTable("tb_exercises_workoutday"));
            
            modelBuilder.Entity<SplitData>()
                .HasMany(s => s.Days)
                .WithMany()
                .UsingEntity(t => t.ToTable("tb_split_workoutday"));

            modelBuilder.Entity<CheckInDayData>()
                .HasOne(c => c.Member)
                .WithMany()
                .IsRequired(); 
            modelBuilder.Entity<CheckInDayData>()
                .HasOne(c => c.Employee)
                .WithMany(e => e.CheckInDays)
                .IsRequired();
            modelBuilder.Entity<CheckInDayData>()
                .HasOne(c => c.WorkoutDay)
                .WithMany()
                .IsRequired();
            
            modelBuilder.Entity<ProgressCheckData>()
                .HasOne(p => p.Member)
                .WithMany(m => m.ProgressChecks)
                .IsRequired();
            modelBuilder.Entity<ProgressCheckData>()
                .HasOne(p => p.Coach)
                .WithMany(c => c.ProgressChecks)
                .IsRequired(); 

            modelBuilder.Entity<ScheduleData>()
                .HasMany(s => s.TimeSlots)
                .WithMany()
                .UsingEntity(t => t.ToTable("tb_schedule_timeslot"));
        }
    }
}
