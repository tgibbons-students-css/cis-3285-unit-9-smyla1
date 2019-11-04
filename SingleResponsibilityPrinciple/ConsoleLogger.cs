using System;
using System.IO;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class ConsoleLogger : ILogger
    {
        public void LogWarning(string message, params object[] args)
        {
            // Displays Message in console
            Console.WriteLine(string.Concat("WARN: ", message), args);

            // writes Message in log file
            using (StreamWriter logfile = File.AppendText("log.xml"))
            {
                logfile.WriteLine("<log> + <message>" + message + "</message></log> ", args);
            }

        }

        public void LogInfo(string message, params object[] args)
        {
            // Displays Message in console
            Console.WriteLine(string.Concat("INFO: ", message), args);

            // writes Message in log file
            using (StreamWriter logfile = File.AppendText("log.xml"))
            {
                logfile.WriteLine("<log> + <message>" + message + "</message></log> ", args);
            }
        }

    }
}
