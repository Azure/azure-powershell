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
            else if (ex.Response?.Content != null)
            {
                message = $"{ex.Message}. Response: {ex.Response.Content}";
                desensitizedMessage = ex.Message;
            }
            else
            {
                message = ex.Message;
                desensitizedMessage = ex.Message;
            }

            return new AzPSCloudException(message, desensitizedMessage, ex)
            {
                Request = ex.Request,
                Response = ex.Response,
            };
        }
    }
}
