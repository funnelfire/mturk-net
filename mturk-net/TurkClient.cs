using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using MTurk.DTO;
using MTurk.Extensions;

namespace MTurk
{
    public partial class TurkClient
    {
        private readonly string _accessKey;
        private readonly string _secretKey;
        private readonly Uri _baseUri;

        private static readonly HttpClient HttpClient = new HttpClient();

        public TurkClient(string accessKey, string secretKey, Uri baseUri)
        {
            if (accessKey == null) throw new ArgumentNullException("accessKey");
            if (secretKey == null) throw new ArgumentNullException("secretKey");
            if (baseUri == null) throw new ArgumentNullException("baseUri");

            _accessKey = accessKey;
            _secretKey = secretKey;
            _baseUri = baseUri;
        }

        public TurkClient(string accessKey, string secretKey, bool sandbox)
            : this(accessKey, secretKey, sandbox ? new Uri("https://mechanicalturk.sandbox.amazonaws.com/") : new Uri("https://mechanicalturk.amazonaws.com/"))
        {
        }

        public TurkClient(string accessKey, string secretKey)
            : this(accessKey, secretKey, false)
        {
        }

        public static string CalculateHMAC(string data, string secretKey)
        {
            var hmac = new HMACSHA1(Encoding.ASCII.GetBytes(secretKey));
            var hmacBytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(data));
            var hmacString = Convert.ToBase64String(hmacBytes, Base64FormattingOptions.None);
            return hmacString;
        }

        public static void Sign(RestHeader header, string secretKey)
        {
            var hash = header.Service + header.Operation + header.Timestamp.ToString("O");
            var hmac = CalculateHMAC(hash, secretKey);

            header.Signature = hmac;
        }

        private class NamespaceIgnorantXmlTextReader : XmlTextReader
        {
            public NamespaceIgnorantXmlTextReader(System.IO.TextReader reader) : base(reader) { }

            public override string NamespaceURI
            {
                get { return base.NamespaceURI == string.Empty ? "http://requester.mturk.amazonaws.com/doc/2013-11-15" : base.NamespaceURI; }
            }
        }

        private async Task<TResponse> ExecuteRequest<TRequest, TResponse>(TRequest request)
        {
            var operation = typeof(TRequest).Name.TrimEnd("Request");
            var header = new RestHeader
            {
                Operation = operation,
                AWSAccessKeyId = _accessKey,
                Timestamp = DateTime.UtcNow
            };
            Sign(header, _secretKey);

            var col = TurkSerializer.Collect(request);
            TurkSerializer.Collect(header, col);
            var qs = col.ToQueryString();

            var serializer = new XmlSerializer(typeof(TResponse));

            var builder = new UriBuilder(_baseUri) { Query = qs };
            using (var result = await HttpClient.GetAsync(builder.Uri))
            {
                result.EnsureSuccessStatusCode();

                using (var stream = await result.Content.ReadAsStreamAsync())
                using (var tr = new StreamReader(stream))
                using (var nsxtr = new NamespaceIgnorantXmlTextReader(tr))
                {
                    var resp = (TResponse)serializer.Deserialize(nsxtr);
                    return resp;
                }
            }
        }
    }
}