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

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    /// <summary>
    /// ARM tracked resource
    /// </summary>
    public class PSNetAppFilesPool
    {
        /// <summary>
        /// Gets or sets the Resource group name
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets Resource location
        /// </summary>
        public string Location { get; set; }
        
        /// <summary>
        /// Gets resource Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets resource name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets resource type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets resource tags
        /// </summary>
        public object Tags { get; set; }

        /// <summary>
        /// Gets or sets resource etag
        /// </summary>
        /// <remarks>
        /// A unique read-only string that changes whenever the resource is updated.
        /// </remarks>
        public string Etag { get; set; }

        /// <summary>
        /// Gets poolId
        /// </summary>
        public string PoolId { get; set; }

        /// <summary>
        /// Gets or sets size
        /// </summary>
        public long? Size { get; set; }

        /// <summary>
        /// Gets or sets serviceLevel
        /// </summary>
        public string ServiceLevel { get; set; }

        /// <summary>
        /// Gets azure lifecycle management
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets TotalThroughputMibps
        /// </summary>
        /// <value>
        /// total throughput of pool in Mibps        
        /// </value>
        public double? TotalThroughputMibps { get; set; }

        /// <summary>
        /// Gets or sets UtilizedThroughputMibps
        /// </summary>
        /// <value>
        /// Utilized throughput of pool in Mibps        
        /// </value>
        public double? UtilizedThroughputMibps { get; set; }

        /// <summary>
        /// Gets or sets QosType
        /// </summary>
        /// <value>
        /// The qos type of the pool (Auto, Manual)
        /// </value>
        public string QosType { get; set; }

        /// <summary>
        /// Gets or sets CoolAccess
        /// </summary>
        /// <value>
        /// If enabled (true) the pool can contain cool Access enabled volumes.
        /// </value>
        public bool? CoolAccess { get; set; }

        /// <summary>
        /// Gets or sets EncryptionType
        /// </summary>
        /// <value>
        /// Encryption type of the capacity pool (Single, Double), set encryption type for data at rest for this pool and all volumes in it. This value can only be set when creating new pool.
        /// </value>
        public string EncryptionType { get; set; }

        /// <summary>
        /// Gets or sets System Data
        /// </summary>
        public PSSystemData SystemData { get; set; }
    }
}