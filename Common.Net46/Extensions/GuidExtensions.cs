using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Net46.Extensions
{
    public static class GuidExtensions
    {
        public static decimal ToLongNumber(this Guid input)
        {
            decimal result = 1;
            foreach (var b in input.ToByteArray())
            {
                result += Convert.ToInt16(b) * Convert.ToInt16(b);
            }
            return result;
        }

        public static decimal ToShortNumber(this Guid input)
        {
            decimal result = 0;
            foreach (var b in input.ToByteArray())
            {
                result += Convert.ToInt16(b);
            }
            return result;
        }
    }
}
