using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure.Interfaces
{
    public interface IMetadataService
    {
        string GetMetadata(Stream stream);
        string GetThumbnail(Stream stream);
    }
}
