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

using System;
using Microsoft.Azure.Management.Logic.Models;

namespace Microsoft.Azure.Commands.LogicApp.Cmdlets
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.LogicApp.Utilities;

    /// <summary>
    /// Gets the integration account callback URL. 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntegrationAccountCallbackUrl"), OutputType(typeof (object))]
    public class GetAzureIntegrationAccountCallbackUrlCommand : LogicAppBaseCmdlet
    {

        #region Input Parameters

        [Parameter(Mandatory = true, HelpMessage = "The integration account resource group name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account name.",
            ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account callback URL expiry time.")]
        [ValidateNotNullOrEmpty]
        public DateTime? NotAfter { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the get integration account callback URL command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            this.WriteObject(
                IntegrationAccountClient.GetIntegrationAccountCallbackUrl(this.ResourceGroupName, this.Name,
                    (NotAfter != null)
                        ? new ListCallbackUrlParameters
                        {
                            NotAfter = NotAfter
                        }
                        : new ListCallbackUrlParameters()), true);
        }
    }
}