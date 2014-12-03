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
    public class TurkClient
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
            var col = new NameValueCollection
            {
                ["service"] = header.Service,
                ["operation"] = header.Operation,
                ["timestamp"] = header.Timestamp.ToString("O")
            };

            var qs = col.ToQueryString(urlEncode: false);

            var hmac = CalculateHMAC(qs, secretKey);

            header.Signature = hmac;
        }

        public async Task<CreateHITResponse> CreateHIT(string hitTypeId,
            IQuestion question,
            TimeSpan lifetime,
            ReviewPolicy assignmentReviewPolicy = null,
            ReviewPolicy hitReviewPolicy = null,
            string requesterAnnotation = null,
            int maxAssignments = 1)
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

            PackQuestion(question, request);

            var resp = await ExecuteRequest(request);
            return resp;
        }

        public async Task<CreateHITResponse> CreateHIT(string title,
            string description,
            Price reward,
            TimeSpan assignmentDuration,
            IEnumerable<string> keywords,
            TimeSpan autoApprovalDelay,
            IEnumerable<QualificationRequirement> qualificationRequirements,
            IQuestion question,
            TimeSpan lifetime,
            ReviewPolicy assignmentReviewPolicy = null,
            ReviewPolicy hitReviewPolicy = null,
            string requesterAnnotation = null,
            int maxAssignments = 1)
        {
            var requestToken = Guid.NewGuid();
            var request = new CreateHITRequest
            {
                Title = title,
                Description = description,
                Reward = reward,
                AssignmentDurationInSeconds = (long)assignmentDuration.TotalSeconds,
                Keywords = string.Join(",", keywords ?? Enumerable.Empty<string>()),
                AutoApprovalDelayInSeconds = (long)autoApprovalDelay.TotalSeconds,
                QualificationRequirement = (qualificationRequirements ?? Enumerable.Empty<QualificationRequirement>()).ToArray(),
                LifetimeInSeconds = (long)lifetime.TotalSeconds,
                MaxAssignments = maxAssignments,
                AssignmentReviewPolicy = assignmentReviewPolicy,
                HITReviewPolicy = hitReviewPolicy,
                RequesterAnnotation = requesterAnnotation,
                UniqueRequestToken = requestToken.ToString("N")
            };

            PackQuestion(question, request);

            var resp = await ExecuteRequest(request);
            return resp;
        }

        private async Task<CreateHITResponse> ExecuteRequest(CreateHITRequest request)
        {
            var header = new RestHeader
            {
                Operation = "CreateHIT",
                AWSAccessKey = _accessKey,
                Timestamp = DateTime.UtcNow
            };
            Sign(header, _secretKey);

            var col = TurkSerializer.Collect(request);
            TurkSerializer.Collect(header, col);
            var qs = col.ToQueryString();

            var serializer = new XmlSerializer(typeof(CreateHITResponse));

            var builder = new UriBuilder(_baseUri) { Query = qs };
            using (var result = await HttpClient.GetAsync(builder.Uri))
            {
                using (var stream = await result.Content.ReadAsStreamAsync())
                {
                    var resp = (CreateHITResponse)serializer.Deserialize(stream);
                    return resp;
                }
            }
        }

        private static void PackQuestion(IQuestion question, CreateHITRequest request)
        {
            var serializer = new XmlSerializer(question.GetType());
            using (var sw = new StringWriter())
            {
                serializer.Serialize(sw, question);
                request.Question = sw.ToString();
            }
        }
    }
}
