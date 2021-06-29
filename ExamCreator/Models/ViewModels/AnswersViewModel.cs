using E.Entities.Entities;

namespace ExamCreator.Models.ViewModels
{
    public class AnswersViewModel
    {
        public AnswersViewModel(Answers answers)
        {
            Id = answers.Id;
            Answer = answers.Answer;
        }
        public int Id { get; set; }
        public string Answer { get; set; }
    }
}
