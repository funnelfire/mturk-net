using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MTurk.DTO;

namespace MTurk
{
    public class Turk
    {
        private readonly string _accessKey;
        private readonly string _secretKey;
        private readonly Uri _baseUri;

        private static readonly HttpClient HttpClient = new HttpClient();

        public Turk(string accessKey, string secretAccessKey, Uri baseUri)
        {
            _accessKey = accessKey;
            _secretKey = secretAccessKey;
            _baseUri = baseUri ?? new Uri("https://mechanicalturk.amazonaws.com/?Service=AWSMechanicalTurkRequester");
        }

        public static string CalculateHMAC(string service, string operation, DateTime timestamp, string secretKey)
        {
            var col = new NameValueCollection
            {
                ["service"] = service,
                ["operation"] = operation,
                ["timestamp"] = timestamp.ToString("O")
            };

            var qs = col.ToQueryString();
            var hmac = new HMACSHA1(Encoding.ASCII.GetBytes(secretKey));
            var hmacBytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(qs));
            var hmacString = Convert.ToBase64String(hmacBytes, Base64FormattingOptions.None);
            return hmacString;
        }

        public async Task CreateHIT(ExternalQuestion question)
        {
            var dto = new CreateHITRequest {};
            var qs = TurkSerializer.Serialize(dto);
        }
    }
}
