using Core.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.API.Request;

namespace API_REST_NETCORE.Controllers.Amortizacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmortizacionController : ControllerBase
    {
        #region PROPIEDADES
        /// <summary>
        /// Inicializamos la estancia de la interface
        /// </summary>
        private readonly IAmortizacion _AmortizacionServices;
        #endregion

        #region CONSTRUCTOR
        public AmortizacionController(IAmortizacion AmortizacionServices)
        {
            _AmortizacionServices = AmortizacionServices;
        }
        #endregion

        #region METODO
        /// <summary>
        /// Metodo para Generar el calculo de la Tabla de Amotizacion del credito
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [HttpPost("ObtenerAmortizacionCredito")]
        public async Task<IActionResult> ObtenerAmortizacionCredito ([FromBody] AmortizacionRequestViewModel x)
        {
            var resultado = await _AmortizacionServices.ObtenerAmortizacionCredito(x);
            return Ok(resultado);
        }
        #endregion
    }
}
