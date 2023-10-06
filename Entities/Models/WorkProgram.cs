using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class WorkProgram
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public IEnumerable<Skill> SkillsRequired { get; set; }
    public string Benefits { get; set; }
    public string ApplicationCriteria { get; set; }
    //implement programtype
    public string ProgramType { get; set; }
    public string ProgramStart { get; set; }
    public string ApplicationOpen { get; set; }
    public string ApplicationClose { get; set; }
    public string Duration { get; set; }
    public string MinQualifications { get; set; }
    public int MaxApplications { get; set; }
    public ApplicationForm ApplicationForm { get; set; }
    public IEnumerable<Stage> Stages { get; set; }
    public bool IsPublished { get; set; }
}