namespace Entities.Models;

public class PersonalInfo
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public Nationality Nationality { get; set; }
    public CurrentResidence CurrentResidence { get; set; }
    public IDNumber IDNumber { get; set; }
    public DateOfBirth DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public IEnumerable<Question> Questions { get; set; }
}

public class PhoneNumber
{
    public string Number { get; set; }
    public bool IsInternal { get; set; }
    public bool IsHidden { get; set; }
}

public class Nationality
{
    public string NationalityName { get; set; }
    public bool IsInternal { get; set; }
    public bool IsHidden { get; set; }
}

public class CurrentResidence
{
    public string Residence { get; set; }
    public bool IsInternal { get; set; }
    public bool IsHidden { get; set; }
}

public class IDNumber
{
    public string Number { get; set; }
    public bool IsInternal { get; set; }
    public bool IsHidden { get; set; }
}

public class DateOfBirth
{
    public DateOnly Date { get; set; }
    public bool IsInternal { get; set; }
    public bool IsHidden { get; set; }
}

public class Gender
{
    public string GenderName { get; set; }
    public bool IsInternal { get; set; }
    public bool IsHidden { get; set; }
}