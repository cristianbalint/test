using Common.Net46.Storage;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure.Services
{
    public class BlobStorageService : IStorageService
    {
        CloudStorageAccount storageAccount;
        CloudBlobClient blobClient;
        CloudBlobContainer container;
        public BlobStorageService(string connectionString, string containerName = null)
        {
            // Retrieve storage account from connection string.
            storageAccount = CloudStorageAccount.Parse(connectionString);
            // Create the blob client.
            blobClient = storageAccount.CreateCloudBlobClient();
            // Retrieve a reference to a container.
            container = blobClient.GetContainerReference(containerName ?? "container");
            // Create the container if it doesn't already exist.
            container.CreateIfNotExistsAsync();
            container.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
        }

        public StorageFile Get(string fileUrl)
        {
            var fileResult = new StorageFile();
            // Retrieve reference to a blob named "photo1.jpg".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileUrl);
            fileResult.FileName = blockBlob.Name;
            fileResult.FileUrl = blockBlob.StorageUri.PrimaryUri.ToString();

            // Save blob contents to a file.
            using (var memoryStream = new MemoryStream())
            {
                blockBlob.DownloadToStreamAsync(memoryStream);
                fileResult.FileStream = memoryStream;
            }

            return fileResult;
        }

        public StorageFile Store(Stream fileStream)
        {
            var fileResult = new StorageFile();
            string fileUrl = DateTime.Now.ToString("yyyyMMddhhmmssff") + ".stm";

            try
            {
                // Retrieve reference to a blob named "myblob".
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileUrl);
                fileResult.FileName = blockBlob.Name;
                fileResult.FileUrl = blockBlob.StorageUri.PrimaryUri.ToString();
                fileResult.FileStream = fileStream;

                // Create or overwrite the "myblob" blob with contents from a local file.
                blockBlob.UploadFromStreamAsync(fileStream);
                return fileResult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public StorageFile Store(Stream fileStream, string fileName)
        {
            var fileResult = new StorageFile();
            try
            {
                // Retrieve reference to a blob named "myblob".
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                fileResult.FileName = blockBlob.Name;
                fileResult.FileUrl = blockBlob.StorageUri.PrimaryUri.ToString();
                fileResult.FileStream = fileStream;

                // Create or overwrite the "myblob" blob with contents from a local file.
                blockBlob.UploadFromStreamAsync(fileStream);
                return fileResult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Delete(string fileUrl)
        {
            try
            {
                // Retrieve reference to a blob named "myblob.txt".
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileUrl);

                // Delete the blob.
                blockBlob.DeleteIfExistsAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region Private Methods

        #endregion
    }
}
