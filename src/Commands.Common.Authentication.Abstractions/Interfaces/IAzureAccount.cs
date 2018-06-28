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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// Representation of an azure account with credentials
    /// </summary>
    public interface IAzureAccount : IExtensibleModel
    {
        /// <summary>
        /// The displayable id for the account
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// The account credential
        /// </summary>
        string Credential { get; set; }

        /// <summary>
        /// The account type
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// The mapping between tenants the account has permission to access and the account identifier in each tenant
        /// </summary>
        IDictionary<string, string> TenantMap { get; }
    }
}
