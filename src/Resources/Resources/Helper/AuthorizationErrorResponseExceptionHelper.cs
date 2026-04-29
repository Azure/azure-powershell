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
using Microsoft.Azure.Management.Authorization.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Resources.Helper
{
    /// <summary>
    /// Helper class to convert <see cref="ErrorResponseException"/> from the Authorization SDK
    /// into <see cref="AzPSCloudException"/> with descriptive error messages.
    /// The SDK-generated <see cref="ErrorResponseException"/> only contains the HTTP status code
    /// in its message; the actual service error details live on <c>ex.Body.Error</c> or
    /// <c>ex.Response.Content</c>. This helper surfaces those details to the user.
    /// </summary>
    internal static class AuthorizationErrorResponseExceptionHelper
    {
        // Telemetry-safe placeholder used when no service-supplied error code is available.
        // Avoids any risk of leaking PII via ex.Message if the SDK template ever changes.
        private const string UnknownErrorCode = "UnknownAuthorizationError";

        // Maximum number of characters of raw response content embedded in the user-facing
        // exception message. The full body remains available on ex.Response.Content for debugging.
        private const int MaxRawContentLength = 500;

        /// <summary>
        /// Creates an <see cref="AzPSCloudException"/> from an <see cref="ErrorResponseException"/>,
        /// extracting the service error details from either the structured Body or the raw response content.
        /// </summary>
        /// <param name="ex">The original <see cref="ErrorResponseException"/>.</param>
        /// <returns>An <see cref="AzPSCloudException"/> with the descriptive error message.</returns>
        internal static AzPSCloudException CreateDescriptiveException(ErrorResponseException ex)
        {
            string message;
            string desensitizedMessage;

            if (ex.Body?.Error != null)
            {
                message = $"{ex.Message}. {ex.Body.Error.Code}: {ex.Body.Error.Message}";
                desensitizedMessage = ex.Body.Error.Code;
            }
            else if (!string.IsNullOrEmpty(ex.Response?.Content))
            {
                (message, desensitizedMessage) = ParseErrorContent(ex.Message, ex.Response.Content);
            }
            else
            {
                message = ex.Message;
                desensitizedMessage = UnknownErrorCode;
            }

            return new AzPSCloudException(message, desensitizedMessage, ex)
            {
                Request = ex.Request,
                Response = ex.Response,
            };
        }

        // Builds the (user-facing message, telemetry-safe code) pair from a raw response body.
        // On a successful parse of the standard Azure error JSON shape
        // ({ "error": { "code": "...", "message": "..." } }) we surface code+message;
        // otherwise we fall back to embedding the raw content with an UnknownErrorCode tag.
        private static (string Message, string Desensitized) ParseErrorContent(string original, string content)
        {
            try
            {
                var error = JObject.Parse(content)["error"] as JObject;
                var code = error?.Value<string>("code");
                var detail = error?.Value<string>("message");

                if (!string.IsNullOrEmpty(code) || !string.IsNullOrEmpty(detail))
                {
                    var suffix = !string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(detail)
                        ? $"{code}: {detail}"
                        : (code ?? detail);
                    return ($"{original}. {suffix}", string.IsNullOrEmpty(code) ? UnknownErrorCode : code);
                }
            }
            catch (Exception)
            {
                // Fall through to raw-content fallback.
            }

            return ($"{original}. Response: {TruncateForDisplay(content)}", UnknownErrorCode);
        }

        // Collapses runs of whitespace and truncates overly long bodies so a multi-line/large
        // service response doesn't flood the console. The full body is still available via
        // AzPSCloudException.Response.Content for debugging.
        private static string TruncateForDisplay(string content)
        {
            var collapsed = Regex.Replace(content.Trim(), @"\s+", " ");
            return collapsed.Length <= MaxRawContentLength
                ? collapsed
                : collapsed.Substring(0, MaxRawContentLength) + "... (truncated)";
        }
    }
}
