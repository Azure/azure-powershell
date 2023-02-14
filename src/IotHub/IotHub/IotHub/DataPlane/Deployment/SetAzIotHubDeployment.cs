﻿// ----------------------------------------------------------------------------------
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

    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubDeployment", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSDeployment))]
    public class SetAzIotHubDeployment : IotHubBaseCmdlet
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

        [Parameter(Mandatory = true, HelpMessage = "Identifier for the deployment.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Weight of deployment in case of competing rules (highest wins).")]
        [ValidateNotNullOrEmpty]
        public int Priority { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Target condition in which an Edge deployment applies to.")]
        [ValidateNotNullOrEmpty]
        public string TargetCondition { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Queries collection for IoT Edge deployment metrics definition.")]
        public Hashtable Metric { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Map of labels to be applied to target deployment.")]
        public Hashtable Label { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Allows deployment object to be replaced even if it was updated since it was retrieved last time.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.IotHubName, Properties.Resources.SetIotHubConfiguration))
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

                Configuration config = registryManager.GetConfigurationAsync(this.Name).GetAwaiter().GetResult();
                if (config != null && config.Content.ModulesContent != null)
                {
                    PSDeployment psDeployment = IotHubDataPlaneUtils.ToPSDeployment(config);

                    if (this.IsParameterBound(c => c.Priority))
                    {
                        psDeployment.Priority = this.Priority;
                    }

                    if (this.IsParameterBound(c => c.TargetCondition))
                    {
                        psDeployment.TargetCondition = this.TargetCondition;
                    }

                    if (this.IsParameterBound(c => c.Label))
                    {
                        psDeployment.Labels = this.Label;
                    }

                    if (this.IsParameterBound(c => c.Metric))
                    {
                        psDeployment.Metrics.Queries = this.Metric;
                    }

                    this.WriteObject(IotHubDataPlaneUtils.ToPSDeployment(registryManager.UpdateConfigurationAsync(IotHubDataPlaneUtils.ToConfiguration(psDeployment), this.Force.IsPresent).GetAwaiter().GetResult()));
                }
                else
                {
                    throw new ArgumentException("The deployment doesn't exist.");
                }
            }
        }
    }
}
