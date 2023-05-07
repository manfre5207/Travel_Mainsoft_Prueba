using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace Travel.Connections
{
    /// <summary>
    /// Clase que maneja todos los tipos de conexión a diferentes bases de datos (sql server, oracle, mysql).
    /// </summary>
    public class cConnection
    {
        #region Parameter
        public int IdExcalar;
        cError Error = new cError();
        public enum TipoCnn { SqlServer, Oracle, Mysql };
        private TipoCnn MotorDB = TipoCnn.Oracle;
        public TipoCnn TipoConexion
        {
            get { return MotorDB; }
            set { this.MotorDB = (TipoCnn)value; }
        }

        public static string? connectionString { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que recibe el parámetro del tipo de base de datos que se conecta.
        /// <param name="TipoCon">Recibe el password desde el controller.</param>
        /// </summary>
        public cConnection(string TipoCon)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();

            if (TipoCon == "Oracle")
            {
                MotorDB = TipoCnn.Oracle;
                connectionString = root.GetConnectionString("oracle");
            }
            else if (TipoCon == "SqlServer")
            {
                MotorDB = TipoCnn.SqlServer;
                connectionString = root.GetConnectionString("sqlserver");

            }
            else if (TipoCon == "Mysql")
            {
                MotorDB = TipoCnn.Mysql;
                connectionString = root.GetConnectionString("mysql");
            }
        }
        #endregion
        /// <summary>
        /// Métodos públicos que se acceden desde las clases de business.
        /// </summary>
        #region Methods Publics
        /// <summary>
        /// Métodos genéricos tipo List.
        /// </summary>
        #region List
        /// <summary>
        /// Método que retorna un tipo List genérica.
        /// <param name="strSQL">Recibe la sentencia sql para ejecutar en la base de datos.</param>
        /// </summary>
        public async Task<List<OrderedDictionary>> getList(string strSQL)
        {
            List<OrderedDictionary> list = new List<OrderedDictionary>();

            if (MotorDB == TipoCnn.Oracle)
            {
                using (OracleConnection cn = new OracleConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        using (OracleCommand cmd = new OracleCommand(strSQL, cn))
                        {
                            cmd.CommandText = strSQL;
                            cmd.CommandType = CommandType.StoredProcedure;
                            OracleDataReader _reader = (OracleDataReader)await cmd.ExecuteReaderAsync();
                            string columnName;

                            OrderedDictionary row;
                            while (_reader.Read())
                            {

                                row = new OrderedDictionary();

                                for (int i = 0; i < _reader.FieldCount; i++)
                                {
                                    columnName = _reader.GetName(i);
                                    object value = _reader.GetValue(i);

                                    if (value == DBNull.Value)
                                    {
                                        columnName = _reader.GetName(i);
                                        value = "";

                                    }
                                    else
                                    {
                                        columnName = _reader.GetName(i);
                                    }
                                    row.Add(columnName, value);
                                }
                                list.Add(row);
                            }

                        }
                    }
                    catch (SqlException ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            else if (MotorDB == TipoCnn.SqlServer)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                        {
                            cmd.CommandText = strSQL;
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlDataReader _reader = (SqlDataReader)await cmd.ExecuteReaderAsync();
                            string columnName;

                            OrderedDictionary row;
                            while (_reader.Read())
                            {

                                row = new OrderedDictionary();

                                for (int i = 0; i < _reader.FieldCount; i++)
                                {
                                    columnName = _reader.GetName(i);
                                    object value = _reader.GetValue(i);

                                    if (value == DBNull.Value)
                                    {
                                        columnName = _reader.GetName(i);
                                        value = "";

                                    }
                                    else
                                    {
                                        columnName = _reader.GetName(i);
                                    }
                                    row.Add(columnName, value);
                                }
                                list.Add(row);
                            }

                        }
                    }
                    catch (SqlException ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            else if (MotorDB == TipoCnn.Mysql)
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(strSQL, cn))
                        {
                            cmd.CommandText = strSQL;
                            cmd.CommandType = CommandType.StoredProcedure;
                            MySqlDataReader _reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
                            string columnName;

                            OrderedDictionary row;
                            while (_reader.Read())
                            {

                                row = new OrderedDictionary();

                                for (int i = 0; i < _reader.FieldCount; i++)
                                {
                                    columnName = _reader.GetName(i);
                                    object value = _reader.GetValue(i);

                                    if (value == DBNull.Value)
                                    {
                                        columnName = _reader.GetName(i);
                                        value = "";

                                    }
                                    else
                                    {
                                        columnName = _reader.GetName(i);
                                    }
                                    row.Add(columnName, value);
                                }
                                list.Add(row);
                            }

                        }
                    }
                    catch (SqlException ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// Método que retorna un tipo List genérica.
        /// <param name="strSQL">Recibe la sentencia sql para ejecutar en la base de datos.</param>
        /// <param name="NombreParametros">Recibe un array con el nombre de los parámetros.</param>
        /// <param name="ValoresParametros">Recibe un array con el valor de los parámetros.</param>
        /// </summary>
        public async Task<List<OrderedDictionary>> getList(string strSQL, string[] NombreParametros, object[] ValoresParametros)
        {
            List<OrderedDictionary> list = new List<OrderedDictionary>();


            if (MotorDB == TipoCnn.Oracle)
            {
                using (OracleConnection cn = new OracleConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        using (OracleCommand cmd = new OracleCommand(strSQL, cn))
                        {
                            cmd.CommandText = strSQL;
                            cmd.CommandType = CommandType.StoredProcedure;
                            this.setParametrosOracle(cmd, getParametrosOracle(NombreParametros, ValoresParametros));
                            OracleDataReader _reader = (OracleDataReader)await cmd.ExecuteReaderAsync();
                            string columnName;

                            OrderedDictionary row;
                            while (_reader.Read())
                            {

                                row = new OrderedDictionary();

                                for (int i = 0; i < _reader.FieldCount; i++)
                                {
                                    columnName = _reader.GetName(i);
                                    object value = _reader.GetValue(i);

                                    if (value == DBNull.Value)
                                    {
                                        columnName = _reader.GetName(i);
                                        value = "";

                                    }
                                    else
                                    {
                                        columnName = _reader.GetName(i);
                                    }
                                    row.Add(columnName, value);
                                }
                                list.Add(row);
                            }

                        }
                    }
                    catch (SqlException ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            else if (MotorDB == TipoCnn.SqlServer)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                        {
                            cmd.CommandText = strSQL;
                            cmd.CommandType = CommandType.StoredProcedure;
                            this.setParametros(cmd, getParametros(NombreParametros, ValoresParametros));
                            SqlDataReader _reader = (SqlDataReader)await cmd.ExecuteReaderAsync();
                            string columnName;

                            OrderedDictionary row;
                            while (_reader.Read())
                            {

                                row = new OrderedDictionary();

                                for (int i = 0; i < _reader.FieldCount; i++)
                                {
                                    columnName = _reader.GetName(i);
                                    object value = _reader.GetValue(i);

                                    if (value == DBNull.Value)
                                    {
                                        columnName = _reader.GetName(i);
                                        value = "";

                                    }
                                    else
                                    {
                                        columnName = _reader.GetName(i);
                                    }
                                    row.Add(columnName, value);
                                }
                                list.Add(row);
                            }

                        }
                    }
                    catch (SqlException ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            else if (MotorDB == TipoCnn.Mysql)
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(strSQL, cn))
                        {
                            cmd.CommandText = strSQL;
                            cmd.CommandType = CommandType.StoredProcedure;
                            this.setParametrosMysql(cmd, getParamertrosMySql(NombreParametros, ValoresParametros));
                            MySqlDataReader _reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
                            string columnName;

                            OrderedDictionary row;
                            while (_reader.Read())
                            {

                                row = new OrderedDictionary();

                                for (int i = 0; i < _reader.FieldCount; i++)
                                {
                                    columnName = _reader.GetName(i);
                                    object value = _reader.GetValue(i);

                                    if (value == DBNull.Value)
                                    {
                                        columnName = _reader.GetName(i);
                                        value = "";

                                    }
                                    else
                                    {
                                        columnName = _reader.GetName(i);
                                    }
                                    row.Add(columnName, value);
                                }
                                list.Add(row);
                            }

                        }
                    }
                    catch (SqlException ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            return list;
        }
        #endregion
        /// <summary>
        /// Métodos genéricos tipo DataSet.
        /// </summary>
        #region Dataset
        /// <summary>
        /// Método que retorna un tipo Dataset.
        /// <param name="strSQL">Recibe la sentencia sql para ejecutar en la base de datos.</param>
        /// <param name="NombreParametros">Recibe un array con el nombre de los parámetros.</param>
        /// <param name="ValoresParametros">Recibe un array con el valor de los parámetros.</param>
        /// </summary>
        public DataSet getDataset(string strSQL, string[] NombreParametros, object[] ValoresParametros)
        {
            DataSet ds = new DataSet();
            if (MotorDB == TipoCnn.Oracle)
            {
                using (OracleConnection cn = new OracleConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as OracleCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametrosOracle(cmd, getParametrosOracle(NombreParametros, ValoresParametros));
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(ds);
                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                        //return (null);
                    }
                }
            }
            else if (MotorDB == TipoCnn.SqlServer)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as SqlCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametros(cmd, getParametros(NombreParametros, ValoresParametros));
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);


                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                        //return (null);
                    }
                }
            }
            else if (MotorDB == TipoCnn.Mysql)
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as MySqlCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametrosMysql(cmd, getParamertrosMySql(NombreParametros, ValoresParametros));
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(ds);


                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                        //return (null);
                    }
                }
            }
            return ds;
        }
        /// <summary>
        /// Método que retorna un tipo Dataset.
        /// <param name="strSQL">Recibe la sentencia sql para ejecutar en la base de datos.</param>
        /// <param name="NombreParametros">Recibe un array con el nombre de los parámetros.</param>
        /// <param name="ValoresParametros">Recibe un array con el valor de los parámetros.</param>
        /// </summary>
        public DataSet getDataset(string strSQL, string[] NombreParametros, object[] ValoresParametros, OracleDbType[] typParam, ParameterDirection[] DirParam)
        {
            DataSet ds = new DataSet();

            if (MotorDB == TipoCnn.Oracle)
            {
                using (OracleConnection cn = new OracleConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as OracleCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametrosOracle(cmd, getParametrosOracle(NombreParametros, ValoresParametros));
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(ds);
                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                        //return (null);
                    }
                }
            }
            else if (MotorDB == TipoCnn.SqlServer)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as SqlCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametros(cmd, getParametros(NombreParametros, ValoresParametros));
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);


                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                        //return (null);
                    }
                }
            }
            else if (MotorDB == TipoCnn.Mysql)
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as MySqlCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametrosMysql(cmd, getParamertrosMySql(NombreParametros, ValoresParametros));
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(ds);


                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                        //return (null);
                    }
                }
            }
            return ds;
        }
        /// <summary>
        /// Método que retorna un tipo Dataset.
        /// <param name="strSQL">Recibe la sentencia sql para ejecutar en la base de datos.</param>
        /// <param name="NombreParametros">Recibe un array con el nombre de los parámetros.</param>
        /// <param name="ValoresParametros">Recibe un array con el valor de los parámetros.</param>
        /// </summary>
        public DataSet getDataset(string strSQL, string[] NombreParametros, object[] ValoresParametros, SqlDbType[] typParam, ParameterDirection[] DirParam)
        {
            DataSet ds = new DataSet();

            if (MotorDB == TipoCnn.Oracle)
            {
                using (OracleConnection cn = new OracleConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as OracleCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametrosOracle(cmd, getParametrosOracle(NombreParametros, ValoresParametros));
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(ds);
                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                        //return (null);
                    }
                }
            }
            else if (MotorDB == TipoCnn.SqlServer)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as SqlCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametros(cmd, getParametros(NombreParametros, ValoresParametros));
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);


                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                        //return (null);
                    }
                }
            }
            else if (MotorDB == TipoCnn.Mysql)
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as MySqlCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametrosMysql(cmd, getParamertrosMySql(NombreParametros, ValoresParametros));
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(ds);


                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                        //return (null);
                    }
                }
            }
            return ds;
        }
        /// <summary>
        /// Método que retorna un tipo Dataset.
        /// <param name="strSQL">Recibe la sentencia sql para ejecutar en la base de datos.</param>
        /// </summary>
        public DataSet getDataset(string strSQL)
        {
            DataSet ds = new DataSet();

            if (MotorDB == TipoCnn.Oracle)
            {
                using (OracleConnection cn = new OracleConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as OracleCommand;
                        cmd.CommandText = strSQL;
                        cmd.CommandType = CommandType.Text;
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(ds);
                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                        //return (null);
                    }
                }
            }
            else if (MotorDB == TipoCnn.SqlServer)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as SqlCommand;
                        cmd.CommandText = strSQL;
                        cmd.CommandType = CommandType.Text;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);


                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                        //return (null);
                    }
                }
            }
            else if (MotorDB == TipoCnn.Mysql)
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as MySqlCommand;
                        cmd.CommandText = strSQL;
                        cmd.CommandType = CommandType.Text;
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(ds);


                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                        //return (null);
                    }
                }
            }
            return ds;
        }
        #endregion
        /// <summary>
        /// Métodos genéricos tipo DataTable.
        /// </summary>
        #region Datatable
        /// <summary>
        /// Método que retorna un tipo DataTable.
        /// <param name="strSQL">Recibe la sentencia sql para ejecutar en la base de datos.</param>
        /// </summary>
        public DataTable getDataTable(string strSQL)
        {
            DataTable dt = new DataTable();

            if (MotorDB == TipoCnn.Oracle)
            {

                using (OracleConnection cn = new OracleConnection(connectionString))
                {

                    try
                    {

                        cn.Open();
                        var cmd = cn.CreateCommand() as OracleCommand;
                        cmd.CommandText = strSQL;
                        cmd.CommandType = CommandType.Text;
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(dt);

                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            else if (MotorDB == TipoCnn.SqlServer)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as SqlCommand;
                        cmd.CommandText = strSQL;
                        cmd.CommandType = CommandType.Text;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);


                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            else if (MotorDB == TipoCnn.Mysql)
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as MySqlCommand;
                        cmd.CommandText = strSQL;
                        cmd.CommandType = CommandType.Text;
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);


                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            return dt;
        }
        /// <summary>
        /// Método que retorna un tipo DataTable.
        /// <param name="strSQL">Recibe la sentencia sql para ejecutar en la base de datos.</param>
        /// <param name="NombreParametros">Recibe un array con el nombre de los parámetros.</param>
        /// <param name="ValoresParametros">Recibe un array con el valor de los parámetros.</param>
        /// </summary>
        public DataTable getDataTable(string strSQL, string[] NombreParametros, object[] ValoresParametros)
        {
            DataTable dt = new DataTable();

            if (MotorDB == TipoCnn.Oracle)
            {
                using (OracleConnection cn = new OracleConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as OracleCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametrosOracle(cmd, getParametrosOracle(NombreParametros, ValoresParametros));
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(dt);

                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            else if (MotorDB == TipoCnn.SqlServer)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as SqlCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametros(cmd, getParametros(NombreParametros, ValoresParametros));
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);


                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            else if (MotorDB == TipoCnn.Mysql)
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as MySqlCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametrosMysql(cmd, getParamertrosMySql(NombreParametros, ValoresParametros));
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);


                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            return dt;
        }
        /// <summary>
        /// Método que retorna un tipo DataTable.
        /// <param name="strSQL">Recibe la sentencia sql para ejecutar en la base de datos.</param>
        /// <param name="NombreParametros">Recibe un array con el nombre de los parámetros.</param>
        /// <param name="ValoresParametros">Recibe un array con el valor de los parámetros.</param>
        /// </summary>
        public DataTable getDataTable(string strSQL, string[] NombreParametros, object[] ValoresParametros, OracleDbType[] typParam, ParameterDirection[] DirParam)
        {
            DataTable dt = new DataTable();

            if (MotorDB == TipoCnn.Oracle)
            {
                using (OracleConnection cn = new OracleConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as OracleCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametrosOracle(cmd, getParametrosOracle(NombreParametros, ValoresParametros));
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                        //return (null);
                    }
                }
            }
            else if (MotorDB == TipoCnn.SqlServer)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as SqlCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametros(cmd, getParametros(NombreParametros, ValoresParametros));
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);


                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                        //return (null);
                    }
                }
            }
            else if (MotorDB == TipoCnn.Mysql)
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as MySqlCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametrosMysql(cmd, getParamertrosMySql(NombreParametros, ValoresParametros));
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);


                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                        //return (null);
                    }
                }
            }
            return dt;
        }
        #endregion
        /// <summary>
        /// Métodos genéricos tipo Boleano.
        /// </summary>
        #region Sentence
        /// <summary>
        /// Método que retorna una respuesta boleana.
        /// <param name="strSQL">Recibe la sentencia sql para ejecutar en la base de datos.</param>
        /// </summary>
        public async Task<bool> EjecutarSentencia(string strSQL)
        {
            bool sw = false;

            if (MotorDB == TipoCnn.Oracle)
            {
                using (OracleConnection cn = new OracleConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as OracleCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        await cmd.ExecuteNonQueryAsync();


                        cn.Close();
                        sw = true;
                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            else if (MotorDB == TipoCnn.SqlServer)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as SqlCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        await cmd.ExecuteNonQueryAsync();


                        cn.Close();
                        sw = true;
                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            else if (MotorDB == TipoCnn.Mysql)
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as MySqlCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        await cmd.ExecuteNonQueryAsync();


                        cn.Close();
                        sw = true;
                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            return sw;
        }
        /// <summary>
        /// Método que retorna una respuesta boleana.
        /// <param name="strSQL">Recibe la sentencia sql para ejecutar en la base de datos.</param>
        /// <param name="NombreParametros">Recibe un array con el nombre de los parámetros.</param>
        /// <param name="ValoresParametros">Recibe un array con el valor de los parámetros.</param>
        /// </summary>
        public async Task<bool> EjecutarSentencia(string strSQL, string[] NombreParametros, object[] ValoresParametros)
        {

            bool sw = false;

            if (MotorDB == TipoCnn.Oracle)
            {
                using (OracleConnection cn = new OracleConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as OracleCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametrosOracle(cmd, getParametrosOracle(NombreParametros, ValoresParametros));
                        await cmd.ExecuteNonQueryAsync();


                        cn.Close();
                        sw = true;
                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            else if (MotorDB == TipoCnn.SqlServer)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as SqlCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametros(cmd, getParametros(NombreParametros, ValoresParametros));
                        await cmd.ExecuteNonQueryAsync();


                        cn.Close();
                        sw = true;
                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            else if (MotorDB == TipoCnn.Mysql)
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as MySqlCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametrosMysql(cmd, getParamertrosMySql(NombreParametros, ValoresParametros));
                        await cmd.ExecuteNonQueryAsync();


                        cn.Close();
                        sw = true;
                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            return sw;

        }
        /// <summary>
        /// Método que retorna un excalar.
        /// <param name="strSQL">Recibe la sentencia sql para ejecutar en la base de datos.</param>
        /// <param name="NombreParametros">Recibe un array con el nombre de los parámetros.</param>
        /// <param name="ValoresParametros">Recibe un array con el valor de los parámetros.</param>
        /// </summary>
        public async Task<int> EjecutarSentenciaExcalar(string strSQL, string[] NombreParametros, object[] ValoresParametros)
        {

            if (MotorDB == TipoCnn.Oracle)
            {
                using (OracleConnection cn = new OracleConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as OracleCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametrosOracle(cmd, getParametrosOracle(NombreParametros, ValoresParametros));
                        //await cmd.ExecuteNonQueryAsync();
                        IdExcalar = Convert.ToInt32(await cmd.ExecuteScalarAsync());


                        cn.Close();

                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            else if (MotorDB == TipoCnn.SqlServer)
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as SqlCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametros(cmd, getParametros(NombreParametros, ValoresParametros));
                        //await cmd.ExecuteNonQueryAsync();
                        IdExcalar = Convert.ToInt32(await cmd.ExecuteScalarAsync());


                        cn.Close();

                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            else if (MotorDB == TipoCnn.Mysql)
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();
                        var cmd = cn.CreateCommand() as MySqlCommand;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strSQL;
                        setParametrosMysql(cmd, getParamertrosMySql(NombreParametros, ValoresParametros));
                        IdExcalar = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                        //await cmd.ExecuteNonQueryAsync();


                        cn.Close();

                    }
                    catch (Exception ex)
                    {
                        Error.WriterError(ex);
                    }
                }
            }
            return IdExcalar;
        }
        #endregion

        #endregion
        /// <summary>
        /// Métodos privados set y get que sólo son accesibles desde esta clase.
        /// </summary>
        #region Methods Privates

        private void setParametros(SqlCommand setCmd, SqlParameter[] setParameter)
        {
            if (setParameter != null)
            {
                for (int ic = 0; ic <= setParameter.Length - 1; ic++)
                {
                    setCmd.Parameters.Add(setParameter[ic]);
                }
            }

        }
        private void setParametrosOracle(OracleCommand setCmd, OracleParameter[] setParameter)
        {
            if (setParameter != null)
            {
                for (int ic = 0; ic <= setParameter.Length - 1; ic++)
                {
                    setCmd.Parameters.Add(setParameter[ic]);
                }
            }

        }
        private void setParametrosOracle(OracleCommand setCmd, string[] nomParametro, OracleDbType[] typParam, ParameterDirection[] DirParam)
        {
            if (nomParametro != null)
            {
                for (int ic = 0; ic <= nomParametro.Length - 1; ic++)
                {

                    setCmd.Parameters[nomParametro[ic]].Direction = DirParam[ic];
                    setCmd.Parameters.Add(nomParametro[ic], typParam[ic]);
                }
            }

        }
        private void setParametrosMysql(MySqlCommand setCmd, MySqlParameter[] setParameter)
        {
            if (setParameter != null)
            {
                for (int ic = 0; ic <= setParameter.Length - 1; ic++)
                {
                    setCmd.Parameters.Add(setParameter[ic]);
                }
            }

        }


        private SqlParameter[] getParametros(string[] NombreParametros, object[] ValoresParametros)
        {
            SqlParameter[] arrParametros = new SqlParameter[NombreParametros.Length];

            for (int ic = 0; ic <= NombreParametros.Length - 1; ic++)
            {
                SqlParameter? Parametro = new SqlParameter();
                Parametro.ParameterName = NombreParametros[ic];
                Parametro.Value = ValoresParametros[ic];
                arrParametros[ic] = Parametro;
                Parametro = null;
            }
            return arrParametros;
        }
        private OracleParameter[] getParametrosOracle(string[] NombreParametros, object[] ValoresParametros)
        {
            OracleParameter[] arrParametros = new OracleParameter[NombreParametros.Length];

            for (int ic = 0; ic <= NombreParametros.Length - 1; ic++)
            {
                OracleParameter? Parametro = new OracleParameter();
                Parametro.ParameterName = NombreParametros[ic];
                Parametro.Value = ValoresParametros[ic];
                arrParametros[ic] = Parametro;
                Parametro = null;
            }
            return arrParametros;
        }
        private MySqlParameter[] getParamertrosMySql(string[] NombreParametros, object[] ValoresParametros)
        {
            MySqlParameter[] arrParametros = new MySqlParameter[NombreParametros.Length];

            for (int ic = 0; ic <= NombreParametros.Length - 1; ic++)
            {
                MySqlParameter? Parametro = new MySqlParameter();
                Parametro.ParameterName = NombreParametros[ic];
                Parametro.Value = ValoresParametros[ic];
                arrParametros[ic] = Parametro;
                Parametro = null;
            }
            return arrParametros;
        }


        #endregion
    }
}
