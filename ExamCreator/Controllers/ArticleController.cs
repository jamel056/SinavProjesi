using E.Core.ArticleModule.Requests;
using E.Core.ArticleModule.Services;
using ExamCreator.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCreator.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IActionResult> Index()
        {
            var articlesFromDb = await _articleService.GetAll();

            var response = articlesFromDb.Select(x => new ArticleViewModel(x));
            return View(response);
        }

        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ArticleRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _articleService.Create(request);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var articleFromDb = await _articleService.Get(id);

            var result = new EditArticleRequest(articleFromDb);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditArticleRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _articleService.Edit(request, id);

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
            var result = await _articleService.Delete(id);

            return Ok(new { IsDeleted = result });
        }
    }
}
