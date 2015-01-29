using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Text;

namespace Vrooms.WebUI.App_Settings
{
    public sealed class GlobalSettings
    {
        private static readonly GlobalSettings instance = new GlobalSettings();

        static public string SiteTitle { get; set; }
        static public string SiteTitlePrefix { get; set; }
        static public string SiteTitleSuffix { get; set; }
        static public string SiteTitleHeader { get; set; }
        static public string SiteTitleWithPrefixAndSuffix { get; set; }

        static GlobalSettings()
        {
            SiteTitle = WebConfigurationManager.AppSettings["SiteTitle"];
            SiteTitlePrefix = WebConfigurationManager.AppSettings["SiteTitlePrefix"];
            SiteTitleSuffix = WebConfigurationManager.AppSettings["SiteTitleSuffix"];
            SiteTitleHeader = WebConfigurationManager.AppSettings["SiteTitleHeader"];
            SiteTitleWithPrefixAndSuffix = GetSiteTitleWithPrefixAndSuffix();
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

        // utility methods
        private static string GetSiteTitleWithPrefixAndSuffix()
        {
            StringBuilder sb = new StringBuilder();
            if (!String.IsNullOrWhiteSpace(SiteTitlePrefix))
            {
                sb.Append(SiteTitlePrefix);
                sb.Append(" ");
            }
            sb.Append(SiteTitle);
            if (!String.IsNullOrWhiteSpace(SiteTitleSuffix))
            {
                sb.Append(" ");
                sb.Append(SiteTitleSuffix);
            }
            return sb.ToString();
        }
    } 
}