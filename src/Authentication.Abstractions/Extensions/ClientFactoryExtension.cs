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

using System;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    public static class ServiceClientExtension
    {
        /// <summary>
        /// Set max retry times of retry after handler that is used to handle the response with retry-after header
        /// </summary>
        /// <param name="retrytimes">Max retry times</param>
        /// <returns>Whether succeed to set max retry times or not</returns>
        public static bool SetMaxTimesForRetryAfterHandler<TClient>(this Microsoft.Rest.ServiceClient<TClient> serviceClient, uint retrytimes) where TClient : Microsoft.Rest.ServiceClient<TClient>
        {
            bool findRetryHandler = false;
            foreach(var handler in serviceClient.HttpMessageHandlers)
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
    }
}
