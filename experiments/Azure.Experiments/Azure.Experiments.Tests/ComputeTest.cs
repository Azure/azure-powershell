using Microsoft.Rest;
using Xunit;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Azure.Management.Compute;

namespace Azure.Experiments.Tests
{
    public class ComputeTest
    {
        sealed class TokenProvider : ITokenProvider
        {           
            public TokenProvider(Configuration c)
            {
                var parameters = new[]
                {
                    KeyValuePair.Create("grant_type", "client_credentials"),
                    KeyValuePair.Create("client_id", c.applicationId),
                    KeyValuePair.Create("client_secret", c.clientSecret),
                    KeyValuePair.Create("resource", "https://management.core.windows.net/")
                };
                Content = new FormUrlEncodedContent(parameters);
                Uri = new Uri("https://login.microsoftonline.com/" + c.tenantId + "/oauth2/token");
            }

            public async Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync(
                CancellationToken cancellationToken)
            {
                if (Header == null)
                {
                    using (var client = new HttpClient())
                    {
                        var response = await client
                            .PostAsync(Uri, Content)
                            .Result
                            .Content
                            .ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<AuthenticationResponse>(
                            response);
                        Header = new AuthenticationHeaderValue(
                            responseObject.token_type, responseObject.access_token);
                    }
                }
                return Header;
            }

            private Uri Uri { get; }

            private FormUrlEncodedContent Content { get; }

            private AuthenticationHeaderValue Header { get; set; }
        }

        private sealed class AuthenticationResponse
        {
            public string token_type;
            public string access_token;
        }

        private sealed class Configuration
        {
            public string applicationId;
            public string tenantId;
            public string clientSecret;
            public string subscriptionId;
        }

        [Fact]
        public async void Test1()
        {
            var text = File.ReadAllText(@"c:\Users\sergey\Desktop\php-test.json");
            var c = JsonConvert.DeserializeObject<Configuration>(text);
            var credentials = new TokenCredentials(new TokenProvider(c));
            var client = new ComputeManagementClient(credentials);
            client.SubscriptionId = c.subscriptionId;
            var list = await client.VirtualMachines.ListAllAsync();
        }
    }
}
