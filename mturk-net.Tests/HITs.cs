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
            var response = await client.CreateHIT("Test HIT", "A test HIT", new Price {Amount = 0.07M, CurrencyCode = "USD"},
                TimeSpan.FromDays(7), null, TimeSpan.FromDays(7), null,
                new ExternalQuestion {ExternalURL = "http://www.google.com/", FrameHeight = "100px"},
                TimeSpan.FromDays(7));

            // client.CreateHIT()
        }
    }
}
