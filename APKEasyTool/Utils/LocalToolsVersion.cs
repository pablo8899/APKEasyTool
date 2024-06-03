using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APKEasyTool.Utils
{
    public class LocalToolsVersion
    {
        public static List<string> LocalApkToolVersion()
        {
            List<string> apktoolFiles = new List<string>();
            apktoolFiles.AddRange(Directory.GetFiles("Apktool"));
            return apktoolFiles;
        }
    }
}
