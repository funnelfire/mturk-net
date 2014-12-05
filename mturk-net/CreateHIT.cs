using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MTurk.DTO;

namespace MTurk
{
    partial class TurkClient
    {
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

            var resp = await ExecuteRequest<CreateHITRequest, CreateHITResponse>(request);
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

            var resp = await ExecuteRequest<CreateHITRequest, CreateHITResponse>(request);
            return resp;
        }

        private class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding { get; } = new UTF8Encoding(true);
        }

        private static void PackQuestion(IQuestion question, CreateHITRequest request)
        {
            var serializer = new XmlSerializer(question.GetType());
            using (var sw = new Utf8StringWriter())
            {
                serializer.Serialize(sw, question);
                request.Question = sw.ToString();
            }
        }
    }
}
