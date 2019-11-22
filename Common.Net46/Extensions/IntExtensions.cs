using System;
using System.Reflection;

namespace Common.Net46.Extensions
{
    public static class IntExtensions
    {
        public static T ToEnumOption<T>(this int input)
         where T : struct, IConvertible
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            return (T)Enum.Parse(typeof(T), input.ToString());
        }
    }
}
