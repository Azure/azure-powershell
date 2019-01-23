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
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication.Utilities
{
    /// <summary>
    /// Retry algorithm for Http messages
    /// </summary>
    public interface IHttpRetryAlgorithm
    {
        /// <summary>
        /// Determine if a request should be retried
        /// </summary>
        /// <param name="message">The response to the request</param>
        /// <returns>True if the request should be retried</returns>
        bool ShouldRetry(HttpResponseMessage message);

        /// <summary>
        /// Wait for the appropriate retry interval
        /// </summary>
        /// <returns>A Task that dealys for the appropriate interval</returns>
        Task WaitForRetry();
    }
}
