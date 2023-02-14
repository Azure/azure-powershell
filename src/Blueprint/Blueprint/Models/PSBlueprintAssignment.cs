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
        public IDictionary<string, PSParameterValue> Parameters { get; set; }
        public IDictionary<string, PSResourceGroupValue> ResourceGroups { get; set; }
        public PSAssignmentStatus Status { get; set; }
        public PSAssignmentLockSettings Locks { get; set; }
        public PSAssignmentProvisioningState ProvisioningState {get; set; }

        /// <summary>
        /// Create a PSBluprintAssignment object from an Assignment model.
        /// </summary>
        /// <param name="assignment">Assignment object from which to create the PSBlueprintAssignment.</param>
        /// <returns>A new PSBlueprintAssignment object.</returns>
        internal static PSBlueprintAssignment FromAssignment(Assignment assignment)
        {
            var psAssignment = new PSBlueprintAssignment
            {
                Name = assignment.Name,
                Id = assignment.Id,
                Type = assignment.Type,
                Location = assignment.Location,
                Scope = assignment.Scope,
                Identity = new PSManagedServiceIdentity
                {
                    PrincipalId = assignment.Identity.PrincipalId,
                    TenantId = assignment.Identity.TenantId,
                    Type = assignment.Type,
                    UserAssignedIdentities = new Dictionary<string, PSUserAssignedIdentity>()
                },
                DisplayName = assignment.DisplayName,
                Description = assignment.Description,
                BlueprintId = assignment.BlueprintId,
                ProvisioningState = PSAssignmentProvisioningState.Unknown,
                Status = new PSAssignmentStatus(),
                Locks = new PSAssignmentLockSettings
                {
                    Mode = PSLockMode.None,
                    ExcludedActions = new List<string>(),
                    ExcludedPrincipals = new List<string>()
                },
                Parameters = new Dictionary<string, PSParameterValue>(),
                ResourceGroups = new Dictionary<string, PSResourceGroupValue>()
            };

            psAssignment.Status.TimeCreated = assignment.Status.TimeCreated;

            psAssignment.Status.LastModified = assignment.Status.LastModified;

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

            if (assignment.Locks.ExcludedActions != null)
            {
                foreach (var item in assignment.Locks.ExcludedActions)
                {
                    psAssignment.Locks.ExcludedActions.Add(item);
                }
            }

            if (assignment.Locks.ExcludedPrincipals != null)
            {
                foreach (var item in assignment.Locks.ExcludedPrincipals)
                {
                    psAssignment.Locks.ExcludedPrincipals.Add(item);
                }
            }

            foreach (var item in assignment.Parameters)
            {
                PSParameterValue parameter = GetAssignmentParameters(item);
                psAssignment.Parameters.Add(item.Key, parameter);
            }

            foreach (var item in assignment.ResourceGroups)
            {
                psAssignment.ResourceGroups.Add(item.Key,
                    new PSResourceGroupValue {Name = item.Value.Name, Location = item.Value.Location});
            }

            if (assignment.Identity.UserAssignedIdentities != null)
            {
                foreach (var item in assignment.Identity.UserAssignedIdentities)
                {
                    psAssignment.Identity.UserAssignedIdentities.Add(item.Key,
                        new PSUserAssignedIdentity { ClientId = item.Value.ClientId, PrincipalId = item.Value.PrincipalId });
                }
            }

            return psAssignment;
        }

        private static PSParameterValue GetAssignmentParameters(KeyValuePair<string, ParameterValue> parameterKvp)
        {
            PSParameterValue parameter = null;

            if (parameterKvp.Value?.Value != null)
            {
                // Need to cast as ParameterValue since assignment.Parameters value type is ParameterValueBase. 
                var parameterValue = parameterKvp.Value;

                parameter = new PSParameterValue { Value = parameterValue.Value };
            }
            else if (parameterKvp.Value?.Reference != null)
            {
                var parameterValue = parameterKvp.Value;

                var secretReference = new PSSecretValueReference
                {
                    KeyVault = new PSKeyVaultReference { Id = parameterValue.Reference.KeyVault.Id },
                    SecretName = parameterValue.Reference.SecretName,
                    SecretVersion = parameterValue.Reference.SecretVersion
                };

                parameter = new PSParameterValue { Reference = secretReference };
            }

            return parameter;
        }
    }
}
