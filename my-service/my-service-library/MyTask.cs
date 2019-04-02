using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_service_library
{
    public class MyTask
    {
        public static void CopyFiles(string inputFolder, string outputFolder)
        {
            if ((outputFolder.Length < 3) || (inputFolder.Length < 3))
                throw new Exception("Invalid input or output folder");
            
            string[] filePaths = Directory.GetFiles(inputFolder);
            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);

                string newFilePath = string.Format("{0}\\{1}", outputFolder, fileName);

                if (!File.Exists(newFilePath))
                {
                    File.Copy(filePath, newFilePath);
                }
            }           
        }
    }
}
