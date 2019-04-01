using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        public MyServiceForm()
        {
            InitializeComponent();

            this.ControlBox = false;

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

        private void MyServiceForm_Resize(object sender, EventArgs e)
        {
            //if (FormWindowState.Minimized == WindowState)
            //    Hide();
        }

        private void MyServiceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;

            //Hide();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
