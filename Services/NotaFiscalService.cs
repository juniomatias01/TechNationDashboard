using TechNationDashboard.Entities;
using TechNationDashboard.Repositories;
using TechNationDashboard.ViewModels;

namespace TechNationDashboard.Services
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly INotaFiscalRepository _repository;

        public NotaFiscalService(INotaFiscalRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<NotaFiscal> GetAll()
        {
            return _repository.GetAll();
        }
        public List<NotaFiscalViewModel> GetNotasFiscais(int pageNumber, int pageSize, out int totalItems, string filterMonth = null, string filterYear = null, string filterStatus = null)
        {
            var notas = _repository.GetAll();

            if (!string.IsNullOrEmpty(filterMonth))
            {
                notas = notas.Where(n => n.DataEmissao.ToString("MM") == filterMonth).ToList();
            }
            if (!string.IsNullOrEmpty(filterYear))
            {
                notas = notas.Where(n => n.DataEmissao.ToString("yyyy") == filterYear).ToList();
            }
            if (!string.IsNullOrEmpty(filterStatus))
            {
                notas = notas.Where(n => n.Status.ToString() == filterStatus).ToList();
            }

            totalItems = notas.Count();
            return notas.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(n => new NotaFiscalViewModel
            {
                Id = n.Id,
                NomePagador = n.NomePagador,
                NumeroIdentificacao = n.NumeroIdentificacao,
                DataEmissao = n.DataEmissao,
                DataCobranca = n.DataCobranca,
                DataPagamento = n.DataPagamento,
                Valor = n.Valor,
                DocumentoNotaFiscal = n.DocumentoNotaFiscal,
                DocumentoBoletoBancario = n.DocumentoBoletoBancario,
                Status = n.Status
            }).ToList();
        }

        public DashboardViewModel GetDashboardData(int pageNumber, int pageSize, string filterMonth = null, string filterYear = null, string filterStatus = null)
        {
            var notas = _repository.GetAll();

            if (!string.IsNullOrEmpty(filterMonth))
            {
                notas = notas.Where(n => n.DataEmissao.ToString("MM") == filterMonth).ToList();
            }
            if (!string.IsNullOrEmpty(filterYear))
            {
                notas = notas.Where(n => n.DataEmissao.ToString("yyyy") == filterYear).ToList();
            }
            if (!string.IsNullOrEmpty(filterStatus))
            {
                notas = notas.Where(n => n.Status.ToString() == filterStatus).ToList();
            }

            var totalEmitidas = notas.Sum(n => n.Valor);
            var totalSemCobranca = notas.Where(n => n.Status == StatusNota.Emitida).Sum(n => n.Valor);
            var totalVencidas = notas.Where(n => n.Status == StatusNota.PagamentoAtrasado).Sum(n => n.Valor);
            var totalAVencer = notas.Where(n => n.Status == StatusNota.CobrancaRealizada).Sum(n => n.Valor);
            var totalPagas = notas.Where(n => n.Status == StatusNota.PagamentoRealizado).Sum(n => n.Valor);

            var meses = new List<string> { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
            var inadimplenciaMesAMes = notas.GroupBy(n => n.DataEmissao.Month)
                                             .Select(g => new { Mes = g.Key, Valor = g.Where(n => n.Status == StatusNota.PagamentoAtrasado).Sum(n => n.Valor) })
                                             .OrderBy(m => m.Mes)
                                             .Select(m => m.Valor)
                                             .ToList();
            var receitaMesAMes = notas.GroupBy(n => n.DataEmissao.Month)
                                      .Select(g => new { Mes = g.Key, Valor = g.Where(n => n.Status == StatusNota.PagamentoRealizado).Sum(n => n.Valor) })
                                      .OrderBy(m => m.Mes)
                                      .Select(m => m.Valor)
                                      .ToList();

            int totalItems;
            var notasPaginadas = GetNotasFiscais(pageNumber, pageSize, out totalItems, filterMonth, filterYear, filterStatus);

            return new DashboardViewModel
            {
                ValorTotalNotasEmitidas = totalEmitidas,
                ValorTotalNotasSemCobranca = totalSemCobranca,
                ValorTotalNotasVencidas = totalVencidas,
                ValorTotalNotasAVencer = totalAVencer,
                ValorTotalNotasPagas = totalPagas,
                Meses = meses,
                InadimplenciaMesAMes = inadimplenciaMesAMes,
                ReceitaMesAMes = receitaMesAMes,
                NotasFiscais = notasPaginadas,
                TotalItems = totalItems,
                PageSize = pageSize,
                PageNumber = pageNumber
            };
        }

        public NotaFiscal GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(NotaFiscal notaFiscal)
        {
            _repository.Add(notaFiscal);
        }

        public void Update(NotaFiscal notaFiscal)
        {
            _repository.Update(notaFiscal);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
