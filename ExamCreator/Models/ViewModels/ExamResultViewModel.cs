using E.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ExamCreator.Models.ViewModels
{
    public class ExamResultViewModel
    {
        public ExamResultViewModel(ExamForm form)
        {
            CorrectAnswerIds = new List<int>();
            CorrectAnswerIds = form.Questions.SelectMany(x => x.Answers).Where(x => x.IsTrue).Select(x => x.Id).ToList();
        }
        public List<int> CorrectAnswerIds { get; set; }
    }
}
