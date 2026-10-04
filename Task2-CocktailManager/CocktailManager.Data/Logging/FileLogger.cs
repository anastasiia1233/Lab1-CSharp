using System;
using System.IO;

namespace CocktailManager.Data.Logging
{
    public class FileLogger
    {
        private readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt");

        public void Log(string message)
        {
            try
            {
                File.AppendAllText(logFilePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + message + Environment.NewLine);
            }
            catch
            {
            }
        }
    }
}