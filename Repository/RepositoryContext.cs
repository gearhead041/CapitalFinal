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

    }
    public DbSet<WorkProgram> WorkProgram { get; set; }
    public DbSet<ApplicationForm> ApplicationForm { get; set; }
    public DbSet<Stage> Stage { get; set; }
    public DbSet<Skill> Skill { get; set; }

    public static async Task CheckAndSeedDatabaseAsync( DbContextOptions<RepositoryContext> options )
    {
        using var context = new RepositoryContext(options);
        var _ = await context.Database.EnsureDeletedAsync();
        var workProgramSeed = new WorkProgram
        {
            Id = new Guid("0896b4cd-733a-4b30-b9a7-08dbc65b71fb"),
            Title = "London Internship",
            Summary = "This is a summary",
            Description = "Description",
            SkillsRequired = new[]
            {
                new Skill {
                    Name = "Problem Solving",
                    WorkProgramId = new Guid()
                    },

            },
            Benefits = "Benefits",
            ApplicationCriteria = "Application Criteria Here",
            ProgramStart = "9-10-23",
            ApplicationOpen = "9-10-23",
            ApplicationClose = "9-10-23",
            Duration = "3 Months",
            MinQualifications = "Bsc/BEng",
            MaxApplications = 200,
            IsPublished = false,

        };

        var appFormSeed = new ApplicationForm
        {
            WorkProgramId = new Guid("0896b4cd-733a-4b30-b9a7-08dbc65b71fb"),
            PersonalInformation = new PersonalInfo
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "example@a23.com",
                FrontData = new[]
        {
            new FrontData
        {
            Title="PhoneNumber",
            Value ="565365646546",
            IsHidden=true,
            IsInternal=true,
        },
            new FrontData {
                Title = "Nationality",
                Value = "Algeria",
                IsHidden=true,
                IsInternal=true,
                }
            ,
            new FrontData {
                Title = "Gender",
                Value = "Male",
                IsHidden=true,
                IsInternal=true,
                }
            ,
            new FrontData {
                Title = "Current Residence",
                Value = "Algeria",
                IsHidden=true,
                IsInternal=true,
                },

            new FrontData {
                Title = "ID Number",
                Value = "234054543",
                IsHidden=true,
                IsInternal=true,
                },

            new FrontData {
                Title = "Date Of Birth",
                Value = "30-10-2001",
                IsHidden=true,
                IsInternal=true,
                },
        },
                Questions = new[]
        {
            new Question
            {
                QuestionType = "paragraph",
                QuestionText = "Favourite Food"
            }
        },

            },
            Profile = new Profile
            {
                Education = new[] {
            new Education
            {
                School ="Blue College",
                CourseName = "Computer Science",
                IsCurrent = false,
                EndDate = new DateOnly(2024,9,23),
                LocationOfStudy = "Algeria",
                Degree = "Bsc"

            }
        },
                Experience = new[] {
            new Experience
            {
                Company = "HobShop",
                Title = "Senior Developer",
                WorkLocation = "Algeria",
                StartDate = new DateOnly(2001,2,23),
                EndDate = new DateOnly(2020,3,14)
            }
        }
            }

        };

        if (await context.Database.EnsureCreatedAsync())
        {
            context.WorkProgram.Add(workProgramSeed);
            context.ApplicationForm.Add(appFormSeed);
            await context.SaveChangesAsync();
        }
    }
}