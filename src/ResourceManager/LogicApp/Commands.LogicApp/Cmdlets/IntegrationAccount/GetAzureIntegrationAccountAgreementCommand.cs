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

namespace Microsoft.Azure.Commands.LogicApp.Cmdlets
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using ResourceManager.Common.ArgumentCompleters;

    /// <summary>
    /// Gets the integration account agreement by name 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntegrationAccountAgreement")]
    [OutputType(typeof(IntegrationAccountAgreement), typeof(IList<IntegrationAccountAgreement>))]
    public class GetAzureIntegrationAccountAgreementCommand : LogicAppBaseCmdlet
    {

        #region Input Parameters

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The integration account resource group name.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the integration account name.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The integration account name.")]
        [ValidateNotNullOrEmpty]
        [Alias("IntegrationAccountName", "ResourceName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the agreement name.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The integration account agreement name.")]
        [ValidateNotNullOrEmpty]
        public string AgreementName { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the get integration account agreement command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (string.IsNullOrEmpty(this.AgreementName))
            {
                this.WriteObject(this.IntegrationAccountClient.ListIntegrationAccountAgreements(this.ResourceGroupName, this.Name), true);
            }
            else
            {
                this.WriteObject(this.IntegrationAccountClient.GetIntegrationAccountAgreement(this.ResourceGroupName, this.Name, this.AgreementName), true);
            }
        }
    }
}