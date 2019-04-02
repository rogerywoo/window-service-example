using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using my_service_library;
using Newtonsoft.Json;

namespace my_service_form_app
{
    public partial class MyServiceForm : Form
    {
        private ServiceController _sc;

        public MyServiceForm()
        {
            InitializeComponent();
            _sc = new ServiceController(Settings.SERVICE_NAME);
        }

        private void MyServiceForm_Load(object sender, EventArgs e)
        {
            try
            {
                ReadSettings();
            }
            catch (DirectoryNotFoundException ex)
            {
                tb_Output.Text = "Directory not found";
            }
            catch (Exception ex)
            {
                tb_Output.Text = ex.ToString();
            }
        }

            private void btn_SelectInputFolder_Click(object sender, EventArgs e)
        {
            if (tb_InputFolder.Text.Length > 0) fbd_InputFolder.SelectedPath = tb_InputFolder.Text;

            fbd_InputFolder.ShowDialog();
            tb_InputFolder.Text = fbd_InputFolder.SelectedPath;
        }

        private void btn_SelectOutputFolder_Click(object sender, EventArgs e)
        {
            if (tb_OutputFolder.Text.Length > 0) fbd_OutputFolder.SelectedPath = tb_OutputFolder.Text;

            fbd_OutputFolder.ShowDialog();
            tb_OutputFolder.Text = fbd_OutputFolder.SelectedPath;
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            try
            {
                tb_Output.Clear();
                MyTask.CopyFiles(tb_InputFolder.Text, tb_OutputFolder.Text);
                tb_Output.Text = "Complete";
            }
            catch (Exception ex)
            {
                tb_Output.Text = ex.ToString();
            }
        }

        private void btn_UpdateSettings_Click(object sender, EventArgs e)
        {
            try
            {
                tb_Output.Clear();
                updateSettings();
                tb_Output.Text = "Complete";
            }
            catch (Exception ex)
            {
                tb_Output.Text = ex.ToString();
            }
        }


        private void notifyIcon_Click(object sender, EventArgs e)
        {
            notifyIconMenuStrip.Show();
        }


        private void MyServiceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Only exit if Exiting from menu
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Show();
            }
            catch (DirectoryNotFoundException ex)
            {
                tb_Output.Text = "Directory not found";
            }
            catch (Exception ex)
            {
                tb_Output.Text = ex.ToString();
            }
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_StopService_Click(object sender, EventArgs e)
        {
            try
            {
                _sc.Stop();
                Refresh();
            }
            catch (Exception ex)
            {
                tb_Output.Text = ex.ToString();
            }
        }

        private void btn_StartService_Click(object sender, EventArgs e)
        {
            try
            {
                _sc.Start();
                Refresh();
            }
            catch (Exception ex)
            {
                tb_Output.Text = ex.ToString();
            }
        }

        private void btn_RestartService_Click(object sender, EventArgs e)
        {
            try
            {
                _sc.Stop();
                _sc.Start();
                Refresh();
            }
            catch (Exception ex)
            {
                tb_Output.Text = ex.ToString();
            }
        }

        private void updateSettings()
        {
            Settings settings = new Settings();
            settings.inputFolder = tb_InputFolder.Text;
            settings.outputFolder = tb_OutputFolder.Text;

            bool mutexCreated = false;
            Mutex mutex;

            using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(Settings.MEMORY_FILENAME, FileMode.OpenOrCreate, Settings.MEMORY_NAME, Settings.MEMORY_SIZE))
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
                    BinaryWriter writer = new BinaryWriter(stream);

                    writer.Write(JsonConvert.SerializeObject(settings));
                }

                if (!mutexCreated)
                {
                    mutex.WaitOne();
                }
                mutex.ReleaseMutex();
            }
        }

        private void ReadSettings()
        {
            bool mutexCreated = false;
            Mutex mutex;
            Settings settings;

            using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(Settings.MEMORY_FILENAME, FileMode.Open, Settings.MEMORY_NAME, Settings.MEMORY_SIZE))
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

                    tb_InputFolder.Text = settings.inputFolder;

                    tb_OutputFolder.Text = settings.outputFolder;
                }

                if (!mutexCreated)
                {
                    mutex.WaitOne();
                }
                mutex.ReleaseMutex();
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            btn_RestartService.Enabled = false;
            btn_StartService.Enabled = false;
            btn_StopService.Enabled = false;

            btn_RestartService.Enabled = _sc.Status == ServiceControllerStatus.Running;
            btn_StartService.Enabled = _sc.Status == ServiceControllerStatus.Stopped;
            btn_StopService.Enabled = _sc.Status == ServiceControllerStatus.Running;

            ReadSettings();
        }


    }
}
