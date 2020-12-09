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
    using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Management.Automation;

    // TODO (rajivnan) move strings to resources?
    [Cmdlet(
        VerbsCommon.New,
        AzureRMConstants.AzureRMPrefix + "ManagedServicesAssignment",
        DefaultParameterSetName = DefaultParameterSet,
        SupportsShouldProcess = true), OutputType(typeof(PSRegistrationAssignment))]
    public class NewAzureRmManagedServicesAssignment : ManagedServicesCmdletBase
    {
        protected const string DefaultParameterSet = "Default";
        protected const string ByInputObjectParameterSet = "ByInputObject";

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = false, HelpMessage = "The unique name of the Registration Assignment.")]
        [Parameter(ParameterSetName = ByInputObjectParameterSet, Mandatory = false, HelpMessage = "The unique name of the Registration Assignment.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = false, HelpMessage = "The scope where the registration assignment should be created.")]
        [Parameter(ParameterSetName = ByInputObjectParameterSet, Mandatory = false, HelpMessage = "The scope where the registration assignment should be created.")]
        [ScopeCompleter]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        [Parameter(ParameterSetName = ByInputObjectParameterSet, ValueFromPipeline = true, Mandatory = true, HelpMessage = "The registration definition input object.")]
        [ValidateNotNull]
        public PSRegistrationDefinition RegistrationDefinition { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "The fully qualified resource id of the registration definition.")]
        [ValidateNotNullOrEmpty]
        public string RegistrationDefinitionId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            var definitionId = String.Empty;
            var assignmentId = Guid.NewGuid().ToString();
            var scope = this.GetDefaultScope();

            if (!String.IsNullOrWhiteSpace(this.Name))
            {
                if (!this.Name.IsGuid())
                {
                    throw new ApplicationException("Name must be a valid GUID.");
                }

                assignmentId = (new Guid(this.Name)).ToString();
            }

            if (this.IsParameterBound(x => x.RegistrationDefinition))
            {
                definitionId = this.RegistrationDefinition.Id;
            }

            if (this.IsParameterBound(x => x.RegistrationDefinitionId))
            {
                definitionId = this.RegistrationDefinitionId;
            }

            if (this.IsParameterBound(x => x.Scope))
            {
                scope = this.Scope;
            }

            if (string.IsNullOrWhiteSpace(definitionId))
            {
                throw new ApplicationException("RegistrationDefinition details are required. Please provider either RegistrationDefinition or RegistrationDefinitionId parameters.");
            }

            ConfirmAction(MyInvocation.InvocationName,
                $"{scope}/providers/Microsoft.ManagedServices/registrationAssignments/{assignmentId}",
                () =>
                {
                    var result = this.PSManagedServicesClient.CreateOrUpdateRegistrationAssignment(
                        scope: scope,
                        registrationDefinitionId: definitionId,
                        registrationAssignmentId: assignmentId);

                    WriteObject(new PSRegistrationAssignment(result), true);
                });
        }
    }
}