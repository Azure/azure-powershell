// ----------------------------------------------------------------------------------
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
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public enum AllowedClusterServiceTiers
    {
        CapacityReservation
    }

    public class PSCluster
    {
        public PSCluster() { }

        /// <summary>
        /// Creates a PSCluster instance from SDK response.
        /// </summary>
        /// <param name="cluster"></param>
        public PSCluster(Cluster cluster)
        {
            if (cluster == null)
            {
                throw new PSInvalidOperationException("Input cluster cannot be null - unable to create instance.");
            }

            if (cluster.Identity != null)
            {
                Identity = new PSIdentity(cluster.Identity);
            }

            ClusterId = cluster.ClusterId;//cluster's GUID
            ProvisioningState = cluster.ProvisioningState;
            IsDoubleEncryptionEnabled = cluster.IsDoubleEncryptionEnabled;
            IsAvailabilityZonesEnabled = cluster.IsAvailabilityZonesEnabled;
            BillingType = cluster.BillingType;
            KeyVaultProperties = cluster.KeyVaultProperties == null ? null : PSKeyVaultProperties.GetKVPropertiesFromSDK(cluster.KeyVaultProperties);
            LastModifiedDate = cluster.LastModifiedDate;
            CreatedDate = cluster.CreatedDate;
            AssociatedWorkspaces = cluster.AssociatedWorkspaces;
            CapacityReservationProperties = new PSCapacityReservationProperties(cluster.CapacityReservationProperties, cluster.Sku);
            Sku = new PSClusterSku(cluster.Sku);

            if (cluster.Tags != null)
            {
                Tags = new Hashtable((IDictionary)cluster.Tags);
            }

            Location = cluster.Location;
            Name = cluster.Name;
            Type = cluster.Type;
            Id = cluster.Id; //resource ID
        }

        public PSIdentity Identity { get; set; }
        public string ClusterId { get; private set; }
        public string ProvisioningState { get; private set; }
        public bool? IsDoubleEncryptionEnabled { get; set; }
        public bool? IsAvailabilityZonesEnabled { get; set; }
        public string BillingType { get; set; }
        public PSClusterSku Sku { get; set; }
        public PSKeyVaultProperties KeyVaultProperties { get; set; }
        public string LastModifiedDate { get; set; }
        public string CreatedDate { get; set; }
        public IList<AssociatedWorkspace> AssociatedWorkspaces { get; set; }
        public PSCapacityReservationProperties CapacityReservationProperties { get; set; }
        public string Location { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Hashtable Tags { get; set; }
        public string NextLink { get; set; }//this is not in use anymore - removing this will cause the build to fail

        private IDictionary<string, string> GetTags()
        {
            return Tags?.Cast<DictionaryEntry>().ToDictionary(kv => (string)kv.Key, kv => (string)kv.Value);
        }

        public Cluster GetCluster()
        {
            return new Cluster(
                name: this.Name,
                location: this.Location,
                tags: this.GetTags(),
                identity: this.Identity?.GetIdentity(),
                sku: this.CreateClusterSku(),
                isDoubleEncryptionEnabled: this.IsDoubleEncryptionEnabled,
                isAvailabilityZonesEnabled: this.IsAvailabilityZonesEnabled,
                billingType: this.BillingType,
                keyVaultProperties: this.KeyVaultProperties?.GetKeyVaultProperties(),
                capacityReservationProperties: this.CapacityReservationProperties.GetCapacityReservationProperties()
                );
        }

        public ClusterPatch GetClusterPatch()
        {
            return new ClusterPatch(
                keyVaultProperties: this.KeyVaultProperties?.GetKeyVaultProperties(),
                billingType: this.BillingType,
                identity: this.Identity.GetIdentity(),
                sku: this.CreateClusterSku(),
                tags: this.GetTags()
            );
        }

        private ClusterSku CreateClusterSku()
        {
            if (this.CapacityReservationProperties == null)
            {
                return null;
            }

            return new ClusterSku(name: this.CapacityReservationProperties.SkuName, capacity: this.CapacityReservationProperties.MaxCapacity);
        }
    }
}
