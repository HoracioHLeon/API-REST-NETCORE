using Core.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.API.Request;

namespace API_REST_NETCORE.Controllers.Cotizacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {
        #region PROPIEDADES
        /// <summary>
        /// Inicializamos la estancia de la interface
        /// </summary>
        private readonly ICotizacion _CotizacionServices;
        #endregion

        #region CONSTRUCTOR
        public CotizacionController(ICotizacion CotizacionServices)
        {
            _CotizacionServices = CotizacionServices;
        }
        #endregion

        #region METODO
        /// <summary>
        /// Metodo para Generar el calculo de la Tabla de Amotizacion del credito
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [HttpPost("GenerarCotizacionCredito")]
        public async Task<IActionResult> GenerarCotizacionCredito([FromBody] CotizacionRequestViewModel x)
        {
            var resultado = await _CotizacionServices.GenerarCotizacionCredito(x);
            return Ok(resultado);
        }
        #endregion
    }
}
