using Fatura.Application;
using Microsoft.AspNetCore.Mvc;

namespace Fatura.Infra.Controllers
{
    [ApiController]
    [Route("cartoes")]
    public class FaturaController : ControllerBase
    {
        private readonly FaturaUseCase _faturaUseCase;

        public FaturaController(FaturaUseCase faturaUseCase)
        {
            _faturaUseCase = faturaUseCase;
        }

        [HttpGet("{numeroCartao}")]
        public async Task<IActionResult> GetAsync([FromRoute] string numeroCartao)
        {
            var total = await _faturaUseCase.CalcularFaturaAsync(numeroCartao);

            return Ok(total);
        }
    }
}
