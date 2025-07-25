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
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.Instance_Pools.Model
{
    public class AzureSqlInstancePoolModel
    {
        /// <summary>
        /// Gets or sets the instance pool's resource group name
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the instance pool's type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the instance pool's resource id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the instance pool name.
        /// </summary>
        public string InstancePoolName { get; set; }

        /// <summary>
        /// Gets or sets the instance pool's subnet id.
        /// </summary>
        public string SubnetId { get; set; }

        /// <summary>
        /// Gets or sets the instance pool's vCores.
        /// </summary>
        public int VCores { get; set; }

        /// <summary>
        /// Gets or sets the instance pool's compute generation.
        /// </summary>
        public string ComputeGeneration { get; set; }

        /// <summary>
        /// Gets or sets the instance pool's edition.
        /// </summary>
        public string Edition { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the instance pool.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the sku
        /// </summary>
        public Sku Sku { get; set; }

        /// <summary>
        /// Gets or sets the location of the instance pool
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the license type
        /// </summary>
        public string LicenseType { get; set; }

        /// <summary>
        /// Gets or sets the Maintenance Configuration Id.
        /// </summary>
        public string MaintenanceConfigurationId { get; set; }

        /// <summary>
        /// Gets or sets the DNS Zone.
        /// </summary>
        public string DnsZone { get; set; }
    }
}
