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
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Advisor.Cmdlets.Models;
    using Microsoft.Azure.Commands.Advisor.Cmdlets.Utilities;
    using Microsoft.Azure.Commands.Advisor.Cmdlets.Utilities.Client;
    using Microsoft.Azure.Commands.Advisor.Properties;
    using Microsoft.Azure.Commands.Advisor.Utilities;
    using Microsoft.Azure.Management.Advisor.Models;
    using Microsoft.Rest.Azure;
    using ResourceManager.Common.ArgumentCompleters;

    /// <summary>
    /// Set-AzAdvisorConfiguration cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AdvisorConfiguration", DefaultParameterSetName = InputObjectRgExcludeParameterSet, SupportsShouldProcess = true), OutputType(typeof(PsAzureAdvisorConfigurationData))]
    public class SetAzAdvisorConfiguration : ResourceAdvisorBaseCmdlet
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
        [Parameter(ParameterSetName = InputObjectLowCpuExcludeParameterSet, Mandatory = false, Position = 2, HelpMessage = "Exclude from the recommendation generation. If not specified exclude property will be set to false.")]
        [Parameter(ParameterSetName = InputObjectRgExcludeParameterSet, Mandatory = false, Position = 2, HelpMessage = "Exclude from the recommendation generation. If not specified exclude property will be set to false.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Exclude { get; set; }

        /// <summary>
        /// Gets or sets the LowCpuThreshold.
        /// </summary>s
        [Parameter(ParameterSetName = InputObjectLowCpuExcludeParameterSet, Position = 0, Mandatory = true, HelpMessage = "Value for Low Cpu threshold.")]
        [ValidateSet("0", "5", "10", "15", "20")]
        [ValidateNotNullOrEmpty]
        public int LowCpuThreshold { get; set; }

        /// <summary>
        /// Gets or sets the include.
        /// </summary>
        [Parameter(ParameterSetName = InputObjectRgExcludeParameterSet, Mandatory = false, Position = 0, HelpMessage = "Resource Group name for the configuration.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the Object passed on from the pipeline
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 1, ParameterSetName = InputObjectLowCpuExcludeParameterSet, HelpMessage = "The powershell object type PsAzureAdvisorConfigurationData returned by Get-AzAdvisorConfiguration call.")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 1, ParameterSetName = InputObjectRgExcludeParameterSet, HelpMessage = "The powershell object type PsAzureAdvisorConfigurationData returned by Get-AzAdvisorConfiguration call.")]
        [ValidateNotNullOrEmpty]
        public PsAzureAdvisorConfigurationData InputObject { get; set; }

        /// <summary>
        /// Sets the configuration of the current subscription with the given user configuration.
        /// </summary>
        /// <param name="configData">Configuration Properties</param>
        /// <returns>List of PsAzureAdvisorConfigurationData</returns>
        internal List<PsAzureAdvisorConfigurationData> CreateConfigurationBySubscription(ConfigData configData)
        {
            List<PsAzureAdvisorConfigurationData> results = new List<PsAzureAdvisorConfigurationData>();
            ConfigurationResource configResourceClient = new ConfigurationResource();
            AzureOperationResponse<ARMErrorResponseBody> response = null;
            List<PsAzureAdvisorConfigurationData> psConfigDataList = null;

            response = this.ResourceAdvisorClient.Configurations.CreateInSubscriptionWithHttpMessagesAsync(configData).Result;
            psConfigDataList = configResourceClient.GetAllConfiguratioFromClient(this.ResourceAdvisorClient);

            foreach (PsAzureAdvisorConfigurationData entry in psConfigDataList)
            {
                if (entry.Name.Equals(this.ResourceAdvisorClient.SubscriptionId))
                {
                    results.Add(entry);
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
        internal List<PsAzureAdvisorConfigurationData> CreateConfigurationByResourceGroup(ConfigData configData, string resourceGroupName)
        {
            List<PsAzureAdvisorConfigurationData> results = new List<PsAzureAdvisorConfigurationData>();

            AzureOperationResponse<ARMErrorResponseBody> response = null;
            AzureOperationResponse<IEnumerable<ConfigData>> azureOperationResponse = null;

            response = this.ResourceAdvisorClient.Configurations.CreateInResourceGroupWithHttpMessagesAsync(configData, resourceGroupName).Result;
            azureOperationResponse = this.ResourceAdvisorClient.Configurations.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName).Result;

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
            AzureOperationResponse<IEnumerable<ConfigData>> azureOperationResponse = this.ResourceAdvisorClient.Configurations.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName).Result;

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
            ConfigurationResource configResourceClient = new ConfigurationResource();
            List<PsAzureAdvisorConfigurationData> psConfigDataList = configResourceClient.GetAllConfiguratioFromClient(this.ResourceAdvisorClient);

            foreach (PsAzureAdvisorConfigurationData entry in psConfigDataList)
            {
                if (entry.Name.Equals(this.ResourceAdvisorClient.SubscriptionId))
                {
                    returnConfigurationData = entry;
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

            WriteVerboseWithTimestamp(string.Format(Resources.ConfigurationUpdate, this.ResourceAdvisorClient.SubscriptionId));

            // Used to store type of configuration 
            bool isSubscriptionTypeConfiguration = false;
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
                        configDataProperties.Exclude = false;
                    }

                    configDataProperties.LowCpuThreshold = this.LowCpuThreshold.ToString();
                    configData.Properties = configDataProperties;

                    // If InputObject is not null, this is a piping scenario.
                    if (this.InputObject != null)
                    {
                        isSubscriptionTypeConfiguration = SuppressionHelper.IsConfigurationSubscriptionLevel(this.InputObject);
                        if (isSubscriptionTypeConfiguration)
                        {
                            if (ShouldProcess(this.ResourceAdvisorClient.SubscriptionId, string.Format(Resources.ConfigurationUpdateSubscriptionLevel, this.ResourceAdvisorClient.SubscriptionId)))
                            {
                                results = this.CreateConfigurationBySubscription(configData);
                            }
                        }
                    }
                    else
                    {
                        if (ShouldProcess(this.ResourceAdvisorClient.SubscriptionId, string.Format(Resources.ConfigurationUpdateSubscriptionLevel, this.ResourceAdvisorClient.SubscriptionId)))
                        {
                            results = this.CreateConfigurationBySubscription(configData);
                        }
                    }
                    break;

                case InputObjectRgExcludeParameterSet:
                    if (Exclude)
                    {
                        configDataProperties.Exclude = true;
                    }
                    else
                    {
                        configDataProperties.Exclude = false;
                    }

                    configData.Properties = configDataProperties;

                    // InputObject is not null, this is a piping scenario.
                    if (this.InputObject != null)
                    {
                        isResourceGroupTypeConfiguration = SuppressionHelper.IsConfigurationResourceGroupLevel(this.InputObject);
                        if (isResourceGroupTypeConfiguration)
                        {
                            string resourceGroup = RecommendationHelper.GetResourceGroupFromResourceID(this.InputObject.Id);
                            if (ShouldProcess(resourceGroup, string.Format(Resources.ConfigurationUpdateResourceGroupLevel, this.ResourceAdvisorClient.SubscriptionId, resourceGroup)))
                            {
                                results = this.CreateConfigurationByResourceGroup(configData, resourceGroup);
                            }
                        }
                        else
                        {
                            configData.Properties.LowCpuThreshold = InputObject.Properties.LowCpuThreshold;
                            if (ShouldProcess(this.ResourceAdvisorClient.SubscriptionId, string.Format(Resources.ConfigurationUpdateSubscriptionLevel, this.ResourceAdvisorClient.SubscriptionId)))
                            {
                                results = this.CreateConfigurationBySubscription(configData);
                            }
                        }
                    }
                    else
                    {
                        if (ShouldProcess(this.ResourceGroupName, string.Format(Resources.ConfigurationUpdateResourceGroupLevel, this.ResourceAdvisorClient.SubscriptionId, this.ResourceGroupName)))
                        {
                            results = this.CreateConfigurationByResourceGroup(configData, this.ResourceGroupName);
                        }
                    }
                    break;
            }

            this.WriteObject(results, true);
        }
    }
}
