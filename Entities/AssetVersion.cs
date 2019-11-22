using Common.Net46.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class AssetVersion : IntIdentifiableBaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }
        public int FolderId { get; set; }
        public virtual Folder Folder { get; set; }
    }
}
