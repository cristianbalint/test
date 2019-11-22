using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Common.Net46.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidEmail(this string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return false;

            var emailPattern = @"[a-zA-Z0-9!#$%&'*+=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?";
            //return Regex.IsMatch(input, @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$",
            return Regex.IsMatch(input, emailPattern,
                  RegexOptions.IgnoreCase);
        }

        public static byte[] GetBytes(this string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static T ToEnumOption<T>(this string input)
        where T : struct, IConvertible
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            return (T)Enum.Parse(typeof(T), input);
        }

        /// <summary>
        /// Capitalization - writing a word with its first letter in upper-case and the remaining letters in lower-case.
        /// </summary>
        /// <param name="theString"></param>
        /// <returns></returns>
        public static string Capitalize(this string theString)
        {
            return theString == null ? null : theString.First().ToString().ToUpper() + theString.Substring(1);
        }

        /// <summary>
        /// Add random numbers to a base string
        /// </summary>
        /// <param name="baseString"></param>
        /// <param name="fixedLength">How many random characters to be concatenated to base string</param>
        /// <returns></returns>
        public static string WithRandomNumbers(this string baseString, int fixedLength = 5)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < fixedLength; i++)
                s = string.Concat(s, random.Next(10).ToString());
            return string.Concat(baseString, s);
        }

        /// <summary>
        /// Capitalize a persons name. For example: leonardo da vinci -> Leonardo Da Vinci
        /// </summary>
        /// <param name="theString"></param>
        /// <returns></returns>
        public static string CapitalizeNames(this string theString)
        {
            if (string.IsNullOrEmpty(theString))
                return string.Empty;

            var parts = theString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < parts.Length; i++)
            {
                parts[i] = parts[i].Capitalize();
            }
            return string.Join(" ", parts);
        }

        public static string ToEmailRegexPattern(this string input)
        {
            return @"";
        }
    }
}
