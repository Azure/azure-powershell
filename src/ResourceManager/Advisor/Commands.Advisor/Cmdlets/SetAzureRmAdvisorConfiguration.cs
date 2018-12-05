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
    using System;

    /// <summary>
    /// Set-AzureRmAdvisorConfiguration cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AdvisorConfiguration", DefaultParameterSetName = LowCpuAndExcludeParameterSet), OutputType(typeof(List<PsAzureAdvisorConfigurationData>))]
    public class SetAzureRmAdvisorConfiguration : ResourceAdvisorBaseCmdlet
    {
        /// <summary>
        /// Constant for LowCpuAndIncludeParameterSet
        /// </summary>
        // public const string LowCpuAndIncludeParameterSet = "LowCPUAndIncludeParameterSet";

        /// <summary>
        /// Constant for RgAndIncludeParameterSet
        /// </summary>
        // public const string RgAndIncludeParameterSet = "RgAndIncludeParameterSet";

        /// <summary>
        /// Constant for LowCpuAndExcludeParameterSet
        /// </summary>
        public const string LowCpuAndExcludeParameterSet = "LowCpuAndExcludeParameterSet";

        /// <summary>
        /// Constant for RgAndExcludeParameterSet
        /// </summary>
        public const string RgAndExcludeParameterSet = "RgAndExcludeParameterSet";

        /// <summary>
        /// Constant for InputObjectLowCpuIncludeParameterSet
        /// </summary>
        // public const string InputObjectLowCpuIncludeParameterSet = "InputObjectLowCpuIncludeParameterSet";

        /// <summary>
        /// Constant for InputObjectLowCpuExcludeParameterSet
        /// </summary>
        public const string InputObjectLowCpuExcludeParameterSet = "InputObjectLowCpuExcludeParameterSet";

        /// <summary>
        /// Constant for InputObjectRgIncludeParameterSet
        /// </summary>
        // public const string InputObjectRgIncludeParameterSet = "InputObjectRgIncludeParameterSet";

        /// <summary>
        /// Constant for InputObjectRgExcludeParameterSet
        /// </summary>
        public const string InputObjectRgExcludeParameterSet = "InputObjectRgExcludeParameterSet";

        /// <summary>
        /// Gets or sets the Exclude.
        /// </summary>s
        [Parameter(ParameterSetName = LowCpuAndExcludeParameterSet, Mandatory = false, HelpMessage = "Exclude from the recommendation generation.")]
        [Parameter(ParameterSetName = RgAndExcludeParameterSet, Mandatory = false, HelpMessage = "Exclude from the recommendation generation.")]
        [Parameter(ParameterSetName = InputObjectLowCpuExcludeParameterSet, Mandatory = false, HelpMessage = "Exclude from the recommendation generation.")]
        [Parameter(ParameterSetName = InputObjectRgExcludeParameterSet, Mandatory = false, HelpMessage = "Exclude from the recommendation generation.")]
        [Alias("E")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Exclude { get; set; }

        /// <summary>
        /// Gets or sets the LowCpuThreshold.
        /// </summary>s
        [Parameter(ParameterSetName = LowCpuAndExcludeParameterSet, Mandatory = true, HelpMessage = "Value for Low Cpu threshold.")]
        [Parameter(ParameterSetName = InputObjectLowCpuExcludeParameterSet, Mandatory = true, HelpMessage = "Value for Low Cpu threshold.")]
        [Alias("L", "LowCpu")]
        [ValidateNotNullOrEmpty]
        public string LowCpuThreshold { get; set; }

        /// <summary>
        /// Gets or sets the include.
        /// </summary>
        [Parameter(ParameterSetName = RgAndExcludeParameterSet, Mandatory = true, HelpMessage = "Resource Group name for the configuration.")]
        [Parameter(ParameterSetName = InputObjectRgExcludeParameterSet, Mandatory = false, HelpMessage = "Resource Group name for the configuration.")]
        [Alias("Rg", "ResoureGroup")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the Object passed on from the pipeline
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = InputObjectLowCpuExcludeParameterSet)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = InputObjectRgExcludeParameterSet)]
        [ValidateNotNullOrEmpty]
        public List<PsAzureAdvisorConfigurationData> InputObject { get; set; }

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

            response = this.ResourcAdvisorclient.Configurations.CreateInSubscriptionWithHttpMessagesAsync(configData).Result;
            azureOperationResponseBySubscription = this.ResourcAdvisorclient.Configurations.ListBySubscriptionWithHttpMessagesAsync().Result;

            foreach (ConfigData entry in azureOperationResponseBySubscription.Body)
            {
                if (entry.Name.Equals(this.ResourcAdvisorclient.SubscriptionId))
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

            response = this.ResourcAdvisorclient.Configurations.CreateInResourceGroupWithHttpMessagesAsync(configData, resourceGroupName).Result;
            azureOperationResponse = this.ResourcAdvisorclient.Configurations.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName).Result;

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
        /// Checks if the LowCPUThreshold is a valid integer. Accepted values are 0,5,10,15,20.
        /// </summary>
        /// <param name="LowCPUThreshold">LowCPUThreshold value</param>
        /// <returns></returns>
        public bool ValidateLowCpuThresholdValue(int LowCPUThreshold)
        {
            if (LowCPUThreshold == 0 || LowCPUThreshold == 5 || LowCPUThreshold == 10 || LowCPUThreshold == 15 || LowCPUThreshold == 20)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            // bool include;

            //bool exclude;
            //try
            //{
            //    exclude = this.MyInvocation.BoundParameters.ContainsKey("Exclude") ? bool.Parse(this.Exclude) : false;
            //}
            //catch (Exception ex)
            //{
            //    Exception e = new Exception("User provided input for -Include (or) -Exclude is not an accpeted value. Accepted values are true (or) false.", ex);
            //    throw e;
            //}

            List<PsAzureAdvisorConfigurationData> results = new List<PsAzureAdvisorConfigurationData>();

            string lowCpuThreshold = this.MyInvocation.BoundParameters.ContainsKey("LowCpuThreshold") ? this.LowCpuThreshold : "0";
            string resourceGroupName = this.MyInvocation.BoundParameters.ContainsKey("ResourceGroupName") ? this.ResourceGroupName : string.Empty;

            try
            {
                lowCpuThreshold = int.Parse(lowCpuThreshold).ToString();
            }
            catch (Exception ex)
            {
                Exception e = new Exception("User provided input for -LowCpuThreshold is not a integer.", ex);
                throw e;
            }

            if (!ValidateLowCpuThresholdValue(int.Parse(lowCpuThreshold)))
            {
                throw new Exception("User provided input for -LowCpuThreshold is not an accpeted value. Accepted values are 0, 5, 10, 15, 20.");
            }

            ConfigData configData = new ConfigData();
            ConfigDataProperties configDataProperties = new ConfigDataProperties();

            // Used to store type of configuration 
            bool isSubsCriptionTypeConfiguration = false;
            bool isResourceGroupTypeConfiguration = false;

            switch (this.ParameterSetName)
            {
                case LowCpuAndExcludeParameterSet:
                    if (Exclude)
                    {
                        configDataProperties.Exclude = true;
                    }
                    else
                    {
                        configDataProperties.Exclude = false;
                    }

                    configDataProperties.LowCpuThreshold = lowCpuThreshold;
                    configData.Properties = configDataProperties;

                    results = this.CreateConfigurationBySubscription(configData);
                    break;

                case RgAndExcludeParameterSet:
                    if (Exclude)
                    {
                        configDataProperties.Exclude = true;
                    }
                    else
                    {
                        configDataProperties.Exclude = false;
                    }

                    configData.Properties = configDataProperties;

                    results = this.CreateConfigurationByResourceGroup(configData, this.ResourceGroupName);
                    break;

                case InputObjectLowCpuExcludeParameterSet:
                    if (Exclude)
                    {
                        configDataProperties.Exclude = true;
                    }
                    else
                    {
                        configDataProperties.Exclude = false;
                    }

                    configDataProperties.LowCpuThreshold = lowCpuThreshold;
                    configData.Properties = configDataProperties;

                    foreach (PsAzureAdvisorConfigurationData psConfigData in this.InputObject)
                    {
                        isSubsCriptionTypeConfiguration = SuppressionHelper.IsConfigurationSubscriptionLevel(psConfigData);
                        if (isSubsCriptionTypeConfiguration)
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

                    foreach (PsAzureAdvisorConfigurationData psConfigData in this.InputObject)
                    {
                        isResourceGroupTypeConfiguration = SuppressionHelper.IsConfigurationResourceGroupLevel(psConfigData);

                        if (isResourceGroupTypeConfiguration)
                        {
                            results = this.CreateConfigurationByResourceGroup(configData, RecommendationHelper.GetResourceGroupfromResoureID(psConfigData.Id));
                        }
                    }
                    break;
            }

            this.WriteObject(results);
        }
    }
}
