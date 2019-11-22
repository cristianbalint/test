using Common.Net46.Interfaces;
using Common.Net46.Services;
using Common.Net46.Storage;
using Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class AssetsService : IAssetsService
    {
        private readonly IStorageService storageService;
        private readonly IGenericRepository<Asset> assetsRepo;
        private readonly IGenericRepository<AssetVersion> assetVersionRepo;
        private readonly IMetadataService metadataService;

        public AssetsService(IStorageService storageService, IGenericRepository<Asset> assetsRepo,
            IGenericRepository<AssetVersion> assetVersionRepo, IMetadataService metadataService)
        {
            this.storageService = storageService;
            this.assetsRepo = assetsRepo;
            this.assetVersionRepo = assetVersionRepo;
            this.metadataService = metadataService;
        }

        public StorageFile SaveAssetToStorage(StorageFile asset)
        {
            return storageService.Store(asset.FileStream, asset.FileName);
        }

        public IOperationResult SaveAsset(StorageFile file)
        {
            var storedFile = SaveAssetToStorage(file);
            if (storedFile != null)
            {
                // save to db
                var savedAsset = assetsRepo.AddAndSave(new Asset()
                {
                    Name = storedFile.FileName,
                    Url = storedFile.FileUrl,
                    Metadata = metadataService.GetMetadata(storedFile.FileStream)
                });

                if (savedAsset != null)
                {
                    return OperationResult.Succeeded(savedAsset, "Asset Saved");
                }
            }

            //return OperationResult.NotSucceeded("Asset Not Saved");
            return OperationResult.NotSucceeded("Asset not Saved");

        }

        public IEnumerable<Asset> GetAll()
        {
            return assetsRepo.GetAll().ToList();
        }
    }
}
