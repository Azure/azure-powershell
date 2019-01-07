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

namespace Microsoft.Azure.Commands.Advisor.Cmdlets
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Advisor.Cmdlets.Models;
    using Microsoft.Azure.Commands.Advisor.Utilities;
    using Microsoft.Azure.Management.Advisor.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Rest.Azure;
    using Microsoft.Azure.Commands.Advisor.Cmdlets.Utilities.Client;

    /// <summary>
    /// Get-AzAdvisorConfiguration cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AdvisorConfiguration", DefaultParameterSetName = "RgParameterSet"),
        OutputType(typeof(PsAzureAdvisorConfigurationData))]
    public class GetAzAdvisorConfiguration : ResourceAdvisorBaseCmdlet
    {
        public const string RgParameterSet = "RgParameterSet";

        /// <summary>
        /// Gets or sets the resource-group name.
        /// </summary>
        [Parameter(ParameterSetName = RgParameterSet, Mandatory = false, HelpMessage = "Resource Group name of the configuration ")]
        [ResourceGroupCompleter]
        public string ResourceGroupName
        {
            get;
            set;
        }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ConfigurationResource configResourceClient = new ConfigurationResource();
            IEnumerable<ConfigData> responseData = null;
            List<PsAzureAdvisorConfigurationData> returnPsConfigData = new List<PsAzureAdvisorConfigurationData>();

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                returnPsConfigData = configResourceClient.GetAllConfiguratioFromClient(this.ResourceAdvisorClient);
            }
            else
            {
                responseData = this.ResourceAdvisorClient.Configurations.ListByResourceGroupWithHttpMessagesAsync(this.ResourceGroupName).Result.Body;

                // Parse the response data from the API to PS object
                foreach (ConfigData configData in responseData)
                {
                    returnPsConfigData.Add(PsAzureAdvisorConfigurationData.GetFromConfigurationData(configData));
                }
            }

            this.WriteObject(returnPsConfigData, true);
        }
    }
}