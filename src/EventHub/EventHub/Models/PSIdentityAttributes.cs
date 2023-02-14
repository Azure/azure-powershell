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

using Microsoft.Azure.Management.EventHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.EventHub.Models
{

    public class PSIdentityAttributes
    {
        public const string DefaultClaimType = "SharedAccessKey";
        public const string DefaultClaimValue = "None";
        internal const string DefaultNamespaceAuthorizationRule = "RootManageSharedAccessKey";

        public PSIdentityAttributes(Identity resIdentity)
        {
            if (resIdentity != null)
            {
                PrincipalId = resIdentity.PrincipalId;
                TenantId = resIdentity.TenantId;
                if (resIdentity.Type != null)
                {
                    if (resIdentity.Type == ManagedServiceIdentityType.SystemAssigned)
                    {
                        Type = IdentityType.SystemAssigned;
                    }
                }
                
            };
        }

        public string PrincipalId { get; set; }

        /// <summary>
        /// Gets or sets tenantId from the KeyVault
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// Gets or sets enumerates the possible value Identity type, which
        /// currently supports only 'SystemAssigned'. Possible values include:
        /// 'SystemAssigned'
        /// </summary>
        public IdentityType? Type { get; set; }

    }
}
