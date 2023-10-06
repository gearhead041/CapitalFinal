using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Stage
{
    [Key]
    public Guid Id { get; set; }
    public Guid WorkProgramId { get; set; }
    public WorkProgram WorkProgram { get; set; }
    public string StageType { get; set; }
    public string Name { get; set; }
    public bool ShowStage { get; set; }
    public VideoInterView? VideoInterView { get; set; }

}

public class VideoInterView
{
    public string InterviewQuestion { get; set; }
    public string AdditionalInfo { get; set; }
    public int MaxDuration { get; set; }
    public int DeadlineSubmission { get; set; }
}

