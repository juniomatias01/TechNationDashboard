using TechNationDashboard.Entities;

namespace TechNationDashboard.Repositories
{
    public interface INotaFiscalRepository
    {
        IEnumerable<NotaFiscal> GetAll();
        NotaFiscal GetById(int id);
        void Add(NotaFiscal notaFiscal);
        void Update(NotaFiscal notaFiscal);
        void Delete(int id);
    }
}
