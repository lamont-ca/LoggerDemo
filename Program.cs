using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace LoggerTesting
{
    class Program
    {/// <summary>
     /// For testing - injecting logger type as parameter
     /// </summary>
     /// <param name="args"></param>
        static void Main(string[] args)
        {
            // SET Enviornment
            string basePath = "C:\\temp\\";
            string environment = ConfigurationManager.AppSettings["DevlEnvironment"];
            //string environment = ConfigurationManager.AppSettings["ProdEnvironment"];
            string fullPath = basePath + environment;
            
            string allMessagesfilePath   = fullPath + "\\" + ConfigurationManager.AppSettings["AllMessages"] + "";            
            string infoMessagesfilePath  = fullPath + "\\" + ConfigurationManager.AppSettings["Information"] + "";
            string debugMessagesfilePath = fullPath + "\\" + ConfigurationManager.AppSettings["Debug"] + "";
            string warnMessagesfilePath  = fullPath + "\\" + ConfigurationManager.AppSettings["Warning"] + "";
            string errorMessagesfilePath = fullPath + "\\" + ConfigurationManager.AppSettings["Error"] + "";

            FileLogger logger = new FileLogger();

            // TESTING ---------------------------//

            // Information
            TestInfoLog(logger,    infoMessagesfilePath);
            // Warning
            TestWarningLog(logger, warnMessagesfilePath);
            // Debug
            TestDebugLog(logger,   debugMessagesfilePath);
            // Error
            TestErrorLog(logger,   errorMessagesfilePath);
        }

        // All log types have the type of Logger injected

        /// <summary>
        /// Tests that Information Logs are written
        /// </summary>
        /// <param name="logger"></param>
        public static void TestInfoLog(FileLogger logger, string filePath)
        {
            //Information
            logger.Log("Information", " This is an Information Log Message", filePath);
        }

        /// <summary>
        /// Tests that Warning Logs are written
        /// </summary>
        /// <param name="logger"></param>
        public static void TestWarningLog(FileLogger logger, string filePath)
        {
            var arg2 = 0;
            if (arg2 == 0)
            {
                //Information
                logger.Log("Warning", " This is an Warning Log Message - Can't do Zero Division " + arg2, filePath);
            }
        }

        /// <summary>
        /// Tests that Debug logs are written
        /// </summary>
        /// <param name="logger"></param>
        public static void TestDebugLog(FileLogger logger, string filePath)
        {
            // Debug
            var firstNum = 10;
            logger.Log("Debug", " : First Num " + firstNum.ToString(), filePath);
            var secondNum = 5;
            logger.Log("Debug", " : Second Num " + secondNum.ToString(), filePath);
            logger.Log("Debug", " This is an Debug Log Message : Sum of FirstNum and SecondNum is " + (firstNum + secondNum), filePath);
        }

        /// <summary>
        /// Tests that Error Logs are written
        /// </summary>
        /// <param name="logger"></param>
        public static void TestErrorLog(FileLogger logger, string filePath)
        {
            var arg1 = 1;
            var arg2 = 0;
            try
            {
                var result = arg1 / arg2;
            }
            catch (Exception ex)
            {
                // Error
                logger.Log("Error", " This is an Error Log Message " + ex.Message, filePath);
            }

        }
    }
}
