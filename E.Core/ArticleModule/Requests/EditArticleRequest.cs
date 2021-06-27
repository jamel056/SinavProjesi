using E.Entities.Entities;
using System.ComponentModel.DataAnnotations;

namespace E.Core.ArticleModule.Requests
{
    public class EditArticleRequest
    {
        public EditArticleRequest()
        {

        }
        public EditArticleRequest(Article article)
        {
            Id = article.Id;
            Title = article.Title;
            Text = article.Text;
        }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
