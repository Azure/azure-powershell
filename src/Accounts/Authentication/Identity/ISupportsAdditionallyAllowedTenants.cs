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
//

using System.Collections.Generic;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    internal interface ISupportsAdditionallyAllowedTenants
    {
        /// <summary>
        /// Specifies tenants in addition to the configured tenant for which the credential may acquire tokens.
        /// Add the wildcard value "*" to allow the credential to acquire tokens for any tenant the logged in account can access.
        /// If no specific tenant was configured this option will have no effect, and the credential will acquire tokens for any requested tenant.
        /// </summary>
        IList<string> AdditionallyAllowedTenants { get; }
    }
}
