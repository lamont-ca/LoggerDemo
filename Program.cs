using System;
using System.Collections.Generic;
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
            FileLogger logger = new FileLogger();

            // TESTING ---------------------------//

            // Information
            TestInfoLog(logger);
            // Warning
            TestWarningLog(logger);
            // Debug
            TestDebugLog(logger);
            // Error
            TestErrorLog(logger);
        }

        // All log types have the type of Logger injected

        /// <summary>
        /// Tests that Information Logs are written
        /// </summary>
        /// <param name="logger"></param>
        public static void TestInfoLog(FileLogger logger)
        {
            //Information
            logger.Log("Information", " This is an Information Log Message");
        }

        /// <summary>
        /// Tests that Warning Logs are written
        /// </summary>
        /// <param name="logger"></param>
        public static void TestWarningLog(FileLogger logger)
        {
            var arg2 = 0;
            if (arg2 == 0)
            {
                //Information
                logger.Log("Warning", " This is an Warning Log Message - Can't do Zero Division " + arg2);
            }
        }

        /// <summary>
        /// Tests that Debug logs are written
        /// </summary>
        /// <param name="logger"></param>
        public static void TestDebugLog(FileLogger logger)
        {
            // Debug
            var firstNum = 10;
            logger.Log("Debug", " : First Num " + firstNum.ToString());
            var secondNum = 5;
            logger.Log("Debug", " : Second Num " + secondNum.ToString());
            logger.Log("Debug", " This is an Debug Log Message : Sum of FirstNum and SecondNum is " + (firstNum + secondNum));
        }

        /// <summary>
        /// Tests that Error Logs are written
        /// </summary>
        /// <param name="logger"></param>
        public static void TestErrorLog(FileLogger logger)
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
                logger.Log("Error", " This is an Error Log Message " + ex.Message);
            }

        }
    }
}
