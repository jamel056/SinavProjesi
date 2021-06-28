using System.Collections.Generic;

namespace E.Entities.Entities
{
    public class Questions
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int FormId { get; set; }
        public ExamForm ExamForm { get; set; }
        public ICollection<Answers> Answers { get; set; }
    }
}
