using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTurk.DTO;
using Xunit;

namespace MTurk.Tests
{
    public class HIT
    {
        [Fact]
        public async Task CreateHIT()
        {
            var client = new TurkClient(Credentials.AccessKey, Credentials.SecretKey, true);
            var resp = await client.CreateHIT("Test HIT", "A test HIT", new Price {Amount = 0.07M, CurrencyCode = "USD"},
                TimeSpan.FromDays(7), null, TimeSpan.FromDays(7), null,
                new ExternalQuestion {ExternalURL = "https://www.google.com/", FrameHeight = "100"},
                TimeSpan.FromDays(7));

            if (resp.OperationRequest != null && resp.OperationRequest.Errors != null && resp.OperationRequest.Errors.Length != 0)
                Assert.False(true, string.Format("Global operation error: [{0}] {1}", resp.OperationRequest.Errors[0].Code, resp.OperationRequest.Errors[0].Message));

            if (resp.HIT[0].Request.Errors != null && resp.HIT[0].Request.Errors.Length != 0)
                Assert.False(true, string.Format("HIT operation error: [{0}] {1}", resp.HIT[0].Request.Errors[0].Code, resp.HIT[0].Request.Errors[0].Message));
        }
    }
}
