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

        public ExamFormController(IExamFormService examFormService)
        {
            _examFormService = examFormService;
        }

        public async Task<IActionResult> Index()
        {
            var formsFromDb = await _examFormService.GetAll();

            var response = formsFromDb.Select(x => new ExamFormViewModel(x));
            return View(response);
        }

        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ExamFormRequest request)
        {
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
