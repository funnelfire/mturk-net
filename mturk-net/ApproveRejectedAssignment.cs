using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTurk.DTO;

namespace MTurk
{
    partial class TurkClient
    {
        /// <summary>
        /// The ApproveRejectedAssignment operation approves an assignment that was previously rejected.
        /// ApproveRejectedAssignment works only on rejected assignments that were submitted within the previous 30 days and only if the assignment's related HIT has not been disposed.
        /// Approving the rejected assignment initiates two payments from the Requester's Amazon.com account: one payment to the Worker who submitted the results for the reward amount specified in the HIT and one payment for Amazon Mechanical Turk fees. For the operation to succeed, a Requester must have sufficient funds in their account to pay the Worker and the fees.
        /// If the assignment is not currently rejected, or if the Requester does not have sufficient funds in their account to pay the Worker and the Mechanical Turk fees, then the ApproveRejectedAssignment operation returns an exception and the approval is not processed.
        /// You can include an optional feedback message with the approval, which the Worker can see in the Status section of the Amazon Mechanical Turk website.
        /// </summary>
        /// <param name="assignmentId">The ID of the assignment. This parameter must correspond to a HIT created by the Requester.</param>
        /// <param name="requesterFeedback">A message for the Worker, which the Worker can see in the Status section of the web site.</param>
        /// <seealso cref="http://docs.aws.amazon.com/AWSMechTurk/latest/AWSMturkAPI/ApiReference_ApproveRejectedAssignmentOperation.html"/>
        public async Task<ApproveRejectedAssignmentResponse> ApproveRejectedAssignment(string assignmentId, string requesterFeedback = null)
        {
            var request = new ApproveRejectedAssignmentRequest
            {
                AssignmentId = assignmentId,
                RequesterFeedback = requesterFeedback
            };

            var resp = await ExecuteRequest<ApproveRejectedAssignmentRequest, ApproveRejectedAssignmentResponse>(request);
            return resp;
        }
    }
}
