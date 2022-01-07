using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

using Microsoft.Azure.Commands.Common.Authentication.Policy;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

using static Azure.Core.HttpHeader;

namespace Microsoft.Azure.Commands.Common.Authentication.Extensions
{
    internal static class ArmClientOptionExtension
    {

        internal class AzPsHttpMessageHandler : HttpMessageHandler
        {
            private IEnumerable<ProductInfoHeaderValue> _userAgent;

            public AzPsHttpMessageHandler(IEnumerable<ProductInfoHeaderValue> userAgent)
            {
                _userAgent = userAgent;
            }
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                _userAgent?.ForEach((agent) => {
                    request.Headers.UserAgent.Add(agent);
                });

                return SendAsync(request, cancellationToken);
            }
        }

        /// <summary>
        /// Set max retry times of retry after handler that is used to handle the response with retry-after header
        /// from environement variable AZURE_PS_HTTP_MAX_RETRIES_FOR_429
        /// </summary>
        /// <returns>Whether succeed to set max retry times or not</returns>
        public static void AddUserAgent(this ArmClientOptions option, ProductInfoHeaderValue[] userAgent)
        {
            if (null == option.Transport || default(HttpPipelineTransport) == option.Transport)
            {
                option.Transport = new HttpClientTransport(new AzPsHttpMessageHandler(userAgent));
            }
            else
            {
                throw new Exception("Client Transport already has defined.");
            }
        }

        /// <summary>
        /// Set max retry times of retry after handler that is used to handle the response with retry-after header
        /// from environement variable AZURE_PS_HTTP_MAX_RETRIES_FOR_429
        /// </summary>
        /// <returns>Whether succeed to set max retry times or not</returns>
        public static void SetMaxDelayForRetryOption(this ArmClientOptions option, int maxDelay)
        {
            int? maxretriesfor429 = HttpRetryTimes.AzurePsHttpMaxRetriesFor429;
            if (maxretriesfor429 != null && maxretriesfor429 >= 0)
            {
                option.Retry.MaxDelay = new TimeSpan();
            }
        }

        /// <summary>
        /// Set max retry count of retry policy from environement variable AZURE_PS_HTTP_MAX_RETRIES
        /// </summary>
        /// <returns>Whether succeed to set retry count or not</returns>
        public static void SetMaxRetryCountofRetryOption(this ArmClientOptions option, int maxRetries)
        {
            option.Retry.MaxRetries = maxRetries;
        }
    }
}
