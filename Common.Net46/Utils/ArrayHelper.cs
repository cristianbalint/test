using System.Collections.Generic;

namespace Common.Net46.Utils
{
    public class ArrayHelper
    {
        public static string[] ArrayFrom(string[] array, params string[] otherElements)
        {
            List<string> result = new List<string>();
            if (array != null)
            {
                result.AddRange(array);
            }
            if (otherElements != null && otherElements.Length > 0)
            {
                foreach (var elem in otherElements)
                {
                    result.Add(elem);
                }
            }

            return result.ToArray();
        }
    }
}
