using System.Collections.Generic;

namespace E.Core.ExamFormModule.Requests
{
    public class QuestionsRequest
    {
        public string Question { get; set; }
        public List<AnswersRequest> Answers { get; set; }
    }
}
