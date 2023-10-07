using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record QuestionDto
{
    [Required]
    public string QuestionType { get; set; }
    [Required]
    public string QuestionText { set; get; }

}

public record ParagraphDto : QuestionDto
{

}

public record YesNoDto : QuestionDto
{ 
    public bool? YesNoAnswer { get; set; }
    public bool? DisqualifyIfNo { get; set; }
}


public record MultipleChoiceDto : QuestionDto
{
    public string[] Choices { get; set; }
    public int? MaxChoices { get; set; }
    public bool? EnableOther { get; set; }
}

public record DropDownDto : QuestionDto {
    public string[] Choices { get; set; }
    public bool? EnableOther { get; set; }
    
}



public record CreateQuestionDto
{
    public Guid QuestionId { get; set; }
    public Guid ApplicationFormId { get; set; }
    [Required]
    public string QuestionType { get; set; }
    [Required]
    public string QuestionText { set; get; }
    public IEnumerable<string>? Choices { get; set; }
    public int? MaxChoices { get; set; }
    public bool? EnableOther { get; set; }
    public bool? YesNoAnswer { get; set; }
    public bool? DisqualifyIfNo { get; set; }
}