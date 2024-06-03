using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace APKEasyTool
{
    public static class Variables
    {
        public static readonly string MyDocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static readonly string ApkSignerPath = "\"" + RealPath("Resources\\ApkSigner.jar\" sign ");

        public static readonly string GetDiskLetter = Path.GetPathRoot(RealPath()).Replace("\\", "");

        public static string LogPath = Path.Combine(Path.GetTempPath(), "AET", "log.txt");

        public static string TempPath = Path.Combine(Path.GetTempPath(), "AET");

        public static string TempPathCache = Path.Combine(Path.GetTempPath(), "AET", "Cache");

        // public static string Apktool = "\"" + RealPath + "Apktool\\" + apkToolComboBox.Text + "\"";
        public static string Apktool, InsCount, CodePage, ApkToolVer;

        public static string GetTodayDate()
        {
            return DateTime.Now.ToString("yyyy_MM_dd");
        }

        public static string GetPath()
        {
            if (Path.GetPathRoot(RealPath()) == "C:\\" &&
                !Path.GetFullPath(RealPath()).Contains(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)))
            {
                return MyDocPath + "\\APK Easy Tool\\";
            }
            else
                return RealPath();
        }

        public static string GetFileThatContains(string path, string textToSearch)
        {

            if (string.IsNullOrWhiteSpace(textToSearch))
                return null;

            string[] allFiles = Directory.GetFiles(path, "*.smali", SearchOption.AllDirectories);

            foreach (string file in allFiles)
            {
                string[] lines = File.ReadAllLines(file);
                string firstOccurrence = lines.FirstOrDefault(l => l.Contains(textToSearch));
                if (firstOccurrence != null)
                    return file;
            }

            return null;
        }
        public static string RealPath(string path = "")
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + path;
        }

        public static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        public static string GetFileMD5Sum(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public static string CreateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
