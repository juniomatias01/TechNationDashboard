using System;
using System.Collections.Generic;
using TechNationDashboard.Entities;

namespace TechNationDashboard.ViewModels
{
    public class DashboardViewModel
    {
        public decimal ValorTotalNotasEmitidas { get; set; }
        public decimal ValorTotalNotasSemCobranca { get; set; }
        public decimal ValorTotalNotasVencidas { get; set; }
        public decimal ValorTotalNotasAVencer { get; set; }
        public decimal ValorTotalNotasPagas { get; set; }
        public List<string> Meses { get; set; }
        public List<decimal> InadimplenciaMesAMes { get; set; }
        public List<decimal> ReceitaMesAMes { get; set; }
        public List<NotaFiscalViewModel> NotasFiscais { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }

    public class NotaFiscalViewModel
    {
        public int Id { get; set; }
        public string NomePagador { get; set; }
        public string NumeroIdentificacao { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataCobranca { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal Valor { get; set; }
        public string DocumentoNotaFiscal { get; set; }
        public string DocumentoBoletoBancario { get; set; }
        public StatusNota Status { get; set; }
    }
}
