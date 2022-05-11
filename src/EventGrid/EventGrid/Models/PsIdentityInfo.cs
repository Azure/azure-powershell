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
using Microsoft.Azure.Management.EventGrid.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.EventGrid.Models
{
    public class PsIdentityInfo
    {
        public PsIdentityInfo(IdentityInfo identityInfo)
        {
            if(identityInfo != null)
            {
                this.IdentityType = identityInfo.Type;
                if(identityInfo.UserAssignedIdentities != null && identityInfo.UserAssignedIdentities.Count > 0)
                {
                    this.UserAssignedIdentities = new List<string>();
                    foreach (string userAssignedIdentity in identityInfo.UserAssignedIdentities.Keys)
                    {
                        UserAssignedIdentities.Add(userAssignedIdentity);
                    }
                }
            }
        }

        public string IdentityType { get; set; }

        public List<string> UserAssignedIdentities { get; set; }
    }
}
