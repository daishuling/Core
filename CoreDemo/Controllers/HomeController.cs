using CoreDemo.Models;
using CoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CoreDemo.Settings;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;

namespace CoreDemo.Controllers
{
    public class HomeController:Controller
    {
        private readonly ICinemaService _cinemaService;
        private readonly IOptions<ConnectionOptions> _options;

        public HomeController(ICinemaService cinemaService,IOptions<ConnectionOptions> options)
        {
            _cinemaService = cinemaService;
            _options = options;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "电影院列表";
            return View(await _cinemaService.GetllAllAsync());
        }
        public IActionResult Add()
        {
            ViewBag.Title = "添加电影院";
            return View(new Cinema());
        }
        public async Task<IActionResult> Edit(int cinemaId)
        {
            var cinema = await _cinemaService.GetByIdAsync(cinemaId);
            return View(cinema);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Cinema model)
        {
            if (ModelState.IsValid)
            {
                var exist = await _cinemaService.GetByIdAsync(id);
                if (exist == null)
                {
                    return NotFound();
                }

                exist.Name = model.Name;
                exist.Location = model.Location;
                exist.Capacity = model.Capacity;
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Add(Cinema model)
        {
            if (ModelState.IsValid)
            {
                await _cinemaService.AddAsync(model);
            }
            return RedirectToAction("Index");
        }
    }
}
