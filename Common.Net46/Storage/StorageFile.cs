using System.IO;

namespace Common.Net46.Storage
{
    public class StorageFile
    {
        public StorageFile()
        {
        }

        public StorageFile(string fileName, Stream content, string contentType, int length)
        {
            FileName = fileName;
            FileContentType = contentType;
            Length = length;
            FileStream = content;
        }

        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string FileContentType { get; set; }
        public int Length { get; set; }
        public string FileExtension
        {
            get
            {
                return Path.GetExtension(FileName).TrimStart('.');
            }
        }
        public Stream FileStream { get; set; }
    }
}
