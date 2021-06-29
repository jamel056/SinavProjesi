using E.Entities.Entities;
using System.Collections.Generic;

namespace ExamCreator.Models.ViewModels
{
    public class QuestionViewModel
    {
        public QuestionViewModel(Questions questions)
        {
            Id = questions.Id;
            Question = questions.Question;
            Answers = new List<AnswersViewModel>();

            foreach (var item in questions.Answers)
            {
                Answers.Add(new AnswersViewModel(item));
            }
        }
        public int Id { get; set; }
        public string Question { get; set; }
        public List<AnswersViewModel> Answers { get; set; }
    }
}
