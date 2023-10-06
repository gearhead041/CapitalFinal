
using Entities.Validation;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record StageDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Guid WorkProgramId { get; set; }
    public string Name { get; set; }
    public string StageType {  get; set; }
    public bool ShowStage { get; set; }
    [ValidateVideoInterview]
    public VideoInterviewStageDto? VideoInterviewStageDto { get; set; }

}

public record VideoInterviewStageDto
{
    public string InterviewQuestion { get; set; }
    public string AdditionalInfo { get; set; }
    public int MaxDuration { get; set; }
    public int DeadlineSubmission { get; set; }
}

public record CreateStageDto
{
    [Required]
    public Guid WorkProgramId { get; set; }
    public string Name { get; set; }
    public string StageType { get; set; }
    public bool ShowStage { get; set; }
    [ValidateVideoInterview]
    public VideoInterviewStageDto? VideoInterviewStageDto { get; set; }
}

