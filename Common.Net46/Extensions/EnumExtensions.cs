using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Net46.Extensions
{
    public static class EnumExtensions
    {
        public static int Value(this Enum input)
        {
            return Convert.ToInt32(input);
        }

        public static string ToDictionary(this Enum input)
        {
            return Convert.ToString(input);
        }
    }
}
