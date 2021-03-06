﻿using System;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hitTypeId"></param>
        /// <param name="question"></param>
        /// <param name="lifetime"></param>
        /// <param name="assignmentReviewPolicy"></param>
        /// <param name="hitReviewPolicy"></param>
        /// <param name="requesterAnnotation"></param>
        /// <param name="maxAssignments"></param>
        /// <returns></returns>
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
            IEnumerable<QualificationRequirement> qualificationRequirements,
            IQuestion question,
            TimeSpan lifetime,
            TimeSpan? autoApprovalDelay = null,
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
                AssignmentDurationInSecondsSpecified = true,
                Keywords = string.Join(",", keywords ?? Enumerable.Empty<string>()),
                AutoApprovalDelayInSeconds = (long)(autoApprovalDelay ?? TimeSpan.FromDays(30)).TotalSeconds,
                AutoApprovalDelayInSecondsSpecified = autoApprovalDelay != null,
                QualificationRequirement = (qualificationRequirements ?? Enumerable.Empty<QualificationRequirement>()).ToArray(),
                LifetimeInSeconds = (long)lifetime.TotalSeconds,
                MaxAssignments = maxAssignments,
                MaxAssignmentsSpecified = maxAssignments != 1,
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
