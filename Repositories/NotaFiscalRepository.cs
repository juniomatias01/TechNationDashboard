using TechNationDashboard.Data;
using TechNationDashboard.Entities;

namespace TechNationDashboard.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly ApplicationDbContext _context;

        public NotaFiscalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<NotaFiscal> GetAll()
        {
            return _context.NotasFiscais.ToList();
        }

        public NotaFiscal GetById(int id)
        {
            return _context.NotasFiscais.Find(id);
        }

        public void Add(NotaFiscal notaFiscal)
        {
            _context.NotasFiscais.Add(notaFiscal);
            _context.SaveChanges();
        }

        public void Update(NotaFiscal notaFiscal)
        {
            _context.NotasFiscais.Update(notaFiscal);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var notaFiscal = GetById(id);
            if (notaFiscal != null)
            {
                _context.NotasFiscais.Remove(notaFiscal);
                _context.SaveChanges();
            }
        }
    }
}
