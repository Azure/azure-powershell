using Microsoft.Rest;
using System;
using Xunit;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Experiments.Tests
{
    public class ComputeTest
    {
        sealed class TokenProvider : ITokenProvider
        {
            public Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync(
                CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void Test1()
        {
            var credentials = new TokenCredentials(new TokenProvider());
            var client = new Microsoft.Azure.Management.Compute.ComputeManagementClient(credentials);
        }
    }
}
