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

using Microsoft.Azure.Management.Search.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Management.Search.Models
{
    public class PSIdentity
    {
        public string PrincipalId { get; private set; }

        public string TenantId { get; private set; }

        [Ps1Xml(Label = "Type", Target = ViewControl.List, Position = 0)]
        public PSIdentityType Type { get; set; }

        public static explicit operator PSIdentity(Identity v)
        {
            PSIdentityType? identityType = (PSIdentityType?)v?.Type;

            if (identityType.HasValue)
            {
                return new PSIdentity()
                {
                    PrincipalId = v?.PrincipalId,
                    TenantId = v?.TenantId,
                    Type = identityType.Value
                };
            }
            else
            {
                return null;
            }
        }

        public static explicit operator Identity(PSIdentity v)
        {
            IdentityType? identityType = (IdentityType?)v?.Type;
            if (identityType.HasValue)
            {
                return new Identity(
                    type: identityType.Value,
                    principalId: v?.PrincipalId,
                    tenantId: v?.TenantId);
            }
            else
            {
                return null;
            }
        }
    }
}
