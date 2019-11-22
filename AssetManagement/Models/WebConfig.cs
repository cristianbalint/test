using System.Configuration;

namespace AssetManagement.Models
{
    public class WebConfig
    {
        public static string BlobConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["BlobConnectionString"];
            }
        }

        public static string DbConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["DbConnectionString"];
            }
        }
    }
}