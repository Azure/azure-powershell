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
        protected const string ByNameParameterSet = "ByName";

        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "The scope where the registration assignment is created.")]
        [Parameter(Mandatory = false, ParameterSetName = ByNameParameterSet, HelpMessage = "The scope where the registration assignment is created.")]
        [ScopeCompleter]
        public string Scope { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByNameParameterSet, HelpMessage = "The unique name of the Registration Assignment.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, HelpMessage = "Whether to include registration definition details.")]
        [Parameter(ParameterSetName = ByNameParameterSet, HelpMessage = "Whether to include registration definition details.")]
        public SwitchParameter ExpandRegistrationDefinition { get; set; }

        public override void ExecuteCmdlet()
        {
            string scope = null;
            string assignmentId = null;

            if (this.IsParameterBound(x => x.Name))
            {
                assignmentId = this.Name;
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
                this.WriteRegistrationAssignmentList(results, scope);
            }
            else
            {
                // validate assignmentId.
                if (!assignmentId.IsGuid())
                {
                    throw new ApplicationException("Name must be a valid GUID.");
                }

                var result = this.PSManagedServicesClient.GetRegistrationAssignment(
                    scope: scope,
                    registrationAssignmentId: assignmentId,
                    expandRegistrationDefinition: this.ExpandRegistrationDefinition);
                WriteObject(new PSGetRegistrationAssignment(result, scope), true);
            }
        }
    }
}