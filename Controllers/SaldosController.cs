using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;
using PTNF.Services;

namespace PTNF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaldosController : ControllerBase
    {
        private readonly ISPAsignarSaldoService _spAsignarSaldoService;

        public SaldosController(ISPAsignarSaldoService spAsignarSaldoService)
        {
            _spAsignarSaldoService = spAsignarSaldoService;
        }

        [HttpGet("ObtenerSaldos")]
        public async Task<IActionResult> ObtenerSaldosAsignados()
        {
            var result = await _spAsignarSaldoService.ExecuteStoredProcedureAsync();
            return Ok(result);
        }
    }
}
