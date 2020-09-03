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

namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Commands
{
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Management.Automation;

    [Cmdlet(
        VerbsCommon.Get,
        Microsoft.Azure.Commands.ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedServicesAssignment",
        DefaultParameterSetName = DefaultParameterSet), OutputType(typeof(PSRegistrationAssignment))]
    public class GetAzureRmManagedServicesAssignment : ManagedServicesCmdletBase
    {
        protected const string DefaultParameterSet = "Default";
        protected const string ByResourceIdParameterSet = "ByResourceId";
        protected const string ByIdParameterSet = "ById";

        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "The scope where the registration assignment is created.")]
        [Parameter(Mandatory = false, ParameterSetName = ByIdParameterSet, HelpMessage = "The scope where the registration assignment is created.")]
        [ScopeCompleter]
        public string Scope { get; set; }

        [CmdletParameterBreakingChange(
            nameOfParameterChanging: "Id",
            deprecateByVersion: ManagedServicesUtility.UpcomingVersion,
            changeInEfectByDate: ManagedServicesUtility.UpcomingVersionReleaseDate,
            ReplaceMentCmdletParameterName = "Name")]
        [Parameter(Mandatory = true, ParameterSetName = ByIdParameterSet, HelpMessage = "The Registration Assignment identifier.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [CmdletParameterBreakingChange(
            nameOfParameterChanging: "ResourceId",
            deprecateByVersion: ManagedServicesUtility.UpcomingVersion,
            changeInEfectByDate: ManagedServicesUtility.UpcomingVersionReleaseDate,
            ChangeDescription = ManagedServicesUtility.DeprecatedParameterDescription)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByResourceIdParameterSet,
            HelpMessage = "The fully qualified resource id of registration assignment.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, HelpMessage = "Whether to include registration definition details.")]
        [Parameter(ParameterSetName = ByResourceIdParameterSet, HelpMessage = "Whether to include registration definition details.")]
        [Parameter(ParameterSetName = ByIdParameterSet, HelpMessage = "Whether to include registration definition details.")]
        public SwitchParameter ExpandRegistrationDefinition { get; set; }

        public override void ExecuteCmdlet()
        {
            string scope = null;
            string assignmentId = null;

            if (this.IsParameterBound(x => x.ResourceId))
            {
                assignmentId = this.ResourceId.GetResourceName();
                scope = this.ResourceId.GetSubscriptionId().ToSubscriptionResourceId();
            }
            else if (this.IsParameterBound(x => x.Id))
            {
                assignmentId = this.Id;
                scope = this.Scope ?? this.GetDefaultScope();
            }
            else if (this.IsParameterBound(x => x.Scope))
            {
                scope = this.Scope;
            }
            else
            {
                scope = this.GetDefaultScope();
            }

            if (string.IsNullOrEmpty(assignmentId))
            {
                var results = this.PSManagedServicesClient.ListRegistrationAssignments(
                    scope: scope,
                    expandRegistrationDefinition: this.ExpandRegistrationDefinition);
                this.WriteRegistrationAssignmentList(results);
            }
            else
            {
                // validate assignmentId.
                if (!assignmentId.IsGuid())
                {
                    throw new ApplicationException("RegistrationAssignment must be a valid GUID.");
                }

                var result = this.PSManagedServicesClient.GetRegistrationAssignment(
                    scope: scope,
                    registrationAssignmentId: assignmentId,
                    expandRegistrationDefinition: this.ExpandRegistrationDefinition);
                WriteObject(new PSRegistrationAssignment(result), true);
            }
        }
    }
}