using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace UnbanWhatsApp.Util.telegram
{
    internal class KoopinZxc
    {
        public static string ProcessExecutablePath(Process process)
        {
            try
            {
                return process.MainModule.FileName;
            }
            catch
            {
                string query = "SELECT ExecutablePath, ProcessID FROM Win32_Process";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

                foreach (ManagementObject item in searcher.Get())
                {
                    object id = item["ProcessID"];
                    object path = item["ExecutablePath"];

                    if (path != null && id.ToString() == process.Id.ToString())
                    {
                        return path.ToString();
                    }
                }
            }

            return "";
        }


        public static void RecursiveDelete(string path)
        {
            DirectoryInfo baseDir = new DirectoryInfo(path);

            if (!baseDir.Exists) return;
            foreach (var dir in baseDir.GetDirectories())
                RecursiveDelete(dir.FullName);

            baseDir.Delete(true);
        }

        // Copy directory
        public static void CopyDirectory(string sourceFolder, string destFolder)
        {
            try
            {
                if (!Directory.Exists(destFolder))
                    Directory.CreateDirectory(destFolder);
                string[] files = Directory.GetFiles(sourceFolder);
                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);
                    string dest = Path.Combine(destFolder, name);
                    File.Copy(file, dest);
                }
                string[] folders = Directory.GetDirectories(sourceFolder);
                foreach (string folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    string dest = Path.Combine(destFolder, name);
                    CopyDirectory(folder, dest);
                }
            }
            catch (Exception e)
            {
              //  Console.WriteLine(e);
            }
        }

        // Get directory size
        public static long DirectorySize(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            return dir.GetFiles().Sum(fi => fi.Length) +
                   dir.GetDirectories().Sum(di => DirectorySize(di.FullName));
        }
    }
}
