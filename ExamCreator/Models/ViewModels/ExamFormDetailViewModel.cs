using E.Entities.Entities;
using System.Collections.Generic;

namespace ExamCreator.Models.ViewModels
{
    public class ExamFormDetailViewModel
    {
        public ExamFormDetailViewModel(ExamForm form)
        {
            Id = form.Id;
            FormQuestion = form.FormQuestion;
            FormText = form.FormText;
            Questions = new List<QuestionViewModel>();

            foreach (var item in form.Questions)
            {
                Questions.Add(new QuestionViewModel(item));
            }
        }
        public int Id { get; set; }
        public string FormQuestion { get; set; }
        public string FormText { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }
}
