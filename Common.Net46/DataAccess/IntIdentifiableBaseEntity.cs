using System.Collections.Generic;
using System.Reflection;

namespace Common.Net46.DataAccess
{
    public abstract class IntIdentifiableBaseEntity : BaseEntity
    {
        public virtual int Id { get; set; }

        public virtual IntIdentifiableBaseEntity Clone()
        {
            return (IntIdentifiableBaseEntity)this.MemberwiseClone();
        }

        public virtual IntIdentifiableBaseEntity CloneWithoutReferences()
        {
            var clone = (IntIdentifiableBaseEntity)this.MemberwiseClone();

            foreach (var property in clone.GetType().GetProperties())
            {
                var propertyInfo = property.PropertyType.GetTypeInfo();
                if ((propertyInfo.IsClass && propertyInfo.IsSubclassOf(typeof(IntIdentifiableBaseEntity))) ||
                    (propertyInfo.IsGenericType && propertyInfo.IsInterface))
                {
                    property.SetValue(clone, null);
                }
            }

            return clone;
        }
    }
}
