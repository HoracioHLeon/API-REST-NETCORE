using Core.BL.Interfaces;
using Microsoft.Data.SqlClient;
using Models.API.Request;
using Models.API.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BL.Services
{
    public class AmortizacionServices : IAmortizacion
    {
        public async Task<List<AmortizacionResponseViewModel>> ObtenerAmortizacionCredito(AmortizacionRequestViewModel x)
        {
            using (var conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionCadena))
            {

                AmortizacionResponseViewModel response = null;

                var command = new SqlCommand();
                command.Connection = conexion;
                #region PARAMETROS DEL PROCEDIMIENTO ALMACENADO
                var intClienteKey = command.CreateParameter();
                intClienteKey.ParameterName = "@intClienteKey";
                intClienteKey.Value = x.intClienteKey;
                command.Parameters.Add(intClienteKey);
                #endregion
                #region EJECUCION DEL PROCEDIMIENTO ALMACENADO
                command.CommandText = "[dbo].[spObtenerCotizacion]";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                conexion.Open();
                #endregion
                var result = new List<AmortizacionResponseViewModel>();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    
                    while (reader.Read())
                    {
                        try
                        {
                            //Creamos el Objeto JSON
                            var item = new AmortizacionResponseViewModel
                            {
                                RFC = reader["RFC"].ToString(),
                                vchNombre = reader["vchNombre"].ToString(),
                                vchPrimerApellido = reader["vchPrimerApellido"].ToString(),
                                vchSegundoApellido = reader["vchSegundoApellido"].ToString(),
                                fltMontoPrestamo = (double)reader["fltMontoPrestamo"],
                                fltTasaInteresAnual = (double)reader["fltTasaInteresAnual"],
                                intPlazo = (int)reader["intPlazo"],
                                intNumeroPago = (int)reader["intNumeroPago"],
                                fltMontoCapitalPago = (double)reader["fltMontoCapitalPago"],
                                fltMontoInteresPago = (double)reader["fltMontoInteresPago"],
                                fltSaldoInsolutoCredito = (double)reader["fltSaldoInsolutoCredito"]

                            };

                            result.Add(item);

                        }
                        catch (Exception ex)
                        {
                            var Valor = ex.Message.ToString();
                        }
                    }

                    conexion.Close();
                    return result;
                }
            }
        }
    }
}
