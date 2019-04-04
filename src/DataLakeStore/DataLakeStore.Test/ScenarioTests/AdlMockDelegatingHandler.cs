using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.DataLake.Test.ScenarioTests
{
    /// <summary>
    /// This is needed to non-indent the output for jsons
    /// </summary>
    public class AdlMockDelegatingHandler : DelegatingHandler
    {
        public static bool IsJson(string content)
        {
            content = content.Trim();
            return content.StartsWith("{") && content.EndsWith("}")
                   || content.StartsWith("[") && content.EndsWith("]");
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            var str = await response.Content.ReadAsStringAsync();
            if (IsJson(str))
            {
                try
                {
                    object parsedJson = JsonConvert.DeserializeObject(str);
                    response.Content = new StringContent(JsonConvert.SerializeObject(parsedJson));
                    return response;
                }
                catch
                {
                    // can't parse JSON, return the original string
                    return response;
                }
            }

            return response;
        }
    }
}
