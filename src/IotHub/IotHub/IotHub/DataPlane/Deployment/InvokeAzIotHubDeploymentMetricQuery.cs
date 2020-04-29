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
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Devices;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubDeploymentMetricsQuery", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true)]
    [Alias("Invoke-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubDeployMetric")]
    [OutputType(typeof(PSConfigurationMetricsResult))]
    public class InvokeAzIotHubDeploymentMetricsQuery : IotHubBaseCmdlet
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

        [Parameter(Mandatory = true, HelpMessage = "Target metric for evaluation.")]
        [ValidateNotNullOrEmpty]
        public string MetricName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indicates which metric collection should be used to lookup a metric.")]
        [ValidateNotNullOrEmpty]
        public PSConfigurationMetricType MetricType { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.IotHubName, Properties.Resources.InvokeIotHubConfigurationMetricsQuery))
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
                    Hashtable queries;
                    string metricKey = this.MetricName;
                    if (this.MetricType.Equals(PSConfigurationMetricType.System))
                    {
                        if (this.MetricName.Equals("targeted", StringComparison.OrdinalIgnoreCase))
                        {
                            metricKey = "targetedCount";
                        }

                        if (this.MetricName.Equals("applied", StringComparison.OrdinalIgnoreCase))
                        {
                            metricKey = "appliedCount";
                        }

                        if (this.MetricName.Equals("reporting success", StringComparison.OrdinalIgnoreCase))
                        {
                            metricKey = "reportedSuccessfulCount";
                        }

                        if (this.MetricName.Equals("reporting failure", StringComparison.OrdinalIgnoreCase))
                        {
                            metricKey = "reportedFailedCount";
                        }

                        queries = psDeployment.SystemMetrics.Queries;
                    }
                    else
                    {
                        queries = psDeployment.Metrics.Queries;
                    }

                    if (queries.ContainsKey(metricKey))
                    {
                        PSConfigurationMetricsResult psConfigurationMetricsResult = new PSConfigurationMetricsResult();
                        psConfigurationMetricsResult.Name = this.MetricName;
                        psConfigurationMetricsResult.Criteria = queries[metricKey].ToString();
                        IQuery metricQuery = registryManager.CreateQuery(queries[metricKey].ToString());
                        psConfigurationMetricsResult.Result = metricQuery.GetNextAsJsonAsync().GetAwaiter().GetResult().ToList();
                        this.WriteObject(psConfigurationMetricsResult);
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("The metric '{0}' is not defined in the deployment '{1}'", this.MetricName, this.Name));
                    }
                }
                else
                {
                    throw new ArgumentException("The deployment doesn't exist.");
                }
            }
        }
    }
}
