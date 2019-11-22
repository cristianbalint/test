using Infrastructure.Interfaces;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Infrastructure.Services
{
    public class CognitiveVisionMetadataService : IMetadataService
    {
        ComputerVisionClient client;
        public CognitiveVisionMetadataService(string key, string endpoint)
        {
            client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(key)) { Endpoint = endpoint };
        }
        public string GetMetadata(Stream stream)
        {
            using (Stream imageFileStream = stream)
            {
                //
                // Analyze the image for all visual features.
                //
                //VisualFeatureTypes[] visualFeatures = GetSelectedVisualFeatures();
                ImageAnalysis analysisResult = client.AnalyzeImageInStreamAsync(imageFileStream, null, null).Result;
                return JsonConvert.SerializeObject(analysisResult);
            }
        }

        public string GetThumbnail(Stream stream)
        {
            return "";
        }
    }
}
