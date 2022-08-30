// ----------------------------------------------------------------------------------
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

using System.Management.Automation;
using Microsoft.Azure.Management.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSIdentity
    {
        public PSIdentity(string type, string principalId = default, string tenantId = default)
        {
            PrincipalId = principalId;
            TenantId = tenantId;
            Type = string.IsNullOrEmpty(type) ? "SystemAssigned" : type;
        }

        public PSIdentity(Identity identity)
        {
            this.PrincipalId = identity.PrincipalId;
            this.TenantId = identity.TenantId;
            this.Type = identity.Type.ToString();
        }

        public string PrincipalId { get; private set; }

        public string TenantId { get; private set; }

        public string Type { get; set; }

        public IdentityType getIdentityType()
        {
            switch (this.Type)
            {
                case "SystemAssigned":
                    return IdentityType.SystemAssigned;
                case "None":
                    return IdentityType.None;
                default:
                    throw new PSArgumentException("invalid identity type");
            }
        }

        public Identity GetIdentity()
        {
            return new Identity(this.getIdentityType(), this.PrincipalId, this.TenantId);
        }
    }
}
