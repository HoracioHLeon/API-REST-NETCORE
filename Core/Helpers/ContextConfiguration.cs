using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Helpers
{
    public class ContextConfiguration
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Inicializa los atributos de la clase
        /// </summary>
        /// <param name="conexion">Cadena de conexión (Bade de datos) del DataContext</param>
        public ContextConfiguration(string conexion)
        {
            ConexionCadena = conexion;
        }

        #endregion
        #region PROPIEDADES
        /// <summary>
        /// Obtiene el valor de la cade de conexion de la base de datos
        /// </summary>
        public static string ConexionCadena { get; set; }
        #endregion
        #region METODOS
        /// <summary>
        /// Obtiene el objeto DbContextOptions con la conexion de datos
        /// </summary>
        /// <param name="ConexionCadena">Cadena de conexión</param>
        /// <returns></returns>
        public static DbContextOptions GetOptions (string ConexionCadena)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConexionCadena).Options;
        }
        #endregion
    }
}
