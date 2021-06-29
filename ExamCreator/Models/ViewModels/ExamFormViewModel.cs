using E.Common.Extensions;
using E.Entities.Entities;

namespace ExamCreator.Models.ViewModels
{
    public class ExamFormViewModel
    {
        public ExamFormViewModel(ExamForm form)
        {
            Id = form.Id;
            FormQuestion = form.FormQuestion.SubAddString(30);
            CreateDate = form.CreateDate.ToString("dd/MM/yyyy");
        }

        public int Id { get; set; }
        public string FormQuestion { get; set; }
        public string CreateDate { get; set; }
    }
}
