namespace Entities.Models;

public class PersonalInfo
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public IEnumerable<FrontData> FrontData { get; set; }
    public IEnumerable<Question> Questions { get; set; }
}

public class FrontData
{
    public string Title { get; set; }
    public string Value { get; set; }
    public bool IsInternal { get; set; }
    public bool IsHidden { get; set; }
}
