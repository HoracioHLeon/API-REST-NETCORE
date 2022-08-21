using System;
using System.Collections.Generic;
using System.Text;

namespace Models.API.Response
{
    public class AmortizacionResponseViewModel
    {
        public AmortizacionResponseViewModel() { }
        public string RFC { get; set; }
        public string vchNombre { get; set; }
        public string vchPrimerApellido { get; set; }
        public string vchSegundoApellido { get; set; }
        public double fltMontoPrestamo { get; set; }
        public double fltTasaInteresAnual { get; set; }
        public int intPlazo { get; set; }
        public int intNumeroPago { get; set; }
        public double fltMontoCapitalPago { get; set; }
        public double fltMontoInteresPago { get; set; }
        public double fltSaldoInsolutoCredito { get; set; }

    }
}
