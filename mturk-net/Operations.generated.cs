using System;
using System.Threading.Tasks;
using MTurk.DTO;

namespace MTurk
{
	partial class TurkClient
	{
        public async Task<DisposeHITResponse> DisposeHIT(string hitId, string[] responseGroup)
		{
			var request = new DisposeHITRequest
            {
				HITId = hitId,
				ResponseGroup = responseGroup,
            };

            var resp = await ExecuteRequest<DisposeHITRequest, DisposeHITResponse>(request);
            return resp;
		}

        public async Task<GetHITResponse> GetHIT(string hitId, string[] responseGroup)
		{
			var request = new GetHITRequest
            {
				HITId = hitId,
				ResponseGroup = responseGroup,
            };

            var resp = await ExecuteRequest<GetHITRequest, GetHITResponse>(request);
            return resp;
		}

        public async Task<GrantBonusResponse> GrantBonus(string workerId, MTurk.DTO.Price bonusAmount, string assignmentId, string reason, string uniqueRequestToken, string[] responseGroup)
		{
			var request = new GrantBonusRequest
            {
				WorkerId = workerId,
				BonusAmount = bonusAmount,
				AssignmentId = assignmentId,
				Reason = reason,
				UniqueRequestToken = uniqueRequestToken,
				ResponseGroup = responseGroup,
            };

            var resp = await ExecuteRequest<GrantBonusRequest, GrantBonusResponse>(request);
            return resp;
		}

        public async Task<GetAssignmentsForHITResponse> GetAssignmentsForHIT(string hitId, MTurk.DTO.AssignmentStatus[] assignmentStatus, string[] responseGroup, System.Nullable<MTurk.DTO.SortDirection> sortDirection = null, System.Nullable<MTurk.DTO.GetAssignmentsForHITSortProperty> sortProperty = null, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new GetAssignmentsForHITRequest
            {
				HITId = hitId,
				AssignmentStatus = assignmentStatus,
				ResponseGroup = responseGroup,
				SortDirection = sortDirection ?? default(MTurk.DTO.SortDirection),
				SortDirectionSpecified = sortDirection == default(System.Nullable<MTurk.DTO.SortDirection>),
				SortProperty = sortProperty ?? default(MTurk.DTO.GetAssignmentsForHITSortProperty),
				SortPropertySpecified = sortProperty == default(System.Nullable<MTurk.DTO.GetAssignmentsForHITSortProperty>),
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber == default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize == default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetAssignmentsForHITRequest, GetAssignmentsForHITResponse>(request);
            return resp;
		}

        public async Task<GetReviewResultsForHITResponse> GetReviewResultsForHIT(string hitId, MTurk.DTO.ReviewPolicyLevel[] policyLevel, string[] responseGroup, System.Nullable<bool> retrieveActions = null, System.Nullable<bool> retrieveResults = null, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new GetReviewResultsForHITRequest
            {
				HITId = hitId,
				PolicyLevel = policyLevel,
				ResponseGroup = responseGroup,
				RetrieveActions = retrieveActions ?? default(bool),
				RetrieveActionsSpecified = retrieveActions == default(System.Nullable<bool>),
				RetrieveResults = retrieveResults ?? default(bool),
				RetrieveResultsSpecified = retrieveResults == default(System.Nullable<bool>),
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber == default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize == default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetReviewResultsForHITRequest, GetReviewResultsForHITResponse>(request);
            return resp;
		}

        public async Task<GetQualificationsForQualificationTypeResponse> GetQualificationsForQualificationType(string qualificationTypeId, string[] responseGroup, System.Nullable<MTurk.DTO.QualificationStatus> status = null, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new GetQualificationsForQualificationTypeRequest
            {
				QualificationTypeId = qualificationTypeId,
				ResponseGroup = responseGroup,
				Status = status ?? default(MTurk.DTO.QualificationStatus),
				StatusSpecified = status == default(System.Nullable<MTurk.DTO.QualificationStatus>),
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber == default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize == default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetQualificationsForQualificationTypeRequest, GetQualificationsForQualificationTypeResponse>(request);
            return resp;
		}

        public async Task<GetQualificationRequestsResponse> GetQualificationRequests(string qualificationTypeId, string[] responseGroup, System.Nullable<MTurk.DTO.SortDirection> sortDirection = null, System.Nullable<MTurk.DTO.GetQualificationRequestsSortProperty> sortProperty = null, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new GetQualificationRequestsRequest
            {
				QualificationTypeId = qualificationTypeId,
				ResponseGroup = responseGroup,
				SortDirection = sortDirection ?? default(MTurk.DTO.SortDirection),
				SortDirectionSpecified = sortDirection == default(System.Nullable<MTurk.DTO.SortDirection>),
				SortProperty = sortProperty ?? default(MTurk.DTO.GetQualificationRequestsSortProperty),
				SortPropertySpecified = sortProperty == default(System.Nullable<MTurk.DTO.GetQualificationRequestsSortProperty>),
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber == default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize == default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetQualificationRequestsRequest, GetQualificationRequestsResponse>(request);
            return resp;
		}

        public async Task<HelpResponse> Help(string[] about, string[] responseGroup, System.Nullable<MTurk.DTO.HelpRequestHelpType> helpType = null)
		{
			var request = new HelpRequest
            {
				About = about,
				ResponseGroup = responseGroup,
				HelpType = helpType ?? default(MTurk.DTO.HelpRequestHelpType),
				HelpTypeSpecified = helpType == default(System.Nullable<MTurk.DTO.HelpRequestHelpType>),
            };

            var resp = await ExecuteRequest<HelpRequest, HelpResponse>(request);
            return resp;
		}

        public async Task<DisableHITResponse> DisableHIT(string hitId, string[] responseGroup)
		{
			var request = new DisableHITRequest
            {
				HITId = hitId,
				ResponseGroup = responseGroup,
            };

            var resp = await ExecuteRequest<DisableHITRequest, DisableHITResponse>(request);
            return resp;
		}

        public async Task<GetFileUploadURLResponse> GetFileUploadURL(string assignmentId, string questionIdentifier)
		{
			var request = new GetFileUploadURLRequest
            {
				AssignmentId = assignmentId,
				QuestionIdentifier = questionIdentifier,
            };

            var resp = await ExecuteRequest<GetFileUploadURLRequest, GetFileUploadURLResponse>(request);
            return resp;
		}

        public async Task<GetAssignmentResponse> GetAssignment(string assignmentId, string[] responseGroup)
		{
			var request = new GetAssignmentRequest
            {
				AssignmentId = assignmentId,
				ResponseGroup = responseGroup,
            };

            var resp = await ExecuteRequest<GetAssignmentRequest, GetAssignmentResponse>(request);
            return resp;
		}

        public async Task<SearchHITsResponse> SearchHITs(string[] responseGroup, System.Nullable<MTurk.DTO.SortDirection> sortDirection = null, System.Nullable<MTurk.DTO.SearchHITsSortProperty> sortProperty = null, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new SearchHITsRequest
            {
				ResponseGroup = responseGroup,
				SortDirection = sortDirection ?? default(MTurk.DTO.SortDirection),
				SortDirectionSpecified = sortDirection == default(System.Nullable<MTurk.DTO.SortDirection>),
				SortProperty = sortProperty ?? default(MTurk.DTO.SearchHITsSortProperty),
				SortPropertySpecified = sortProperty == default(System.Nullable<MTurk.DTO.SearchHITsSortProperty>),
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber == default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize == default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<SearchHITsRequest, SearchHITsResponse>(request);
            return resp;
		}

        public async Task<GetReviewableHITsResponse> GetReviewableHITs(string hitTypeId, string[] responseGroup, System.Nullable<MTurk.DTO.ReviewableHITStatus> status = null, System.Nullable<MTurk.DTO.SortDirection> sortDirection = null, System.Nullable<MTurk.DTO.GetReviewableHITsSortProperty> sortProperty = null, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new GetReviewableHITsRequest
            {
				HITTypeId = hitTypeId,
				ResponseGroup = responseGroup,
				Status = status ?? default(MTurk.DTO.ReviewableHITStatus),
				StatusSpecified = status == default(System.Nullable<MTurk.DTO.ReviewableHITStatus>),
				SortDirection = sortDirection ?? default(MTurk.DTO.SortDirection),
				SortDirectionSpecified = sortDirection == default(System.Nullable<MTurk.DTO.SortDirection>),
				SortProperty = sortProperty ?? default(MTurk.DTO.GetReviewableHITsSortProperty),
				SortPropertySpecified = sortProperty == default(System.Nullable<MTurk.DTO.GetReviewableHITsSortProperty>),
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber == default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize == default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetReviewableHITsRequest, GetReviewableHITsResponse>(request);
            return resp;
		}

        public async Task<SearchQualificationTypesResponse> SearchQualificationTypes(string query, bool mustBeRequestable, string[] responseGroup, System.Nullable<bool> mustBeOwnedByCaller = null, System.Nullable<MTurk.DTO.SortDirection> sortDirection = null, System.Nullable<MTurk.DTO.SearchQualificationTypesSortProperty> sortProperty = null, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new SearchQualificationTypesRequest
            {
				Query = query,
				MustBeRequestable = mustBeRequestable,
				ResponseGroup = responseGroup,
				MustBeOwnedByCaller = mustBeOwnedByCaller ?? default(bool),
				MustBeOwnedByCallerSpecified = mustBeOwnedByCaller == default(System.Nullable<bool>),
				SortDirection = sortDirection ?? default(MTurk.DTO.SortDirection),
				SortDirectionSpecified = sortDirection == default(System.Nullable<MTurk.DTO.SortDirection>),
				SortProperty = sortProperty ?? default(MTurk.DTO.SearchQualificationTypesSortProperty),
				SortPropertySpecified = sortProperty == default(System.Nullable<MTurk.DTO.SearchQualificationTypesSortProperty>),
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber == default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize == default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<SearchQualificationTypesRequest, SearchQualificationTypesResponse>(request);
            return resp;
		}

        public async Task<GetBonusPaymentsResponse> GetBonusPayments(string hitId, string assignmentId, string[] responseGroup, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new GetBonusPaymentsRequest
            {
				HITId = hitId,
				AssignmentId = assignmentId,
				ResponseGroup = responseGroup,
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber == default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize == default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetBonusPaymentsRequest, GetBonusPaymentsResponse>(request);
            return resp;
		}

        public async Task<GetQualificationScoreResponse> GetQualificationScore(string qualificationTypeId, string subjectId, string[] responseGroup)
		{
			var request = new GetQualificationScoreRequest
            {
				QualificationTypeId = qualificationTypeId,
				SubjectId = subjectId,
				ResponseGroup = responseGroup,
            };

            var resp = await ExecuteRequest<GetQualificationScoreRequest, GetQualificationScoreResponse>(request);
            return resp;
		}

        public async Task<GrantQualificationResponse> GrantQualification(string qualificationRequestId, string[] responseGroup, System.Nullable<int> integerValue = null)
		{
			var request = new GrantQualificationRequest
            {
				QualificationRequestId = qualificationRequestId,
				ResponseGroup = responseGroup,
				IntegerValue = integerValue ?? default(int),
				IntegerValueSpecified = integerValue == default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GrantQualificationRequest, GrantQualificationResponse>(request);
            return resp;
		}

        public async Task<RegisterHITTypeResponse> RegisterHITType(System.TimeSpan assignmentDuration, MTurk.DTO.Price reward, string title, string keywords, string description, MTurk.DTO.QualificationRequirement[] qualificationRequirement, string[] responseGroup, System.Nullable<System.TimeSpan> autoApprovalDelay = null)
		{
			var request = new RegisterHITTypeRequest
            {
				AssignmentDurationInSeconds = ((long)assignmentDuration.TotalSeconds),
				Reward = reward,
				Title = title,
				Keywords = keywords,
				Description = description,
				QualificationRequirement = qualificationRequirement,
				ResponseGroup = responseGroup,
				AutoApprovalDelayInSeconds = autoApprovalDelay == null ? default(long) : ((long)autoApprovalDelay.Value.TotalSeconds),
				AutoApprovalDelayInSecondsSpecified = autoApprovalDelay == default(System.Nullable<System.TimeSpan>),
            };

            var resp = await ExecuteRequest<RegisterHITTypeRequest, RegisterHITTypeResponse>(request);
            return resp;
		}

        public async Task<GetRequesterStatisticResponse> GetRequesterStatistic(MTurk.DTO.RequesterStatistic statistic, string[] responseGroup, System.Nullable<MTurk.DTO.TimePeriod> timePeriod = null, System.Nullable<int> count = null)
		{
			var request = new GetRequesterStatisticRequest
            {
				Statistic = statistic,
				ResponseGroup = responseGroup,
				TimePeriod = timePeriod ?? default(MTurk.DTO.TimePeriod),
				TimePeriodSpecified = timePeriod == default(System.Nullable<MTurk.DTO.TimePeriod>),
				Count = count ?? default(int),
				CountSpecified = count == default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetRequesterStatisticRequest, GetRequesterStatisticResponse>(request);
            return resp;
		}

        public async Task<GetHITsForQualificationTypeResponse> GetHITsForQualificationType(string qualificationTypeId, string[] responseGroup, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new GetHITsForQualificationTypeRequest
            {
				QualificationTypeId = qualificationTypeId,
				ResponseGroup = responseGroup,
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber == default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize == default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetHITsForQualificationTypeRequest, GetHITsForQualificationTypeResponse>(request);
            return resp;
		}

        public async Task<SendTestEventNotificationResponse> SendTestEventNotification(MTurk.DTO.NotificationSpecification notification, System.Nullable<MTurk.DTO.EventType> testEventType = null)
		{
			var request = new SendTestEventNotificationRequest
            {
				Notification = notification,
				TestEventType = testEventType ?? default(MTurk.DTO.EventType),
				TestEventTypeSpecified = testEventType == default(System.Nullable<MTurk.DTO.EventType>),
            };

            var resp = await ExecuteRequest<SendTestEventNotificationRequest, SendTestEventNotificationResponse>(request);
            return resp;
		}

        public async Task<SetHITAsReviewingResponse> SetHITAsReviewing(string hitId, string[] responseGroup, System.Nullable<bool> revert = null)
		{
			var request = new SetHITAsReviewingRequest
            {
				HITId = hitId,
				ResponseGroup = responseGroup,
				Revert = revert ?? default(bool),
				RevertSpecified = revert == default(System.Nullable<bool>),
            };

            var resp = await ExecuteRequest<SetHITAsReviewingRequest, SetHITAsReviewingResponse>(request);
            return resp;
		}

        public async Task<AssignQualificationResponse> AssignQualification(string qualificationTypeId, string workerId, string[] responseGroup, System.Nullable<int> integerValue = null, System.Nullable<bool> sendNotification = null)
		{
			var request = new AssignQualificationRequest
            {
				QualificationTypeId = qualificationTypeId,
				WorkerId = workerId,
				ResponseGroup = responseGroup,
				IntegerValue = integerValue ?? default(int),
				IntegerValueSpecified = integerValue == default(System.Nullable<int>),
				SendNotification = sendNotification ?? default(bool),
				SendNotificationSpecified = sendNotification == default(System.Nullable<bool>),
            };

            var resp = await ExecuteRequest<AssignQualificationRequest, AssignQualificationResponse>(request);
            return resp;
		}

        public async Task<ExtendHITResponse> ExtendHIT(string hitId, string uniqueRequestToken, string[] responseGroup, System.Nullable<int> maxAssignmentsIncrement = null, System.Nullable<System.TimeSpan> expirationIncrement = null)
		{
			var request = new ExtendHITRequest
            {
				HITId = hitId,
				UniqueRequestToken = uniqueRequestToken,
				ResponseGroup = responseGroup,
				MaxAssignmentsIncrement = maxAssignmentsIncrement ?? default(int),
				MaxAssignmentsIncrementSpecified = maxAssignmentsIncrement == default(System.Nullable<int>),
				ExpirationIncrementInSeconds = expirationIncrement == null ? default(long) : ((long)expirationIncrement.Value.TotalSeconds),
				ExpirationIncrementInSecondsSpecified = expirationIncrement == default(System.Nullable<System.TimeSpan>),
            };

            var resp = await ExecuteRequest<ExtendHITRequest, ExtendHITResponse>(request);
            return resp;
		}

        public async Task<GetBlockedWorkersResponse> GetBlockedWorkers(string[] responseGroup, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new GetBlockedWorkersRequest
            {
				ResponseGroup = responseGroup,
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber == default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize == default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetBlockedWorkersRequest, GetBlockedWorkersResponse>(request);
            return resp;
		}

        public async Task<ApproveRejectedAssignmentResponse> ApproveRejectedAssignment(string assignmentId, string[] responseGroup, string requesterFeedback)
		{
			var request = new ApproveRejectedAssignmentRequest
            {
				AssignmentId = assignmentId,
				ResponseGroup = responseGroup,
				RequesterFeedback = requesterFeedback,
            };

            var resp = await ExecuteRequest<ApproveRejectedAssignmentRequest, ApproveRejectedAssignmentResponse>(request);
            return resp;
		}

        public async Task<RevokeQualificationResponse> RevokeQualification(string subjectId, string qualificationTypeId, string reason, string[] responseGroup)
		{
			var request = new RevokeQualificationRequest
            {
				SubjectId = subjectId,
				QualificationTypeId = qualificationTypeId,
				Reason = reason,
				ResponseGroup = responseGroup,
            };

            var resp = await ExecuteRequest<RevokeQualificationRequest, RevokeQualificationResponse>(request);
            return resp;
		}

        public async Task<GetRequesterWorkerStatisticResponse> GetRequesterWorkerStatistic(MTurk.DTO.RequesterStatistic statistic, string workerId, string[] responseGroup, System.Nullable<MTurk.DTO.TimePeriod> timePeriod = null, System.Nullable<int> count = null)
		{
			var request = new GetRequesterWorkerStatisticRequest
            {
				Statistic = statistic,
				WorkerId = workerId,
				ResponseGroup = responseGroup,
				TimePeriod = timePeriod ?? default(MTurk.DTO.TimePeriod),
				TimePeriodSpecified = timePeriod == default(System.Nullable<MTurk.DTO.TimePeriod>),
				Count = count ?? default(int),
				CountSpecified = count == default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetRequesterWorkerStatisticRequest, GetRequesterWorkerStatisticResponse>(request);
            return resp;
		}

        public async Task<CreateHITResponse> CreateHIT(string hitTypeId, System.TimeSpan lifetime, MTurk.DTO.Price reward, string title, string keywords, string description, string question, string requesterAnnotation, MTurk.DTO.QualificationRequirement[] qualificationRequirement, string uniqueRequestToken, MTurk.DTO.ReviewPolicy assignmentReviewPolicy, MTurk.DTO.ReviewPolicy hitReviewPolicy, string hitLayoutId, MTurk.DTO.HITLayoutParameter[] hitLayoutParameter, string[] responseGroup, System.Nullable<int> maxAssignments = null, System.Nullable<System.TimeSpan> autoApprovalDelay = null, System.Nullable<System.TimeSpan> assignmentDuration = null)
		{
			var request = new CreateHITRequest
            {
				HITTypeId = hitTypeId,
				LifetimeInSeconds = ((long)lifetime.TotalSeconds),
				Reward = reward,
				Title = title,
				Keywords = keywords,
				Description = description,
				Question = question,
				RequesterAnnotation = requesterAnnotation,
				QualificationRequirement = qualificationRequirement,
				UniqueRequestToken = uniqueRequestToken,
				AssignmentReviewPolicy = assignmentReviewPolicy,
				HITReviewPolicy = hitReviewPolicy,
				HITLayoutId = hitLayoutId,
				HITLayoutParameter = hitLayoutParameter,
				ResponseGroup = responseGroup,
				MaxAssignments = maxAssignments ?? default(int),
				MaxAssignmentsSpecified = maxAssignments == default(System.Nullable<int>),
				AutoApprovalDelayInSeconds = autoApprovalDelay == null ? default(long) : ((long)autoApprovalDelay.Value.TotalSeconds),
				AutoApprovalDelayInSecondsSpecified = autoApprovalDelay == default(System.Nullable<System.TimeSpan>),
				AssignmentDurationInSeconds = assignmentDuration == null ? default(long) : ((long)assignmentDuration.Value.TotalSeconds),
				AssignmentDurationInSecondsSpecified = assignmentDuration == default(System.Nullable<System.TimeSpan>),
            };

            var resp = await ExecuteRequest<CreateHITRequest, CreateHITResponse>(request);
            return resp;
		}

        public async Task<DisposeQualificationTypeResponse> DisposeQualificationType(string qualificationTypeId)
		{
			var request = new DisposeQualificationTypeRequest
            {
				QualificationTypeId = qualificationTypeId,
            };

            var resp = await ExecuteRequest<DisposeQualificationTypeRequest, DisposeQualificationTypeResponse>(request);
            return resp;
		}

        public async Task<NotifyWorkersResponse> NotifyWorkers(string subject, string messageText, string[] workerId, string[] responseGroup)
		{
			var request = new NotifyWorkersRequest
            {
				Subject = subject,
				MessageText = messageText,
				WorkerId = workerId,
				ResponseGroup = responseGroup,
            };

            var resp = await ExecuteRequest<NotifyWorkersRequest, NotifyWorkersResponse>(request);
            return resp;
		}

        public async Task<RejectAssignmentResponse> RejectAssignment(string assignmentId, string[] responseGroup, string requesterFeedback)
		{
			var request = new RejectAssignmentRequest
            {
				AssignmentId = assignmentId,
				ResponseGroup = responseGroup,
				RequesterFeedback = requesterFeedback,
            };

            var resp = await ExecuteRequest<RejectAssignmentRequest, RejectAssignmentResponse>(request);
            return resp;
		}

        public async Task<UpdateQualificationTypeResponse> UpdateQualificationType(string qualificationTypeId, string description, string test, string answerKey, string[] responseGroup, System.Nullable<MTurk.DTO.QualificationTypeStatus> qualificationTypeStatus = null, System.Nullable<System.TimeSpan> testDuration = null, System.Nullable<System.TimeSpan> retryDelay = null, System.Nullable<bool> autoGranted = null, System.Nullable<int> autoGrantedValue = null)
		{
			var request = new UpdateQualificationTypeRequest
            {
				QualificationTypeId = qualificationTypeId,
				Description = description,
				Test = test,
				AnswerKey = answerKey,
				ResponseGroup = responseGroup,
				QualificationTypeStatus = qualificationTypeStatus ?? default(MTurk.DTO.QualificationTypeStatus),
				QualificationTypeStatusSpecified = qualificationTypeStatus == default(System.Nullable<MTurk.DTO.QualificationTypeStatus>),
				TestDurationInSeconds = testDuration == null ? default(long) : ((long)testDuration.Value.TotalSeconds),
				TestDurationInSecondsSpecified = testDuration == default(System.Nullable<System.TimeSpan>),
				RetryDelayInSeconds = retryDelay == null ? default(long) : ((long)retryDelay.Value.TotalSeconds),
				RetryDelayInSecondsSpecified = retryDelay == default(System.Nullable<System.TimeSpan>),
				AutoGranted = autoGranted ?? default(bool),
				AutoGrantedSpecified = autoGranted == default(System.Nullable<bool>),
				AutoGrantedValue = autoGrantedValue ?? default(int),
				AutoGrantedValueSpecified = autoGrantedValue == default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<UpdateQualificationTypeRequest, UpdateQualificationTypeResponse>(request);
            return resp;
		}

        public async Task<UpdateQualificationScoreResponse> UpdateQualificationScore(string qualificationTypeId, string subjectId, string[] responseGroup, System.Nullable<int> integerValue = null)
		{
			var request = new UpdateQualificationScoreRequest
            {
				QualificationTypeId = qualificationTypeId,
				SubjectId = subjectId,
				ResponseGroup = responseGroup,
				IntegerValue = integerValue ?? default(int),
				IntegerValueSpecified = integerValue == default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<UpdateQualificationScoreRequest, UpdateQualificationScoreResponse>(request);
            return resp;
		}

        public async Task<UnblockWorkerResponse> UnblockWorker(string workerId, string reason, string[] responseGroup)
		{
			var request = new UnblockWorkerRequest
            {
				WorkerId = workerId,
				Reason = reason,
				ResponseGroup = responseGroup,
            };

            var resp = await ExecuteRequest<UnblockWorkerRequest, UnblockWorkerResponse>(request);
            return resp;
		}

        public async Task<ForceExpireHITResponse> ForceExpireHIT(string hitId, string[] responseGroup)
		{
			var request = new ForceExpireHITRequest
            {
				HITId = hitId,
				ResponseGroup = responseGroup,
            };

            var resp = await ExecuteRequest<ForceExpireHITRequest, ForceExpireHITResponse>(request);
            return resp;
		}

        public async Task<GetQualificationTypeResponse> GetQualificationType(string qualificationTypeId, string[] responseGroup)
		{
			var request = new GetQualificationTypeRequest
            {
				QualificationTypeId = qualificationTypeId,
				ResponseGroup = responseGroup,
            };

            var resp = await ExecuteRequest<GetQualificationTypeRequest, GetQualificationTypeResponse>(request);
            return resp;
		}

        public async Task<ApproveAssignmentResponse> ApproveAssignment(string assignmentId, string[] responseGroup, string requesterFeedback)
		{
			var request = new ApproveAssignmentRequest
            {
				AssignmentId = assignmentId,
				ResponseGroup = responseGroup,
				RequesterFeedback = requesterFeedback,
            };

            var resp = await ExecuteRequest<ApproveAssignmentRequest, ApproveAssignmentResponse>(request);
            return resp;
		}

        public async Task<ChangeHITTypeOfHITResponse> ChangeHITTypeOfHIT(string hitId, string hitTypeId, string[] responseGroup)
		{
			var request = new ChangeHITTypeOfHITRequest
            {
				HITId = hitId,
				HITTypeId = hitTypeId,
				ResponseGroup = responseGroup,
            };

            var resp = await ExecuteRequest<ChangeHITTypeOfHITRequest, ChangeHITTypeOfHITResponse>(request);
            return resp;
		}

        public async Task<GetAccountBalanceResponse> GetAccountBalance(string[] responseGroup, string unused)
		{
			var request = new GetAccountBalanceRequest
            {
				ResponseGroup = responseGroup,
				Unused = unused,
            };

            var resp = await ExecuteRequest<GetAccountBalanceRequest, GetAccountBalanceResponse>(request);
            return resp;
		}

        public async Task<SetHITTypeNotificationResponse> SetHITTypeNotification(string hitTypeId, MTurk.DTO.NotificationSpecification notification, System.Nullable<bool> active = null)
		{
			var request = new SetHITTypeNotificationRequest
            {
				HITTypeId = hitTypeId,
				Notification = notification,
				Active = active ?? default(bool),
				ActiveSpecified = active == default(System.Nullable<bool>),
            };

            var resp = await ExecuteRequest<SetHITTypeNotificationRequest, SetHITTypeNotificationResponse>(request);
            return resp;
		}

        public async Task<BlockWorkerResponse> BlockWorker(string workerId, string reason, string[] responseGroup)
		{
			var request = new BlockWorkerRequest
            {
				WorkerId = workerId,
				Reason = reason,
				ResponseGroup = responseGroup,
            };

            var resp = await ExecuteRequest<BlockWorkerRequest, BlockWorkerResponse>(request);
            return resp;
		}

        public async Task<CreateQualificationTypeResponse> CreateQualificationType(string name, string keywords, string description, string test, string answerKey, string[] responseGroup, System.Nullable<MTurk.DTO.QualificationTypeStatus> qualificationTypeStatus = null, System.Nullable<System.TimeSpan> retryDelay = null, System.Nullable<System.TimeSpan> testDuration = null, System.Nullable<bool> autoGranted = null, System.Nullable<int> autoGrantedValue = null)
		{
			var request = new CreateQualificationTypeRequest
            {
				Name = name,
				Keywords = keywords,
				Description = description,
				Test = test,
				AnswerKey = answerKey,
				ResponseGroup = responseGroup,
				QualificationTypeStatus = qualificationTypeStatus ?? default(MTurk.DTO.QualificationTypeStatus),
				QualificationTypeStatusSpecified = qualificationTypeStatus == default(System.Nullable<MTurk.DTO.QualificationTypeStatus>),
				RetryDelayInSeconds = retryDelay == null ? default(long) : ((long)retryDelay.Value.TotalSeconds),
				RetryDelayInSecondsSpecified = retryDelay == default(System.Nullable<System.TimeSpan>),
				TestDurationInSeconds = testDuration == null ? default(long) : ((long)testDuration.Value.TotalSeconds),
				TestDurationInSecondsSpecified = testDuration == default(System.Nullable<System.TimeSpan>),
				AutoGranted = autoGranted ?? default(bool),
				AutoGrantedSpecified = autoGranted == default(System.Nullable<bool>),
				AutoGrantedValue = autoGrantedValue ?? default(int),
				AutoGrantedValueSpecified = autoGrantedValue == default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<CreateQualificationTypeRequest, CreateQualificationTypeResponse>(request);
            return resp;
		}

	}
}