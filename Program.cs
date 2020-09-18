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
        // SET Enviornment
        static string basePath = "C:\\temp\\";
        static string environment = ConfigurationManager.AppSettings["Environment"];        
        static string fullPath = basePath + environment;
        // SET File Paths
        static string allMessagesfilePath   = fullPath + "\\" + ConfigurationManager.AppSettings["AllMessages"] + "";
        static string infoMessagesfilePath  = fullPath + "\\" + ConfigurationManager.AppSettings["Information"] + "";
        static string debugMessagesfilePath = fullPath + "\\" + ConfigurationManager.AppSettings["Debug"] + "";
        static string warnMessagesfilePath  = fullPath + "\\" + ConfigurationManager.AppSettings["Warning"] + "";
        static string errorMessagesfilePath = fullPath + "\\" + ConfigurationManager.AppSettings["Error"] + "";

        /// <summary>
        /// For testing - injecting logger type as parameter
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
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
            AllMessages(logger);
            //Information
            logger.Log(LogType.Information.ToString(), " This is an Information Log Message", filePath);
        }

        /// <summary>
        /// Tests that Warning Logs are written
        /// </summary>
        /// <param name="logger"></param>
        public static void TestWarningLog(FileLogger logger, string filePath)
        {
            AllMessages(logger);
            var arg2 = 0;
            if (arg2 == 0)
            {
                //Warning
                logger.Log(LogType.Warning.ToString(), " This is an Warning Log Message - Can't do Zero Division " + arg2, filePath);
            }
        }

        /// <summary>
        /// Tests that Debug logs are written
        /// </summary>
        /// <param name="logger"></param>
        public static void TestDebugLog(FileLogger logger, string filePath)
        {
            AllMessages(logger);
            // Debug
            var firstNum = 10;
            logger.Log(LogType.Debug.ToString(), " : First Num " + firstNum.ToString(), filePath);
            var secondNum = 5;
            logger.Log(LogType.Debug.ToString(), " : Second Num " + secondNum.ToString(), filePath);
            logger.Log(LogType.Debug.ToString(), " This is an Debug Log Message : Sum of FirstNum and SecondNum is " + (firstNum + secondNum), filePath);
        }

        /// <summary>
        /// Tests that Error Logs are written
        /// </summary>
        /// <param name="logger"></param>
        public static void TestErrorLog(FileLogger logger, string filePath)
        {
            AllMessages(logger);
            var arg1 = 1;
            var arg2 = 0;
            try
            {
                var result = arg1 / arg2;
            }
            catch (Exception ex)
            {
                // Error
                logger.Log(LogType.Error.ToString(), " This is an Error Log Message " + ex.Message, filePath);
            }

        }

        public static void AllMessages(FileLogger logger)
        {
            var filePath = allMessagesfilePath;
            logger.Log(LogType.All.ToString(), " This is a Log Message ", filePath);
        }

        public enum LogType
        {
            Information,
            Warning,
            Debug,
            Error,
            All
        }
    }
}
