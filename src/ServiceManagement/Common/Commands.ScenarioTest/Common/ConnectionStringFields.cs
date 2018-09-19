//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.Common
{
    /// <summary>
    /// Contains constant definitions for the fields that
    /// are allowed in the test connection strings.
    /// </summary>
    public static class ConnectionStringFields
    {
        /// <summary>
        /// The key inside the connection string for the management certificate
        /// </summary>
        public const string ManagementCertificate = "ManagementCertificate";

        /// <summary>
        /// The key inside the connection string for the subscription identifier
        /// </summary>
        public const string SubscriptionId = "SubscriptionId";

        /// <summary>
        /// The key inside the connection string for the base management URI
        /// </summary>
        public const string BaseUri = "BaseUri";

        /// <summary>
        /// The key inside the connection string for a microsoft ID (OrgId or LiveId)
        /// </summary>
        public const string UserId = "UserId";

        /// <summary>
        /// The key inside the connection string for a user password matchign the microsoft ID
        /// </summary>
        public const string Password = "Password";

        /// <summary>
        /// A raw JWT token for AAD authentication
        /// </summary>
        public const string RawToken = "RawToken";

        /// <summary>
        /// The client ID to use when authenticating with AAD
        /// </summary>
        public const string AADClientId = "AADClientId";

        /// <summary>
        /// ENdpoint to use for AAD authentication
        /// </summary>
        public const string AADAuthenticationEndpoint = "AADAuthEndpoint";

        /// <summary>
        /// If a tenant other than common is to be used with the subscription, specifies the tenant
        /// </summary>
        public const string AADTenant = "AADTenant";

    }
}
