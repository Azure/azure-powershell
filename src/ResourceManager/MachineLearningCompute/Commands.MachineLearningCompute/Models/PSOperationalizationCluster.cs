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

using Microsoft.Azure.Management.MachineLearningCompute.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.MachineLearningCompute.Models
{
    public class PSOperationalizationCluster
    {
        public string Id { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ProvisioningState { get; set; }

        public IList<ErrorResponseWrapper> ProvisioningErrors { get; set; }

        public string ClusterType { get; set; }

        public StorageAccountProperties StorageAccount { get; set; }

        public ContainerRegistryProperties ContainerRegistry { get; set; }

        public AcsClusterProperties ContainerService { get; set; }

        public AppInsightsProperties AppInsights { get; set; }   

        public GlobalServiceConfiguration GlobalServiceConfiguration { get; set; }

        public PSOperationalizationCluster()
        {

        }

        public PSOperationalizationCluster(OperationalizationCluster cluster)
        {
            this.Id = cluster.Id;
            this.Name = cluster.Name;
            this.Type = cluster.Type;
            this.Tags = cluster.Tags;
            this.Location = cluster.Location;
            this.Description = cluster.Description;
            this.CreatedOn = cluster.CreatedOn;
            this.ModifiedOn = cluster.ModifiedOn;
            this.ProvisioningState = cluster.ProvisioningState;
            this.ProvisioningErrors = cluster.ProvisioningErrors;
            this.ClusterType = cluster.ClusterType;
            this.StorageAccount = cluster.StorageAccount;
            this.ContainerRegistry = cluster.ContainerRegistry;
            this.ContainerService = cluster.ContainerService;
            this.AppInsights = cluster.AppInsights;
            this.GlobalServiceConfiguration = cluster.GlobalServiceConfiguration;
        }

        public OperationalizationCluster ConvertToOperationalizationCluster()
        {
            return new OperationalizationCluster(Location, ClusterType, Id, Name, Type, Tags, Description, CreatedOn, ModifiedOn, ProvisioningState, ProvisioningErrors, StorageAccount, ContainerRegistry, ContainerService, AppInsights, GlobalServiceConfiguration); 
        }
    }
}
