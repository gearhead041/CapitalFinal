using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : 
        base(options)
    {
            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<Question>()
        //    .HasOne<ApplicationForm>()
        //    .WithMany(a => a.AdditionalQuestions)
        //    .HasForeignKey(q => q.ApplicationFormId);

        //modelBuilder.Entity<Question>()
        //    .HasOne<PersonalInfo>()
        //    .WithMany(p => p.Questions);

        //modelBuilder.Entity<ApplicationForm>()
        //    .OwnsOne(p => p.PersonalInformation, sa =>
        //    {
        //        sa.Property(a => a.Questions).
        //    });

    }
    public DbSet<WorkProgram> WorkProgram { get; set; }
    public DbSet<ApplicationForm> ApplicationForm { get; set; }
    public DbSet<Stage> Stage { get; set; }
    public DbSet<Skill> Skill { get; set; }
}