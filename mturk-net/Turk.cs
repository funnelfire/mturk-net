using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
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

        public static void Sign(RestHeader header, string secretKey)
        {
            var hmac = CalculateHMAC(
                service: "AWSMechanicalTurkRequester", // see: http://docs.aws.amazon.com/AWSMechTurk/latest/AWSMturkAPI/ApiReference_CommonParametersArticle.html
                operation: header.Operation,
                timestamp: header.Timestamp,
                secretKey: secretKey
            );

            header.Signature = hmac;
        }

        public async Task CreateHIT(string hitTypeId, IQuestion question, TimeSpan lifetime, ReviewPolicy assignmentReviewPolicy = null, ReviewPolicy hitReviewPolicy = null, string requesterAnnotation = null, int maxAssignments = 1)
        {
            var requestToken = Guid.NewGuid();
            var request = new CreateHITRequest
            {
                HITTypeId = hitTypeId,
                LifetimeInSeconds = (long)lifetime.TotalSeconds,
                MaxAssignments = maxAssignments,
                AssignmentReviewPolicy = assignmentReviewPolicy,
                HITReviewPolicy = hitReviewPolicy,
                RequesterAnnotation = requesterAnnotation,
                UniqueRequestToken = requestToken.ToString("N")
            };

            var serializer = new XmlSerializer(question.GetType());
            using (var sw = new StringWriter())
            {
                serializer.Serialize(sw, question);
                request.Question = sw.ToString();
            }

            var header = new RestHeader
            {
                Operation = "CreateHIT",
                AWSAccessKey = _accessKey,
            };
            Sign(header, _secretKey);

            var col = TurkSerializer.Collect(request);
            TurkSerializer.Collect(header, col);
            var qs = col.ToQueryString();

            using (var result = await HttpClient.GetAsync(new UriBuilder(_baseUri) { Query = qs }.Uri))
            {
                
            }
        }
    }
}
