using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTurk.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns characters from the middle of a string.
        /// </summary>
        /// <param name="str">The source string. </param>
        /// <param name="start"> The start position. </param>
        /// <param name="end"> The end position. </param>
        /// <returns> The component of the source <see cref="string"/> that is between the start and end point. </returns>
        public static string Mid(this string str, int start, int end)
        {
            if (str == null) throw new ArgumentNullException("str");

            return str.Substring(start, end - start);
        }

        /// <summary>
        /// Trims the supplied array of strings the from end of the source string.
        /// </summary>
        /// <param name="str"> Source string </param>
        /// <param name="trimStrings"> Array of strings to trim from the end of the source string. </param>
        /// <returns> Trimmed source string. </returns>
        public static string TrimEnd(this string str, params string[] trimStrings)
        {
            return TrimEnd(str, StringComparison.Ordinal, trimStrings);
        }

        /// <summary>
        /// Trims the supplied array of strings the from end of the source string.
        /// </summary>
        /// <param name="str"> Source string  </param>
        /// <param name="comparisonType"> The comparison type. </param>
        /// <param name="trimStrings"> Strings to trim from the end of the source string. </param>
        /// <returns> Trimmed source string. </returns>
        public static string TrimEnd(this string str, StringComparison comparisonType, params string[] trimStrings)
        {
            if (str == null) throw new ArgumentNullException("str");
            if (trimStrings == null) throw new ArgumentNullException("trimStrings");

            bool matches;
            do
            {
                matches = false;
                foreach (var trimString in trimStrings)
                {
                    var index = str.LastIndexOf(trimString, comparisonType);
                    if (index == -1) continue;
                    if (index + trimString.Length != str.Length) continue;

                    str = str.Mid(0, index);
                    matches = true;
                }
            } while (matches);

            return str;
        }
    }
}
