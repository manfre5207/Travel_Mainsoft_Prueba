using System.Collections.Specialized;
using System.Data;
using Travel.Connections;

namespace Travel.Business.Business
{
    /// <summary>
    /// Esta clase representa un objeto de usuarios.
    /// </summary>
	public class bUsuarios
    {
        /// <summary>
        /// Métodos públicos que se acceden desde el controller.
        /// </summary>
        #region "Métodos Públicos"
        /// <summary>
        /// Métodos login para acceder al sistema.
        /// <param name="user">Recibe cómo parámetro un usuario.</param>
        /// <param name="password">Recibe cómo parámetro un password encriptadp en MD5.</param>
        /// </summary>
		public DataTable Login(string user, string password)
        {
            string[] nomParam = {
            "@Nombre_Usuario",
            "@Password"
            };

            object[] vlrParam = {
            user,
            password

            };
            return getDataTable("spUsuarios_Validar_Login", nomParam, vlrParam);
        }
        #endregion
        /// <summary>
        /// Métodos privados que solo se acceden desde esta clase.
        /// </summary>
        #region "Métodos Privados"
        /// <summary>
        /// Método genérico que retorna un DataTable.
        /// <param name="sql">Sentencia sql que se va ejecutar en la base de datos.</param>
        /// <param name="nomParam">Nombre de los parámetros del array.</param>
        /// <param name="valParam">Valor de los parámetros del array.</param>
        /// </summary>
        private DataTable getDataTable(string sql, string[] nomParam, object[] valParam)
        {
            return new cConnection("SqlServer").getDataTable(sql, nomParam, valParam);
        }
        /// <summary>
        /// Método genérico que retorna un DataTable.
        /// <param name="sql">Sentencia sql que se va ejecutar en la base de datos.</param>
        /// </summary>
        private DataTable getDataTable(string sql)
        {
            return new cConnection("SqlServer").getDataTable(sql);
        }
        /// <summary>
        /// Método genérico que retorna un respuesta boleana.
        /// <param name="sql">Sentencia sql que se va ejecutar en la base de datos.</param>
        /// <param name="nomParam">Nombre de los parámetros del array.</param>
        /// <param name="valParam">Valor de los parámetros del array.</param>
        /// </summary>
        private async Task<bool> EjecutarSentencia(string sql, string[] nomParam, object[] valParam)
        {
            return await new cConnection("SqlServer").EjecutarSentencia(sql, nomParam, valParam);
        }
        /// <summary>
        /// Método genérico que retorna un DataSet.
        /// <param name="sql">Sentencia sql que se va ejecutar en la base de datos.</param>
        /// <param name="nomParam">Nombre de los parámetros del array.</param>
        /// <param name="valParam">Valor de los parámetros del array.</param>
        /// </summary>
        private DataSet getDataSet(string sql, string[] nomParam, object[] valParam)
        {
            return new cConnection("SqlServer").getDataset(sql, nomParam, valParam);
        }
        /// <summary>
        /// Método genérico que retorna un DataSet.
        /// <param name="sql">Sentencia sql que se va ejecutar en la base de datos.</param>
        /// </summary>
        private DataSet getDataSet(string sql)
        {
            return new cConnection("SqlServer").getDataset(sql);
        }
        /// <summary>
        /// Método genérico que retorna una List.
        /// <param name="sql">Sentencia sql que se va ejecutar en la base de datos.</param>
        /// </summary>
        private async Task<List<OrderedDictionary>> getDataList(string sql)
        {
            return await new cConnection("SqlServer").getList(sql);
        }
        /// <summary>
        /// Método genérico que retorna una List.
        /// <param name="sql">Sentencia sql que se va ejecutar en la base de datos.</param>
        /// <param name="nomParam">Nombre de los parámetros del array.</param>
        /// <param name="valParam">Valor de los parámetros del array.</param>
        /// </summary>
        private async Task<List<OrderedDictionary>> getDataList(string sql, string[] nomParam, object[] valParam)
        {
            return await new cConnection("SqlServer").getList(sql, nomParam, valParam);
        }
        #endregion
    }
}
