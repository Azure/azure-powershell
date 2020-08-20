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
    VerbsCommon.Get,
    Microsoft.Azure.Commands.ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedServicesDefinition",
    DefaultParameterSetName = ByIdParameterSet), OutputType(typeof(PSRegistrationDefinition))]
    public class GetAzureRmManagedServicesDefinition : ManagedServicesCmdletBase
    {
        ////protected const string DefaultParameterSet = "Default";
        protected const string ByResourceIdParameterSet = "ByResourceId";
        protected const string ByIdParameterSet = "ById";

        [Parameter(ParameterSetName = ByIdParameterSet, Mandatory = false, HelpMessage = "The registration definition identifier.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [CmdletParameterBreakingChange(
            nameOfParameterChanging: "ResourceId",
            deprecateByVersion: ManagedServicesUtility.UpcomingVersion,
            changeInEfectByDate: ManagedServicesUtility.UpcomingVersionReleaseDate,
            ChangeDescription = ManagedServicesUtility.DeprecatedParameterDescription)]
        [Parameter(
            ParameterSetName = ByResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The full qualified resource id of registration definition.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            string definitionId = null;
            string scope = this.GetDefaultScope();

            if (this.IsParameterBound(x => x.Name))
            {
                definitionId = this.Name;
            }
            else if (this.IsParameterBound(x => x.ResourceId))
            {
                definitionId = this.ResourceId.GetResourceName();
                scope = this.ResourceId.GetSubscriptionId().ToSubscriptionResourceId();
            }

            if (string.IsNullOrEmpty(definitionId))
            {
                var results = this.PSManagedServicesClient.ListRegistrationDefinitions(
                    scope: scope);
                this.WriteRegistrationDefinitionsList(results);
            }
            else
            {
                // validate definitionId.
                if (!definitionId.IsGuid())
                {
                    throw new ApplicationException("RegistrationDefinitionId must be a valid GUID.");
                }

                var result = this.PSManagedServicesClient.GetRegistrationDefinition(
                    scope: scope,
                    registrationDefinitionId: definitionId);
                WriteObject(new PSRegistrationDefinition(result), true);
            }
        }
    }
}
