using E.Core.ExamFormModule.Services;
using ExamCreator.Models;
using ExamCreator.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCreator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExamFormService _examFormService;

        public HomeController(IExamFormService examFormService)
        {
            _examFormService = examFormService;
        }

        public async Task<IActionResult> Index()
        {
            var formsFromDb = await _examFormService.GetAll();

            var response = formsFromDb.Select(x => new ExamFormViewModel(x));
            return View(response);
        }

        public async Task<IActionResult> TakeTest(int id)
        {
            var examForm = await _examFormService.Get(id);
            var response = new ExamFormDetailViewModel(examForm);

            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> TakeResult([FromRoute] int id)
        {
            var examForm = await _examFormService.Get(id);
            var response = new ExamResultViewModel(examForm);

            return Ok(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
