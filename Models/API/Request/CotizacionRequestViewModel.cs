using System;
using System.Collections.Generic;
using System.Text;

namespace Models.API.Request
{
    public class CotizacionRequestViewModel
    {
        public int intAccion { get; set; }
        public int intPrestamoLink { get; set; }
        public string RFC { get; set; }
        public string vchNombre { get; set; }
        public string vchPrimerApellido { get; set; }
        public string vchSegundoApellido { get; set; }
        public string txtTelefono { get; set; }
        public double fltMontoPrestamo { get; set; }
        public double fltTasaInteresAnual { get; set; }
        public int intPlazo { get; set; }
        public int intErrorNumber { get; set; }
        public string vchErrorMessage { get; set; }

    }
}
