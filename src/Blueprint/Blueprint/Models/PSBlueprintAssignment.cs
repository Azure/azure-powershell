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

using Microsoft.Azure.Management.Blueprint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Blueprint.Models
{
    public class PSBlueprintAssignment : PSAzureResourceBase
    {
        public string Location { get; set; }
        public string Scope { get; set; }
        public PSManagedServiceIdentity Identity { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string BlueprintId { get; set; }
        public IDictionary<string, PSParameterValueBase> Parameters { get; set; }
        public IDictionary<string, PSResourceGroupValue> ResourceGroups { get; set; }
        public PSAssignmentStatus Status { get; set; }
        public PSAssignmentLockSettings Locks { get; set; }
        public PSAssignmentProvisioningState ProvisioningState {get; set; }
        public List<string> ParametersDisplayList { get; set; }
        public List<string> ResourceGroupDisplayList { get; set; }

        /// <summary>
        /// Create a PSBluprintAssignment object from an Assignment model.
        /// </summary>
        /// <param name="assignment">Assignment object from which to create the PSBlueprintAssignment.</param>
        /// <param name="subscriptionId">ID of the subscription the assignment is associated with.</param>
        /// <returns>A new PSBlueprintAssignment object.</returns>
        internal static PSBlueprintAssignment FromAssignment(Assignment assignment, string scope)
        {
            var psAssignment = new PSBlueprintAssignment
            {
                Name = assignment.Name,
                Id = assignment.Id,
                Type = assignment.Type,
                Location = assignment.Location,
                Scope = scope,
                Identity = new PSManagedServiceIdentity
                {
                    PrincipalId = assignment.Identity.PrincipalId,
                    TenantId = assignment.Identity.TenantId,
                    Type = assignment.Type
                },
                DisplayName = assignment.DisplayName,
                Description = assignment.Description,
                BlueprintId = assignment.BlueprintId,
                ProvisioningState = PSAssignmentProvisioningState.Unknown,
                Status = new PSAssignmentStatus(),
                Locks = new PSAssignmentLockSettings { Mode = PSLockMode.None },
                Parameters = new Dictionary<string, PSParameterValueBase>(),
                ResourceGroups = new Dictionary<string, PSResourceGroupValue>(),
                ParametersDisplayList = new List<string>(),
                ResourceGroupDisplayList = new List<string>()
            };

            if (DateTime.TryParse(assignment.Status.TimeCreated, out DateTime timeCreated))
            {
                psAssignment.Status.TimeCreated = timeCreated;
            }
            else
            {
                psAssignment.Status.TimeCreated = null;
            }

            if (DateTime.TryParse(assignment.Status.LastModified, out DateTime lastModified))
            {
                psAssignment.Status.LastModified = lastModified;
            }
            else
            {
                psAssignment.Status.LastModified = null;
            }

            if (Enum.TryParse(assignment.ProvisioningState, true, out PSAssignmentProvisioningState state))
            {
                psAssignment.ProvisioningState = state;
            }
            else
            {
                psAssignment.ProvisioningState = PSAssignmentProvisioningState.Unknown;
            }

            if (Enum.TryParse(assignment.Locks.Mode, true, out PSLockMode lockMode))
            {
                psAssignment.Locks.Mode = lockMode;
            }
            else
            {
                psAssignment.Locks.Mode = PSLockMode.None;
            }

            foreach (var item in assignment.Parameters)
            {
                psAssignment.Parameters.Add(item.Key, new PSParameterValueBase {Description = item.Value.Description});
                psAssignment.ParametersDisplayList.Add(item.Key);
            }

            foreach (var item in assignment.ResourceGroups)
            {
                psAssignment.ResourceGroups.Add(item.Key, new PSResourceGroupValue {Name = item.Value.Name, Location = item.Value.Location});
                psAssignment.ResourceGroupDisplayList.Add(item.Key);
            }

            return psAssignment;
        }
    }
}
