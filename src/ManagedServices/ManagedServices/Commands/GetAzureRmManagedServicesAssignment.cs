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
<<<<<<< HEAD
=======
    using Microsoft.Azure.Commands.ResourceManager.Common;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Management.Automation;

    [Cmdlet(
        VerbsCommon.Get,
<<<<<<< HEAD
        Microsoft.Azure.Commands.ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedServicesAssignment",
=======
        AzureRMConstants.AzureRMPrefix + "ManagedServicesAssignment",
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        DefaultParameterSetName = DefaultParameterSet), OutputType(typeof(PSRegistrationAssignment))]
    public class GetAzureRmManagedServicesAssignment : ManagedServicesCmdletBase
    {
        protected const string DefaultParameterSet = "Default";
<<<<<<< HEAD
        protected const string ByResourceIdParameterSet = "ByResourceId";
        protected const string ByIdParameterSet = "ById";

        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "The scope where the registration assignment is created.")]
        [Parameter(Mandatory = false, ParameterSetName = ByIdParameterSet, HelpMessage = "The scope where the registration assignment is created.")]
        [ScopeCompleter]
        public string Scope { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByIdParameterSet, HelpMessage = "The Registration Assignment identifier.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

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
=======
        protected const string ByNameParameterSet = "ByName";

        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "The scope where the registration assignment created.")]
        [Parameter(Mandatory = false, ParameterSetName = ByNameParameterSet, HelpMessage = "The scope where the registration assignment created.")]
        [ValidateNotNullOrEmpty]
        [ScopeCompleter]
        public string Scope { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByNameParameterSet, HelpMessage = "The unique name of the Registration Assignment.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "Whether to include registration definition details.")]
        [Parameter(Mandatory = false, ParameterSetName = ByNameParameterSet, HelpMessage = "Whether to include registration definition details.")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public SwitchParameter ExpandRegistrationDefinition { get; set; }

        public override void ExecuteCmdlet()
        {
<<<<<<< HEAD
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
=======
            string scope = this.GetDefaultScope();
            string assignmentId = null;

            if (this.IsParameterBound(x => x.Name))
            {
                if (!this.Name.IsGuid())
                {
                    throw new ApplicationException("Name must be a valid GUID.");
                }

                assignmentId = this.Name;
            }

            if (this.IsParameterBound(x => x.Scope))
            {
                scope = this.Scope;
            }

            if (string.IsNullOrWhiteSpace(assignmentId))
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            {
                var results = this.PSManagedServicesClient.ListRegistrationAssignments(
                    scope: scope,
                    expandRegistrationDefinition: this.ExpandRegistrationDefinition);
                this.WriteRegistrationAssignmentList(results);
            }
            else
            {
<<<<<<< HEAD
                // validate assignmentId.
                if (!assignmentId.IsGuid())
                {
                    throw new ApplicationException("RegistrationAssignment must be a valid GUID.");
                }

=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                var result = this.PSManagedServicesClient.GetRegistrationAssignment(
                    scope: scope,
                    registrationAssignmentId: assignmentId,
                    expandRegistrationDefinition: this.ExpandRegistrationDefinition);
                WriteObject(new PSRegistrationAssignment(result), true);
            }
        }
    }
}