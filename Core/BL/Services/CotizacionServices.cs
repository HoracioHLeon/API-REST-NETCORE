using Core.BL.Interfaces;
using Microsoft.Data.SqlClient;
using Models.API.Request;
using Models.API.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BL.Services
{
    public class CotizacionServices : ICotizacion
    {
        public async Task<CotizacionResponseViewModel> GenerarCotizacionCredito(CotizacionRequestViewModel x)
        {
            using (var conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionCadena))
            {
                CotizacionResponseViewModel responde = new CotizacionResponseViewModel();

                var command = new SqlCommand();
                command.Connection = conexion;

                #region PARAMETROS DEL PROCEDIMIENTO ALMACENADO
                var intAccion = command.CreateParameter();
                intAccion.ParameterName = "@intAccion";
                intAccion.Value = x.intAccion;
                command.Parameters.Add(intAccion);

                var intPrestamoLink = command.CreateParameter();
                intPrestamoLink.ParameterName = "@intPrestamoLink";
                intPrestamoLink.Value = x.intPrestamoLink;
                command.Parameters.Add(intPrestamoLink);

                var RFC = command.CreateParameter();
                RFC.ParameterName = "@RFC";
                RFC.Value = x.RFC;
                command.Parameters.Add(RFC);

                var vchNombre = command.CreateParameter();
                vchNombre.ParameterName = "@vchNombre";
                vchNombre.Value = x.vchNombre;
                command.Parameters.Add(vchNombre);

                var vchPrimerApellido = command.CreateParameter();
                vchPrimerApellido.ParameterName = "@vchPrimerApellido";
                vchPrimerApellido.Value = x.vchPrimerApellido;
                command.Parameters.Add(vchPrimerApellido);

                var vchSegundoApellido = command.CreateParameter();
                vchSegundoApellido.ParameterName = "@vchSegundoApellido";
                vchSegundoApellido.Value = x.vchSegundoApellido;
                command.Parameters.Add(vchSegundoApellido);

                var txtTelefono = command.CreateParameter();
                txtTelefono.ParameterName = "@txtTelefono ";
                txtTelefono.Value = x.txtTelefono;
                command.Parameters.Add(txtTelefono);

                var fltMontoPrestamo = command.CreateParameter();
                fltMontoPrestamo.ParameterName = "@fltMontoPrestamo";
                fltMontoPrestamo.Value = x.fltMontoPrestamo;
                command.Parameters.Add(fltMontoPrestamo);

                var fltTasaInteresAnual = command.CreateParameter();
                fltTasaInteresAnual.ParameterName = "@fltTasaInteresAnual";
                fltTasaInteresAnual.Value = x.fltTasaInteresAnual;
                command.Parameters.Add(fltTasaInteresAnual);

                var intPlazo = command.CreateParameter();
                intPlazo.ParameterName = "@intPlazo";
                intPlazo.Value = x.intPlazo;
                command.Parameters.Add(intPlazo);

                var intErrorNumber = command.CreateParameter();
                intErrorNumber.ParameterName = "@intErrorNumber";
                intErrorNumber.Value = x.intErrorNumber;
                command.Parameters.Add(intErrorNumber);

                var vchErrorMessage = command.CreateParameter();
                vchErrorMessage.ParameterName = "@vchErrorMessage";
                vchErrorMessage.Value = x.fltTasaInteresAnual;
                command.Parameters.Add(vchErrorMessage);
                #endregion
                #region EJECUCION DEL PROCEDIMIENTO ALMACENADO
                command.CommandText = "[dbo].[spProduccionCotizacion]";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                conexion.Open();
                #endregion
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            responde.Mensaje = reader.GetString(reader.GetOrdinal("Mensaje"));

                        }
                        catch (Exception ex)
                        {
                            var Valor = ex.Message.ToString();
                        }
                    }

                    conexion.Close();
                    return responde;
                }
            }
        }
    }
}
