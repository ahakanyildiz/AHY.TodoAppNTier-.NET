using AHY.ToDoAppNTier.Business.Services.Abstract;
using AHY.ToDoAppNTier.Common.ResponseObjects;
using AHY.ToDoAppNTier.Dtos.WorkDtos;
using AHY.ToDoAppNTier.UI.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AHY.ToDoAppNTier.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkService _workService;
        public HomeController(IWorkService workService)
        {
            _workService = workService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _workService.GetAll();
            return this.ResponseView(response);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new WorkCreateDto());
        }

        [HttpPost]
        public async Task<ActionResult> Create(WorkCreateDto dto)
        {
            var response = await _workService.Create(dto);
            return (ActionResult)this.ResponseRedirectToAction(response,"Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var response = await _workService.GetById<WorkUpdateDto>(id);
            return this.ResponseView(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto dto)
        {
            var response = await _workService.Update(dto);
            return this.ResponseRedirectToAction(response, "Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _workService.Remove(id);
            return this.ResponseRedirectToAction(response, "Index");
        }

        public IActionResult NotFound(int code)
        {
            return View();
        }
    }
}
