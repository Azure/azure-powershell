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

namespace Microsoft.Azure.Commands.Management.IotHub
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Devices;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubConfiguration", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSConfiguration))]
    public class AddAzIotHubConfiguration : IotHubBaseCmdlet
    {
        private const string ResourceIdParameterSet = "ResourceIdSet";
        private const string ResourceParameterSet = "ResourceSet";
        private const string InputObjectParameterSet = "InputObjectSet";

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = InputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "IotHub object")]
        [ValidateNotNullOrEmpty]
        public PSIotHub InputObject { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "IotHub Resource Id")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Devices/IotHubs")]
        public string ResourceId { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Name of the Resource Group")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string IotHubName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Identifier for the configuration.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Configuration for IotHub devices.")]
        [ValidateNotNullOrEmpty]
        public Hashtable DeviceContent { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Weight of the device configuration in case of competing rules (highest wins).")]
        [ValidateNotNullOrEmpty]
        public int Priority { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Target condition in which a device configuration applies to.")]
        [ValidateNotNullOrEmpty]
        public string TargetCondition { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Queries collection for configuration metrics definition.")]
        public Hashtable Metric { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Map of labels to be applied to target configuration.")]
        public Hashtable Label { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.IotHubName, Properties.Resources.AddIotHubConfiguration))
            {
                IotHubDescription iotHubDescription;
                if (ParameterSetName.Equals(InputObjectParameterSet))
                {
                    this.ResourceGroupName = this.InputObject.Resourcegroup;
                    this.IotHubName = this.InputObject.Name;
                    iotHubDescription = IotHubUtils.ConvertObject<PSIotHub, IotHubDescription>(this.InputObject);
                }
                else
                {
                    if (ParameterSetName.Equals(ResourceIdParameterSet))
                    {
                        this.ResourceGroupName = IotHubUtils.GetResourceGroupName(this.ResourceId);
                        this.IotHubName = IotHubUtils.GetIotHubName(this.ResourceId);
                    }

                    iotHubDescription = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.IotHubName);
                }

                IEnumerable<SharedAccessSignatureAuthorizationRule> authPolicies = this.IotHubClient.IotHubResource.ListKeys(this.ResourceGroupName, this.IotHubName);
                SharedAccessSignatureAuthorizationRule policy = IotHubUtils.GetPolicy(authPolicies, PSAccessRights.RegistryWrite);
                PSIotHubConnectionString psIotHubConnectionString = IotHubUtils.ToPSIotHubConnectionString(policy, iotHubDescription.Properties.HostName);
                RegistryManager registryManager = RegistryManager.CreateFromConnectionString(psIotHubConnectionString.PrimaryConnectionString);

                PSConfiguration psConfiguration = new PSConfiguration();
                psConfiguration.Id = this.Name;
                psConfiguration.Priority = this.Priority;
                psConfiguration.TargetCondition = string.IsNullOrEmpty(this.TargetCondition) ? "" : this.TargetCondition;
                psConfiguration.Labels = new Hashtable();
                psConfiguration.Metrics = new PSConfigurationMetrics() { Queries = new Hashtable(), Results = new Hashtable() };
                psConfiguration.Content = new PSConfigurationContent() { DeviceContent = new Hashtable(), ModulesContent = new Hashtable() };

                if (this.IsParameterBound(c => c.Label))
                {
                    psConfiguration.Labels = this.Label;
                }

                if (this.IsParameterBound(c => c.Metric))
                {
                    psConfiguration.Metrics.Queries = this.Metric;
                }

                if (this.IsParameterBound(c => c.DeviceContent))
                {
                    foreach (DictionaryEntry kvp in this.DeviceContent)
                    {
                        if (!Convert.ToString(kvp.Key).StartsWith("properties.desired", StringComparison.InvariantCultureIgnoreCase))
                        {
                            throw new ArgumentException("The device content key must begin with \"properties.desired\".");
                        }
                    }

                    psConfiguration.Content.DeviceContent = this.DeviceContent;
                }

                this.WriteObject(IotHubDataPlaneUtils.ToPSConfiguration(registryManager.AddConfigurationAsync(IotHubDataPlaneUtils.ToConfiguration(psConfiguration)).GetAwaiter().GetResult()));
            }
        }
    }
}
