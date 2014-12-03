using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTurk.DTO
{
    public class RestHeader
    {
        public string Service { get; set; } = "AWSMechanicalTurkRequester";
        public string AWSAccessKeyId { get; set; }
        public string Version { get; set; }
        public string Operation { get; set; }
        public string Signature { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
