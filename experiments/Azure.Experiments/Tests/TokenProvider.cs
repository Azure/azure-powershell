using Microsoft.Rest;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using Newtonsoft.Json;

namespace Microsoft.Azure.Experiments.Tests
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
                        responseObject.token_type,
                        responseObject.access_token);
                }
            }
            return Header;
        }

        private Uri Uri { get; }

        private FormUrlEncodedContent Content { get; }

        private AuthenticationHeaderValue Header { get; set; }
    }
}
