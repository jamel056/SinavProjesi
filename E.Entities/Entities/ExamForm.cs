using System;
using System.Collections.Generic;

namespace E.Entities.Entities
{
    public class ExamForm
    {
        public int Id { get; set; }
        public string FormQuestion { get; set; }
        public string FormText { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public ICollection<Questions> Questions { get; set; }
    }
}
