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

namespace Microsoft.Azure.Commands.ResourceGraph.Cmdlets
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using Advisor.Cmdlets.Models;
    using Advisor.Cmdlets.Utilities;
    using Advisor.Utilities;
    using Microsoft.Azure.Management.Advisor.Models;
    using Microsoft.Rest.Azure;
    using Management.Internal.Resources.Utilities.Models;

    /// <summary>
    /// Set-AzureRmAdvisorConfiguration cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AdvisorConfiguration", DefaultParameterSetName = InputObjectLowCpuExcludeParameterSet), OutputType(typeof(List<PsAzureAdvisorConfigurationData>))]
    public class SetAzureRmAdvisorConfiguration : ResourceAdvisorBaseCmdlet
    {
        /// <summary>
        /// Constant for InputObjectLowCpuExcludeParameterSet
        /// </summary>
        public const string InputObjectLowCpuExcludeParameterSet = "InputObjectLowCpuExcludeParameterSet";

        /// <summary>
        /// Constant for InputObjectRgExcludeParameterSet
        /// </summary>
        public const string InputObjectRgExcludeParameterSet = "InputObjectRgExcludeParameterSet";

        /// <summary>
        /// Gets or sets the Exclude.
        /// </summary>s
        [Parameter(ParameterSetName = InputObjectLowCpuExcludeParameterSet, Mandatory = false, Position = 2, HelpMessage = "Exclude from the recommendation generation.")]
        [Parameter(ParameterSetName = InputObjectRgExcludeParameterSet, Mandatory = false, Position = 2, HelpMessage = "Exclude from the recommendation generation.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Exclude { get; set; }

        /// <summary>
        /// Gets or sets the LowCpuThreshold.
        /// </summary>s
        [Parameter(ParameterSetName = InputObjectLowCpuExcludeParameterSet, Position = 0, Mandatory = true, HelpMessage = "Value for Low Cpu threshold.")]
        [Alias("LowCpu")]
        [ValidateSet("0", "5", "10", "15", "20")]
        [ValidateNotNullOrEmpty]
        public string LowCpuThreshold { get; set; }

        /// <summary>
        /// Gets or sets the include.
        /// </summary>
        [Parameter(ParameterSetName = InputObjectRgExcludeParameterSet, Mandatory = false, Position = 0, HelpMessage = "Resource Group name for the configuration.")]
        [Alias("Rg", "ResoureGroup")]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the Object passed on from the pipeline
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 1, ParameterSetName = InputObjectLowCpuExcludeParameterSet, HelpMessage = "The powershell object type PsAzureAdvisorConfigurationData returned by Get-AzureRmAdvisorConfiguration call.")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 1, ParameterSetName = InputObjectRgExcludeParameterSet, HelpMessage = "The powershell object type PsAzureAdvisorConfigurationData returned by Get-AzureRmAdvisorConfiguration call.")]
        [ValidateNotNullOrEmpty]
        public PsAzureAdvisorConfigurationData InputObject { get; set; }

        /// <summary>
        /// Sets the configuration of the current subscription with the given user configuration.
        /// </summary>
        /// <param name="configData">Configuration Properties</param>
        /// <returns>List of PsAzureAdvisorConfigurationData</returns>
        public List<PsAzureAdvisorConfigurationData> CreateConfigurationBySubscription(ConfigData configData)
        {
            List<PsAzureAdvisorConfigurationData> results = new List<PsAzureAdvisorConfigurationData>();

            AzureOperationResponse<ARMErrorResponseBody> response = null;
            AzureOperationResponse<IPage<ConfigData>> azureOperationResponseBySubscription = null;

            response = this.ResourcAdvisorClient.Configurations.CreateInSubscriptionWithHttpMessagesAsync(configData).Result;
            azureOperationResponseBySubscription = this.ResourcAdvisorClient.Configurations.ListBySubscriptionWithHttpMessagesAsync().Result;

            foreach (ConfigData entry in azureOperationResponseBySubscription.Body)
            {
                if (entry.Name.Equals(this.ResourcAdvisorClient.SubscriptionId))
                {
                    results.Add(PsAzureAdvisorConfigurationData.GetFromConfigurationData(entry));
                }
            }

            return results;
        }

        /// <summary>
        /// Sets the configuration of the current subscription with the given user configuration.
        /// </summary>
        /// <param name="configData">Configuration Properties</param>
        /// <param name="resourceGroupName">Name of the resourceGroup</param>
        /// <returns>List of PsAzureAdvisorConfigurationData</returns>
        public List<PsAzureAdvisorConfigurationData> CreateConfigurationByResourceGroup(ConfigData configData, string resourceGroupName)
        {
            List<PsAzureAdvisorConfigurationData> results = new List<PsAzureAdvisorConfigurationData>();

            AzureOperationResponse<ARMErrorResponseBody> response = null;
            AzureOperationResponse<IEnumerable<ConfigData>> azureOperationResponse = null;

            response = this.ResourcAdvisorClient.Configurations.CreateInResourceGroupWithHttpMessagesAsync(configData, resourceGroupName).Result;
            azureOperationResponse = this.ResourcAdvisorClient.Configurations.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName).Result;

            foreach (ConfigData entry in azureOperationResponse.Body)
            {
                if (entry.Id.Contains("-" + resourceGroupName))
                {
                    results.Add(PsAzureAdvisorConfigurationData.GetFromConfigurationData(entry));
                }
            }

            return results;
        }

        /// <summary>
        /// Get the PsAzureAdvisorConfigurationData for the given resource-group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name</param>
        /// <returns>A PsAzureAdvisorConfigurationData</returns>
        private PsAzureAdvisorConfigurationData GetConfigurationDataForResourceGroup(string resourceGroupName)
        {
            PsAzureAdvisorConfigurationData returnConfigurationData = null;
            AzureOperationResponse<IEnumerable<ConfigData>> azureOperationResponse = this.ResourcAdvisorClient.Configurations.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName).Result;

            foreach (ConfigData entry in azureOperationResponse.Body)
            {
                if (entry.Id.Contains("-" + resourceGroupName))
                {
                    // We will have only one configruation for the given RG name
                    returnConfigurationData = PsAzureAdvisorConfigurationData.GetFromConfigurationData(entry);
                }
            }

            return returnConfigurationData;
        }

        /// <summary>
        /// Get the PsAzureAdvisorConfigurationData for the current subscription.
        /// </summary>
        /// <returns>A PsAzureAdvisorConfigurationData</returns>
        private PsAzureAdvisorConfigurationData GetConfigurationDataForCurrentSubscription()
        {
            PsAzureAdvisorConfigurationData returnConfigurationData = null;
            AzureOperationResponse<IPage<ConfigData>> azureOperationResponse = this.ResourcAdvisorClient.Configurations.ListBySubscriptionWithHttpMessagesAsync().Result;

            foreach (ConfigData entry in azureOperationResponse.Body)
            {
                if (entry.Name.Equals(this.ResourcAdvisorClient.SubscriptionId))
                {
                    returnConfigurationData = PsAzureAdvisorConfigurationData.GetFromConfigurationData(entry);
                }
            }

            return returnConfigurationData;
        }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            List<PsAzureAdvisorConfigurationData> results = new List<PsAzureAdvisorConfigurationData>();

            ConfigData configData = new ConfigData();
            ConfigDataProperties configDataProperties = new ConfigDataProperties();

            // Used to store type of configuration 
            bool isSubsCriptionTypeConfiguration = false;
            bool isResourceGroupTypeConfiguration = false;

            switch (this.ParameterSetName)
            {
                case InputObjectLowCpuExcludeParameterSet:
                    if (Exclude)
                    {
                        configDataProperties.Exclude = true;
                    }
                    else
                    {
                        PsAzureAdvisorConfigurationData configurationData = this.GetConfigurationDataForCurrentSubscription();
                        configDataProperties.Exclude = configurationData.Properties.Exclude;
                    }

                    configDataProperties.LowCpuThreshold = this.LowCpuThreshold;
                    configData.Properties = configDataProperties;

                    // If InputObject is not null, this is a piping scenario.
                    if (this.InputObject != null)
                    {
                        isSubsCriptionTypeConfiguration = SuppressionHelper.IsConfigurationSubscriptionLevel(this.InputObject);
                        if (isSubsCriptionTypeConfiguration)
                        {
                            results = this.CreateConfigurationBySubscription(configData);
                        }
                    }
                    else
                    {
                        results = this.CreateConfigurationBySubscription(configData);
                    }
                    break;

                case InputObjectRgExcludeParameterSet:
                    if (Exclude)
                    {
                        configDataProperties.Exclude = true;
                    }
                    else
                    {
                        // Get the exisiting configrationData for the resource-group and assign the exclude property to preserve existing data.
                        PsAzureAdvisorConfigurationData configurationData = this.GetConfigurationDataForResourceGroup(this.ResourceGroupName);
                        configDataProperties.Exclude = configurationData.Properties.Exclude;
                    }

                    configData.Properties = configDataProperties;

                    // InputObject is not null, this is a piping scenario.
                    if (this.InputObject != null)
                    {
                        isResourceGroupTypeConfiguration = SuppressionHelper.IsConfigurationResourceGroupLevel(this.InputObject);
                        if (isResourceGroupTypeConfiguration)
                        {
                            results = this.CreateConfigurationByResourceGroup(configData, RecommendationHelper.GetResourceGroupfromResoureID(this.InputObject.Id));
                        }
                    }
                    else
                    {
                        results = this.CreateConfigurationByResourceGroup(configData, this.ResourceGroupName);
                    }
                    break;
            }

            this.WriteObject(results, true);
        }
    }
}
