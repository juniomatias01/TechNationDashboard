using Microsoft.AspNetCore.Mvc;
using TechNationDashboard.Entities;
using TechNationDashboard.Services;

namespace TechNationDashboard.Controllers
{
    public class NotasFiscaisController : Controller
    {
        private readonly INotaFiscalService _service;

        public NotasFiscaisController(INotaFiscalService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var notasFiscais = _service.GetAll();
            return View(notasFiscais);
        }

        public IActionResult Details(int id)
        {
            var notaFiscal = _service.GetById(id);
            if (notaFiscal == null)
            {
                return NotFound();
            }
            return View(notaFiscal);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NotaFiscal notaFiscal)
        {
            if (ModelState.IsValid)
            {
                _service.Add(notaFiscal);
                return RedirectToAction(nameof(Index));
            }
            return View(notaFiscal);
        }

        public IActionResult Edit(int id)
        {
            var notaFiscal = _service.GetById(id);
            if (notaFiscal == null)
            {
                return NotFound();
            }
            return View(notaFiscal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NotaFiscal notaFiscal)
        {
            if (ModelState.IsValid)
            {
                _service.Update(notaFiscal);
                return RedirectToAction(nameof(Index));
            }
            return View(notaFiscal);
        }

        public IActionResult Delete(int id)
        {
            var notaFiscal = _service.GetById(id);
            if (notaFiscal == null)
            {
                return NotFound();
            }
            return View(notaFiscal);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
