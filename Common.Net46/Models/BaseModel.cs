using Common.Net46.DataAccess;

namespace Common.Net46.Models
{
    public class BaseModel : BaseEntity
    {
        public string TenantId { get; set; }
    }
}
