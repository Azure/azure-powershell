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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Management.Sql.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.Common
{
    /// <summary>
    /// Helper class to convert ErrorResponseException to AzPSCloudException with descriptive error messages.
    /// Due to a change in the SDK generator when common-types v5 ErrorResponse schema is used,
    /// the ErrorResponseException.Message is not populated with the actual error details.
    /// This helper extracts the real error message from the response body.
    /// </summary>
    internal static class ErrorResponseExceptionHelper
    {
        /// <summary>
        /// Creates an AzPSCloudException from an ErrorResponseException by extracting
        /// the actual error message from the response body.
        /// </summary>
        /// <param name="ex">The original ErrorResponseException</param>
        /// <returns>An AzPSCloudException with the descriptive error message</returns>
        internal static AzPSCloudException CreateFrom(ErrorResponseException ex)
        {
            // First try to get the message from the structured Body object
            string detailedMessage = ex.Body?.Error?.Message;

            // Append error details if available (e.g., Azure Policy violation details)
            if (!string.IsNullOrEmpty(detailedMessage) && ex.Body?.Error?.Details != null && ex.Body.Error.Details.Any())
            {
                var sb = new StringBuilder(detailedMessage);
                foreach (var detail in ex.Body.Error.Details)
                {
                    if (!string.IsNullOrEmpty(detail.Message))
                    {
                        sb.AppendLine();
                        sb.Append(detail.Message);
                    }
                }
                detailedMessage = sb.ToString();
            }

            // If that didn't work, try parsing the raw response content
            if (string.IsNullOrEmpty(detailedMessage) && ex.Response != null && !string.IsNullOrEmpty(ex.Response.Content))
            {
                try
                {
                    var parsed = JObject.Parse(ex.Response.Content);

                    var errorObj = parsed["error"] as JObject;
                    if (errorObj != null)
                    {
                        JToken errorMessage;
                        if (errorObj.TryGetValue("message", StringComparison.OrdinalIgnoreCase, out errorMessage))
                        {
                            detailedMessage = errorMessage.ToString();
                        }
                    }
                    else
                    {
                        var messageToken = parsed["Message"];
                        if (messageToken != null)
                        {
                            detailedMessage = messageToken.ToString();
                        }
                    }
                }
                catch (Exception)
                {
                    // JSON parsing or property access failed — fall through to use original message
                }
            }

            var message = !string.IsNullOrEmpty(detailedMessage) ? detailedMessage : ex.Message;
            var wrappedException = new AzPSCloudException(message, message, ex)
            {
                Request = ex.Request,
                Response = ex.Response,
            };

            if (!string.IsNullOrEmpty(ex.Body?.Error?.Code))
            {
                wrappedException.Data["CloudErrorCode"] = ex.Body.Error.Code;
            }

            return wrappedException;
        }
    }
}
