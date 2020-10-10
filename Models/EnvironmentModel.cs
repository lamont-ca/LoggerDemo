using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerTesting.Models
{
    public class EnvironmentModel
    {
        public string basePath { get; set; }
        public string environment { get; set; }
        public string fullPath { get; set; }
        public string allMessagesPath { get; set; }
        public string infoMessagesPath { get; set; }
        public string debugMessagesPath { get; set; }
        public string warnMessagesPath { get; set; }
        public string erroMessagesPath { get; set; }

    }
}
