using my_service_library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace my_service_setup
{
    class Program
    {
        static void Main(string[] args)
        {
            FileAttributes attributes = File.GetAttributes(Settings.MEMORY_FILENAME);

            FileSecurity filesecurity = File.GetAccessControl(Settings.MEMORY_FILENAME);

            filesecurity.AddAccessRule(
    new FileSystemAccessRule("Users", FileSystemRights.Write, AccessControlType.Allow));

            File.SetAccessControl(Settings.MEMORY_FILENAME, filesecurity);

            StartService();


            DateTime dt = File.GetCreationTime(Settings.MEMORY_FILENAME);
        }


        static void StartService()
        {
            ServiceController sc = new ServiceController(Settings.SERVICE_NAME);
            sc.Start();
        }
    }
}
