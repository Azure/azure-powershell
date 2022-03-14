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
        public PSCluster() { }

        public PSCluster(string location, PSIdentity identity = default, PSClusterSku sku = default, string id = default, string provisioningState = default, bool isDoubleEncryptionEnabled = default, bool isAvailabilityZonesEnabled = default, string billingType = default, PSKeyVaultProperties keyVaultProperties = default, string lastModifiedDate = default, string createdDate = default, IList<AssociatedWorkspace> associatedWorkspaces = default, CapacityReservationProperties capacityReservationProperties = default, Hashtable tags = default, string name = default, string type = default, string nextLink = default, string clusterId = default)
        {
            Identity = identity;
            Sku = sku;
            Id = id;
            ProvisioningState = provisioningState;
            IsDoubleEncryptionEnabled = isDoubleEncryptionEnabled;
            IsAvailabilityZonesEnabled = isAvailabilityZonesEnabled;
            BillingType = billingType;
            KeyVaultProperties = keyVaultProperties;
            LastModifiedDate = lastModifiedDate;
            CreatedDate = createdDate;
            AssociatedWorkspaces = associatedWorkspaces;
            CapacityReservationProperties = capacityReservationProperties;

            Tags = tags;
            Location = location;
            Name = name;
            Type = type;
            ClusterId = clusterId;
            validateClusterName();
        }

        public PSCluster(Cluster cluster)
        {
            if (cluster.Identity != null)
            {
                this.Identity = new PSIdentity(cluster.Identity);
            }

            if (cluster.Sku != null)
            {
                this.Sku = new PSClusterSku(cluster.Sku);
            }

            this.ClusterId = cluster.ClusterId;//cluster's GUID
            this.ProvisioningState = cluster.ProvisioningState;
            this.IsDoubleEncryptionEnabled = cluster.IsDoubleEncryptionEnabled;
            this.IsAvailabilityZonesEnabled = cluster.IsAvailabilityZonesEnabled;
            this.BillingType = cluster.BillingType;

            if (cluster.KeyVaultProperties != null)
            {
                this.KeyVaultProperties = new PSKeyVaultProperties(cluster.KeyVaultProperties);
            }

            this.LastModifiedDate = cluster.LastModifiedDate;
            this.CreatedDate = cluster.CreatedDate;
            this.AssociatedWorkspaces = cluster.AssociatedWorkspaces;
            this.CapacityReservationProperties = cluster.CapacityReservationProperties;

            if (cluster.Tags != null)
            {
                this.Tags = new Hashtable((IDictionary)cluster.Tags);
            }

            this.Location = cluster.Location;
            this.Name = cluster.Name;
            this.Type = cluster.Type;
            this.Id = cluster.Id;//resource ID

            validateClusterName();
        }

        public PSIdentity Identity { get; set; }
        public PSClusterSku Sku { get; set; }
        public string ClusterId { get; private set; }
        public string ProvisioningState { get; private set; }
        public bool? IsDoubleEncryptionEnabled { get; set; }
        public bool? IsAvailabilityZonesEnabled { get; set; }
        public string BillingType { get; set; }
        public PSKeyVaultProperties KeyVaultProperties { get; set; }
        public string LastModifiedDate { get; set; }
        public string CreatedDate { get; set; }
        public IList<AssociatedWorkspace> AssociatedWorkspaces { get; set; }
        public CapacityReservationProperties CapacityReservationProperties { get; set; }

        public string Location { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Hashtable Tags { get; set; }
        public string NextLink { get; set; }//this is not in use anymore - removing this will cause the build to fail

        private IDictionary<string, string> getTags()
        {
            return this.Tags?.Cast<DictionaryEntry>().ToDictionary(kv => (string)kv.Key, kv => (string)kv.Value);
        }

        public Cluster getCluster()
        {
            return new Cluster(
                name: Name,
                location: Location,
                tags: getTags(),
                identity: Identity?.getIdentity(),
                sku: Sku?.getClusterSku(), 
                isDoubleEncryptionEnabled: IsDoubleEncryptionEnabled,
                isAvailabilityZonesEnabled: IsAvailabilityZonesEnabled,
                billingType: BillingType,
                keyVaultProperties: KeyVaultProperties?.GetKeyVaultProperties()
                );
        }

        private const string Pattern = "^[A-Za-z0-9][A-Za-z0-9-]+[A-Za-z0-9]$";

        private void validateClusterName()
        {
            Regex regex = new Regex(Pattern);
            if (!regex.Match(this.Name).Success)
            {
                throw new PSArgumentException("ClusterName should starts/ends with numerical or alphabetical characters only");
            }

            if (this.Name.Length < 4 || this.Name.Length > 63)
            {
                throw new PSArgumentException("length of ClusterName need to be in range ''");
            }
        }
    }

}
