using System.Collections.Specialized;
using System.Data;
using Travel.Connections;
using Travel.Entities.Entities;

namespace Travel.Business.Business
{
    /// <summary>
    /// Esta clase representa un objeto de editoriales.
    /// </summary>
    public class bEditoriales
    {
        /// <summary>
        /// Métodos públicos que se acceden desde el controller.
        /// </summary>
        #region "Métodos Públicos"
        /// <summary>
        /// Métodos para listar todos los editoriales.
        /// <param name="origen">Que identifica que controller esta realizando la petición.</param>
        /// </summary>
        public List<eEditoriales> ListEditoriales(string origen)
        {
            DataTable dt = new DataTable();
            DataSet ds = getDataSet("spList_Editoriales");
            if (origen == "Ed")
            {
                dt = ds.Tables[0];
            }
            else
            {
                dt = ds.Tables[1];
            }

            List<eEditoriales> listEdit = new List<eEditoriales>();
            listEdit = (from DataRow dr in dt.Rows
                        select new eEditoriales()
                        {
                            Id_Editorial = dr.Field<Int32?>("Id_Editorial") ?? 0,
                            Nombre_Editorial = (string?)dr["Nombre_Editorial"] ?? "",
                            Sede = (string?)dr["Sede"] ?? "",

                        }).ToList();

            return listEdit;
        }
        /// <summary>
        /// Métodos para buscar editorial por Id.
        /// <param name="Id">Id que envio desde el controller para realizar la busqueda por parámetro Id_Autor.</param>
        /// </summary>
        public List<eEditoriales> ListEditorialesXId(int Id)
        {
            DataTable dt = null;

            string[] nomParam = {
            "@Id_Editorial"
            };

            object[] vlrParam = {
            Id
            };

            dt = getDataTable("spList_EditorialesXId", nomParam, vlrParam);

            List<eEditoriales> listEdit = new List<eEditoriales>();
            listEdit = (from DataRow dr in dt.Rows
                        select new eEditoriales()
                        {
                            Id_Editorial = dr.Field<Int32?>("Id_Editorial") ?? 0,
                            Nombre_Editorial = (string?)dr["Nombre_Editorial"] ?? "",
                            Sede = (string?)dr["Sede"] ?? "",

                        }).ToList();

            return listEdit;
        }
        /// <summary>
        /// Métodos para insertar un editorial.
        /// <param name="editoriales">Envío el modelo cómo parámetro para realizar la edición.</param>
        /// </summary>
        public async Task<bool> InsertEditoriales(eEditoriales editoriales)
        {
            string[] nomParam =
            {
                "@Nombre_Editorial",
                "@Sede"
            };

            object[] vlrParam =
            {
                /*DATOS DEL PACIENTE*/
                editoriales.Nombre_Editorial,
                editoriales.Sede
            };

            return await EjecutarSentencia("spInsertar_Editorial", nomParam, vlrParam);
        }
        /// <summary>
        /// Métodos para editar un editorial.
        /// <param name="editoriales">Envío el modelo cómo parámetro para realizar la edición.</param>
        /// </summary>
        public async Task<bool> UpdateEditoriales(eEditoriales editoriales)
        {
            string[] nomParam =
            {
                "@Id_Editorial",
                "@Nombre_Editorial",
                "@Sede"
            };

            object[] vlrParam =
            {
                editoriales.Id_Editorial,
                editoriales.Nombre_Editorial,
                editoriales.Sede
            };

            return await EjecutarSentencia("spEditar_Editorial", nomParam, vlrParam);
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
