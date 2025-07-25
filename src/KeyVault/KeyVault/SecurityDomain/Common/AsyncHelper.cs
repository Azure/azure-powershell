using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Common
{
    internal static class AsyncOperationExtensions
    {
        internal static string GetFirstHeader(this System.Net.Http.HttpResponseMessage response, string headerName) => response.Headers.FirstOrDefault(each => string.Equals(headerName, each.Key, System.StringComparison.OrdinalIgnoreCase)).Value?.FirstOrDefault() ?? string.Empty;

        internal static HttpRequestMessage CloneAndDispose(this HttpRequestMessage original, System.Uri requestUri = null, System.Net.Http.HttpMethod method = null)
        {
            using (original)
            {
                return original.Clone(requestUri, method);
            }
        }

        internal static HttpRequestMessage Clone(this HttpRequestMessage original, System.Uri requestUri = null, System.Net.Http.HttpMethod method = null)
        {
            var clone = new HttpRequestMessage
            {
                Method = method ?? original.Method,
                RequestUri = requestUri ?? original.RequestUri,
                Version = original.Version,
            };

            foreach (KeyValuePair<string, object> prop in original.Properties)
            {
                clone.Properties.Add(prop);
            }

            foreach (KeyValuePair<string, IEnumerable<string>> header in original.Headers)
            {
                /*
                **temporarily skip cloning telemetry related headers**
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
                */
                if (!"x-ms-unique-id".Equals(header.Key) && !"x-ms-client-request-id".Equals(header.Key) && !"CommandName".Equals(header.Key) && !"FullCommandName".Equals(header.Key) && !"ParameterSetName".Equals(header.Key) && !"User-Agent".Equals(header.Key))
                {
                    clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            return clone;
        }

    }
}