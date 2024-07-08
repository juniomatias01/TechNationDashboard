using TechNationDashboard.Entities;
using TechNationDashboard.ViewModels;

namespace TechNationDashboard.Services
{
    public interface INotaFiscalService
    {
        IEnumerable<NotaFiscal> GetAll();
        NotaFiscal GetById(int id);
        void Add(NotaFiscal notaFiscal);
        void Update(NotaFiscal notaFiscal);
        void Delete(int id);
        List<NotaFiscalViewModel> GetNotasFiscais(int pageNumber, int pageSize, out int totalItems, string filterMonth = null, string filterYear = null, string filterStatus = null);
        DashboardViewModel GetDashboardData(int pageNumber, int pageSize, string filterMonth = null, string filterYear = null, string filterStatus = null);
    }
}
