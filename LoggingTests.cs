using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace LoggerTesting
{
    public class LoggingTests
    {
        // All log types have the type of Logger injected

        /// <summary>
        /// Tests that Information Logs are written
        /// </summary>
        /// <param name="logger"></param>
        public static void TestInfoLog(FileLogger logger, string filePath)
        {
            //Information
            logger.Log(LogType.Information.ToString(), " This is an Information Log Message", filePath);
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

        public static void AllMessages(FileLogger logger, string FilePath)
        {
            // All messages
            logger.Log(LogType.All.ToString(), " This is a Log Message ", FilePath);
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
