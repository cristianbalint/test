using Common.Net46.Interfaces;
using Common.Net46.Storage;
using Entities;
using System.Collections.Generic;

namespace Infrastructure.Interfaces
{
    public interface IAssetsService
    {   
        IOperationResult SaveAsset(StorageFile file);
        IEnumerable<Asset> GetAll();
    }
}
