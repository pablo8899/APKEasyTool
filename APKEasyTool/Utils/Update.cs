using APKEasyTool.JsonModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace APKEasyTool
{
    public class Updates
    {
            //- Updated adb to 33.0.2
            //- Updated aapt, zipalign, apksigner to 32.0.0

        
        private static string EASY_TOOL_UPDATE_URL = "https://evildog1.bitbucket.io/apkeasytool/aet1.txt";
        private static string APK_TOOL_UPDATE_URL = "https://api.bitbucket.org/2.0/repositories/iBotPeaches/apktool/downloads";

        public static string EasyToolVersion()
        {
            if (NetworkInterface.GetIsNetworkAvailable() == true)
            {
                try
                {
                    string getupdatedata;
                    WebClient wc = new WebClient();

                    getupdatedata = wc.DownloadString(EASY_TOOL_UPDATE_URL);

                    if (!String.IsNullOrEmpty(getupdatedata))
                    {
                        return getupdatedata;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return "ERROR";
                }
            }
            return null;
        }

        public static ApkToolUpdate ApkToolVersion()
        {
            if (NetworkInterface.GetIsNetworkAvailable() == true)
            {
                try
                {
                    string getupdatedata;
                    WebClient wc = new WebClient();

                    getupdatedata = wc.DownloadString(APK_TOOL_UPDATE_URL);

                    if (!string.IsNullOrEmpty(getupdatedata))
                    {
                        ApkToolUpdate apkToolUpdate = JsonConvert.DeserializeObject<ApkToolUpdate>(getupdatedata);
                        if (apkToolUpdate == null)
                            return null;

                        return apkToolUpdate;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return null;
                }
            }
            return null;
        }
    }
}
