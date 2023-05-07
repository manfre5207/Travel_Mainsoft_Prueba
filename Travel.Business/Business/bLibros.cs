using System.Collections.Specialized;
using System.Data;
using Travel.Connections;
using Travel.Entities.Entities;

namespace Travel.Business.Business
{
    /// <summary>
    /// Esta clase representa un objeto de libros.
    /// </summary>
    public class bLibros
    {
        /// <summary>
        /// Métodos públicos que se acceden desde el controller.
        /// </summary>
        #region "Métodos Públicos"
        /// <summary>
        /// Métodos para listar todos los libros.
        /// </summary>
        public List<eLibros> ListLibros()
        {
            DataTable dt = new DataTable();
            dt = getDataTable("spList_Libros");

            List<eLibros> listLib = new List<eLibros>();
            listLib = (from DataRow dr in dt.Rows
                       select new eLibros()
                       {
                           Id_Libro = dr.Field<Int32?>("Id_Libro") ?? 0,
                           ISBN = dr.Field<Int32?>("ISBN") ?? 0,
                           Titulo = (string?)dr["Titulo"] ?? "",
                           Nombres_Autor = (string?)dr["Nombres_Autor"] ?? "",
                           Nombre_Editorial = (string?)dr["Nombre_Editorial"] ?? "",
                           //Id_Editorial = dr.Field<Int32?>("Id_Editorial") ?? 0,
                           //Sinopsis = (string?)dr["Sinopsis"] ?? "",
                           //N_Paginas = (string?)dr["N_Paginas"] ?? "",



                       }).ToList();

            return listLib;
        }
        /// <summary>
        /// Métodos para buscar libro por Id.
        /// <param name="Id">Id que envio desde el controller para realizar la busqueda por parámetro Id_Libro.</param>
        /// </summary>
        public List<eLibros> ListLibrosXId(int Id)
        {
            DataTable dt = null;

            string[] nomParam = {
            "@Id_Libro"
            };

            object[] vlrParam = {
            Id
            };

            dt = getDataTable("spList_LibrosXId", nomParam, vlrParam);

            List<eLibros> listLib = new List<eLibros>();
            listLib = (from DataRow dr in dt.Rows
                       select new eLibros()
                       {
                           Id_Libro = dr.Field<Int32?>("Id_Libro") ?? 0,
                           ISBN = dr.Field<Int32?>("ISBN") ?? 0,
                           Titulo = (string?)dr["Titulo"] ?? "",
                           Sinopsis = (string?)dr["Sinopsis"] ?? "",
                           N_Paginas = (string?)dr["N_Paginas"] ?? "",
                           Id_Editorial = dr.Field<Int32?>("Id_Editorial") ?? 0,
                           Id_Autor = dr.Field<Int32?>("Id_Autor") ?? 0,
                           Id_Autor_Libro = dr.Field<Int32?>("Id_Autor_Libro") ?? 0,

                       }).ToList();

            return listLib;
        }
        /// <summary>
        /// Métodos para insertar un libro.
        /// <param name="libros">Envío el modelo cómo parámetro para realizar la inserción.</param>
        /// </summary>
        public async Task<bool> InsertLibros(eLibros libros)
        {
            string[] nomParam =
            {
                "@ISBN",
                "@Id_Editorial",
                "@Titulo",
                "@Sinopsis",
                "@N_Paginas"
            };

            object[] vlrParam =
            {
                libros.ISBN,
                libros.Id_Editorial,
                libros.Titulo,
                libros.Sinopsis,
                libros.N_Paginas
            };

            return await EjecutarSentencia("spInsertar_Libro", nomParam, vlrParam);
        }
        /// <summary>
        /// Métodos para editar un libro.
        /// <param name="libros">Envío el modelo cómo parámetro para realizar la edición.</param>
        /// </summary>
        public async Task<bool> UpdateLibros(eLibros libros)
        {
            string[] nomParam =
            {
                "@Id_Libro",
                "@ISBN",
                "@Id_Editorial",
                "@Titulo",
                "@Sinopsis",
                "@N_Paginas"
            };

            object[] vlrParam =
            {
                libros.Id_Libro,
                libros.ISBN,
                libros.Id_Editorial,
                libros.Titulo,
                libros.Sinopsis,
                libros.N_Paginas
            };

            return await EjecutarSentencia("spEditar_Libro", nomParam, vlrParam);
        }
        /// <summary>
        /// Métodos para insertar un autor_libro.
        /// <param name="libros">Envío el modelo cómo parámetro para realizar la inserción.</param>
        /// </summary>
        public async Task<bool> InsertAutoresLibros(eLibros libros)
        {
            string[] nomParam =
            {
                "@Id_Autor",
                "@ISBN"
            };

            object[] vlrParam =
            {
                libros.Id_Autor,
                libros.ISBN,
            };

            return await EjecutarSentencia("spInsertar_Autor_Libro", nomParam, vlrParam);
        }
        /// <summary>
        /// Métodos para editar un autor_libro.
        /// <param name="libros">Envío el modelo cómo parámetro para realizar la inserción.</param>
        /// </summary>
        public async Task<bool> EditarAutoresLibros(eLibros libros)
        {
            string[] nomParam =
            {
                "@Id_Autor_Libro",
                "@Id_Autor",
                "@ISBN"
            };

            object[] vlrParam =
            {
                libros.Id_Autor_Libro,
                libros.Id_Autor,
                libros.ISBN,

            };

            return await EjecutarSentencia("spEditar_Autor_Libro", nomParam, vlrParam);
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
