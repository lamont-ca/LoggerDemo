using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerTesting.Models;

namespace LoggerTesting
{
    public class SetEnvironmetVariables
    {
        // SET Enviornment
        static string _basePath    = ConfigurationManager.AppSettings["basePath"];
        static string _environment = ConfigurationManager.AppSettings["Environment"];
        static string _fullPath    = _basePath + _environment;
        // SET File Paths
        static string _allMessagesfilePath   = _fullPath + "\\" + ConfigurationManager.AppSettings["AllMessages"] + "";
        static string _infoMessagesfilePath  = _fullPath + "\\" + ConfigurationManager.AppSettings["Information"] + "";
        static string _debugMessagesfilePath = _fullPath + "\\" + ConfigurationManager.AppSettings["Debug"] + "";
        static string _warnMessagesfilePath  = _fullPath + "\\" + ConfigurationManager.AppSettings["Warning"] + "";
        static string _errorMessagesfilePath = _fullPath + "\\" + ConfigurationManager.AppSettings["Error"] + "";
        public static EnvironmentModel SetEnvVariables()
        {

            EnvironmentModel model = new EnvironmentModel()
            {
                basePath          = _basePath,
                environment       = _environment,
                allMessagesPath   = _allMessagesfilePath,
                infoMessagesPath  = _infoMessagesfilePath,
                debugMessagesPath = _debugMessagesfilePath,
                warnMessagesPath  = _warnMessagesfilePath,
                erroMessagesPath  = _errorMessagesfilePath
            };

            return model;
        }
    }
}
