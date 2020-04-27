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

using System.Collections.Generic;
using Microsoft.Azure.Management.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSCluster
    {
        public PSCluster() {}

        public PSCluster(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), PSIdentity identity = default(PSIdentity), PSClusterSku sku = default(PSClusterSku), string nextLink = default(string), string clusterId = default(string), string provisioningState = default(string), PSKeyVaultProperties keyVaultProperties = default(PSKeyVaultProperties))
        {
            Id = id;
            Location = location;
            Name = name;
            Type = type;
            Tags = tags;
            Identity = identity;
            Sku = sku;
            NextLink = nextLink;
            ClusterId = clusterId;
            ProvisioningState = provisioningState;
            KeyVaultProperties = keyVaultProperties;
        }

        public PSCluster(Cluster cluster)
        {
            this.Id = cluster.Id;
            this.Location = cluster.Location;
            this.Name = cluster.Name;
            this.Type = cluster.Type;
            this.Tags = cluster.Tags;
            this.Identity = new PSIdentity(cluster.Identity);
            this.Sku = new PSClusterSku(cluster.Sku);
            this.NextLink = cluster.NextLink;
            this.ClusterId = cluster.ClusterId;
            this.ProvisioningState = cluster.ProvisioningState;
            this.KeyVaultProperties = new PSKeyVaultProperties(cluster.KeyVaultProperties);
        }

        public PSIdentity Identity { get; set; }

        public PSClusterSku Sku { get; set; }

        public string NextLink { get; set; }

        public string ClusterId { get; private set; }

        public string ProvisioningState { get; private set; }

        public PSKeyVaultProperties KeyVaultProperties { get; set; }

        public string Location { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public Cluster getCluster()
        {
            return new Cluster(this.Location, this.Id, this.Name, this.Type, this.Tags, this.Identity.getIdentity(), this.Sku.geteClusterSku(), this.NextLink, this.ClusterId, this.ProvisioningState, this.KeyVaultProperties.GetKeyVaultProperties());
        }
    }

}
