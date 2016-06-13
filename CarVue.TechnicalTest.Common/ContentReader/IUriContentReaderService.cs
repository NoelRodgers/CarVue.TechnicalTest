using System.Text;

namespace CarVue.TechnicalTest.Common.ContentReader
{
    public interface IUriContentReaderService
    {
        string Read(string location, Encoding encoding = null);
    }
}