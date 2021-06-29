using System.ComponentModel.DataAnnotations;

namespace E.Core.ExamFormModule.Requests
{
    public class AnswersRequest
    {
        [Required]
        public string Answer { get; set; }
    }
}
