using E.Common.Extensions;
using E.Entities.Entities;

namespace ExamCreator.Models.ViewModels
{
    public class ArticleViewModel
    {
        public ArticleViewModel(Article article)
        {
            Id = article.Id;
            Title = article.Title.SubAddString(20);
            CreateDate = article.CreateDate.ToString("dd/MM/yyyy");
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string CreateDate { get; set; }
    }
}
