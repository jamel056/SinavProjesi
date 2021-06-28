namespace E.Entities.Entities
{
    public class Answers
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool IsTrue { get; set; }
        public int QuestionId { get; set; }
        public Questions Questions { get; set; }
    }
}
