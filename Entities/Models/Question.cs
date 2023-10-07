namespace Entities.Models;

public class Question
{
    public string QuestionType { get; set; }
    public string QuestionText { set; get; }
    public bool? YesNoAnswer { get; set; }
    public bool? DisqualifyIfNo { get; set; }
    public string[] Choices { get; set; }
    public string[] CorrectAnswers { get; set; }
    public int? MaxChoices { get; set; }
    public bool? EnableOther { get; set; }
    public string CorrectAnswer { get; set; }

}

//public class Answer
//{ 
//    public Guid Id {  set; get; }
//    public Guid QuestionId { set; get; }
//    public Question Question { set; get; }
//    public string AnswerText { get; set; }
//}