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

using System.Management.Automation;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.BaseCommandInterfaces
{
    internal interface INewAzureHDInsightClusterBase : IAzureHDInsightClusterCommandBase
    {
        /// <summary>
        ///     Gets or sets the number of data (worker) nodes to use in the cluster.
        /// </summary>
        int ClusterSizeInNodes { get; set; }

        /// <summary>
        ///     Gets or sets the user credentials (username and password).
        /// </summary>
        PSCredential Credential { get; set; }

        /// <summary>
        ///     Gets or sets the Asv Account key to use for the cluster's default container.
        /// </summary>
        string DefaultStorageAccountKey { get; set; }

        /// <summary>
        ///     Gets or sets the Asv Account name to use for the cluster's default container.
        /// </summary>
        string DefaultStorageAccountName { get; set; }

        /// <summary>
        ///     Gets or sets the container to use for the cluster's default container.
        /// </summary>
        string DefaultStorageContainerName { get; set; }

        /// <summary>
        ///     Gets or sets the version to use for the cluster.
        /// </summary>
        string Version { get; set; }
    }
}
