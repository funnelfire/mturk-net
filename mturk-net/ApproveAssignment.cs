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
        /// The ApproveAssignment operation approves the results of a completed assignment.
        /// Approving an assignment initiates two payments from the Requester's Amazon.com account: the Worker who submitted the results is paid the reward specified in the HIT, and Amazon Mechanical Turk fees are debited. If the Requester's account does not have adequate funds for these payments, the call to ApproveAssignment returns an exception, and the approval is not processed.
        /// You can include an optional feedback message with the approval, which the Worker can see in the Status section of the web site.
        /// </summary>
        /// <param name="assignmentId">The ID of the assignment. This parameter must correspond to a HIT created by the Requester.</param>
        /// <param name="requesterFeedback">A message for the Worker, which the Worker can see in the Status section of the web site.</param>
        /// <returns></returns>
        public async Task<ApproveAssignmentResponse> ApproveAssignment(string assignmentId, string requesterFeedback = null)
        {
            var request = new ApproveAssignmentRequest
            {
                AssignmentId = assignmentId,
                RequesterFeedback = requesterFeedback
            };

            var resp = await ExecuteRequest<ApproveAssignmentRequest, ApproveAssignmentResponse>(request);
            return resp;
        }
    }
}
