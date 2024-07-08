using Microsoft.AspNetCore.Mvc;
using TechNationDashboard.ViewModels;
using TechNationDashboard.Services;

namespace TechNationDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly INotaFiscalService _notaFiscalService;
        private const int PageSize = 10;

        public HomeController(INotaFiscalService notaFiscalService)
        {
            _notaFiscalService = notaFiscalService;
        }

        public IActionResult Index(int pageNumber = 1, string filterMonth = null, string filterYear = null, string filterStatus = null)
        {
            var viewModel = _notaFiscalService.GetDashboardData(pageNumber, PageSize, filterMonth, filterYear, filterStatus);
            ViewData["filterMonth"] = filterMonth;
            ViewData["filterYear"] = filterYear;
            ViewData["filterStatus"] = filterStatus;
            return View(viewModel);
        }
    }
}
