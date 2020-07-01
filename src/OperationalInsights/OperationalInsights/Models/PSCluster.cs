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

using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.Management.OperationalInsights.Models;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSCluster
    {
        public PSCluster() {}

        public PSCluster(string location, string id = default(string), string name = default(string), string type = default(string), Hashtable tags = default(Hashtable), PSIdentity identity = default(PSIdentity), PSClusterSku sku = default(PSClusterSku), string nextLink = default(string), string clusterId = default(string), string provisioningState = default(string), PSKeyVaultProperties keyVaultProperties = default(PSKeyVaultProperties))
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
            validateClusterName();
        }

        public PSCluster(Cluster cluster)
        {
            this.Id = cluster.Id;
            this.Location = cluster.Location;
            this.Name = cluster.Name;
            this.Type = cluster.Type;
            if (cluster.Tags != null)
            {
                this.Tags = new Hashtable((IDictionary)cluster.Tags);
            }           

            if (cluster.Identity != null)
            {
                this.Identity = new PSIdentity(cluster.Identity);
            }

            if (cluster.Sku != null)
            {
                this.Sku = new PSClusterSku(cluster.Sku);
            }
            this.NextLink = cluster.NextLink;
            this.ClusterId = cluster.ClusterId;
            this.ProvisioningState = cluster.ProvisioningState;
            if (cluster.KeyVaultProperties != null)
            {
                this.KeyVaultProperties = new PSKeyVaultProperties(cluster.KeyVaultProperties);
            }

            validateClusterName();
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

        public Hashtable Tags { get; set; }

        private IDictionary<string, string> getTags()
        {
            return this.Tags?.Cast<DictionaryEntry>().ToDictionary(kv => (string)kv.Key, kv => (string)kv.Value);
        }

        public Cluster getCluster()
        {
            return new Cluster(location:this.Location, tags:this.getTags(), identity:this.Identity?.getIdentity(), sku:this.Sku?.geteClusterSku(), clusterId:this.ClusterId);
        }

        private const string Pattern = "^[A-Za-z0-9][A-Za-z0-9-]+[A-Za-z0-9]$";

        private void validateClusterName()
        {
            Regex regex = new Regex(Pattern);
            if (!regex.Match(this.Name).Success)
            {
                throw new PSArgumentException("ClusterName should starts/ends with numerical or alphabetical characters only");
            }

            if (this.Name.Length < 4 || this.Name.Length >63)
            {
                throw new PSArgumentException("length of ClusterName need to be in range ''");
            }
        }
    }

}
