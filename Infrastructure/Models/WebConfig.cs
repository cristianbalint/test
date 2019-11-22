using System.Configuration;

namespace Infrastructure.Models
{
    public class WebConfig
    {
        public string BlobConnectionString { get; set; }
        public string BlobContainerName { get; set; }
        
        public string AzCognitiveVisionKey { get; set; }
        public string AzCognitiveVisionEndpoint { get; set; }


    }
}