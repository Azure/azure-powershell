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

namespace Microsoft.AzureStack.Commands.Security
{
    /// <summary>
    /// constant strings and values
    /// </summary>
    public static class SharedConstants
    {
        /// <summary>
        /// Application settings for Azure Stack PowerShell authorization configuration.
        /// </summary>
        public static class AzureStackPowerShell
        {
            /// <summary>
            /// The Azure Stack PowerShell client identifier.
            /// </summary>
            /// <remarks>We use a hardcoded string with a guid value to be consistent with Azure Active Directory 
            /// and their client application registration procedure (each client app is assigned a string with unique identifier).</remarks>
            public const string ClientId = "445ace50-bb67-4e02-9371-3d69ced8c25a";

            /// <summary>
            /// The redirect uri which is a well-known string for native applications.
            /// </summary>
            public const string RedirectUri = "urn:ietf:wg:oauth:2.0:oob";
        }

        /// <summary>
        /// Application settings for Azure PowerShell authorization configuration.
        /// </summary>
        public static class AzurePowerShell
        {
            /// <summary>
            /// The Azure PowerShell client identifier.
            /// </summary>
            public const string ClientId = "1950a258-227b-4e31-a9cf-717495945fc2";

            /// <summary>
            /// The redirect uri which is a well-known string for native applications.
            /// </summary>
            public const string RedirectUri = AzureStackPowerShell.RedirectUri;
        }

        /// <summary>
        /// Application settings for Frontdoor authorization configuration.
        /// </summary>
        public static class ResourceManager
        {
            /// <summary>
            /// The Azure Stack Frontdoor client identifier.
            /// </summary>
            public const string ClientId = "3795ab9c-1aa9-4258-97b5-79b402cafa8c";
        }
    }
}
