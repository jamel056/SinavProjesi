using System.ComponentModel.DataAnnotations;

namespace E.Core.ArticleModule.Requests
{
    public class ArticleRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
