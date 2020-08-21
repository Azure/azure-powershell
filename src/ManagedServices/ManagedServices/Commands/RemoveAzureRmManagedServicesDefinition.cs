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

using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Extensions;
using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Commands
{
    [Cmdlet(
    VerbsCommon.Remove,
    Microsoft.Azure.Commands.ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedServicesDefinition",
    DefaultParameterSetName = DefaultParameterSet,
    SupportsShouldProcess = true), OutputType(typeof(void))]

    public class RemoveAzureRmManagedServicesDefinition : ManagedServicesCmdletBase
    {
        protected const string DefaultParameterSet = "Default";
        protected const string ByInputObjectParameterSet = "ByInputObject";
        protected const string ByResourceIdParameterSet = "ByResourceId";

        [CmdletParameterBreakingChange(
            nameOfParameterChanging: "Id",
            deprecateByVersion: ManagedServicesUtility.UpcomingVersion,
            changeInEfectByDate: ManagedServicesUtility.UpcomingVersionReleaseDate,
            ReplaceMentCmdletParameterName = "Name")]
        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The registration definition identifier.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [CmdletParameterBreakingChange(
            nameOfParameterChanging: "ResourceId",
            deprecateByVersion: ManagedServicesUtility.UpcomingVersion,
            changeInEfectByDate: ManagedServicesUtility.UpcomingVersionReleaseDate,
            ChangeDescription = ManagedServicesUtility.DeprecatedParameterDescription)]
        [Parameter(ParameterSetName = ByResourceIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The full qualified resource id of registration definition.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ByInputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The registration definition object.")]
        [ValidateNotNull]
        public PSRegistrationDefinition InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            string scope = null;
            string definitionId = null;
            if (this.IsParameterBound(x => x.Id))
            {
                scope = this.GetDefaultScope();
                definitionId = this.Id;
            }
            else if (this.IsParameterBound(x => x.InputObject))
            {
                definitionId = this.InputObject.Id.GetResourceName();
                if(!ManagedServicesUtility.TryParseDefinitionScopeFromResourceId(this.InputObject.Id, out scope))
                {
                    throw new ApplicationException($"Unable to parse the scope from [{this.InputObject.Id}]");
                }
            }
            else if (this.IsParameterBound(x => x.ResourceId))
            {
                definitionId = this.ResourceId.GetResourceName();
                if (!ManagedServicesUtility.TryParseDefinitionScopeFromResourceId(this.ResourceId, out scope))
                {
                    throw new ApplicationException($"Unable to parse the scope from [{this.ResourceId}]");
                }
            }

            ConfirmAction(MyInvocation.InvocationName,
                $"/{scope}/providers/Microsoft.ManagedServices/registrationDefinitions{definitionId}",
                () =>
                {
                    this.PSManagedServicesClient.RemoveRegistrationDefinition(
                        scope: scope,
                        registrationDefinitionId: definitionId);
                });
        }
    }
}
