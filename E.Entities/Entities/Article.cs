using System;

namespace E.Entities.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
