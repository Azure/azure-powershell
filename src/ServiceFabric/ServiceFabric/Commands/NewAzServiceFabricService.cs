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
using System.Collections;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json.Linq;

using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzurePrefix + "ServiceFabricService", SupportsShouldProcess = true, DefaultParameterSetName = StatelessSingleton), OutputType(typeof(PSService))]
    public class NewAzServiceFabricService : ProxyResourceCmdletBase
    {
        private const string StatelessSingleton = "Stateless-Singleton";
        private const string StatelessUniformInt64 = "Stateless-UniformInt64Range";
        private const string StatelessNamed = "Stateless-Named";
        private const string StatefulSingleton = "Stateful-Singleton";
        private const string StatefulUniformInt64 = "Stateful-UniformInt64Range";
        private const string StatefulNamed = "Stateful-Named";

        #region common required params

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = StatelessSingleton,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = StatelessUniformInt64,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = StatelessNamed,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = StatefulSingleton,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = StatefulUniformInt64,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = StatefulNamed,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = StatelessSingleton,
            HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = StatelessUniformInt64,
            HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = StatelessNamed,
            HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = StatefulSingleton,
            HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = StatefulUniformInt64,
            HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = StatefulNamed,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter("Microsoft.ServiceFabric/clusters", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = StatelessSingleton,
            HelpMessage = "Specify the name of the application.")]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = StatelessUniformInt64,
            HelpMessage = "Specify the name of the application.")]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = StatelessNamed,
            HelpMessage = "Specify the name of the application.")]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = StatefulSingleton,
            HelpMessage = "Specify the name of the application.")]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = StatefulUniformInt64,
            HelpMessage = "Specify the name of the application.")]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = StatefulNamed,
            HelpMessage = "Specify the name of the application.")]
        [ValidateNotNullOrEmpty()]
        public string ApplicationName { get; set; }

        [Parameter(Mandatory = true, Position = 3, ParameterSetName = StatelessSingleton,
            HelpMessage = "Specify the name of the service.")]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = StatelessUniformInt64,
            HelpMessage = "Specify the name of the service.")]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = StatelessNamed,
            HelpMessage = "Specify the name of the service.")]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = StatefulSingleton,
            HelpMessage = "Specify the name of the service.")]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = StatefulUniformInt64,
            HelpMessage = "Specify the name of the service.")]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = StatefulNamed,
            HelpMessage = "Specify the name of the service.")]
        [ValidateNotNullOrEmpty()]
        [Alias("ServiceName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = StatelessSingleton,
            HelpMessage = "Specify the service type name of the application, should exist in the application manifest.")]
        [Parameter(Mandatory = true, ParameterSetName = StatelessUniformInt64,
            HelpMessage = "Specify the service type name of the application, should exist in the application manifest.")]
        [Parameter(Mandatory = true, ParameterSetName = StatelessNamed,
            HelpMessage = "Specify the service type name of the application, should exist in the application manifest.")]
        [Parameter(Mandatory = true, ParameterSetName = StatefulSingleton,
            HelpMessage = "Specify the service type name of the application, should exist in the application manifest.")]
        [Parameter(Mandatory = true, ParameterSetName = StatefulUniformInt64,
            HelpMessage = "Specify the service type name of the application, should exist in the application manifest.")]
        [Parameter(Mandatory = true, ParameterSetName = StatefulNamed,
            HelpMessage = "Specify the service type name of the application, should exist in the application manifest.")]
        [ValidateNotNullOrEmpty()]
        [Alias("ServiceType")]
        public string Type { get; set; }

        #endregion

        #region Stateless params

        [Parameter(Mandatory = true, ParameterSetName = StatelessSingleton,
            HelpMessage = "Use for stateless service")]
        [Parameter(Mandatory = true, ParameterSetName = StatelessUniformInt64,
            HelpMessage = "Use for stateless service")]
        [Parameter(Mandatory = true, ParameterSetName = StatelessNamed,
            HelpMessage = "Use for stateless service")]
        public SwitchParameter Stateless { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = StatelessSingleton,
            HelpMessage = "Specify the instance count for the service")]
        [Parameter(Mandatory = true, ParameterSetName = StatelessUniformInt64,
            HelpMessage = "Specify the instance count for the service")]
        [Parameter(Mandatory = true, ParameterSetName = StatelessNamed,
            HelpMessage = "Specify the instance count for the service")]
        [ValidateNotNullOrEmpty()]
        [ValidateRange(-1, int.MaxValue)]
        public int InstanceCount { get; set; }

        #endregion

        #region Stateful params

        [Parameter(Mandatory = true, ParameterSetName = StatefulSingleton,
            HelpMessage = "Use for stateful service")]
        [Parameter(Mandatory = true, ParameterSetName = StatefulUniformInt64,
            HelpMessage = "Use for stateful service")]
        [Parameter(Mandatory = true, ParameterSetName = StatefulNamed,
            HelpMessage = "Use for stateful service")]
        public SwitchParameter Stateful { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = StatefulSingleton,
            HelpMessage = "Specify the target replica set size for the service")]
        [Parameter(Mandatory = true, ParameterSetName = StatefulUniformInt64,
            HelpMessage = "Specify the target replica set size for the service")]
        [Parameter(Mandatory = true, ParameterSetName = StatefulNamed,
            HelpMessage = "Specify the target replica set size for the service")]
        [ValidateNotNullOrEmpty()]
        [ValidateRange(1, int.MaxValue)]
        public int TargetReplicaSetSize { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = StatefulSingleton,
            HelpMessage = "Specify the min replica set size for the service")]
        [Parameter(Mandatory = true, ParameterSetName = StatefulUniformInt64,
            HelpMessage = "Specify the min replica set size for the service")]
        [Parameter(Mandatory = true, ParameterSetName = StatefulNamed,
            HelpMessage = "Specify the min replica set size for the service")]
        [ValidateNotNullOrEmpty()]
        [ValidateRange(1, int.MaxValue)]
        public int MinReplicaSetSize { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = StatefulSingleton,
            HelpMessage = "Specify the replica restart wait duration for the service")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulUniformInt64,
            HelpMessage = "Specify the replica restart wait duration for the service")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulNamed,
            HelpMessage = "Specify the replica restart wait duration for the service")]
        [ValidateNotNullOrEmpty()]
        public TimeSpan ReplicaRestartWaitDuration { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = StatefulSingleton,
            HelpMessage = "Specify the quorum loss wait duration for the service")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulUniformInt64,
            HelpMessage = "Specify the quorum loss wait duration for the service")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulNamed,
            HelpMessage = "Specify the quorum loss wait duration for the service")]
        [ValidateNotNullOrEmpty()]
        public TimeSpan QuorumLossWaitDuration { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = StatefulSingleton,
            HelpMessage = "Specify the stand by replica duration for the service")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulUniformInt64,
            HelpMessage = "Specify the stand by replica duration for the service")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulNamed,
            HelpMessage = "Specify the stand by replica duration for the service")]
        [ValidateNotNullOrEmpty()]
        public TimeSpan StandByReplicaKeepDuration { get; set; }

        #endregion

        #region common optional params

        [Parameter(Mandatory = false, ParameterSetName = StatelessSingleton,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessUniformInt64,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessNamed,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulSingleton,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulUniformInt64,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulNamed,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [ValidateNotNullOrEmpty()]
        public MoveCostEnum DefaultMoveCost { get; set; }
        
        #region partition params

        [Parameter(Mandatory = true, ParameterSetName = StatelessSingleton,
            HelpMessage = "Indicates that the service uses the singleton partition scheme. Singleton partitions are typically used when the service does not require any additional routing.")]
        [Parameter(Mandatory = true, ParameterSetName = StatefulSingleton,
            HelpMessage = "Indicates that the service uses the singleton partition scheme. Singleton partitions are typically used when the service does not require any additional routing.")]
        [ValidateNotNullOrEmpty()]
        public SwitchParameter PartitionSchemeSingleton { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = StatelessUniformInt64,
            HelpMessage = "Indicates that the service uses the UniformInt64 partition scheme. This means that each partition owns a range of int64 keys.")]
        [Parameter(Mandatory = true, ParameterSetName = StatefulUniformInt64,
            HelpMessage = "Indicates that the service uses the UniformInt64 partition scheme. This means that each partition owns a range of int64 keys.")]
        [ValidateNotNullOrEmpty()]
        public SwitchParameter PartitionSchemeUniformInt64 { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = StatelessNamed,
            HelpMessage = "Indicates that the service uses the named partition scheme. Services using this model usually have data that can be bucketed, within a bounded set. Some common examples of data fields used as named partition keys would be regions, postal codes, customer groups, or other business boundaries.")]
        [Parameter(Mandatory = true, ParameterSetName = StatefulNamed,
            HelpMessage = "Indicates that the service uses the named partition scheme. Services using this model usually have data that can be bucketed, within a bounded set. Some common examples of data fields used as named partition keys would be regions, postal codes, customer groups, or other business boundaries.")]
        [ValidateNotNullOrEmpty()]
        public SwitchParameter PartitionSchemeNamed { get; set; }

        #endregion

        #endregion


        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.ResourceGroupName, action: string.Format("Create new Service. name {0} in application: {1}, cluster {2}", this.Name, this.ApplicationName, this.ClusterName)))
            {
                try
                {
                    if (!this.Name.StartsWith(this.ApplicationName))
                    {
                        throw new PSInvalidOperationException(string.Format("Invalid service name, the application name must be a prefix of the service name, for example: '{0}'", $"{this.ApplicationName}~{this.Name}"));
                    }

                    var service = CreateService();
                    WriteObject(new PSService(service), false);
                }
                catch (ErrorModelException ex)
                {
                    PrintSdkExceptionDetail(ex);
                    throw;
                }
            }
        }

        private ServiceResource CreateService()
        {
            var service = SafeGetResource(() =>
                this.SFRPClient.Services.Get(
                    this.ResourceGroupName,
                    this.ClusterName,
                    this.ApplicationName,
                    this.Name),
                false);

            if (service != null)
            {
                WriteVerbose(string.Format("Service '{0}' already exists.", this.Name));
                return service;
            }

            WriteVerbose(string.Format("Creating service '{0}'", this.Name));

            var assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (RunningTest)
            {
                assemblyFolder = AppDomain.CurrentDomain.BaseDirectory;
            }

            string serviceTemplateDirectory = Path.Combine(assemblyFolder, Constants.ServiceTemplateRelativePath);

            string serviceTemplateFile = Path.Combine(serviceTemplateDirectory, Constants.TemplateFileName);
            string serviceParameterFile = Path.Combine(serviceTemplateDirectory, Constants.ParameterFileName);
            var deployment = CreateBasicDeployment(DeploymentMode.Incremental, serviceTemplateFile, serviceParameterFile);
            SetParameters(deployment.Properties.Template as JObject, deployment.Properties.Parameters as JObject);

            var deploymentName = Regex.Replace(string.Format("AzPSService-{0}", this.Name), @"[^-\w\._\(\)]", "");
            var validateResult = this.ResourceManagerClient.Deployments.Validate(
                ResourceGroupName,
                deploymentName,
                deployment);
            
            return WaitForDeployment(deployment, deploymentName);
        }

        protected string GetServiceProvisioningStatus()
        {
            var resource = SafeGetResource(() =>
                this.SFRPClient.Services.Get(
                    this.ResourceGroupName,
                    this.ClusterName,
                    this.ApplicationName,
                    this.Name),
                true);

            if (resource != null)
            {
                return resource.ProvisioningState;
            }

            return null;
        }

        private JObject SetParameters(JObject template, JObject parameters)
        {
            SetParameter(ref parameters, "clusterName", this.ClusterName);
            SetParameter(ref parameters, "applicationName", this.ApplicationName);
            SetParameter(ref parameters, "serviceName", this.Name);

            SetServiceParameter(template, parameters, "serviceTypeName", this.Type);
            SetServiceParameter(template, parameters, "partitionDescription", JObject.Parse($"{{\"partitionScheme\":\"{ParameterSetName.Split('-')[1]}\"}}"));

            if (this.Stateless.IsPresent)
            {
                SetServiceParameter(template, parameters, "instanceCount", this.InstanceCount);
            }
            else
            {
                SetServiceParameter(template, parameters, "targetReplicaSetSize", this.TargetReplicaSetSize);
                SetServiceParameter(template, parameters, "minReplicaSetSize", this.MinReplicaSetSize);
            }

            if (this.IsParameterBound(c => c.DefaultMoveCost))
            {
                SetServiceParameter(template, parameters, "defaultMoveCost", this.DefaultMoveCost.ToString());
            }

            return parameters;
        }

        private void SetServiceParameter<T>(JObject template, JObject parameters, string parameterName, T value)
        {
            JObject templateParameters = template["parameters"] as JObject;
            var token = templateParameters.Children().FirstOrDefault(
                    j => ((JProperty)j).Name.Equals(parameterName, StringComparison.OrdinalIgnoreCase));

            string type = "object";
            string parsedValue = string.Empty;
            if (value is string)
            {
                type = "string";
                parsedValue = $"'{value as string}'";
            }
            else if (value is long || value is int)
            {
                type = "int";
                parsedValue = value.ToString();
            }
            else if (value is bool)
            {
                type = "bool";
                parsedValue = value.ToString();
            }
            else if (value is JObject)
            {
                type = "Object";
                parsedValue = value.ToString();
            }

            var parameterData = JObject.Parse($"{{\"type\":\"{type}\"}}");

            if (token != null)
            {
                var property = token as JProperty;
                property.Value = parameterData;
            }
            else
            {
                templateParameters.Add(parameterName, parameterData);
            }

            JObject serviceProperties = ((JArray)template["resources"])[0].SelectToken("properties") as JObject;

            token = serviceProperties.Children().FirstOrDefault(
                   j => ((JProperty)j).Name.Equals(parameterName, StringComparison.OrdinalIgnoreCase));

            var parameterData2 = $"[parameters('{parameterName}')]";

            if (token != null)
            {
                var property = token as JProperty;
                property.Value = parameterData2;
            }
            else
            {
                serviceProperties.Add(parameterName, parameterData2);
            }
            
            SetParameter(ref parameters, parameterName, JToken.Parse(parsedValue));
        }

        protected void SetParameter(ref JObject parameters, string parameterName, JToken value)
        {
            if (value != null)
            {
                var token = parameters.Children().SingleOrDefault(
                        j => ((JProperty)j).Name.Equals(parameterName, StringComparison.OrdinalIgnoreCase));

                if (token != null && token.Any())
                {
                    token.First()["value"] = value;
                }
                else
                {
                    var valueJObject = JObject.Parse($"{{ \"value\":{{}} }}");
                    valueJObject["value"] = value;
                    parameters.Add(parameterName, valueJObject);
                }
            }
        }

        #region resource group deployment
        private Lazy<IResourceManagementClient> resourceManagerClient;

        public IResourceManagementClient ResourceManagerClient
        {
            get { return resourceManagerClient.Value; }
        }

        public virtual string KeyVaultResourceGroupLocation
        {
            get
            {
                return ResourceManagerClient.ResourceGroups.Get(this.ResourceGroupName).Location;
            }
        }

        public NewAzServiceFabricService()
        {
            resourceManagerClient = new Lazy<IResourceManagementClient>(() =>
            Azure.Commands.Common.Authentication.AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(
                DefaultContext,
                AzureEnvironment.Endpoint.ResourceManager));
        }

        private ServiceResource WaitForDeployment(Deployment deployment, string deploymentName)
        {
            var progress = new ProgressRecord(0, string.Format("Request for {0} in progress", typeof(ServiceResource).Name), "Starting...");
            WriteProgress(progress);
            var token = new CancellationTokenSource();
            DeploymentExtended deploymentDetail = null;
            var deploymentTask = Task.Factory.StartNew(() =>
            {
                try
                {
                    deploymentDetail = ResourceManagerClient.Deployments.CreateOrUpdate(
                        this.ResourceGroupName,
                        deploymentName,
                        deployment);
                }
                finally
                {
                    token.Cancel();
                }
            });

            while (!token.IsCancellationRequested)
            {
                if (!RunningTest)
                {
                    string progressMessage = string.Format("Provisioning State: {0}", GetServiceProvisioningStatus());
                    WriteVerboseWithTimestamp(progressMessage);
                    progress.StatusDescription = progressMessage;
                    WriteProgress(progress);
                }

                Thread.Sleep(TimeSpan.FromSeconds(WriteVerboseIntervalInSec));
            }

            if (deploymentTask.IsFaulted)
            {
                PrintSdkExceptionDetail(deploymentTask.Exception);
                WriteVerbose("Create Service 0peration failed.");
                throw deploymentTask.Exception;
            }

            return this.SFRPClient.Services.Get(
                    this.ResourceGroupName,
                    this.ClusterName,
                    this.ApplicationName,
                    this.Name);
        }
        #endregion
    }
}
