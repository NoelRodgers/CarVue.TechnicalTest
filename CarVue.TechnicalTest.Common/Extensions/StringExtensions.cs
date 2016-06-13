using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CarVue.TechnicalTest.Common.Extensions
{
    public static class StringExtensions
    {
        [DebuggerStepThrough]
        public static string FormatString(this string baseString, params object[] items)
        {
            return string.Format(baseString, items);
        }

        [DebuggerStepThrough]
        public static string WithoutWhitespace(this string baseString)
        {
            return string.IsNullOrEmpty(baseString)
                        ? baseString
                        : Regex.Replace(baseString, @"\s+", string.Empty);
        }


    }
}
