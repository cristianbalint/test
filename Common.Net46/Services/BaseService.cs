using Common.Net46.DataAccess;
using Common.Net46.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Common.Net46.Services
{
    public abstract class BaseService
    {
        public virtual ICollection<ValidationResult> ValidateModel(BaseModel @object)
        {
            var context = new ValidationContext(@object, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            //if (string.IsNullOrWhiteSpace(@object.TenantId))
            //{
            //    results.Add(new ValidationResult("Tenant id must be supplied"));
            //}
            Validator.TryValidateObject(
                @object, context, results,
                validateAllProperties: true
            );

            return results;
        }

        public virtual ICollection<ValidationResult> ValidateEntity(IntIdentifiableBaseEntity @object)
        {
            var context = new ValidationContext(@object, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            //if (string.IsNullOrWhiteSpace(@object.TenantId))
            //{
            //    results.Add(new ValidationResult("Tenant id must be supplied"));
            //}
            Validator.TryValidateObject(
                @object, context, results,
                validateAllProperties: true
            );

            return results;
        }
    }
}
