using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record QuestionDto
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

public record AnswerDto
{
    public int? Id { set; get; }
    public int? QuestionId { set; get; }
    public Question Question { set; get; }
    public string? AnswerText { get; set; }
}

public record CreateAnswerDto
{
    public string? AnswerText { get; set; }
}

public record CreateQuestionDto
{
    public Guid QuestionId { get; set; }
    public Guid ApplicationFormId { get; set; }
    [Required]
    public string QuestionType { get; set; }
    [Required]
    public string QuestionText { set; get; }
    public IEnumerable<CreateAnswerDto>? Choices { get; set; }
    public int? MaxChoices { get; set; }
    public bool? EnableOther { get; set; }
    public bool? YesNoAnswer { get; set; }
    public bool? DisqualifyIfNo { get; set; }
    public CreateAnswerDto AnswerDto { get; set; }
}