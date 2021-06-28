using System.Collections.Generic;

namespace E.Core.ExamFormModule.Requests
{
    public class ExamFormRequest
    {
        public string FormQuestion { get; set; }
        public string FormText { get; set; }
        public List<QuestionsRequest> Questions { get; set; }
    }
}
