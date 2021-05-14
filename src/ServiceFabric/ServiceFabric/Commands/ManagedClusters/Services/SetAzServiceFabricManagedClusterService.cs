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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ServiceFabricManagedClusters;
using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedClusterService", SupportsShouldProcess = true, DefaultParameterSetName = StatelessByResourceGroup), OutputType(typeof(PSManagedService))]
    public class SetAzServiceFabricManagedClusterService : ManagedApplicationCmdletBase
    {
        private const string StatelessByResourceGroup = "Stateless-ByResourceGroup";
        private const string StatelessByInputObject = "Stateless-ByInputObject";
        private const string StatelessByResourceId = "Stateless-ByResourceId";
        private const string StatefulByResourceGroup = "Stateful-ByResourceGroup";
        private const string StatefulByInputObject = "Stateful-ByInputObject";
        private const string StatefulByResourceId = "Stateful-ByResourceId";


        #region Parameters
        #region common required params

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = StatelessByResourceGroup,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = StatefulByResourceGroup,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = StatelessByResourceGroup,
            HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = StatefulByResourceGroup,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = StatelessByResourceGroup,
            HelpMessage = "Specify the name of the managed application.")]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = StatefulByResourceGroup,
            HelpMessage = "Specify the name of the managed application.")]
        [ValidateNotNullOrEmpty]
        public string ApplicationName { get; set; }

        [Parameter(Mandatory = true, Position = 3, ParameterSetName = StatelessByResourceGroup,
            HelpMessage = "Specify the name of the managed service.")]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = StatefulByResourceGroup,
            HelpMessage = "Specify the name of the managed service.")]
        [ValidateNotNullOrEmpty]
        [Alias("ServiceName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = StatelessByResourceId, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Arm ResourceId of the managed service.")]
        [Parameter(Mandatory = true, ParameterSetName = StatefulByResourceId, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Arm ResourceId of the managed service.")]
        [ResourceIdCompleter(Constants.ManagedClustersFullType)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = StatelessByInputObject, ValueFromPipeline = true, HelpMessage = "The managed service resource.")]
        [Parameter(Mandatory = true, ParameterSetName = StatefulByInputObject, ValueFromPipeline = true, HelpMessage = "The managed service resource.")]
        public PSManagedService InputObject { get; set; }

        #endregion

        #region Stateless params

        [Parameter(Mandatory = true, ParameterSetName = StatelessByResourceGroup,
            HelpMessage = "Use for stateless service")]
        [Parameter(Mandatory = true, ParameterSetName = StatelessByResourceId,
            HelpMessage = "Use for stateless service")]
        [Parameter(Mandatory = true, ParameterSetName = StatelessByInputObject,
            HelpMessage = "Use for stateless service")]
        public SwitchParameter Stateless { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = StatelessByResourceGroup,
            HelpMessage = "Specify the instance count for the managed service")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByResourceId,
            HelpMessage = "Specify the instance count for the managed service")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByInputObject,
            HelpMessage = "Specify the instance count for the managed service")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(-1, int.MaxValue)]
        public int InstanceCount { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = StatelessByResourceGroup,
            HelpMessage = "Specify the minimum instance count for the managed service")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByResourceId,
            HelpMessage = "Specify the minimum instance count for the managed service")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByInputObject,
            HelpMessage = "Specify the minimum instance count for the managed service")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(0, int.MaxValue)]
        public int MinInstanceCount { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = StatelessByResourceGroup,
            HelpMessage = "Specify the minimum instance percentage for the managed service")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByResourceId,
            HelpMessage = "Specify the minimum instance percentage for the managed service")] 
        [Parameter(Mandatory = false, ParameterSetName = StatelessByInputObject,
            HelpMessage = "Specify the minimum instance percentage for the managed service")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(0, 100)]
        public int MinInstancePercentage { get; set; }

        #endregion

        #region Stateful params

        [Parameter(Mandatory = true, ParameterSetName = StatefulByResourceGroup,
            HelpMessage = "Use for stateful service")]
        [Parameter(Mandatory = true, ParameterSetName = StatefulByResourceId,
            HelpMessage = "Use for stateful service")]
        [Parameter(Mandatory = true, ParameterSetName = StatefulByInputObject,
            HelpMessage = "Use for stateful service")]
        public SwitchParameter Stateful { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceGroup,
            HelpMessage = "Specify the target replica set size for the managed service")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceId,
            HelpMessage = "Specify the target replica set size for the managed service")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByInputObject,
            HelpMessage = "Specify the target replica set size for the managed service")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(1, int.MaxValue)]
        public int TargetReplicaSetSize { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceGroup,
            HelpMessage = "Specify the min replica set size for the managed service")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceId,
            HelpMessage = "Specify the min replica set size for the managed service")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByInputObject,
            HelpMessage = "Specify the min replica set size for the managed service")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(1, int.MaxValue)]
        public int MinReplicaSetSize { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceGroup,
            HelpMessage = "Specify the target replica set size for the managed service")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceId,
            HelpMessage = "Specify the target replica set size for the managed service")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByInputObject,
            HelpMessage = "Specify the target replica set size for the managed service")]
        public SwitchParameter HasPersistedState { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceGroup,
            HelpMessage = "Specify the replica restart wait duration for the managed service. Duration represented in ISO 8601 format 'hh:mm:ss'")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceId,
            HelpMessage = "Specify the replica restart wait duration for the managed service. Duration represented in ISO 8601 format 'hh:mm:ss'")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByInputObject,
            HelpMessage = "Specify the replica restart wait duration for the managed service. Duration represented in ISO 8601 format 'hh:mm:ss'")]
        [ValidateNotNullOrEmpty]
        public TimeSpan ReplicaRestartWaitDuration { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceGroup,
            HelpMessage = "Specify the quorum loss wait duration for the managed service. Duration represented in ISO 8601 format 'hh:mm:ss'")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceId,
            HelpMessage = "Specify the quorum loss wait duration for the managed service. Duration represented in ISO 8601 format 'hh:mm:ss'")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByInputObject,
            HelpMessage = "Specify the quorum loss wait duration for the managed service. Duration represented in ISO 8601 format 'hh:mm:ss'")]
        [ValidateNotNullOrEmpty]
        public TimeSpan QuorumLossWaitDuration { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceGroup,
            HelpMessage = "Specify the stand by replica duration for the managed service. Duration represented in ISO 8601 format 'hh:mm:ss'")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceId,
            HelpMessage = "Specify the stand by replica duration for the managed service. Duration represented in ISO 8601 format 'hh:mm:ss'")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByInputObject,
            HelpMessage = "Specify the stand by replica duration for the managed service. Duration represented in ISO 8601 format 'hh:mm:ss'")]
        [ValidateNotNullOrEmpty]
        public TimeSpan StandByReplicaKeepDuration { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceGroup,
            HelpMessage = "Specify the service placement time limit for the managed service. Duration represented in ISO 8601 format 'hh:mm:ss'")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceId,
            HelpMessage = "Specify the service placement time limit for the managed service. Duration represented in ISO 8601 format 'hh:mm:ss'")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByInputObject,
            HelpMessage = "Specify the service placement time limit for the managed service. Duration represented in ISO 8601 format 'hh:mm:ss'")]
        [ValidateNotNullOrEmpty]
        public TimeSpan ServicePlacementTimeLimit { get; set; }
        #endregion

        #region common optional params

        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceGroup,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceId,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByInputObject,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByResourceGroup,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByResourceId,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByInputObject,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [ValidateNotNullOrEmpty]
        public MoveCostEnum DefaultMoveCost { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceGroup,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceId,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByInputObject,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByResourceGroup,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByResourceId,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByInputObject,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        [ValidateNotNullOrEmpty]
        public string PlacementConstraint { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceGroup,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceId,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByInputObject,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByResourceGroup,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByResourceId,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByInputObject,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        public PSServiceMetric[] Metric { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceGroup,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceId,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByInputObject,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByResourceGroup,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByResourceId,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByInputObject,
            HelpMessage = "Specify the placement constraints of the managed service, as a string.")]
        public PSServiceCorrelation[] Correlation { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceGroup,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByResourceId,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [Parameter(Mandatory = false, ParameterSetName = StatefulByInputObject,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByResourceGroup,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByResourceId,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [Parameter(Mandatory = false, ParameterSetName = StatelessByInputObject,
            HelpMessage = "Specify the default cost for a move. Higher costs make it less likely that the Cluster Resource Manager will move the replica when trying to balance the cluster")]
        [ValidateNotNullOrEmpty]
        public ServicePackageActivationModeEnum ServicePackageActivationMode { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Specify the tags as key/value pairs.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Continue without prompts")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }

        #endregion
        #endregion


        public override void ExecuteCmdlet()
        {
            try
            {
                this.SetParams();
                ServiceResource updatedServiceParams = null;
                switch (ParameterSetName)
                {
                    case StatefulByResourceGroup:
                    case StatelessByResourceGroup:
                    case StatefulByResourceId:
                    case StatelessByResourceId:
                        updatedServiceParams = this.GetUpdatedServiceParams();
                        break;
                    case StatefulByInputObject:
                    case StatelessByInputObject:
                        updatedServiceParams = this.GetUpdatedServiceParams(this.InputObject);
                        break;
                    default:
                        throw new ArgumentException("Invalid parameter set", ParameterSetName);
                }
                if (updatedServiceParams != null && ShouldProcess(target: this.Name, action: $"Update managed service name {this.Name}, cluster: {this.ClusterName} in resource group {this.ResourceGroupName}"))
                {
                    var beginRequestResponse = this.SfrpMcClient.Services.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.ClusterName, this.ApplicationName, this.Name, updatedServiceParams)
                        .GetAwaiter().GetResult();

                    var managedService = this.PollLongRunningOperation(beginRequestResponse);

                    WriteObject(PSManagedService.GetInstance(managedService), false);
                }
            }
            catch (Exception ex)
            {
                PrintSdkExceptionDetail(ex);
                throw;
            }
        }

        private ServiceResource GetUpdatedServiceParams(PSManagedService inputObject = null)
        {
            ServiceResource currentService;
            if (inputObject == null)
            {
                currentService = SafeGetResource(() =>
                    this.SfrpMcClient.Services.Get(
                        this.ResourceGroupName,
                        this.ClusterName,
                        this.ApplicationName,
                        this.Name),
                    false);

                if (currentService == null)
                {
                    WriteError(new ErrorRecord(new InvalidOperationException($"Managed Service '{this.Name}' does not exist."),
                        "ResourceDoesNotExist", ErrorCategory.InvalidOperation, null));
                    return currentService;
                }
            }
            else
            {
                currentService = inputObject.ToServiceResource();
            }

            WriteVerbose($"Updating managed service '{this.Name}.'");

            if (this.IsParameterBound(c => c.Tag))
            {
                currentService.Tags = this.Tag?.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string);
            }
            ServiceResourceProperties properties = currentService.Properties;

            if (this.Stateless.ToBool())
            {
                StatelessServiceProperties statelessProperties = properties as  StatelessServiceProperties;

                if (this.IsParameterBound(c => c.InstanceCount))
                {
                    statelessProperties.InstanceCount = this.InstanceCount;
                }

                if (this.IsParameterBound(c => c.MinInstancePercentage))
                {
                    statelessProperties.MinInstancePercentage = this.MinInstancePercentage;
                }
                if (this.IsParameterBound(c => c.MinInstanceCount))
                {
                    statelessProperties.MinInstanceCount = this.MinInstanceCount;
                }
            }
            else if (this.Stateful.ToBool())
            {
                StatefulServiceProperties statefulProperties = properties as StatefulServiceProperties;
                if (this.IsParameterBound(c => c.ServicePlacementTimeLimit))
                {
                    statefulProperties.ServicePlacementTimeLimit = this.ServicePlacementTimeLimit.ToString();
                }
                if (this.IsParameterBound(c => c.StandByReplicaKeepDuration))
                {
                    statefulProperties.StandByReplicaKeepDuration = this.StandByReplicaKeepDuration.ToString();
                }
                if (this.IsParameterBound(c => c.QuorumLossWaitDuration))
                {
                    statefulProperties.QuorumLossWaitDuration = this.QuorumLossWaitDuration.ToString();
                }
                if (this.IsParameterBound(c => c.ReplicaRestartWaitDuration))
                {
                    statefulProperties.ReplicaRestartWaitDuration = this.ReplicaRestartWaitDuration.ToString();
                }
                if (this.IsParameterBound(c => c.HasPersistedState))
                {
                    statefulProperties.HasPersistedState = this.HasPersistedState.ToBool();
                }
                if (this.IsParameterBound(c => c.MinReplicaSetSize))
                {
                    statefulProperties.MinReplicaSetSize = this.MinReplicaSetSize;
                }
                if (this.IsParameterBound(c => c.TargetReplicaSetSize))
                {
                    statefulProperties.TargetReplicaSetSize = this.TargetReplicaSetSize;
                }
            }
            SetCommonProperties(properties);

            return currentService;
        }

        private void SetCommonProperties(ServiceResourceProperties properties)
        {
            if (this.IsParameterBound(c => c.ServicePackageActivationMode))
            {
                properties.ServicePackageActivationMode = this.ServicePackageActivationMode.ToString();
            }
            if (this.IsParameterBound(c => c.DefaultMoveCost))
            {
                properties.DefaultMoveCost = this.DefaultMoveCost.ToString();
            }
            if (this.IsParameterBound(c => c.PlacementConstraint))
            {
                properties.PlacementConstraints = this.PlacementConstraint;
            }
            if (this.IsParameterBound(c => c.Metric))
            {
                properties.ServiceLoadMetrics = this.Metric;
            }
            if (this.IsParameterBound(c => c.Correlation))
            {
                properties.CorrelationScheme = this.Correlation;
            }
        }

        private void SetParams()
        {
            switch (ParameterSetName)
            {
                case StatefulByResourceGroup:
                case StatelessByResourceGroup:
                    break;
                case StatefulByInputObject:
                case StatelessByInputObject:
                    if (string.IsNullOrEmpty(this.InputObject?.Id))
                    {
                        throw new ArgumentException("ResourceId is null.");
                    }
                    SetParametersByResourceId(this.InputObject.Id);
                    break;
                case StatefulByResourceId:
                case StatelessByResourceId:
                    SetParametersByResourceId(this.ResourceId);
                    break;
            }
        }

        private void SetParametersByResourceId(string resourceId)
        {
            this.GetParametersByResourceId(resourceId, Constants.serviceProvider, out string resourceGroup, out string resourceName, out string parentResourceName, out string grandParentResourceName);
            this.ResourceGroupName = resourceGroup;
            this.ClusterName = grandParentResourceName;
            this.ApplicationName = parentResourceName;
            this.Name = resourceName;
        }
    }
}
