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
using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Extensions;
using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Commands
{
    // TODO (rajivnan) move strings to resources?
    [Cmdlet(
    VerbsCommon.New,
    Microsoft.Azure.Commands.ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedServicesAssignment",
    DefaultParameterSetName = DefaultParameterSet,
    SupportsShouldProcess = true), OutputType(typeof(PSRegistrationAssignment))]
    public class NewAzureRmManagedServicesAssignment : ManagedServicesCmdletBase
    {
        protected const string DefaultParameterSet = "Default";
        protected const string ByResourceIdParameterSet = "ByResourceId";
        protected const string ByInputObjectParameterSet = "ByInputObject";

        [Parameter(Position = 0, ParameterSetName = DefaultParameterSet, Mandatory = false, HelpMessage = "The scope where the registration assignment should be created.")]
        [Parameter(Position = 0, ParameterSetName = ByResourceIdParameterSet, Mandatory = false, HelpMessage = "The scope where the registration assignment should be created.")]
        [Parameter(Position = 0, ParameterSetName = ByInputObjectParameterSet, Mandatory = false, HelpMessage = "The scope where the registration assignment should be created.")]
        [ScopeCompleter]
        public string Scope { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The registration definition identifier.")]
        [ValidateNotNullOrEmpty]
        public string RegistrationDefinitionName { get; set; }

        [CmdletParameterBreakingChange(
            nameOfParameterChanging: "RegistrationDefinitionResourceId",
            deprecateByVersion: ManagedServicesUtility.UpcomingVersion,
            changeInEfectByDate: ManagedServicesUtility.UpcomingVersionReleaseDate,
            ChangeDescription = ManagedServicesUtility.DeprecatedParameterDescription)]
        [Parameter(ParameterSetName = ByResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "The fully qualified resource id of the registration definition.")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceId")]
        public string RegistrationDefinitionResourceId { get; set; }

        [Parameter(ParameterSetName = ByInputObjectParameterSet, ValueFromPipeline = true, Mandatory = true, HelpMessage = "The registration definition input object.")]
        public PSRegistrationDefinition RegistrationDefinition { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public Guid RegistrationAssignmentId { get; set; } = default(Guid);

        public override void ExecuteCmdlet()
        {
            string scope = this.GetDefaultScope();
            string definitionId = this.RegistrationDefinitionResourceId;

            if (this.IsParameterBound(x => x.RegistrationDefinitionName))
            {
                scope = this.Scope ?? this.GetDefaultScope();
                var subscriptionScope = scope.GetSubscriptionId().ToSubscriptionResourceId();

                // registation definitions can only exist at the subscription level.
                definitionId = $"{subscriptionScope}/providers/Microsoft.ManagedServices/registrationDefinitions/{this.RegistrationDefinitionName}";
            }
            else if (this.IsParameterBound(x => x.RegistrationDefinitionResourceId))
            {
                definitionId = this.RegistrationDefinitionResourceId;
                scope = this.Scope ?? definitionId.GetSubscriptionId().ToSubscriptionResourceId();
            }
            else if (this.IsParameterBound(x => x.RegistrationDefinition))
            {
                definitionId = this.RegistrationDefinition.Id;
                scope = this.Scope ?? definitionId.GetSubscriptionId().ToSubscriptionResourceId();
            }

            if (this.RegistrationAssignmentId == default(Guid))
            {
                this.RegistrationAssignmentId = Guid.NewGuid();
            }

            ConfirmAction(MyInvocation.InvocationName,
                 $"{scope}/providers/Microsoft.ManagedServices/registrationAssignments/{this.RegistrationAssignmentId}",
                () =>
                {
                    var result = this.PSManagedServicesClient.CreateOrUpdateRegistrationAssignment(
                        scope: scope,
                        registrationDefinitionId: definitionId,
                        registrationAssignmentId: this.RegistrationAssignmentId);

                    WriteObject(new PSRegistrationAssignment(result), true);
                });
        }
    }
}
