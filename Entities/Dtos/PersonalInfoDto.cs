
namespace Entities.Dtos;

public record PersonalInfoDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public PhoneNumberDto PhoneNumber { get; set; }
    public NationalityDto Nationality { get; set; }
    public CurrentResidencedDto CurrentResidence { get; set; }
    public IDNumberDto IDNumber { get; set; }
    public DateOfBirthDto DateOfBirth { get; set; }
    public GenderDto Gender { get; set; }
    public IEnumerable<QuestionDto> Questions { get; set; }
}

public class GenderDto
{
    public string GenderName { get; set; }
    public bool IsInternal { get; set; }
    public bool IsHidden { get; set; }
}

public class DateOfBirthDto
{
    public DateOnly Date { get; set; }
    public bool IsInternal { get; set; }
    public bool IsHidden { get; set; }
}

public class IDNumberDto
{
    public string Number { get; set; }
    public bool IsInternal { get; set; }
    public bool IsHidden { get; set; }
}

public class CurrentResidencedDto
{
    public string Residence { get; set; }
    public bool IsInternal { get; set; }
    public bool IsHidden { get; set; }
}

public class PhoneNumberDto
{
    public string Number { get; set; }
    public bool IsInternal { get; set; }
    public bool IsHidden { get; set; }
}

public class NationalityDto
{
    public string NationalityName { get; set; }
    public bool IsInternal { get; set; }
    public bool IsHidden { get; set; }
}

public record CreatePersonalInfoDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public PhoneNumberDto PhoneNumber { get; set; }
    public NationalityDto Nationality { get; set; }
    public CurrentResidencedDto CurrentResidence { get; set; }
    public IDNumberDto IDNumber { get; set; }
    public DateOfBirthDto DateOfBirth { get; set; }
    public GenderDto Gender { get; set; }
    public IEnumerable<QuestionDto> Questions { get; set; }
}