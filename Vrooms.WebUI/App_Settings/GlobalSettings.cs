using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Vrooms.WebUI.App_Settings
{
    public sealed class GlobalSettings
    {
        private static readonly GlobalSettings instance = new GlobalSettings();

        static public string SiteTitle { get; set; }
        static public string SiteTitlePrefix { get; set; }
        static public string SiteTitleSuffix { get; set; }
        static public string SiteTitleHeader { get; set; }
        static public int MaxNumOfLoans { get; set; }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static GlobalSettings()
        {
            SiteTitle = WebConfigurationManager.AppSettings["SiteTitle"];
            SiteTitlePrefix = WebConfigurationManager.AppSettings["SiteTitlePrefix"];
            SiteTitleSuffix = WebConfigurationManager.AppSettings["SiteTitleSuffix"];
            SiteTitleHeader = WebConfigurationManager.AppSettings["SiteTitleHeader"];
            MaxNumOfLoans = Convert.ToInt32(WebConfigurationManager.AppSettings["MaxNumOfLoans"]);
        }

        private GlobalSettings()
        {
        }

        public static GlobalSettings Instance
        {
            get
            {
                return instance;
            }
        }
    } 
}