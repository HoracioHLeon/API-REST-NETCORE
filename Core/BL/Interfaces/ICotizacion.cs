using Models.API.Request;
using Models.API.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BL.Interfaces
{
    public interface ICotizacion
    {
        Task<CotizacionResponseViewModel>GenerarCotizacionCredito(CotizacionRequestViewModel x);
    }
}
