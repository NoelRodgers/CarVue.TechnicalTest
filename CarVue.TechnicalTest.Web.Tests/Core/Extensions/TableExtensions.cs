using System.Linq;
using TechTalk.SpecFlow;

namespace CarVue.TechnicalTest.Web.Tests.Core.Extensions
{
    public static class TableExtensions
    {
        public static bool CompareWithOrder(this Table table, Table comparisonTable)
        {
            return table.Header.SequenceEqual(comparisonTable.Header) && table.Rows.SequenceEqual(comparisonTable.Rows);
        }

        public static bool CompareAnyContains(this Table table, Table comparisonTable)
        {
            return table.Header.SequenceEqual(comparisonTable.Header) && comparisonTable.Rows.Any(x => table.Rows.Any(y => y.Values.SequenceEqual(x.Values)));
        }

        public static bool CompareAllContains(this Table table, Table comparisonTable)
        {
            return table.ToString() == comparisonTable.ToString();
        }

        //TODO - This still needs work, not functioning correctly
        public static bool CompareAllOneWayContains(this Table table, Table comparisonTable)
        {
            return table.Header.SequenceEqual(comparisonTable.Header) && comparisonTable.Rows.All(x =>
            {
                bool result = table.Rows.Any(y => y.Values.SequenceEqual(x.Values));
                return result;
            });
        }
    }
}