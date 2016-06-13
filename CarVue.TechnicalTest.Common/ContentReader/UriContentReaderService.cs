using System;
using System.Net;
using System.Text;
using CarVue.TechnicalTest.Common.ContentReader.Settings;
using CarVue.TechnicalTest.Common.Extensions;
using CarVue.TechnicalTest.Common.Interfaces;

namespace CarVue.TechnicalTest.Common.ContentReader
{
    public class UriContentReaderService : IUriContentReaderService
    {
        private const string _invalidUri = "The supplied uri of '{0}' is not valid";
        private readonly ContentReaderSettings _settings;

        public string ReturnCode { get; set; }
        public UriContentReaderService(IConfigurationBuilder configurationBuilder)
        {
            _settings = configurationBuilder.GetConfiguration<ContentReaderSettings>();
        }

        public string Read(string location, Encoding encoding = null)
        {
            try
            {
                var timeout = (_settings.MaxRequestTimeoutSeconds ?? 30) * 1000;
                using (var client = new ContentWebClient(timeout))
                {
                    client.Encoding = encoding ?? Encoding.UTF8;
                    return client.DownloadString(new Uri(location));
                }
            }
            catch (UriFormatException ex)
            {
                throw new UriFormatException(_invalidUri.FormatString(location), ex);
            }
            catch (WebException we)
            {
                var response = (HttpWebResponse)we.Response;
                var statusCode = response.StatusCode;
                throw new WebException("Error occured: " + statusCode);
            }
        }
    }
}