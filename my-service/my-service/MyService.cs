using my_service_library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace my_service
{
    public partial class MyService : ServiceBase
    {
        private System.Timers.Timer _timer;
        private string _inputFolder = @"c:\tempInput";
        private string _outputFolder = @"c:\tempOutput";

        public MyService()
        {
            InitializeComponent();

            _timer = new System.Timers.Timer();
            _timer.Interval = 60000; // 60 seconds
            _timer.Elapsed += new ElapsedEventHandler(this.OnTimer);

            if (!EventLog.SourceExists(this.ServiceName))
            {
                EventLog.CreateEventSource(this.ServiceName, "Application");
            }
            eventLog.Source = this.ServiceName;
            eventLog.Log = "Application";
        }

        public void onDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            eventLog.WriteEntry("Started");
            InitSettings();
            _timer.Start();
        }

        protected override void OnStop()
        {
            _timer.Stop();
            eventLog.WriteEntry("Started");
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            MyTask.CopyFiles(_inputFolder, _outputFolder);
        }

        protected void InitSettings()
        {
            Settings settings;
            Mutex mutex;

            bool mutexCreated = false;
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(
                    Settings.MEMORY_FILENAME, FileMode.Open, Settings.MEMORY_NAME))
                {

                    try
                    {
                        mutex = Mutex.OpenExisting(Settings.MUTEX_MEMORY_NAME);
                    }
                    catch (WaitHandleCannotBeOpenedException)
                    {
                        mutex = new Mutex(true, Settings.MUTEX_MEMORY_NAME, out mutexCreated);
                    }

                    using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                    {
                        string strSettings;
                        BinaryReader reader = new BinaryReader(stream);
                        strSettings = reader.ReadString();

                        settings = (Settings)JsonConvert.DeserializeObject(strSettings, typeof(Settings));

                        _inputFolder = settings.inputFolder;

                        _outputFolder = settings.outputFolder;
                    }

                    if (!mutexCreated)
                    {
                        mutex.WaitOne();
                    }

                    mutex.ReleaseMutex();
                }
            }
            catch(Exception ex)
            {
                eventLog.WriteEntry(ex.ToString(), EventLogEntryType.Error);
                eventLog.WriteEntry("Using default settings");
            }
        }
    }
}
