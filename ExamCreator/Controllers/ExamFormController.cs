using E.Core.ArticleModule.Services;
using E.Core.ExamFormModule.Requests;
using E.Core.ExamFormModule.Services;
using ExamCreator.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCreator.Controllers
{
    [Authorize]
    public class ExamFormController : Controller
    {
        private readonly IExamFormService _examFormService;
        private readonly IArticleService _articleService;

        public ExamFormController(IExamFormService examFormService, IArticleService articleService)
        {
            _examFormService = examFormService;
            _articleService = articleService;
        }

        public async Task<IActionResult> Index()
        {
            var formsFromDb = await _examFormService.GetAll();

            var response = formsFromDb.Select(x => new ExamFormViewModel(x));
            return View(response);
        }

        public async Task<IActionResult> Add()
        {
            const int number = 5;
            var articlesFromDb = await _articleService.GetPart(number);
            //var response = articlesFromDb.Select(x => new ArticleForExamFormViewModel(x));

            //ViewBag.ArticlesList = response;

            var model = new ExamFormRequest();
            model.Articles = articlesFromDb;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ExamFormRequest request)
        {
            //const int number = 5;
            //var articlesFromDb = await _articleService.GetPart(number);
            //var response = articlesFromDb.Select(x => new ArticleForExamFormViewModel(x));

            //ViewBag.ArticlesList = response;

            if (ModelState.IsValid)
            {
                var result = await _examFormService.Create(request);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(request);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _examFormService.Delete(id);

            return Ok(new { IsDeleted = result });
        }
    }
}
