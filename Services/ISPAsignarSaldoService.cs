using PTNF.Models.DTOs;
using System.Data;

namespace PTNF.Services
{
    public interface ISPAsignarSaldoService
    {
        Task<List<GestorSaldoDTO>> ExecuteStoredProcedureAsync();
    }
}
