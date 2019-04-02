using my_service_library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        const string MY_NAME = "My-Service-Setup";

        static void Main(string[] args)
        {
            string workingDir = args[0];
            EventLog eventLog = new EventLog();
            if (!EventLog.SourceExists(MY_NAME))
            {
                EventLog.CreateEventSource(MY_NAME, "Application");
            }
            eventLog.Source = MY_NAME;
            eventLog.Log = "Application";

            string filePath;
            try
            {
                StartService();
                SetupFileAccess();

                filePath = String.Format("{0}//{1}.exe", workingDir, Settings.FORM_APP_NAME);
                //StartFormApp(filePath);

                AddStartup(filePath, workingDir);
            }
            catch (Exception ex)
            {
                eventLog.WriteEntry(ex.ToString(), EventLogEntryType.Error);
                eventLog.WriteEntry(String.Format("My current directory {0}", Directory.GetCurrentDirectory()));

                for (int i = 0; i < args.Length; i++)
                {
                    eventLog.WriteEntry(String.Format("Arg {0} : {1}", i, args[i]));
                }
            }

            DateTime dt = File.GetCreationTime(Settings.MEMORY_FILENAME);
        }

        static void SetupFileAccess()
        {
            FileAttributes attributes = File.GetAttributes(Settings.MEMORY_FILENAME);

            FileSecurity filesecurity = File.GetAccessControl(Settings.MEMORY_FILENAME);

            filesecurity.AddAccessRule(
    new FileSystemAccessRule("Users", FileSystemRights.Write, AccessControlType.Allow));

            File.SetAccessControl(Settings.MEMORY_FILENAME, filesecurity);

        }

        static void StartService()
        {
            ServiceController sc = new ServiceController(Settings.SERVICE_NAME);
            sc.Start();
        }

        static void StartFormApp(string fileName)
        {
            Process process = new Process
            {
                StartInfo = {
                    FileName = fileName,
                    UseShellExecute = true }
            };

            process.Start();
        }

        static void AddStartup(string fileName, string workingDir)
        {
            IWshRuntimeLibrary.WshShell wsh = new IWshRuntimeLibrary.WshShell();
            string linkName = String.Format(@"\{0}.lnk", Settings.FORM_APP_NAME);
            IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup) + linkName) as IWshRuntimeLibrary.IWshShortcut;
            shortcut.Arguments = "";
            shortcut.TargetPath = fileName;
            shortcut.WindowStyle = 1;
            shortcut.Description = Settings.FORM_APP_NAME;
            shortcut.WorkingDirectory = workingDir + @"\";
            //shortcut.IconLocation = "specify icon location";
            shortcut.Save();
        }
    }
}
