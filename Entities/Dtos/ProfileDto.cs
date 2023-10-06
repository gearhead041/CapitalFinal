using Microsoft.AspNetCore.Http;

namespace Entities.Dtos;

public record ProfileDto
{
    public IEnumerable<EducationDto> Education { get; set; }
    public IEnumerable<ExperienceDto> Experience { get; set; }
    public IFormFile Resume { get; set; }
}

public record CreateProfileDto
{
    public IEnumerable<CreateEducationDto> Education { get; set; }
    public IEnumerable<CreateExperienceDto> Experience { get; set; }
    public IFormFile? Resume { get; set; }
}
