using E.Entities.Entities;

namespace ExamCreator.Models.ViewModels
{
    public class ArticleForExamFormViewModel
    {
        public ArticleForExamFormViewModel(Article article)
        {
            Title = article.Title;
            Text = article.Text;
        }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
