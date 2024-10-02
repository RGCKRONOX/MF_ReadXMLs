using System;
using System.IO;

/// <summary>
/// Summary description for Class1
/// </summary>

namespace ReadXMLPremium
{
    public class FileManager
    {
        private string workDir;

        public FileManager(string workDir)
        {
            if (!Directory.Exists(workDir))
                Directory.CreateDirectory(workDir);

            this.workDir = workDir;
        }

        public void createFile(string fileName, string content)
        {
            File.WriteAllText(Path.Combine(this.workDir, fileName), content);
        }

    }
}
