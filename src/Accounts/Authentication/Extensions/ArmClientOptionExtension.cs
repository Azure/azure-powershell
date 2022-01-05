using Azure.Core;
using Azure.ResourceManager;

using Microsoft.Azure.Commands.Common.Authentication.Policy;

using System;
using System.Net.Http.Headers;

namespace Microsoft.Azure.Commands.Common.Authentication.Extensions
{
    internal static class ArmClientOptionExtension
    {
        /// <summary>
        /// Set max retry times of retry after handler that is used to handle the response with retry-after header
        /// from environement variable AZURE_PS_HTTP_MAX_RETRIES_FOR_429
        /// </summary>
        /// <returns>Whether succeed to set max retry times or not</returns>
        public static void AddUserAgent(this ArmClientOptions option, ProductInfoHeaderValue[] userAgent)
        {
            option.AddPolicy(new AzPsHttpPipelineSynchronousPolicy(), HttpPipelinePosition.PerCall);
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
