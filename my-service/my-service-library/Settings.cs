using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_service_library
{
    [Serializable]
    public class Settings
    {
        public const string SERVICE_NAME = "MyService";
        public const string MUTEX_APP_NAME = "MutexMyServiceFormApp";
        public const string MUTEX_MEMORY_NAME = "MutexMyServiceMemory";
        public const string MEMORY_NAME = "MyServiceMemory";
        public const Int64 MEMORY_SIZE = 10000;


        public static string MEMORY_FILENAME = String.Format("{0}\\ProgramData\\BCMC\\MyService.data", Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)));
        
        public string inputFolder { get; set; }
        public string outputFolder { get; set; }

    }

}
