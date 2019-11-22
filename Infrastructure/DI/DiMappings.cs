using Common.Net46.Interfaces;
using Common.Net46.Storage;
using DatabaseAccess;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DI
{
    public class DiMappings
    {
        public static IEnumerable<KeyValuePair<Type, Type>> GetTypeDependencies(WebConfig config)
        {
            //AppConfigurations configs = new AppConfigurations(services.BuildServiceProvider().GetService<Microsoft.Extensions.Configuration.IConfiguration>());
            Dictionary<Type, Type> configs = new Dictionary<Type, Type>();
            //configs.Add(typeof(IVideosAssetsService), typeof(VideosAssetsService));
            //configs.Add(typeof(IImagesAssetsService), typeof(AssetsService));
            configs.Add(typeof(IAssetsService), typeof(AssetsService));
            configs.Add(typeof(IFoldersService), typeof(FoldersService));
            configs.Add(typeof(IGenericRepository<>), typeof(EfRepository<>));

            return configs;
        }

        public static IEnumerable<KeyValuePair<Type, Object>> GetCreatedDependencies(WebConfig config)
        {
            //AppConfigurations configs = new AppConfigurations(services.BuildServiceProvider().GetService<Microsoft.Extensions.Configuration.IConfiguration>());
            Dictionary<Type, Object> configs = new Dictionary<Type, Object>();
            //configs.Add(typeof(IVideosAssetsService), typeof(VideosAssetsService));
            //configs.Add(typeof(IImagesAssetsService), typeof(AssetsService));
            configs.Add(typeof(AppDbContext), new AppDbContext());
            configs.Add(typeof(IMetadataService), new CognitiveVisionMetadataService(config.AzCognitiveVisionKey, config.AzCognitiveVisionEndpoint));
            configs.Add(typeof(IStorageService), new BlobStorageService(config.BlobConnectionString, config.BlobContainerName));

            return configs;
        }
    }
}
