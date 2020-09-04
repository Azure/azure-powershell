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
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Management.Automation;

    [Cmdlet(
        VerbsCommon.Remove,
        AzureRMConstants.AzureRMPrefix + "ManagedServicesAssignment",
        DefaultParameterSetName = DefaultParameterSet,
        SupportsShouldProcess = true), OutputType(typeof(void))]
    public class RemoveAzureRmManagedServcicesAssignment : ManagedServicesCmdletBase
    {
        protected const string DefaultParameterSet = "Default";
        protected const string ByInputObjectParameterSet = "ByInputObject";

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = false, HelpMessage = "The scope of the registration assignment.")]
        [ValidateNotNullOrEmpty]
        [ScopeCompleter]
        public string Scope { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The unique name of the Registration Assignment.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ByInputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The registration assignment object.")]
        [ValidateNotNull]
        public PSRegistrationAssignment InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            string scope = this.GetDefaultScope();
            string assignmentId = null;

            if (this.IsParameterBound(x => x.Name))
            {
                if (!this.Name.IsGuid())
                {
                    throw new ApplicationException("Name must be a valid GUID.");
                }

                assignmentId = (new Guid(this.Name)).ToString();
            }

            if (this.IsParameterBound(x => x.Scope))
            {
                scope = this.Scope;
            }

            if (this.IsParameterBound(x => x.InputObject))
            {
                if (!ManagedServicesUtility.TryParseAssignmentScopeFromResourceId(this.InputObject.Id, out scope) &&
                    string.IsNullOrWhiteSpace(scope))
                {
                    throw new ApplicationException($"Unable to parse the scope from [{this.InputObject.Id}].");
                }

                if (string.IsNullOrWhiteSpace(this.InputObject.Name) || !this.InputObject.Name.IsGuid())
                {
                    throw new ApplicationException("Invalid registration assignment name provided in input object.");
                }

                assignmentId = this.InputObject.Name;
            }

            ConfirmAction(MyInvocation.InvocationName,
                $"/{scope}/providers/Microsoft.ManagedServices/registrationAssignments/{assignmentId}",
                () =>
                {
                    this.PSManagedServicesClient.RemoveRegistrationAssignment(
                        scope: scope,
                        registrationAssignmentId: assignmentId);
                });
        }
    }
}