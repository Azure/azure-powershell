// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Rest.TransientFaultHandling;
using System;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    internal static class ServiceClientExtension
    {
        private class HttpRetryTimes
        {
            private const string maxRetriesVariableName = "AZURE_PS_HTTP_MAX_RETRIES";
            private const string maxRetriesFor429VariableName = "AZURE_PS_HTTP_MAX_RETRIES_FOR_429";

            public static int? AzurePsHttpMaxRetries
            {
                get
                {
                    return TryGetAzurePsHttpMaxRetries();
                }
            }
            public static int? AzurePsHttpMaxRetriesFor429
            {
                get
                {
                    return TryGetAzurePsHttpMaxRetriesFor429();
                }
            }

            private static int? TryGetValue(string environmentVariable)
            {
                int? retries = null;
                var value = Environment.GetEnvironmentVariable(environmentVariable);
                if (value != null)
                {
                    int valueParsed = int.MinValue;
                    if (int.TryParse(value, out valueParsed))
                    {
                        retries = valueParsed;
                    }
                }
                return retries;
            }

            private static int? TryGetAzurePsHttpMaxRetries()
            {
                return TryGetValue(maxRetriesVariableName);
            }

            private static int? TryGetAzurePsHttpMaxRetriesFor429()
            {
                return TryGetValue(maxRetriesFor429VariableName);
            }
        }

        private static bool SetMaxTimesForRetryAfterHandler<TClient>(this Microsoft.Rest.ServiceClient<TClient> serviceClient, uint retrytimes) where TClient : Microsoft.Rest.ServiceClient<TClient>
        {
            bool findRetryHandler = false;
            foreach (var handler in serviceClient.HttpMessageHandlers)
            {
                var retryHandler = handler as Microsoft.Rest.RetryAfterDelegatingHandler;
                if (retryHandler != null)
                {
                    retryHandler.MaxRetries = Convert.ToInt32(retrytimes);
                    findRetryHandler = true;
                }
            }
            return findRetryHandler;
        }

        /// <summary>
        /// Set max retry times of retry after handler that is used to handle the response with retry-after header
        /// from environement variable AZURE_PS_HTTP_MAX_RETRIES_FOR_429
        /// </summary>
        /// <returns>Whether succeed to set max retry times or not</returns>
        public static bool TrySetMaxTimesForRetryAfterHandler<TClient>(this Microsoft.Rest.ServiceClient<TClient> serviceClient) where TClient : Microsoft.Rest.ServiceClient<TClient>
        {
            int? maxretriesfor429 = HttpRetryTimes.AzurePsHttpMaxRetriesFor429;
            if (maxretriesfor429 != null && maxretriesfor429 >= 0)
            {
                return serviceClient.SetMaxTimesForRetryAfterHandler(Convert.ToUInt32(maxretriesfor429));
            }
            return false;
        }

        /// <summary>
        /// Set retry count of retry policy using ExponentialBackoffRetryStrategy from environement variable AZURE_PS_HTTP_MAX_RETRIES
        /// </summary>
        /// <returns>Whether succeed to set retry count or not</returns>
        public static bool TrySetRetryCountofRetryPolicy<TClient>(this Microsoft.Rest.ServiceClient<TClient> serviceClient) where TClient : Microsoft.Rest.ServiceClient<TClient>
        {
            int? maxretries = ServiceClientExtension.HttpRetryTimes.AzurePsHttpMaxRetries;
            if (maxretries != null && maxretries >= 0)
            {
                TimeSpan defaultBackoffDelta = new TimeSpan(0, 0, 10);
                TimeSpan defaultMaxBackoff = new TimeSpan(0, 0, 10);
                TimeSpan defaultMinBackoff = new TimeSpan(0, 0, 1);
                var retryStrategy = new ExponentialBackoffRetryStrategy(
                    (int)maxretries,
                    defaultBackoffDelta,
                    defaultMaxBackoff,
                    defaultMinBackoff);
                var retryPolicy = new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(retryStrategy);
                serviceClient.SetRetryPolicy(retryPolicy);
                return true;
            }
            return false;
        }
    }
}