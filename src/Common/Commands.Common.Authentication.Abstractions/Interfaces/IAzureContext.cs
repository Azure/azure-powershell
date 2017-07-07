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

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// The current target for azure powershell cmdlets
    /// </summary>
    public interface IAzureContext : IExtensibleModel
    {
        /// <summary>
        /// The account used for authentication
        /// </summary>
        IAzureAccount Account { get; set; }

        /// <summary>
        /// The targeted Active Directory Tenant
        /// </summary>
        IAzureTenant Tenant { get; set; }

        /// <summary>
        /// The targeted subscription
        /// </summary>
        IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// The targeted azure cloud
        /// </summary>
        IAzureEnvironment Environment { get; set; }

        /// <summary>
        /// The current version profile, outlining the version and capability of cmdlets
        /// </summary>
        string VersionProfile { get; set; }

        /// <summary>
        /// The cached authentication data
        /// </summary>
        IAzureTokenCache TokenCache { get; set; }
    }
}
