using System;
using System.Threading.Tasks;
using MTurk.DTO;

namespace MTurk
{
	partial class TurkClient
	{
        /// <summary>
        /// The SetHITAsReviewing operation updates the status of a HIT. If the status is Reviewable, this operation updates the status to Reviewing, or reverts a Reviewing HIT back to the Reviewable status.
        /// You can update only HITs with status Reviewable to status Reviewing. Similarly, you can revert only Reviewing HITs back to status Reviewable.
        /// The SetHITAsReviewing operation does not toggle the status value. The default behavior is to promote a HIT from Reviewable to Reviewing. To revert a Reviewing HIT back to Reviewable, specify the Revert parameter with a value of true.
        /// </summary>
        /// <param name="hitId">The ID of the HIT whose status is to be updated.</param>
        /// <param name="revert">Specifies whether to update the HIT Status from Reviewing to Reviewable.</param>
        public async Task<SetHITAsReviewingResponse> SetHITAsReviewing(string hitId, string[] responseGroup, System.Nullable<bool> revert = null)
		{
			var request = new SetHITAsReviewingRequest
            {
				HITId = hitId,
				ResponseGroup = responseGroup,
				Revert = revert ?? default(bool),
				RevertSpecified = revert != default(System.Nullable<bool>),
            };

            var resp = await ExecuteRequest<SetHITAsReviewingRequest, SetHITAsReviewingResponse>(request);
            return resp;
		}

        /// <summary>
        /// The GetAssignmentsForHIT operation retrieves completed assignments for a HIT. You can use this operation to retrieve the results for a HIT.
        /// You can get assignments for a HIT at any time, even if the HIT is not yet Reviewable. If a HIT requested multiple assignments, and has received some results but has not yet become Reviewable, you can still retrieve the partial results with this operation.
        /// Use the AssignmentStatus parameter to control which set of assignments for a HIT are returned. The GetAssignmentsForHIT operation can return submitted assignments awaiting approval, or it can return assignments that have already been approved or rejected. You can set  AssignmentStatus=Approved,Rejected  to get assignments that have already been approved and rejected together in one result set.
        /// Only the Requester who created the HIT can retrieve the assignments for that HIT.
        /// Results are sorted and divided into numbered pages and the operation returns a single page of results. You can use the parameters of the operation to control sorting and pagination.
        /// </summary>
        /// <param name="hitId">The ID of the HIT for which completed assignments are requested.</param>
        /// <param name="assignmentStatus">The status of the assignments to return.</param>
        /// <param name="sortDirection">The direction of the sort used with the field specified by the SortProperty parameter.</param>
        /// <param name="sortProperty">The field on which to sort the results returned by the operation.</param>
        /// <param name="pageNumber">The page of results to return. Once the assignments have been filtered, sorted, and divided into pages of size PageSize, the page corresponding to PageNumber is returned as the results of the operation.</param>
        /// <param name="pageSize">The number of assignments to include in a page of results. The complete sorted result set is divided into pages of this many assignments.</param>
        public async Task<GetAssignmentsForHITResponse> GetAssignmentsForHIT(string hitId, MTurk.DTO.AssignmentStatus[] assignmentStatus, string[] responseGroup, System.Nullable<MTurk.DTO.SortDirection> sortDirection = null, System.Nullable<MTurk.DTO.GetAssignmentsForHITSortProperty> sortProperty = null, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new GetAssignmentsForHITRequest
            {
				HITId = hitId,
				AssignmentStatus = assignmentStatus,
				ResponseGroup = responseGroup,
				SortDirection = sortDirection ?? default(MTurk.DTO.SortDirection),
				SortDirectionSpecified = sortDirection != default(System.Nullable<MTurk.DTO.SortDirection>),
				SortProperty = sortProperty ?? default(MTurk.DTO.GetAssignmentsForHITSortProperty),
				SortPropertySpecified = sortProperty != default(System.Nullable<MTurk.DTO.GetAssignmentsForHITSortProperty>),
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber != default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize != default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetAssignmentsForHITRequest, GetAssignmentsForHITResponse>(request);
            return resp;
		}

        /// <summary>
        /// The GetReviewResultsForHIT operation retrieves the computed results and the actions taken in the course of executing your Review Policies during a CreateHIT operation. For information about how to apply Review Policies when you call CreateHIT, see Review Policies. The GetReviewResultsForHIT operation can return results for both Assignment-level and HIT-level review results. You can also specify to only return results pertaining to a particular Assignment.
        /// </summary>
        /// <param name="hitId">The unique identifier of the HIT to retrieve review results for.</param>
        /// <param name="policyLevel">The Policy Level(s) to retrieve review results for.</param>
        /// <param name="retrieveActions">Retrieves a list of the actions taken executing the Review Policies and their outcomes.</param>
        /// <param name="retrieveResults">Retrieves a list of the results computed by the Review Policies.</param>
        /// <param name="pageNumber">The page of results to return. After the results are divided into pages of size  PageSize, the operation returns the page corresponding to the  PageNumber.</param>
        /// <param name="pageSize">The number of results to include in a page of results. The complete results set is  divided into pages of this many HITs.</param>
        public async Task<GetReviewResultsForHITResponse> GetReviewResultsForHIT(string hitId, MTurk.DTO.ReviewPolicyLevel[] policyLevel, string[] responseGroup, System.Nullable<bool> retrieveActions = null, System.Nullable<bool> retrieveResults = null, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new GetReviewResultsForHITRequest
            {
				HITId = hitId,
				PolicyLevel = policyLevel,
				ResponseGroup = responseGroup,
				RetrieveActions = retrieveActions ?? default(bool),
				RetrieveActionsSpecified = retrieveActions != default(System.Nullable<bool>),
				RetrieveResults = retrieveResults ?? default(bool),
				RetrieveResultsSpecified = retrieveResults != default(System.Nullable<bool>),
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber != default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize != default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetReviewResultsForHITRequest, GetReviewResultsForHITResponse>(request);
            return resp;
		}

        /// <summary>
        /// The ApproveRejectedAssignment operation approves an assignment that was previously rejected.
        /// ApproveRejectedAssignment works only on rejected assignments that were submitted within the previous 30 days and only if the assignment's related HIT has not been disposed.
        /// Approving the rejected assignment initiates two payments from the Requester's Amazon.com account: one payment to the Worker who submitted the results for the reward amount specified in the HIT and one payment for Amazon Mechanical Turk fees. For the operation to succeed, a Requester must have sufficient funds in their account to pay the Worker and the fees.
        /// If the assignment is not currently rejected, or if the Requester does not have sufficient funds in their account to pay the Worker and the Mechanical Turk fees, then the ApproveRejectedAssignment operation returns an exception and the approval is not processed.
        /// You can include an optional feedback message with the approval, which the Worker can see in the Status section of the Amazon Mechanical Turk website.
        /// </summary>
        /// <param name="assignmentId">The ID of the assignment. This parameter must correspond to a HIT created by the Requester.</param>
        /// <param name="requesterFeedback">A message for the Worker, which the Worker can see in the Status section of the Mechanical Turk website.</param>
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

        /// <summary>
        /// The RevokeQualification operation revokes a previously granted Qualification from a user.
        /// You can provide a text message explaining why the Qualification was revoked. The user who had the Qualification can see this message.
        /// </summary>
        /// <param name="subjectId">The ID of the Worker who possesses the Qualification to be revoked.</param>
        /// <param name="qualificationTypeId">The ID of the Qualification type of the Qualification to be revoked.</param>
        /// <param name="reason">A text message that explains why the Qualification was revoked. The user who had the Qualification sees this message.</param>
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

        /// <summary>
        /// The GrantBonus operation issues a payment of money from your account to a Worker. This payment happens separately from the reward you pay to the Worker when you approve the Worker's assignment.
        /// The GrantBonus operation requires the Worker's ID and the assignment ID as parameters to initiate payment of the bonus.
        /// You must include a message that explains the reason for the bonus payment, as the Worker may not be expecting the payment.
        /// Amazon Mechanical Turk collects a fee for bonus payments, similar to the HIT listing fee. This operation fails if your account does not have enough funds to pay for both the bonus and the fees.
        /// For information about Amazon Mechanical Turk pricing and fee amounts, see the Amazon Mechanical Turk site.
        /// </summary>
        /// <param name="workerId">The ID of the Worker being paid the bonus, as returned in the assignment data of the GetAssignmentsForHIT operation.</param>
        /// <param name="bonusAmount">The bonus amount to pay.</param>
        /// <param name="assignmentId">The ID of the assignment for which this bonus is paid, as returned in the assignment data of the GetAssignmentsForHIT operation.</param>
        /// <param name="reason">A message that explains the reason for the bonus payment. The Worker receiving the bonus can see this message.</param>
        /// <param name="uniqueRequestToken">A unique identifier for this request, which allows you to retry the call on error without granting multiple bonuses. This is useful in cases such as network timeouts where it is unclear whether or not the call succeeded on the server. If the extend HIT already exists in the system from a previous call using the same UniqueRequestToken, subsequent calls will return an error with a message containing the request ID.</param>
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

        /// <summary>
        /// The GetRequesterWorkerStatistic operation retrieves statistics about a specific Worker who has completed Human Intelligence Tasks (HITs) for you. If you have used Review Policies with known answers or plurality, Mechanical Turk will summarize the following statistics about the Worker's known answers and agreement level. These statistics are only for your Requester account. For more information about Review Policies, see Review Policies.
        /// The following table describes the available statistics:
        /// NumberAssignmentsApproved
        /// The number of assignments you have approved for the Worker.
        /// Type: Long
        /// NumberAssignmentsRejected
        /// The number of assignments you have rejected for the Worker.
        /// Type: Long
        /// PercentAssignmentsApproved
        /// The percentage of assignments approved, which is the Number of assignments approved divided by the number of assignments approved or rejected.
        /// Type: Double
        /// PercentAssignmentsRejected
        /// The percentage of assignments rejected, which is the Number of assignments rejected divided by the number of assignments approved or rejected.
        /// Type: Double
        /// NumberKnownAnswersCorrect
        /// The total number of known answer questions that the Worker has answered correctly.
        /// Type: Long
        /// NumberKnownAnswersIncorrect
        /// The total number of known answer questions that the Worker has answered incorrectly.
        /// Type: Long
        /// NumberKnownAnswersEvaluated
        /// The total number of known answer questions in assignments the Worker has submitted.
        /// Type: Long
        /// PercentKnownAnswersCorrect
        /// The rounded percentage of known answer questions the Worker has answered correctly, which is the number of correct known answers divided by the number of known answers evaluated.
        /// Type: Double
        /// NumberPluralityAnswersCorrect
        /// The number of evaluated questions that the Worker provided the agreed-upon answer for.
        /// Type: Long
        /// NumberPluralityAnswersIncorrect
        /// The number of evaluated questions that the Worker did not provide the agreed-upon answer for.
        /// Type: Long
        /// NumberPluralityAnswersEvaluated
        /// The number of evaluated questions answered by the Worker participating in the HIT.
        /// Type: Long
        /// PercentPluralityAnswersCorrect
        /// The number of questions that the Worker provided the agreed-upon answer for, divided by the number of evaluated questions.
        /// Type: Double
        /// </summary>
        /// <param name="statistic">The statistic to return.</param>
        /// <param name="workerId">The Worker you want to return the statistics for.</param>
        /// <param name="timePeriod">The time period of the statistic to return.</param>
        /// <param name="count">The number of data points to return.</param>
        public async Task<GetRequesterWorkerStatisticResponse> GetRequesterWorkerStatistic(MTurk.DTO.RequesterStatistic statistic, string workerId, string[] responseGroup, System.Nullable<MTurk.DTO.TimePeriod> timePeriod = null, System.Nullable<int> count = null)
		{
			var request = new GetRequesterWorkerStatisticRequest
            {
				Statistic = statistic,
				WorkerId = workerId,
				ResponseGroup = responseGroup,
				TimePeriod = timePeriod ?? default(MTurk.DTO.TimePeriod),
				TimePeriodSpecified = timePeriod != default(System.Nullable<MTurk.DTO.TimePeriod>),
				Count = count ?? default(int),
				CountSpecified = count != default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetRequesterWorkerStatisticRequest, GetRequesterWorkerStatisticResponse>(request);
            return resp;
		}

        /// <summary>
        /// The GetHIT operation retrieves the details of the specified HIT.
        /// </summary>
        /// <param name="hitId">The ID of the HIT to retrieve.</param>
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

        /// <summary>
        /// The GetReviewableHITs operation retrieves the HITs with Status equal to Reviewable or Status equal to Reviewing that belong to the Requester calling the operation.
        /// You can limit the query to HITs with a specified HIT type.
        /// The operation sorts the results, divides them into numbered pages, and returns a single page of results. You can control sorting and pagination can be controlled with parameters to the operation.
        /// When (PageNumber x PageSize) is less than 100, you can get reliable results when you use any of the sort properties. If this number is greater than 100, use the Enumeration sort property for best results. The Enumeration sort property guarantees that the operation returns all reviewable HITs with no duplicates, but not in any specific order.
        /// </summary>
        /// <param name="hitTypeId">The ID of the HIT type of the HITs to consider for the query.</param>
        /// <param name="status">The status of the HITs to return</param>
        /// <param name="sortDirection">The direction of the sort used with the field specified by the SortProperty property.</param>
        /// <param name="sortProperty">The field on which to sort the results.</param>
        /// <param name="pageNumber">The page of results to return. After the operation filters, sorts, and divides the HITs into pages of size PageSize, it returns the page corresponding to PageNumber as the results of the operation.</param>
        /// <param name="pageSize">The number of HITs to include in a page of results. The operation divides the complete sorted result set is divided into pages of this many HITs.</param>
        public async Task<GetReviewableHITsResponse> GetReviewableHITs(string hitTypeId, string[] responseGroup, System.Nullable<MTurk.DTO.ReviewableHITStatus> status = null, System.Nullable<MTurk.DTO.SortDirection> sortDirection = null, System.Nullable<MTurk.DTO.GetReviewableHITsSortProperty> sortProperty = null, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new GetReviewableHITsRequest
            {
				HITTypeId = hitTypeId,
				ResponseGroup = responseGroup,
				Status = status ?? default(MTurk.DTO.ReviewableHITStatus),
				StatusSpecified = status != default(System.Nullable<MTurk.DTO.ReviewableHITStatus>),
				SortDirection = sortDirection ?? default(MTurk.DTO.SortDirection),
				SortDirectionSpecified = sortDirection != default(System.Nullable<MTurk.DTO.SortDirection>),
				SortProperty = sortProperty ?? default(MTurk.DTO.GetReviewableHITsSortProperty),
				SortPropertySpecified = sortProperty != default(System.Nullable<MTurk.DTO.GetReviewableHITsSortProperty>),
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber != default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize != default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetReviewableHITsRequest, GetReviewableHITsResponse>(request);
            return resp;
		}

        /// <summary>
        /// The GetQualificationsForQualificationType operation returns all of the Qualifications granted to Workers for a given Qualification type.
        /// This operations divides the results into numbered pages and returns a single page of results. You can control pagination with parameters to the operation.
        /// </summary>
        /// <param name="qualificationTypeId">The ID of the Qualification type of the Qualifications to return.</param>
        /// <param name="status">The status of the Qualifications to return.</param>
        /// <param name="pageNumber">The page of results to return. Once the operation divides the Qualifications into pages of size PageSize, it returns the page corresponding to PageNumber.</param>
        /// <param name="pageSize">The number of Qualifications to include in a page of results. The operation divides the complete result set into pages of this many Qualifications.</param>
        public async Task<GetQualificationsForQualificationTypeResponse> GetQualificationsForQualificationType(string qualificationTypeId, string[] responseGroup, System.Nullable<MTurk.DTO.QualificationStatus> status = null, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new GetQualificationsForQualificationTypeRequest
            {
				QualificationTypeId = qualificationTypeId,
				ResponseGroup = responseGroup,
				Status = status ?? default(MTurk.DTO.QualificationStatus),
				StatusSpecified = status != default(System.Nullable<MTurk.DTO.QualificationStatus>),
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber != default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize != default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetQualificationsForQualificationTypeRequest, GetQualificationsForQualificationTypeResponse>(request);
            return resp;
		}

        /// <summary>
        /// The SendTestEventNotification operation causes Amazon Mechanical Turk to send a notification message as if a HIT event occurred, according to the provided notification specification.  This allows you to test notifications without setting up notifications for a real HIT type and trying to trigger them using the website.
        /// When you call this operation, the service sends the test notification immediately.
        /// </summary>
        /// <param name="notification">The notification specification to test. This value is identical to the value you would provide to the SetHITTypeNotification operation when you establish the notification specification for a HIT type.</param>
        /// <param name="testEventType">The event to simulate to test the notification specification. This event is included in the test message even if the notification specification does not include the event type. The notification specification does not filter out the test event.</param>
        public async Task<SendTestEventNotificationResponse> SendTestEventNotification(MTurk.DTO.NotificationSpecification notification, System.Nullable<MTurk.DTO.EventType> testEventType = null)
		{
			var request = new SendTestEventNotificationRequest
            {
				Notification = notification,
				TestEventType = testEventType ?? default(MTurk.DTO.EventType),
				TestEventTypeSpecified = testEventType != default(System.Nullable<MTurk.DTO.EventType>),
            };

            var resp = await ExecuteRequest<SendTestEventNotificationRequest, SendTestEventNotificationResponse>(request);
            return resp;
		}

        /// <summary>
        /// The GetHITsForQualificationType operation returns the HITs that use the given Qualification type for a Qualification requirement.
        /// The operation returns HITs of any status, except for HITs that have been disposed with the DisposeHIT operation.
        /// This operation returns only HITs that you created.
        /// For reasons internal to the service, there may be a delay between when a HIT is created and when the HIT will be returned from a call to GetHITsForQualificationType.
        /// The operation divides the results into numbered pages and returns a single page of results. You can control pagination with parameters to the operation.
        /// </summary>
        /// <param name="qualificationTypeId">The ID of the Qualification type to use when querying HITs, as returned by the CreateQualificationType operation. The operation returns HITs that require that a Worker have a Qualification of this type.</param>
        /// <param name="pageNumber">The page of results to return. After the HITs are divided into pages of size PageSize, the operation returns the page corresponding to the PageNumber.</param>
        /// <param name="pageSize">The number of HITs to include in a page of results. The complete results set is divided into pages of this many HITs.</param>
        public async Task<GetHITsForQualificationTypeResponse> GetHITsForQualificationType(string qualificationTypeId, string[] responseGroup, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new GetHITsForQualificationTypeRequest
            {
				QualificationTypeId = qualificationTypeId,
				ResponseGroup = responseGroup,
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber != default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize != default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetHITsForQualificationTypeRequest, GetHITsForQualificationTypeResponse>(request);
            return resp;
		}

        /// <summary>
        /// The SearchHITs operation returns all of a Requester's HITs, on behalf of the Requester.
        /// The operation returns HITs of any status, except for HITs that have been disposed of with the DisposeHIT operation.
        /// The SearchHITs operation does not accept any search parameters that filter the results.
        /// The operation sorts the results and divides them into numbered pages. The operation returns a single page of results. You can control sorting and pagination with parameters to the operation.
        /// When (PageNumber x PageSize) is less than 100, you can get reliable results when you use any of the sort properties. If this number is greater than 100, use the Enumeration sort property for best results. The Enumeration sort property guarantees that all HITs are returned with no duplicates, but not in any specific order.
        /// </summary>
        /// <param name="sortDirection">The direction of the sort, used with the field specified by the SortProperty parameter.</param>
        /// <param name="sortProperty">The field on which to sort the returned results</param>
        /// <param name="pageNumber">The page of results to return. After the operation sorts the HITs and divides them into pages of size PageSize, the operation returns the page corresponding to PageNumber.</param>
        /// <param name="pageSize">The number of HITs to include in a page of results. The complete sorted result set is divided into pages of this many HITs.</param>
        public async Task<SearchHITsResponse> SearchHITs(string[] responseGroup, System.Nullable<MTurk.DTO.SortDirection> sortDirection = null, System.Nullable<MTurk.DTO.SearchHITsSortProperty> sortProperty = null, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new SearchHITsRequest
            {
				ResponseGroup = responseGroup,
				SortDirection = sortDirection ?? default(MTurk.DTO.SortDirection),
				SortDirectionSpecified = sortDirection != default(System.Nullable<MTurk.DTO.SortDirection>),
				SortProperty = sortProperty ?? default(MTurk.DTO.SearchHITsSortProperty),
				SortPropertySpecified = sortProperty != default(System.Nullable<MTurk.DTO.SearchHITsSortProperty>),
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber != default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize != default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<SearchHITsRequest, SearchHITsResponse>(request);
            return resp;
		}

        /// <summary>
        /// The GetBlockedWorkers operation retrieves a list of Workers who are blocked from working on your HITs.
        /// </summary>
        /// <param name="pageNumber">The page of results to return. Once the assignments have been filtered, sorted, and divided into pages of size PageSize, the page corresponding to PageSize is returned as the results of the operation.</param>
        /// <param name="pageSize">The number of assignments to include in a page of results.  The complete sorted result set is divided into pages of this many assignments.</param>
        public async Task<GetBlockedWorkersResponse> GetBlockedWorkers(string[] responseGroup, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new GetBlockedWorkersRequest
            {
				ResponseGroup = responseGroup,
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber != default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize != default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetBlockedWorkersRequest, GetBlockedWorkersResponse>(request);
            return resp;
		}

        /// <summary>
        /// The GetQualificationRequests operation retrieves requests for Qualifications of a particular Qualification type. The owner of the Qualification type calls this operation to poll for pending requests, and grants Qualifications based on the requests using the GrantQualification operation.
        /// The GetQualificationRequests operation returns only those Qualifications that require the type owner's attention. The operation does not return requests awaiting Qualification test answers and requests that have already been granted.
        /// Only the owner of the Qualification type can retrieve its requests.
        /// The operation sorts the results, divides them into numbered pages, and returns a single page of results. You can control sorting and pagination with parameters to the operation.
        /// </summary>
        /// <param name="qualificationTypeId">The ID of the Qualification type, as returned by the CreateQualificationType operation.</param>
        /// <param name="sortDirection">The direction of the sort.</param>
        /// <param name="sortProperty">The field on which to sort the returned results.</param>
        /// <param name="pageNumber">The page of results to return. When the operation has filtered the Qualification requests, sorted them, and divided them into pages of size PageSize, the operation returns the page corresponding to the PageNumber parameter.</param>
        /// <param name="pageSize">The number of Qualification requests to include in a page of results. The operation divides the complete sorted result set into pages of this many Qualification requests.</param>
        public async Task<GetQualificationRequestsResponse> GetQualificationRequests(string qualificationTypeId, string[] responseGroup, System.Nullable<MTurk.DTO.SortDirection> sortDirection = null, System.Nullable<MTurk.DTO.GetQualificationRequestsSortProperty> sortProperty = null, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new GetQualificationRequestsRequest
            {
				QualificationTypeId = qualificationTypeId,
				ResponseGroup = responseGroup,
				SortDirection = sortDirection ?? default(MTurk.DTO.SortDirection),
				SortDirectionSpecified = sortDirection != default(System.Nullable<MTurk.DTO.SortDirection>),
				SortProperty = sortProperty ?? default(MTurk.DTO.GetQualificationRequestsSortProperty),
				SortPropertySpecified = sortProperty != default(System.Nullable<MTurk.DTO.GetQualificationRequestsSortProperty>),
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber != default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize != default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetQualificationRequestsRequest, GetQualificationRequestsResponse>(request);
            return resp;
		}

        /// <summary>
        /// The DisableHIT operation removes a HIT from the Amazon Mechanical Turk marketplace, approves any submitted assignments pending approval or rejection, and disposes of the HIT and all assignment data. Assignment results data cannot be retrieved for a HIT that has been disposed.
        /// Assignments in progress at the time of the call to the DisableHIT operation are  approved once the assignments are submitted. You will be charged for approval of these assignments.
        /// When either all of the HIT's assignments have been submitted by Workers, or the HIT has expired and all assignments have either been submitted, returned or abandoned, the HIT is considered Reviewable. For more information about the Reviewable state, see Creating and Managing Assignments.
        /// The DisableHIT operation does not work on HITs in the Reviewable state. For HITs in the Reviewable state, call the ApproveAssignment or the RejectAssignment operation for each submitted assignment for the HIT. Then call the DisposeHIT operation to dispose of the HIT.
        /// 
        /// Only the Requester who created the HIT can disable it.
        /// </summary>
        /// <param name="hitId">The ID of the HIT, as returned by the  CreateHIT operation.</param>
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

        /// <summary>
        /// The GetQualificationScore operation returns the value of a Worker's Qualification for a given Qualification type.
        /// To get a Worker's Qualification, you must know the Worker's ID. The Worker's ID is included in the assignment data returned by the GetAssignmentsForHIT operation.
        /// Only the owner of a Qualification type can query the value of a Worker's Qualification of that type.
        /// </summary>
        /// <param name="qualificationTypeId">The ID of the Qualification type, as returned by the CreateQualificationType operation.</param>
        /// <param name="subjectId">The ID of the Worker whose Qualification is being updated.</param>
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

        /// <summary>
        /// The ExtendHIT operation increases the maximum number of assignments, or extends the expiration date, of an existing HIT.
        /// To extend the maximum number of assignments, specify the number of additional assignments.
        /// To extend the expiration date, specify an amount of time as a number of seconds. If the HIT has not yet expired, the new expiration date is the existing date plus the amount of time specified. If the HIT has already expired, the new expiration date is the current time plus the amount of time specified.
        /// Only the Requester who created a HIT can extend it.
        /// </summary>
        /// <param name="hitId">The ID of the HIT to extend</param>
        /// <param name="uniqueRequestToken">A unique identifier for this request, which allows you to retry the call on error without extending the HIT multiple times. This is useful in cases such as network timeouts where it is unclear whether or not the call succeeded on the server. If the extend HIT already exists in the system from a previous call using the same UniqueRequestToken, subsequent calls will return an error with a message containing the request ID.</param>
        /// <param name="maxAssignmentsIncrement">The number of assignments by which to increment the MaxAssignments parameter of the HIT.</param>
        /// <param name="expirationIncrement">The amount of time, in seconds, by which to extend the expiration date. If the HIT has not yet expired, this amount is added to the HIT's expiration date. If the HIT has expired, the new expiration date is the current time plus this value.</param>
        public async Task<ExtendHITResponse> ExtendHIT(string hitId, string uniqueRequestToken, string[] responseGroup, System.Nullable<int> maxAssignmentsIncrement = null, System.Nullable<System.TimeSpan> expirationIncrement = null)
		{
			var request = new ExtendHITRequest
            {
				HITId = hitId,
				UniqueRequestToken = uniqueRequestToken,
				ResponseGroup = responseGroup,
				MaxAssignmentsIncrement = maxAssignmentsIncrement ?? default(int),
				MaxAssignmentsIncrementSpecified = maxAssignmentsIncrement != default(System.Nullable<int>),
				ExpirationIncrementInSeconds = expirationIncrement == null ? default(long) : ((long)expirationIncrement.Value.TotalSeconds),
				ExpirationIncrementInSecondsSpecified = expirationIncrement != default(System.Nullable<System.TimeSpan>),
            };

            var resp = await ExecuteRequest<ExtendHITRequest, ExtendHITResponse>(request);
            return resp;
		}

        /// <summary>
        /// The GetFileUploadURL operation generates and returns a temporary URL. You use the temporary URL to retrieve a file uploaded by a Worker as an answer to a FileUploadAnswer question for a HIT. For information about the FileUploadAnswer answer, see QuestionForm.
        /// The temporary URL is generated the instant the GetFileUploadURL operation is called, and is valid for 60 seconds.
        /// URL expiration allows your application to retrieve the file without credentials, but still retain control over who can access your data, because you need an access key ID and signature to get the temporary URL. If you need to retrieve the file after the URL has expired, call GetFileUploadURL again to get a new URL.
        /// You can get a temporary file upload URL any time until the HIT is disposed. After the HIT is disposed, any uploaded files are deleted, and cannot be retrieved.
        /// </summary>
        /// <param name="assignmentId">The ID of the assignment that contains the question with a FileUploadAnswer.</param>
        /// <param name="questionIdentifier">The identifier of the question with a FileUploadAnswer, as specified in the QuestionForm of the HIT.</param>
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

        /// <summary>
        /// The NotifyWorkers operation sends an email to one or more Workers that you specify with the Worker ID.
        /// You can specify up to 100 Worker IDs to send the same message with a single call to the NotifyWorkers operation.
        /// The NotifyWorkers operation will send a notification email to a Worker only if you have previously approved or rejected work from the Worker.
        /// </summary>
        /// <param name="subject">The subject line of the email message to send.</param>
        /// <param name="messageText">The text of the email message to send</param>
        /// <param name="workerId">The ID of the Worker to notify, as returned by the  GetAssignmentsForHIT operation.</param>
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

        /// <summary>
        /// The DisposeQualificationType operation disposes a Qualification type and disposes any HIT types that are associated with the Qualification type. A Qualification type is represented by a  QualificationType  data structure.
        /// This operation does not revoke Qualifications already assigned to Workers because the Qualifications might be needed for active HITs. If there are any pending requests for the Qualification type, Amazon Mechanical Turk rejects those requests.
        /// After you dispose of a Qualification type, you can no longer use it to create HITs or HIT types.
        /// DisposeQualificationType must wait for all the HITs that use the disposed Qualification type to be disposed before completing.  It may take up to 48 hours before DisposeQualificationType completes and the unique name of the disposed Qualification type is  available for reuse with CreateQualificationType.
        /// </summary>
        /// <param name="qualificationTypeId">The ID of the QualificationType to dispose.</param>
        public async Task<DisposeQualificationTypeResponse> DisposeQualificationType(string qualificationTypeId)
		{
			var request = new DisposeQualificationTypeRequest
            {
				QualificationTypeId = qualificationTypeId,
            };

            var resp = await ExecuteRequest<DisposeQualificationTypeRequest, DisposeQualificationTypeResponse>(request);
            return resp;
		}

        /// <summary>
        /// The GrantQualification operation grants a Worker's request for a Qualification.
        /// Only the owner of the Qualification type can grant a Qualification request for that type.
        /// </summary>
        /// <param name="qualificationRequestId">The ID of the Qualification request, as returned by the GetQualificationRequests operation.</param>
        /// <param name="integerValue">The value of the Qualification</param>
        public async Task<GrantQualificationResponse> GrantQualification(string qualificationRequestId, string[] responseGroup, System.Nullable<int> integerValue = null)
		{
			var request = new GrantQualificationRequest
            {
				QualificationRequestId = qualificationRequestId,
				ResponseGroup = responseGroup,
				IntegerValue = integerValue ?? default(int),
				IntegerValueSpecified = integerValue != default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GrantQualificationRequest, GrantQualificationResponse>(request);
            return resp;
		}

        /// <summary>
        /// The GetBonusPayments operation retrieves the amounts of bonuses you have paid to Workers for a given HIT or assignment.
        /// </summary>
        /// <param name="hitId">The ID of the HIT associated with the bonus payments to retrieve. If not specified, all bonus payments for all assignments for the given HIT are returned.</param>
        /// <param name="assignmentId">The ID of the assignment associated with the bonus payments to retrieve. If specified, only bonus payments for the given assignment are returned.</param>
        /// <param name="pageNumber">The page of results to return. Once the list of bonus payments has been divided into pages of size PageSize, the page corresponding to PageNumber is returned as the results of the operation.</param>
        /// <param name="pageSize">The number of bonus payments to include in a page of results. The complete result set is divided into pages of this many bonus payments.</param>
        public async Task<GetBonusPaymentsResponse> GetBonusPayments(string hitId, string assignmentId, string[] responseGroup, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new GetBonusPaymentsRequest
            {
				HITId = hitId,
				AssignmentId = assignmentId,
				ResponseGroup = responseGroup,
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber != default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize != default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetBonusPaymentsRequest, GetBonusPaymentsResponse>(request);
            return resp;
		}

        /// <summary>
        /// The GetQualificationType operation retrieves information about a Qualification type using its ID.
        /// </summary>
        /// <param name="qualificationTypeId">The ID of the Qualification type, as returned by the CreateQualificationType operation.</param>
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

        /// <summary>
        /// The SetHITTypeNotification operation creates, updates, disables or re-enables notifications for a HIT type.
        /// If you call the SetHITTypeNotification operation for a HIT type that already has a notification specification, the operation replaces the old specification with a new one.
        /// You can call the SetHITTypeNotification operation to enable or disable notifications for the HIT type, without having to modify the notification specification itself.
        /// You can call this operation at any time to change the value of the of the Active parameter of a HIT type. You can specify changes to the Active status without specifying a new notification specification (the Notification parameter).
        /// To change the Active status of a HIT type's notifications, the HIT type must already have a notification specification, or one must be provided in the same call to SetHITTypeNotification.
        /// After you make the call to SetHITTypeNotification, it can take up to five minutes for changes to a HIT type's notification specification to take effect.
        /// </summary>
        /// <param name="hitTypeId">The ID of the HIT type whose notification specification is being updated, as returned by the RegisterHITType operation.</param>
        /// <param name="notification">The notification specification for the HIT type.</param>
        /// <param name="active">Specifies whether notifications are sent for HITs of this HIT type, according to the notification specification.</param>
        public async Task<SetHITTypeNotificationResponse> SetHITTypeNotification(string hitTypeId, MTurk.DTO.NotificationSpecification notification, System.Nullable<bool> active = null)
		{
			var request = new SetHITTypeNotificationRequest
            {
				HITTypeId = hitTypeId,
				Notification = notification,
				Active = active ?? default(bool),
				ActiveSpecified = active != default(System.Nullable<bool>),
            };

            var resp = await ExecuteRequest<SetHITTypeNotificationRequest, SetHITTypeNotificationResponse>(request);
            return resp;
		}

        /// <summary>
        /// The ForceExpireHIT operation causes a HIT to expire immediately, as if the LifetimeInSeconds parameter of the HIT had elapsed.
        /// The effect is identical to the HIT expiring on its own; the HIT no longer appears on the Amazon Amazon Mechanical Turk web site, and no new Workers are allowed to accept the HIT. Workers who have accepted the HIT prior to expiration are allowed to complete it or return it, or allow the assignment duration to elapse (abandon the HIT). Once all remaining assignments have been submitted, the expired HIT becomes Reviewable, and will be returned by a call to the GetReviewableHITs operation.
        /// Unlike the DisableHIT operation, the ForceExpireHIT operation does not have any effect on assignments. If assignments have been submitted for the HIT, your application still needs to approve or reject them before disposing of the HIT.
        /// </summary>
        /// <param name="hitId">The ID of the HIT, as returned by the CreateHIT operation.</param>
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

        /// <summary>
        /// The ApproveAssignment operation approves the results of a completed assignment.
        /// Approving an assignment initiates two payments from the Requester's Amazon.com account: the Worker who submitted the results is paid the reward specified in the HIT, and Amazon Mechanical Turk fees are debited. If the Requester's account does not have adequate funds for these payments, the call to ApproveAssignment returns an exception, and the approval is not processed.
        /// You can include an optional feedback message with the approval, which the Worker can see in the Status section of the web site.
        /// </summary>
        /// <param name="assignmentId">The ID of the assignment. This parameter must correspond to a HIT created by the Requester.</param>
        /// <param name="requesterFeedback">A message for the Worker, which the Worker can see in the Status section of the web site.</param>
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

        public async Task<HelpResponse> Help(string[] about, string[] responseGroup, System.Nullable<MTurk.DTO.HelpRequestHelpType> helpType = null)
		{
			var request = new HelpRequest
            {
				About = about,
				ResponseGroup = responseGroup,
				HelpType = helpType ?? default(MTurk.DTO.HelpRequestHelpType),
				HelpTypeSpecified = helpType != default(System.Nullable<MTurk.DTO.HelpRequestHelpType>),
            };

            var resp = await ExecuteRequest<HelpRequest, HelpResponse>(request);
            return resp;
		}

        /// <summary>
        /// The RejectAssignment operation rejects the results of a completed assignment.
        /// You can include an optional feedback message with the rejection, which the Worker can see in the Status section of the web site. When you include a feedback message with the rejection, it helps the Worker understand why the assignment was rejected, and can improve the quality of the results the Worker submits in the future.
        /// Only the Requester who created the HIT can reject an assignment for the HIT.
        /// </summary>
        /// <param name="assignmentId">The assignment ID</param>
        /// <param name="requesterFeedback">A message for the Worker, which the Worker can see in the Status section of the web site.</param>
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

        /// <summary>
        /// The AssignQualification operation gives a Worker a Qualification. AssignQualification does not require that the Worker submit a Qualification request. It gives the Qualification directly to the Worker.
        /// You can only assign a Qualification of a Qualification type that you created (using the CreateQualificationType operation).
        /// Tip
        /// AssignQualification does not affect any pending Qualification requests for the Qualification by the Worker. If you assign a Qualification to a Worker, then later grant a Qualification request made by the Worker, the granting of the request may modify the Qualification score. To resolve a pending Qualification request without affecting the Qualification the Worker already has, reject the request with the  RejectQualificationRequest operation.
        /// </summary>
        /// <param name="qualificationTypeId">The ID of the Qualification type to use for the assigned Qualification.</param>
        /// <param name="workerId">The ID of the Worker to whom the Qualification is being assigned. Worker IDs are included with submitted HIT assignments and Qualification requests.</param>
        /// <param name="integerValue">The value of the Qualification to assign.</param>
        /// <param name="sendNotification">Specifies whether to send a notification email message to the Worker saying that the qualification was assigned to the Worker.</param>
        public async Task<AssignQualificationResponse> AssignQualification(string qualificationTypeId, string workerId, string[] responseGroup, System.Nullable<int> integerValue = null, System.Nullable<bool> sendNotification = null)
		{
			var request = new AssignQualificationRequest
            {
				QualificationTypeId = qualificationTypeId,
				WorkerId = workerId,
				ResponseGroup = responseGroup,
				IntegerValue = integerValue ?? default(int),
				IntegerValueSpecified = integerValue != default(System.Nullable<int>),
				SendNotification = sendNotification ?? default(bool),
				SendNotificationSpecified = sendNotification != default(System.Nullable<bool>),
            };

            var resp = await ExecuteRequest<AssignQualificationRequest, AssignQualificationResponse>(request);
            return resp;
		}

        /// <summary>
        /// The UpdateQualificationScore operation changes the value of a Qualification previously granted to a Worker.
        /// Only the owner of a Qualification type can update the score of a Qualification of that type.
        /// The Worker must have already been granted a Qualification of the given Qualification type before the score can be updated.
        /// </summary>
        /// <param name="qualificationTypeId">The ID of the Qualification type, as returned by CreateQualificationType operation.</param>
        /// <param name="subjectId">The ID of the Worker whose Qualification is being updated, as returned by the GetAssignmentsForHIT operation.</param>
        /// <param name="integerValue">The new value for the Qualification.</param>
        public async Task<UpdateQualificationScoreResponse> UpdateQualificationScore(string qualificationTypeId, string subjectId, string[] responseGroup, System.Nullable<int> integerValue = null)
		{
			var request = new UpdateQualificationScoreRequest
            {
				QualificationTypeId = qualificationTypeId,
				SubjectId = subjectId,
				ResponseGroup = responseGroup,
				IntegerValue = integerValue ?? default(int),
				IntegerValueSpecified = integerValue != default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<UpdateQualificationScoreRequest, UpdateQualificationScoreResponse>(request);
            return resp;
		}

        /// <summary>
        /// The GetAccountBalance operation retrieves the amount of money in your Amazon Mechanical Turk account.
        /// </summary>
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

        /// <summary>
        /// The CreateQualificationType operation creates a new Qualification type, which is represented by a  QualificationType  data structure.
        /// </summary>
        /// <param name="name">The name you give to the Qualification type. The type name is used to represent the Qualification to Workers, and to find the type using a Qualification type search.</param>
        /// <param name="keywords">One or more words or phrases that describe the Qualification type, separated by commas. The keywords of a type make the type easier to find during a search.</param>
        /// <param name="description">A long description for the Qualification type. On the Amazon Mechanical Turk website, the long description is displayed when a Worker examines a Qualification type.</param>
        /// <param name="test">The questions for the Qualification test a Worker must answer correctly to obtain a Qualification of this type.</param>
        /// <param name="answerKey">The answers to the Qualification test specified in the Test parameter, in the form of an AnswerKey data structure.</param>
        /// <param name="qualificationTypeStatus">The initial status of the Qualification type.</param>
        /// <param name="retryDelay">The number of seconds that a Worker must wait after requesting a Qualification of the Qualification type before the worker can retry the Qualification request.</param>
        /// <param name="testDuration">The number of seconds the Worker has to complete the Qualification test, starting from the time the Worker requests the Qualification.</param>
        /// <param name="autoGranted">Specifies whether requests for the Qualification type are granted immediately, without prompting the Worker with a Qualification test.</param>
        /// <param name="autoGrantedValue">The Qualification value to use for automatically granted Qualifications. This parameter is used only if the AutoGranted parameter is true.</param>
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
				QualificationTypeStatusSpecified = qualificationTypeStatus != default(System.Nullable<MTurk.DTO.QualificationTypeStatus>),
				RetryDelayInSeconds = retryDelay == null ? default(long) : ((long)retryDelay.Value.TotalSeconds),
				RetryDelayInSecondsSpecified = retryDelay != default(System.Nullable<System.TimeSpan>),
				TestDurationInSeconds = testDuration == null ? default(long) : ((long)testDuration.Value.TotalSeconds),
				TestDurationInSecondsSpecified = testDuration != default(System.Nullable<System.TimeSpan>),
				AutoGranted = autoGranted ?? default(bool),
				AutoGrantedSpecified = autoGranted != default(System.Nullable<bool>),
				AutoGrantedValue = autoGrantedValue ?? default(int),
				AutoGrantedValueSpecified = autoGrantedValue != default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<CreateQualificationTypeRequest, CreateQualificationTypeResponse>(request);
            return resp;
		}

        /// <summary>
        /// The UpdateQualificationType operation modifies the attributes of an existing Qualification type, which is represented by a  QualificationType  data structure. Only the owner of a Qualification type can modify its attributes.
        /// Most attributes of a Qualification type can be changed after the type has been created. However, the Name and Keywords fields cannot be modified.  The RetryDelayInSeconds parameter can be modified  or added to change the delay or to enable retries, but RetryDelayInSeconds  cannot be used to disable retries.
        /// Each Qualification type name must be unique across all of your Qualification types.  If you want to reuse the name of an existing Qualification type,  you must first dispose of the existing Qualification type using DisposeQualificationType and then create a new Qualification type with the name of the disposed type using CreateQualificationType.
        /// If you want to disable retries, you must dispose of the existing retry-enabled Qualification type using DisposeQualificationType and then create a new Qualification type with retries disabled using CreateQualificationType.
        /// You can use this operation to update the test for a Qualification type. The test is updated based on the values specified for the Test, TestDurationInSeconds and AnswerKey parameters. All three parameters specify the updated test. If you are updating the test for a type, you must specify the Test and TestDurationInSeconds parameters. The AnswerKey parameter is optional; omitting it specifies that the updated test does not have an answer key.
        /// If you omit the Test parameter, the test for the Qualification type is unchanged. There is no way to remove a test from a Qualification type that has one. If the type already has a test, you cannot update it to be AutoGranted. If the Qualification type does not have a test and one is provided by an update, the type will henceforth have a test.
        /// If you want to update the test duration or answer key for an existing test without changing the questions, you must specify a Test parameter with the original questions, along with the updated values.
        /// If you provide an AnswerKey parameter, Amazon Mechanical Turk processes requests for the Qualification automatically, and assigns the Worker a Qualification with a value calculated from the AnswerKey and the answers submitted by the Worker.
        /// If you provide an updated Test but no AnswerKey, the new test will not have an answer key. Requests for such Qualifications must be granted manually.
        /// You can also update the AutoGranted and AutoGrantedValue attributes of the Qualification type.
        /// A Qualification type cannot be configured with both the Test parameter specified and the AutoGranted parameter set to true. Currently, there is no way to remove a test from a Qualification type that has one. A Qualification type with a test cannot be re-configured to use the auto-granting feature.
        /// </summary>
        /// <param name="qualificationTypeId">The ID of the Qualification type to update.</param>
        /// <param name="description">The new description of the Qualification type.</param>
        /// <param name="test">The questions for a Qualification test a Worker must answer correctly to obtain a Qualification of this type.</param>
        /// <param name="answerKey">The answers to the Qualification test specified in the Test parameter.</param>
        /// <param name="qualificationTypeStatus">The new status of the Qualification type.</param>
        /// <param name="testDuration">The amount of time, in seconds, that a Worker has to complete the Qualification test, starting from when the Worker requested the Qualification.</param>
        /// <param name="retryDelay">The amount of time, in seconds, that Workers must wait after requesting a Qualification of the specified Qualification type before they can retry the Qualification request.</param>
        /// <param name="autoGranted">Specifies whether requests for the Qualification type will be granted immediately, without prompting the Worker with a Qualification test.</param>
        /// <param name="autoGrantedValue">The Qualification value to use if AutoGranted is true.</param>
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
				QualificationTypeStatusSpecified = qualificationTypeStatus != default(System.Nullable<MTurk.DTO.QualificationTypeStatus>),
				TestDurationInSeconds = testDuration == null ? default(long) : ((long)testDuration.Value.TotalSeconds),
				TestDurationInSecondsSpecified = testDuration != default(System.Nullable<System.TimeSpan>),
				RetryDelayInSeconds = retryDelay == null ? default(long) : ((long)retryDelay.Value.TotalSeconds),
				RetryDelayInSecondsSpecified = retryDelay != default(System.Nullable<System.TimeSpan>),
				AutoGranted = autoGranted ?? default(bool),
				AutoGrantedSpecified = autoGranted != default(System.Nullable<bool>),
				AutoGrantedValue = autoGrantedValue ?? default(int),
				AutoGrantedValueSpecified = autoGrantedValue != default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<UpdateQualificationTypeRequest, UpdateQualificationTypeResponse>(request);
            return resp;
		}

        /// <summary>
        /// The SearchQualificationTypes operation searches for Qualification types using the specified search query, and returns a list of Qualification types.
        /// The operation sorts the results, divides them into numbered pages, and returns a single page of results. You can control sorting and pagination with parameters to the operation.
        /// </summary>
        /// <param name="query">A text query against all of the searchable attributes of Qualification types.</param>
        /// <param name="mustBeRequestable">Specifies that only Qualification types that a user can request through the Amazon Mechanical Turk web site, such as by taking a Qualification test, are returned as results of the search. Some Qualification types, such as those assigned automatically by the system, cannot be requested directly by users. If false, all Qualification types, including those managed by the system, are considered for the search.</param>
        /// <param name="mustBeOwnedByCaller">Specifies that only Qualification types that the Requester created are returned. If false, the operation returns all Qualification types.</param>
        /// <param name="sortDirection">The direction of the sort used with the field specified by SortProperty.</param>
        /// <param name="sortProperty">The field on which to sort the results returned by the operation.</param>
        /// <param name="pageNumber">The page of results to return. After the operation filters, sorts, and divides the Qualification types into pages of size PageSize, it returns page corresponding to PageNumber as the results of the operation.</param>
        /// <param name="pageSize">The number of Qualification types to include in a page of results. The operation divides the complete sorted result set into pages of this many Qualification types.</param>
        public async Task<SearchQualificationTypesResponse> SearchQualificationTypes(string query, bool mustBeRequestable, string[] responseGroup, System.Nullable<bool> mustBeOwnedByCaller = null, System.Nullable<MTurk.DTO.SortDirection> sortDirection = null, System.Nullable<MTurk.DTO.SearchQualificationTypesSortProperty> sortProperty = null, System.Nullable<int> pageNumber = null, System.Nullable<int> pageSize = null)
		{
			var request = new SearchQualificationTypesRequest
            {
				Query = query,
				MustBeRequestable = mustBeRequestable,
				ResponseGroup = responseGroup,
				MustBeOwnedByCaller = mustBeOwnedByCaller ?? default(bool),
				MustBeOwnedByCallerSpecified = mustBeOwnedByCaller != default(System.Nullable<bool>),
				SortDirection = sortDirection ?? default(MTurk.DTO.SortDirection),
				SortDirectionSpecified = sortDirection != default(System.Nullable<MTurk.DTO.SortDirection>),
				SortProperty = sortProperty ?? default(MTurk.DTO.SearchQualificationTypesSortProperty),
				SortPropertySpecified = sortProperty != default(System.Nullable<MTurk.DTO.SearchQualificationTypesSortProperty>),
				PageNumber = pageNumber ?? default(int),
				PageNumberSpecified = pageNumber != default(System.Nullable<int>),
				PageSize = pageSize ?? default(int),
				PageSizeSpecified = pageSize != default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<SearchQualificationTypesRequest, SearchQualificationTypesResponse>(request);
            return resp;
		}

        /// <summary>
        /// The BlockWorker operation allows you to prevent a Worker from working on your HITs. For example, you can block a Worker who is producing poor quality work. You can block up to 100,000 Workers.
        /// BlockWorker prevents a Worker from accepting more of your HITs after you block them. However, BlockWorker does not prevent a Worker from submitting assignments that they accepted before you blocked them.
        /// You need the Worker ID to use this operation. You can get the Worker ID in the assignment data returned by a call to the GetAssignmentsForHIT operation. If the Worker ID is missing or invalid, this operation returns with the failure message "WorkerId is invalid." If the Worker is already blocked, this operation returns successfully.
        /// </summary>
        /// <param name="workerId">The ID of the Worker to block.</param>
        /// <param name="reason">A message explaining the reason for blocking the Worker. This parameter enables you to keep track of your Workers. The Worker does not see this message.</param>
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

        /// <summary>
        /// The UnblockWorker operation allows you to reinstate a blocked Worker to work on your HITs. This operation reverses the effects of the BlockWorker operation.
        /// You need the Worker ID to use this operation. If the Worker ID is missing or invalid, this operation fails and returns the message “WorkerId is invalid.” If the specified Worker is not blocked, this operation returns successfully.
        /// </summary>
        /// <param name="workerId">The ID of the Worker to unblock.</param>
        /// <param name="reason">A message that explains the reason for unblocking the Worker. The Worker does not see this message.</param>
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

        /// <summary>
        /// The GetAssignment operation retrieves an assignment with an  AssignmentStatus value of Submitted, Approved, or Rejected,  using the assignment's ID. Requesters can only retrieve their own assignments for HITs that they have not disposed of.  For more information about the AssignmentStatus element, see  the Assignment data structure. For more information about assignments, see  Creating and Managing Assignments.
        /// </summary>
        /// <param name="assignmentId">The ID of the assignment that is being requested.</param>
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

        /// <summary>
        /// The RegisterHITType operation creates a new HIT type.
        /// The RegisterHITType operation lets you be explicit about which HITs ought to be the same type. It also gives you error checking, to ensure that you call the CreateHIT operation with a valid HIT type ID.
        /// If you register a HIT type with values that match an existing HIT type, the HIT type ID of the existing type will be returned.
        /// </summary>
        /// <param name="assignmentDuration">The amount of time a Worker has to complete a HIT of this type after accepting it.</param>
        /// <param name="reward">The amount of money the Requester will pay a user for successfully completing a HIT of this type.</param>
        /// <param name="title">The title for HITs of this type.</param>
        /// <param name="keywords">One or more words or phrases that describe a HIT of this type, separated by commas. Searches for words similar to the keywords are more likely to return the HIT in the search results.</param>
        /// <param name="description">A general description of HITs of this type</param>
        /// <param name="qualificationRequirement">A condition that a Worker's Qualifications must meet before the Worker is allowed to accept and complete a HIT of this type.</param>
        /// <param name="autoApprovalDelay">An amount of time, in seconds, after an assignment for a HIT of this type has been submitted, that the assignment becomes Approved automatically, unless the Requester explicitly rejects it.</param>
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
				AutoApprovalDelayInSecondsSpecified = autoApprovalDelay != default(System.Nullable<System.TimeSpan>),
            };

            var resp = await ExecuteRequest<RegisterHITTypeRequest, RegisterHITTypeResponse>(request);
            return resp;
		}

        /// <summary>
        /// The GetRequesterStatistic operation retrieves statistics about you (the Requester calling the operation). The following table describes the available statistics:
        /// NumberAssignmentsAvailable
        /// The number of times Workers can accept an available HIT, totaled over all available HITs. In other words, a HIT with 3 MaxAssignments can be described as having 3 available assignments, each of become Accepted when a Worker accepts the HIT. (Technically, Amazon Mechanical Turk does not create an assignment with an assignment ID until a Worker accepts a HIT.)
        /// Type: Long
        /// NumberAssignmentsAccepted
        /// The number of times Workers have accepted your HITs.
        /// Type: Long
        /// NumberAssignmentsPending
        /// The total number of assignments for your HITs that have been submitted by Workers and are awaiting approval. The total increases and decreases as assignments are submitted by Workers and approved or rejected by you.
        /// Type: Long
        /// NumberAssignmentsApproved
        /// The number of assignments you have approved.
        /// Type: Long
        /// NumberAssignmentsRejected
        /// The number of assignments you have rejected.
        /// Type: Long
        /// NumberAssignmentsReturned
        /// The number of times Workers have returned assignments for your HITs.
        /// Type: Long
        /// The number of times Workers have abandoned assignments (allowed the deadline to elapse without submitting results) for your HITs.
        /// Type: Long
        /// PercentAssignmentsApproved
        /// The percentage of assignments that you have approved, computed over all assignments that you have approved or rejected. The percentage is represented as a decimal fraction between 0 and 1. The statistic value for a given day represents a change in the overall percentage due to activity for that day.
        /// Type: Double
        /// PercentAssignmentsRejected
        /// The percentage of assignments that you have rejected, computed over all assignments that you have approved or rejected. The percentage is represented as a decimal fraction between 0 and 1. The statistic value for a given day represents a change in the overall percentage due to activity for that day.
        /// Type: Double
        /// TotalRewardPayout
        /// The total amount of the rewards paid for approved assignments. The amount is given in U.S. dollars.
        /// Type: Double
        /// AverageRewardAmount
        /// The change in the average amount of the rewards paid for approved assignments. The amount is given in U.S. dollars.
        /// Type: Double
        /// TotalRewardFeePayout
        /// The total amount of the HIT listing fees paid for approved assignments. The amount is given in U.S. dollars.
        /// Type: Double
        /// TotalFeePayout
        /// The total amount of the HIT listing fees paid for approved assignments and bonus payments. The amount is given in U.S. dollars.
        /// This statistic is deprecated.  To get the total amount of fees paid for rewards and bonuses, get the TotalRewardFeePayout statistic and the TotalBonusFeePayout statistic and add them together.
        /// Type: Double
        /// TotalRewardAndFeePayout
        /// The total amount of money paid for approved assignments, including rewards and fees. The amount is given in U.S. dollars.
        /// This total does not include fees for bonus payments made with the GrantBonus operation.
        /// This statistic is deprecated. To get the total amount of money paid for rewards and reward fees, get the TotalRewardPayout and TotalRewardFeePayout statistics and add them together.
        /// Type: Double
        /// TotalBonusPayout
        /// The total amount of the bonuses paid to Workers. The amount is given in U.S. dollars.
        /// Type: Double
        /// TotalBonusFeePayout
        /// The total amount of the fees paid for bonus payments. The amount is given in U.S. dollars.
        /// Type: Double
        /// NumberHITsCreated
        /// The number of HITs you created.
        /// Type: Long
        /// NumberHITsCompleted
        /// The total number of your HITs that have been completed to their final state of either Disposed or Disabled.
        /// Type: Long
        /// NumberHITsAssignable
        /// The number of your HITs with status Assignable.
        /// NumberHITsAssignable can only be queried as a LifeToDate value. While most statistics change in real time, a day's value for this statistic is added to the LifeToDate total at the end of the day.
        /// Type: Long
        /// NumberHITsReviewable
        /// The number of your HITs with status Reviewable.
        /// Type: Long
        /// EstimatedRewardLiability
        /// The total amount of all of the rewards for HITs and assignments that have not yet been completed. This includes the reward for each unclaimed assignment for HITs that have not yet expired, each assignment in progress, and each submitted assignment that has not yet been approved or rejected. This is an estimate, because it is possible that not all of a HIT's assignments will be completed before the HIT expires. The amount is given in U.S. dollars.
        /// Type: Double
        /// EstimatedFeeLiability
        /// The total amount of all of the HIT listing fees for HITs and assignments that have not yet been completed at a given point in time. The amount is given in U.S. dollars.
        /// Type: Double
        /// EstimatedTotalLiability
        /// The total amount of all of the rewards and fees for HITs and assignments that have not yet been completed at a given point in time. The amount is given in U.S. dollars.
        /// Type: Double
        /// </summary>
        /// <param name="statistic">The statistic to return</param>
        /// <param name="timePeriod">The time period of the statistic to return.</param>
        /// <param name="count">The number of data points to return</param>
        public async Task<GetRequesterStatisticResponse> GetRequesterStatistic(MTurk.DTO.RequesterStatistic statistic, string[] responseGroup, System.Nullable<MTurk.DTO.TimePeriod> timePeriod = null, System.Nullable<int> count = null)
		{
			var request = new GetRequesterStatisticRequest
            {
				Statistic = statistic,
				ResponseGroup = responseGroup,
				TimePeriod = timePeriod ?? default(MTurk.DTO.TimePeriod),
				TimePeriodSpecified = timePeriod != default(System.Nullable<MTurk.DTO.TimePeriod>),
				Count = count ?? default(int),
				CountSpecified = count != default(System.Nullable<int>),
            };

            var resp = await ExecuteRequest<GetRequesterStatisticRequest, GetRequesterStatisticResponse>(request);
            return resp;
		}

        /// <summary>
        /// The DisposeHIT operation disposes of a HIT that is no longer needed. Only the Requester who created the HIT can dispose of it.
        /// You can only dispose of HITs that are in the Reviewable state, with all of their submitted assignments already either approved or rejected. If you call the DisposeHIT operation on a HIT that is not in the Reviewable state (for example, that has not expired, or still has active assignments), or on a HIT that is Reviewable but without all of its submitted assignments already approved or rejected, the service returns an error.
        /// Once you dispose of a HIT, you can no longer approve the HIT's rejected assignments.
        /// </summary>
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

        /// <summary>
        /// The ChangeHITTypeOfHIT operation allows you to change the HITType properties of a HIT. This operation disassociates the HIT from its old HITType properties and associates it with the new HITType properties. The HIT takes on the properties of the new HITType in place of the old ones. For more information about HIT types, see the   Amazon Mechanical Turk Developer Guide.
        /// You can use ChangeHITTypeOfHIT to update any of the HITType properties of a HIT.
        /// </summary>
        /// <param name="hitId">The ID of the HIT to change</param>
        /// <param name="hitTypeId">The ID of the new HIT type</param>
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

	}
}