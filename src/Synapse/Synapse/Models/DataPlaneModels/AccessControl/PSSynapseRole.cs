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

using Azure.Analytics.Synapse.AccessControl.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseRole
    {
        public PSSynapseRole(SynapseRoleDefinition synapseRole)
        {
            this.Id = synapseRole.Id?.ToString();
            this.Name = synapseRole.Name;
            this.IsBuiltIn = synapseRole.IsBuiltIn.Value;
            this.Description = synapseRole.Description;
            this.AvailabilityStatus = synapseRole.AvailabilityStatus;
            this.Permissions = synapseRole.Permissions;
            this.Scopes = synapseRole.Scopes;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsBuiltIn { get; set; }

        public string Description { get; set; }

        public string AvailabilityStatus { get; set; }

        public IReadOnlyList<SynapseRbacPermission> Permissions { get; set; }

        public IReadOnlyList<string> Scopes { get; set; }
    }
}
