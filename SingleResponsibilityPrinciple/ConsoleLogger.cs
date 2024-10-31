using System;

using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class ConsoleLogger : ILogger
    {

        // Logs the message to both the console and an XML file
        private void LogMessage(string type, string message, params object[] args)
        {
            // Format the message with provided arguments
            string formattedMessage = string.Format(message, args);

            // Log to console
            Console.WriteLine($"{type}: {formattedMessage}");

            // Log to XML file
            using (StreamWriter logfile = File.AppendText("log.xml"))
            {
                logfile.WriteLine($"<log><type>{type}</type><message>{formattedMessage}</message></log>");
            }
        }

        // Log a warning message
        public void LogWarning(string message, params object[] args)
        {
            LogMessage("WARN", message, args);
        }

        // Log an informational message
        public void LogInfo(string message, params object[] args)
        {
            LogMessage("INFO", message, args);
        }

        /*
        // original code
        public void LogWarning(string message, params object[] args)
        {
            Console.WriteLine(string.Concat("WARN: ", message), args);
        }

        public void LogInfo(string message, params object[] args)
        {
            Console.WriteLine(string.Concat("INFO: ", message), args);
        }
        */



        /*
        public void LogWarning(string message, params object[] args)
        {
            LogMessage("WARN", message, args);
        }

        public void LogInfo(string message, params object[] args)
        {
            LogMessage("INFO", message, args);
        }
        // New method to log to both console and XML file
        private void LogMessage(string type, string message, params object[] args)
        {
            // Format the message with any provided arguments
            string formattedMessage = string.Format(message, args);

            // Log to console
            Console.WriteLine($"{type}: {formattedMessage}");

            // Log to XML file
            using (StreamWriter logfile = File.AppendText("log.xml"))
            {
                logfile.WriteLine($"<log><type>{type}</type><message>{formattedMessage}</message></log>");
            }
        }
        */
    }
}
