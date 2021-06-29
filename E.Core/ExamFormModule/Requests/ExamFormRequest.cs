using E.Entities.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E.Core.ExamFormModule.Requests
{
    public class ExamFormRequest
    {
        public ExamFormRequest()
        {
            Articles = new List<Article>();
            Questions = new List<QuestionsRequest>();
            for (var i = 0; i < 4; i++)
            {
                var question = new QuestionsRequest();
                Questions.Add(question);
                question.Answers = new List<AnswersRequest>();
                for (var j = 0; j < 4; j++)
                {
                    question.Answers.Add(new AnswersRequest());
                }
            }
        }
        [Required]
        public string FormQuestion { get; set; }
        [Required]
        public string FormText { get; set; }
        public List<QuestionsRequest> Questions { get; set; }
        public List<Article> Articles { get; set; }
    }
}
