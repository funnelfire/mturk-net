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
        /// The AssignQualification operation gives a Worker a Qualification. AssignQualification does not require that the Worker submit a Qualification request. It gives the Qualification directly to the Worker.
        /// You can only assign a Qualification of a Qualification type that you created(using the CreateQualificationType operation).
        /// Tip: AssignQualification does not affect any pending Qualification requests for the Qualification by the Worker.If you assign a Qualification to a Worker, then later grant a Qualification request made by the Worker, the granting of the request may modify the Qualification score.To resolve a pending Qualification request without affecting the Qualification the Worker already has, reject the request with the RejectQualificationRequest operation.
        /// </summary>
        /// <param name="qualificationTypeId">The ID of the Qualification type to use for the assigned Qualification.</param>
        /// <param name="workerId">The ID of the Worker to whom the Qualification is being assigned. Worker IDs are included with submitted HIT assignments and Qualification requests.</param>
        /// <param name="integerValue">The value of the Qualification to assign.</param>
        /// <param name="sendNotification">Specifies whether to send a notification email message to the Worker saying that the qualification was assigned to the Worker.</param>
        public async Task<AssignQualificationResponse> AssignQualification(string qualificationTypeId, string workerId, int integerValue = 1, bool sendNotification = true)
        {
            var request = new AssignQualificationRequest
            {
                QualificationTypeId = qualificationTypeId,
                WorkerId = workerId,
                IntegerValue = 1,
                SendNotification = true
            };

            var resp = await ExecuteRequest<AssignQualificationRequest, AssignQualificationResponse>(request);
            return resp;
        }
    }
}
