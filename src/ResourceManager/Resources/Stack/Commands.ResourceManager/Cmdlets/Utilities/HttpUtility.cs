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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    using System.Net;

    /// <summary>
    /// The http utility.
    /// </summary>
    public static class HttpUtility
    {
        /// <summary>
        /// Returns true if the status code corresponds to a successful request.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        public static bool IsSuccessfulRequest(this HttpStatusCode statusCode)
        {
            return HttpUtility.IsSuccessfulRequest((int)statusCode);
        }

        /// <summary>
        /// Returns true if the status code corresponds to a server failure request.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        public static bool IsServerFailureRequest(this HttpStatusCode statusCode)
        {
            return HttpUtility.IsServerFailureRequest((int)statusCode);
        }

        /// <summary>
        /// Returns true if the status code corresponds to client failure.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        public static bool IsClientFailureRequest(this HttpStatusCode statusCode)
        {
            return HttpUtility.IsClientFailureRequest((int)statusCode);
        }

        /// <summary>
        /// Returns true if the status code corresponds to a successful request.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        private static bool IsSuccessfulRequest(int statusCode)
        {
            return (statusCode >= 200 && statusCode <= 299) || statusCode == 304;
        }

        /// <summary>
        /// Returns true if the status code corresponds to client failure.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        private static bool IsClientFailureRequest(int statusCode)
        {
            return statusCode == 505 || statusCode == 501 || (statusCode >= 400 && statusCode < 500 && statusCode != 408);
        }

        /// <summary>
        /// Returns true if the status code corresponds to a server failure request.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        private static bool IsServerFailureRequest(int statusCode)
        {
            return (statusCode >= 500 && statusCode <= 599 && statusCode != 505 && statusCode != 501) || statusCode == 408;
        }
    }
}
