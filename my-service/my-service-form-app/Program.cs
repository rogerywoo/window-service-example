using my_service_library;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace my_service_form_app
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const string MUTEX_MY_APP_NAME = "MyServiceFormApp";

            bool instanceCountOne = false;

            using (Mutex mtex = new Mutex(true, MUTEX_MY_APP_NAME, out instanceCountOne))
            {
                if (instanceCountOne)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    MyServiceForm myServiceForm = new MyServiceForm();
                    Application.Run();
                    
                    //                    Application.Run(new MyServiceForm());

                    mtex.ReleaseMutex();
                }
                else
                {
                    MessageBox.Show("An application instance is already running");
                }
            }
        }
    }
}
