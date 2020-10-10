using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace LoggerTesting
{
    public class Program
    {        
        /// <summary>
        /// For testing - injecting logger type as parameter
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var envVar = SetEnvironmetVariables.SetEnvVariables();
            FileLogger logger = new FileLogger();

            // TESTING ---------------------------//

            // Information
            LoggingTests.TestInfoLog(logger,    envVar.infoMessagesPath);
            // Warning
            LoggingTests.TestWarningLog(logger, envVar.warnMessagesPath);
            // Debug
            LoggingTests.TestDebugLog(logger,   envVar.debugMessagesPath);
            // Error
            LoggingTests.TestErrorLog(logger,   envVar.erroMessagesPath);
            // All
            LoggingTests.AllMessages(logger,    envVar.allMessagesPath);
        }        
    }
}
