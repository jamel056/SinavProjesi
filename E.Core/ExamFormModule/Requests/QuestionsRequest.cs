using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E.Core.ExamFormModule.Requests
{
    public class QuestionsRequest
    {
        [Required]
        public string Question { get; set; }
        [Required]
        public int AnswerTrue { get; set; }
        public List<AnswersRequest> Answers { get; set; }
    }
}
