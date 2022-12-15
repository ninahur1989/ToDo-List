using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Services.Interfaces;

namespace TodoList.Controllers
{
    public class DoListController : Controller
    {
        private readonly IDoTaskService _service;

        public DoListController(IDoTaskService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        public async Task<IActionResult> Archive(int id)
        {
            if (await _service.ArchiveAsync(id))
            {
                return RedirectToAction("Index");
            }

            return Ok("error in archiving");
        }

        public async Task<IActionResult> EditStatus(int id)
        {
            if (await _service.EditStatusAsync(id))
            {
                return RedirectToAction("Index");
            }

            return Ok("error in archiving");
        }

        public async Task<IActionResult> Create(string description)
        {
            if (await _service.AddAsync(description))
            {
                return RedirectToAction("Index");
            }
            return Ok("error in creating");
        }
    }
}
