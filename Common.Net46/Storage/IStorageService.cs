using System.IO;

namespace Common.Net46.Storage
{
    public interface IStorageService
    {
        StorageFile Get(string fileUrl);
        StorageFile Store(Stream fileStream);
        StorageFile Store(Stream fileStream, string fileName);
        bool Delete(string fileUrl);
    }
}
