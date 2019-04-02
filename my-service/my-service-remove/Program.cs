using my_service_library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_service_remove
{
    class Program
    {
        const string MY_NAME = "My-Service-Remove";
        static void Main(string[] args)
        {
            EventLog eventLog = new EventLog();
            if (!EventLog.SourceExists(MY_NAME))
            {
                EventLog.CreateEventSource(MY_NAME, "Application");
            }
            eventLog.Source = MY_NAME;
            eventLog.Log = "Application";

            RemoveStartup();
        }

        static void RemoveStartup()
        {
            string linkPath = String.Format(@"{0}\{1}.lnk", Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup), Settings.FORM_APP_NAME);

            if (File.Exists(linkPath))
            {
                File.Delete(linkPath);
            }
        }
    }
}