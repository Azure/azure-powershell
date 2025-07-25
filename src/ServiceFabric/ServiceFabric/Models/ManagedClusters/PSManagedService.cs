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

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;
    using System.Collections.Generic;
    using System.Management.Automation;

    public class PSManagedService
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public IDictionary<string, string> Tags { get; set; }
        public SystemData SystemData { get; }
        public string ProvisioningState { get; set; }
        public string ServiceTypeName { get; set; }
        public Partition PartitionDescription { get; set; }
        public string ServicePackageActivationMode { get; set; }
        public string PlacementConstraints { get; set; }
        public IList<ServiceCorrelation> CorrelationScheme { get; set; }
        public IList<ServiceLoadMetric> ServiceLoadMetrics { get; set; }
        public IList<ServicePlacementPolicy> ServicePlacementPolicies { get; set; }
        public string DefaultMoveCost { get; set; }
        public IList<ScalingPolicy> ScalingPolicies { get; set; }
        public PSServiceKind ServiceKind { get; private set; }

        public PSManagedService(ServiceResource service)
        {
            Id = service.Id;
            Name = service.Name;
            Type = service.Type;
            Location = service.Location;
            Tags = service.Tags;
            SystemData = service.SystemData;

            ProvisioningState = service.Properties.ProvisioningState;
            ServiceTypeName = service.Properties.ServiceTypeName;
            PartitionDescription = service.Properties.PartitionDescription;
            ServicePackageActivationMode = service.Properties.ServicePackageActivationMode;

            PlacementConstraints = service.Properties.PlacementConstraints;
            CorrelationScheme = service.Properties.CorrelationScheme;
            ServiceLoadMetrics = service.Properties.ServiceLoadMetrics;
            ServicePlacementPolicies = service.Properties.ServicePlacementPolicies;
            DefaultMoveCost = service.Properties.DefaultMoveCost;
            ScalingPolicies = service.Properties.ScalingPolicies;

            if (service.Properties is StatefulServiceProperties)
            {
                this.ServiceKind = PSServiceKind.Stateful;
            }
            else if (service.Properties is StatelessServiceProperties)
            {
                this.ServiceKind = PSServiceKind.Stateless;
            }
            else
            {
                throw new PSInvalidCastException(string.Format("Unable to cast service properties as stateles or stateful. Type {0}", service.Properties.GetType()));
            }
        }

        public ServiceResource ToServiceResource()
        {
            var serviceResource = new ServiceResource(
                id: this.Id,
                name: this.Name,
                type: this.Type,
                location: this.Location,
                tags: this.Tags);

            if (this is PSManagedStatefulService)
            {
                var statefulService = this as PSManagedStatefulService;

                serviceResource.Properties = new StatefulServiceProperties(
                    provisioningState: this.ProvisioningState,
                    serviceTypeName: this.ServiceTypeName,
                    partitionDescription: this.PartitionDescription,
                    servicePackageActivationMode: this.ServicePackageActivationMode,
                    placementConstraints: this.PlacementConstraints,
                    correlationScheme: this.CorrelationScheme,
                    serviceLoadMetrics: this.ServiceLoadMetrics,
                    servicePlacementPolicies: this.ServicePlacementPolicies,
                    defaultMoveCost: this.DefaultMoveCost,
                    scalingPolicies: this.ScalingPolicies,
                    hasPersistedState: statefulService.HasPersistedState,
                    targetReplicaSetSize: statefulService.TargetReplicaSetSize,
                    minReplicaSetSize: statefulService.MinReplicaSetSize,
                    replicaRestartWaitDuration: statefulService.ReplicaRestartWaitDuration,
                    quorumLossWaitDuration: statefulService.QuorumLossWaitDuration,
                    standByReplicaKeepDuration: statefulService.StandByReplicaKeepDuration,
                    servicePlacementTimeLimit: statefulService.ServicePlacementTimeLimit);
            }
            else if (this is PSManagedStatelessService)
            {
                var statelessService = this as PSManagedStatelessService;

                serviceResource.Properties = new StatelessServiceProperties(
                    provisioningState: this.ProvisioningState,
                    serviceTypeName: this.ServiceTypeName,
                    partitionDescription: this.PartitionDescription,
                    servicePackageActivationMode: this.ServicePackageActivationMode,
                    placementConstraints: this.PlacementConstraints,
                    correlationScheme: this.CorrelationScheme,
                    serviceLoadMetrics: this.ServiceLoadMetrics,
                    servicePlacementPolicies: this.ServicePlacementPolicies,
                    defaultMoveCost: this.DefaultMoveCost,
                    scalingPolicies: this.ScalingPolicies,
                    instanceCount: statelessService.InstanceCount,
                    minInstanceCount: statelessService.MinInstanceCount,
                    minInstancePercentage: statelessService.MinInstancePercentage);
            }
            else
            {
                throw new PSInvalidCastException(string.Format("Unable to cast service as stateles or stateful. Type {0}", this.GetType()));
            }

            return serviceResource;
        }

        public static PSManagedService GetInstance(ServiceResource service)
        {
            if (service.Properties is StatelessServiceProperties)
            {
                return new PSManagedStatelessService(service);
            }
            else if (service.Properties is StatefulServiceProperties)
            {
                return new PSManagedStatefulService(service);
            }
            else
            {
                throw new PSInvalidCastException(string.Format("Unable to cast service properties as stateles or stateful. Type {0}", service.Properties.GetType()));
            }
        }
    }
}
