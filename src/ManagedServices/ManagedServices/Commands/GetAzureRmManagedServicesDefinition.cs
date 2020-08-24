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
    DefaultParameterSetName = ByNameParameterSet), OutputType(typeof(PSRegistrationDefinition))]
    public class GetAzureRmManagedServicesDefinition : ManagedServicesCmdletBase
    {
        protected const string ByNameParameterSet = "ByName";

        [Parameter(ParameterSetName = ByNameParameterSet, Mandatory = false, HelpMessage = "The unique name of the Registration Definition.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            string definitionId = null;
            string scope = this.GetDefaultScope();

            if (this.IsParameterBound(x => x.Name))
            {
                definitionId = this.Name;
            }

            if (string.IsNullOrEmpty(definitionId))
            {
                var results = this.PSManagedServicesClient.ListRegistrationDefinitions(
                    scope: scope);
                this.WriteRegistrationDefinitionsList(results, scope);
            }
            else
            {
                // validate definitionId.
                if (!definitionId.IsGuid())
                {
                    throw new ApplicationException("Name must be a valid GUID.");
                }

                var result = this.PSManagedServicesClient.GetRegistrationDefinition(
                    scope: scope,
                    registrationDefinitionId: definitionId);
                WriteObject(new PSGetRegistrationDefinition(result, scope), true);
            }
        }
    }
}
