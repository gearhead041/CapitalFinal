
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record ApplicationFormDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Guid WorkProgramId { get; set; }
    public IFormFile? Image { get; set; }
    public PersonalInfoDto PersonalInformation { get; set; }
    public ProfileDto Profile { get; set; } = null!;
    public IEnumerable<QuestionDto> AdditionalQuestions { get; set; }
}

public record CreateApplicationFormDto
{
    [Required]
    public Guid WorkProgramId { get; set; }
    public IFormFile? Image { get; set; }
    public CreatePersonalInfoDto? PersonalInformation { get; set; }
    public CreateProfileDto Profile { get; set; }
    public IEnumerable<QuestionDto> AdditionalQuestions { get; set; }

}
