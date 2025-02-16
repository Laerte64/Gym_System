using Microsoft.EntityFrameworkCore;
using Model;

namespace Data;

internal class GymContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Coach> Coaches { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<WorkoutDay> WorkoutDays { get; set; }
    public DbSet<Split> Splits { get; set; }

    public GymContext() {}
    public GymContext(DbContextOptions<GymContext> options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=localhost;Database=db_gym;user=root;Password=admin123;", 
            new MySqlServerVersion(new Version(8, 0, 28)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>()
            .HasOne(m => m.Split)
            .WithMany()
            .HasForeignKey(m => m.SplitId)
            .IsRequired();
        
        modelBuilder.Entity<WorkoutDay>()
            .HasMany(w => w.Exercises)
            .WithMany()
            .UsingEntity(t => t.ToTable("tb_exercises_workoutday"));
        
        modelBuilder.Entity<Split>()
            .HasMany(s => s.Days)
            .WithMany()
            .UsingEntity(t => t.ToTable("tb_split_workoutday"));
    }
}
