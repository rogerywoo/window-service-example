using my_service_library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace my_service_form_read_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_ReadMemory_Click(object sender, EventArgs e)
        {
            try
            {
                tb_Result.Clear();
                bool mutexCreated = false;

                Settings settings;

                using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(
     Settings.MEMORY_FILENAME, FileMode.Open, Settings.MEMORY_NAME))


     //           using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(Settings.MEMORY_NAME))
                {
                    Mutex mutex = new Mutex(true, Settings.MUTEX_MEMORY_NAME, out mutexCreated);

                    //Mutex mutex = Mutex.OpenExisting(Settings.MUTEX_MEMORY_NAME);
                    mutex.WaitOne();

                    using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                    {
                        string strSettings;
                        BinaryReader reader = new BinaryReader(stream);
                        strSettings = reader.ReadString();

                        settings = (Settings)JsonConvert.DeserializeObject(strSettings, typeof(Settings));

                        tb_Result.Text = strSettings;
                    }

                    mutex.ReleaseMutex();
                }
            }
            catch (FileNotFoundException)
            {
                tb_Result.Text = "Memory-mapped file does not exist. Run Process A first.";
            }
            catch (Exception ex)
            {
                tb_Result.Text = ex.ToString();
            }
        }
    }
}
