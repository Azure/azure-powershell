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

using Microsoft.Azure.Commands.Synapse.Models.WorkspacePackages;
using Microsoft.Azure.Management.Synapse.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseSparkPool : PSSynapseTrackedResource
    {
        public PSSynapseSparkPool(BigDataPoolResourceInfo sparkPool)
            : base(sparkPool?.Location, sparkPool?.Id, sparkPool?.Name, sparkPool?.Type, sparkPool?.Tags)
        {
            this.ProvisioningState = sparkPool.ProvisioningState;
            this.AutoScale = sparkPool?.AutoScale != null ? new PSAutoScaleProperties(sparkPool.AutoScale) : null;
            this.CreationDate = sparkPool?.CreationDate;
            this.AutoPause = sparkPool?.AutoPause != null ? new PSAutoPauseProperties(sparkPool.AutoPause) : null;
            this.SparkEventsFolder = sparkPool?.SparkEventsFolder;
            this.NodeCount = sparkPool?.NodeCount;
            this.LibraryRequirements = sparkPool?.LibraryRequirements != null ? new PSLibraryRequirements(sparkPool.LibraryRequirements) : null;
            this.SparkConfigProperties = sparkPool?.SparkConfigProperties != null ? new PSSparkConfigProperties(sparkPool.SparkConfigProperties) : null;
            this.SparkVersion = sparkPool?.SparkVersion;
            this.DefaultSparkLogFolder = sparkPool?.DefaultSparkLogFolder;
            this.NodeSize = sparkPool?.NodeSize;
            this.NodeSizeFamily = sparkPool?.NodeSizeFamily;
            this.IsComputeIsolationEnabled = sparkPool?.IsComputeIsolationEnabled ?? false;
            this.SessionLevelPackagesEnabled = sparkPool?.SessionLevelPackagesEnabled ?? false;
            this.CacheSize = sparkPool?.CacheSize ?? 0;
            this.DynamicExecutorAllocation = sparkPool?.DynamicExecutorAllocation != null ? new PSDynamicExecutorAllocation(sparkPool.DynamicExecutorAllocation) : null;
            this.WorkspacePackages = sparkPool?.CustomLibraries?.Select(library => new PSSynapseWorkspacePackage(library)).ToList() ?? null;
            this.LastSucceededTimestamp = sparkPool?.LastSucceededTimestamp;
        }

        /// <summary>
        /// Gets the state of the Big Data pool.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets auto-scaling properties
        /// </summary>
        public PSAutoScaleProperties AutoScale { get; set; }

        /// <summary>
        /// Gets the time when the Big Data pool was created.
        /// </summary>
        public System.DateTime? CreationDate { get; set; }

        /// <summary>
        /// Gets auto-pausing properties
        /// </summary>
        public PSAutoPauseProperties AutoPause { get; set; }

        /// <summary>
        /// Gets or sets whether compute isolation is required or not.
        /// </summary>
        public bool IsComputeIsolationEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether session level packages enabled.
        /// </summary>
        public bool SessionLevelPackagesEnabled { get; set; }

        /// <summary>
        /// Gets or sets the cache size
        /// </summary>
        public int CacheSize { get; set; }

        /// <summary>
        /// Gets or sets dynamic Executor Allocation
        /// </summary>
        public PSDynamicExecutorAllocation DynamicExecutorAllocation { get; set; }

        /// <summary>
        /// Gets the Spark events folder
        /// </summary>
        public string SparkEventsFolder { get; set; }

        /// <summary>
        /// Gets the number of nodes in the Big Data pool.
        /// </summary>
        public int? NodeCount { get; set; }

        /// <summary>
        /// Gets library version requirements
        /// </summary>
        public PSLibraryRequirements LibraryRequirements { get; set; }

        /// <summary>
        /// Gets or sets list of custom libraries/packages associated with the
        /// spark pool.
        /// </summary>
        public IList<PSSynapseWorkspacePackage> WorkspacePackages { get; set; }

        /// <summary>
        /// Gets the Apache Spark version.
        /// </summary>
        public string SparkVersion { get; set; }

        /// <summary>
        /// Gets the default folder where Spark logs will be written.
        /// </summary>
        public string DefaultSparkLogFolder { get; set; }

        /// <summary>
        /// Gets the level of compute power that each node in the Big
        /// Data pool has. Possible values include: 'None', 'Small', 'Medium',
        /// 'Large'
        /// </summary>
        public string NodeSize { get; set; }

        /// <summary>
        /// Gets the kind of nodes that the Big Data pool provides.
        /// Possible values include: 'None', 'MemoryOptimized'
        /// </summary>
        public string NodeSizeFamily { get; set; }

        /// <summary>
        /// Gets the time when the Big Data pool was updated successfully.
        /// </summary>
        public System.DateTime? LastSucceededTimestamp { get; private set; }

        /// <summary>
        /// Gets the spark configuration properties.
        /// </summary>
        public PSSparkConfigProperties SparkConfigProperties { get; set; }
    }
}
