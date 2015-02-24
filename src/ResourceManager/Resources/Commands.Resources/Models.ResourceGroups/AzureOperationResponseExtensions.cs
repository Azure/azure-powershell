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

namespace Microsoft.Azure.Commands.Resources.Models
{
    /// <summary>
    /// Houses extension methods for the <see cref="AzureOperationResponse"/> class.
    /// </summary>
    public static class AzureOperationResponseExtensions
    {
        /// <summary>
        /// Returns true if the status code corresponds to a successful request.
        /// </summary>
        /// <param name="azureOperationResponse">The azure operation response.</param>
        public static bool IsSuccessfulRequest(this AzureOperationResponse azureOperationResponse)
        {
            return AzureOperationResponseExtensions.IsSuccessfulRequest((int)azureOperationResponse.StatusCode);
        }

        /// <summary>
        /// Returns true if the status code corresponds to a successful request.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        private static bool IsSuccessfulRequest(int statusCode)
        {
            return (statusCode >= 200 && statusCode <= 299) || statusCode == 304;
        }
    }
}
