namespace Travel.Connections
{
    /// <summary>
    /// Clase para manejar el log de errores.
    /// </summary>
    public class cError
    {
        /// <summary>
        /// Método que escribe el error en el archivo log.txt.
        /// <param name="ex">Recibe la Exception y la guarda.</param>
        /// </summary>
        public void WriterError(Exception ex)
        {
            string strPath = "../Travel.Connections/Error/log.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }

            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;

            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine(message);
                sw.Close();
            }
        }
    }
}
