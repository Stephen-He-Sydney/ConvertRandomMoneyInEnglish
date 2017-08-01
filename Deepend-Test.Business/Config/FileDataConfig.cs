using System.Configuration;
using System.IO;
using System;

namespace Deepend_Test.Business.Config
{
    public static class FileDataConfig
    {
        public static string DataSource
        {
           get {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                    AppDomain.CurrentDomain.RelativeSearchPath ?? string.Empty,
                                    ConfigurationManager.AppSettings["DataSource"]);
            }
        }
    }
}
