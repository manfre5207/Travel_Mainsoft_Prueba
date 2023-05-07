using System.Collections.Specialized;
using System.Data;
using Travel.Connections;
using Travel.Entities.Entities;

namespace Travel.Business.Business
{
    /// <summary>
    /// Esta clase representa un objeto de autores.
    /// </summary>
    public class bAutores
    {
        /// <summary>
        /// Métodos públicos que se acceden desde el controller.
        /// </summary>
        #region "Métodos Públicos"
        /// <summary>
        /// Métodos para listar todos los autores.
        /// <param name="origen">Que identifica que controller esta realizando la petición.</param>
        /// </summary>
        public List<eAutores> ListAutores(string origen)
        {
            DataTable dt = new DataTable();
            DataSet ds = getDataSet("spList_Autores");
            if (origen == "Aut")
            {
                dt = ds.Tables[0];
            }
            else
            {
                dt = ds.Tables[1];
            }

            List<eAutores> listAut = new List<eAutores>();
            listAut = (from DataRow dr in dt.Rows
                       select new eAutores()
                       {
                           Id_Autor = dr.Field<Int32?>("Id_Autor") ?? 0,
                           Nombres_Autor = (string?)dr["Nombres_Autor"] ?? "",
                           Apellidos_Autor = (string?)dr["Apellidos_Autor"] ?? "",

                       }).ToList();

            return listAut;
        }
        /// <summary>
        /// Métodos para buscar autor por Id.
        /// <param name="Id">Id que envio desde el controller para realizar la busqueda por parámetro Id_Autor.</param>
        /// </summary>
        public List<eAutores> ListAutoresXId(int Id)
        {
            DataTable dt = null;

            string[] nomParam = {
            "@Id_Autor"
            };

            object[] vlrParam = {
            Id
            };

            dt = getDataTable("spList_AutoresXId", nomParam, vlrParam);

            List<eAutores> listAut = new List<eAutores>();
            listAut = (from DataRow dr in dt.Rows
                       select new eAutores()
                       {
                           Id_Autor = dr.Field<Int32?>("Id_Autor") ?? 0,
                           Nombres_Autor = (string?)dr["Nombres_Autor"] ?? "",
                           Apellidos_Autor = (string?)dr["Apellidos_Autor"] ?? "",

                       }).ToList();

            return listAut;
        }
        /// <summary>
        /// Métodos para insertar un autor.
        /// <param name="autores">Envío el modelo cómo parámetro para realizar la inserción.</param>
        /// </summary>
        public async Task<bool> InsertAutores(eAutores autores)
        {
            string[] nomParam =
            {
                "@Nombres_Autor",
                "@Apellidos_Autor"
            };

            object[] vlrParam =
            {
                /*DATOS DEL PACIENTE*/
                autores.Nombres_Autor,
                autores.Apellidos_Autor
            };

            return await EjecutarSentencia("spInsertar_Autor", nomParam, vlrParam);
        }
        /// <summary>
        /// Métodos para editar un autor.
        /// <param name="autores">Envío el modelo cómo parámetro para realizar la edición.</param>
        /// </summary>
        public async Task<bool> UpdateAutores(eAutores autores)
        {
            string[] nomParam =
            {
                "@Id_Autor",
                "@Nombres_Autor",
                "@Apellidos_Autor"
            };

            object[] vlrParam =
            {
                autores.Id_Autor,
                autores.Nombres_Autor,
                autores.Apellidos_Autor
            };

            return await EjecutarSentencia("spEditar_Autor", nomParam, vlrParam);
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
