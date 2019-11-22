using Common.Net46.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Folder : IntIdentifiableBaseEntity
    {
        [Required]
        public string Name { get; set; }
        public int ParentFolderId { get; set; }
    }
}
