using System.Diagnostics;
using System.Globalization;

namespace CarVue.TechnicalTest.Common.Extensions
{
    public static class NumericExtensions
    {
        [DebuggerStepThrough]
        public static string ToInvariantString(this int value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        } 
    }
}