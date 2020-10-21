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

    [Cmdlet(
        VerbsCommon.Get,
        AzureRMConstants.AzureRMPrefix + "ManagedServicesDefinition",
        DefaultParameterSetName = ByNameParameterSet), OutputType(typeof(PSRegistrationDefinition))]
    public class GetAzureRmManagedServicesDefinition : ManagedServicesCmdletBase
    {
        protected const string DefaultParameterSet = "Default";
        protected const string ByNameParameterSet = "ByName";

        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "The scope where the registration definition created.")]
        [Parameter(Mandatory = false, ParameterSetName = ByNameParameterSet, HelpMessage = "The scope where the registration definition created.")]
        [ValidateNotNullOrEmpty]
        [ScopeCompleter]
        public string Scope { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByNameParameterSet, HelpMessage = "The unique name of the Registration Definition.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            string definitionId = null;
            string scope = this.GetDefaultScope();

            if (this.IsParameterBound(x => x.Name))
            {
                if (!this.Name.IsGuid())
                {
                    throw new ApplicationException("Name must be a valid GUID.");
                }

                definitionId = this.Name;
            }

            if (this.IsParameterBound(x => x.Scope))
            {
                scope = this.Scope;
            }

            if (string.IsNullOrWhiteSpace(definitionId))
            {
                var results = this.PSManagedServicesClient.ListRegistrationDefinitions(
                    scope: scope);
                this.WriteRegistrationDefinitionsList(results);
            }
            else
            {
                var result = this.PSManagedServicesClient.GetRegistrationDefinition(
                    scope: scope,
                    registrationDefinitionId: definitionId);
                WriteObject(new PSRegistrationDefinition(result), true);
            }
        }
    }
}