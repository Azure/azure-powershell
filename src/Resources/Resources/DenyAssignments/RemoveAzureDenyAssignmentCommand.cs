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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.Resources.Models.Authorization;

using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Removes a deny assignment at the specified scope.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DenyAssignment",
        SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Medium,
        DefaultParameterSetName = DenyAssignmentIdParameterSet),
        OutputType(typeof(PSDenyAssignment))]
    public class RemoveAzureDenyAssignmentCommand : ResourcesBaseCmdlet
    {
        private const string DenyAssignmentIdParameterSet = "DenyAssignmentIdParameterSet";
        private const string DenyAssignmentNameAndScopeParameterSet = "DenyAssignmentNameAndScopeParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = DenyAssignmentIdParameterSet,
            HelpMessage = "Fully qualified deny assignment ID including scope, or just the GUID. " +
            "When provided as a GUID, the current subscription scope is used.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = DenyAssignmentNameAndScopeParameterSet,
            HelpMessage = "The display name of the deny assignment to remove.")]
        [ValidateNotNullOrEmpty]
        public string DenyAssignmentName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = DenyAssignmentNameAndScopeParameterSet,
            HelpMessage = "Scope of the deny assignment. In the format of relative URI.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = DenyAssignmentIdParameterSet,
            HelpMessage = "Scope of the deny assignment. In the format of relative URI.")]
        [ValidateNotNullOrEmpty]
        [ScopeCompleter]
        public string Scope { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, ParameterSetName = InputObjectParameterSet,
            HelpMessage = "Deny assignment object from Get-AzDenyAssignment.")]
        [ValidateNotNull]
        public PSDenyAssignment InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If specified, returns the deleted deny assignment.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            string denyAssignmentId;
            string scope;

            if (ParameterSetName == InputObjectParameterSet)
            {
                denyAssignmentId = InputObject.Id;
                scope = InputObject.Scope;
            }
            else if (ParameterSetName == DenyAssignmentNameAndScopeParameterSet)
            {
                // Resolve name to ID by getting the deny assignment first
                denyAssignmentId = null; // Will be resolved by AuthorizationClient
                scope = Scope;
            }
            else
            {
                denyAssignmentId = Id;
                scope = Scope;
            }

            if (!string.IsNullOrEmpty(scope))
            {
                AuthorizationClient.ValidateScope(scope, true);
            }

            string target = denyAssignmentId ?? DenyAssignmentName;

            ConfirmAction(
                Force.IsPresent,
                string.Format("Are you sure you want to remove deny assignment '{0}'?", target),
                string.Format("Removing deny assignment '{0}'", target),
                target,
                () =>
                {
                    PSDenyAssignment result = PoliciesClient.RemoveDenyAssignment(
                        denyAssignmentId,
                        DenyAssignmentName,
                        scope,
                        DefaultProfile.DefaultContext.Subscription.Id.ToString());

                    if (PassThru)
                    {
                        WriteObject(result);
                    }
                });
        }
    }
}
