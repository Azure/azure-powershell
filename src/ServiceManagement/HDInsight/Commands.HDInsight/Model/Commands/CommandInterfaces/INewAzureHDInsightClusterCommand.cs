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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.BaseCommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces
{
    /// <summary>
    ///     Worker object for creating a cluster via PowerShell.
    /// </summary>
    internal interface INewAzureHDInsightClusterCommand : IAzureHDInsightCommand<AzureHDInsightCluster>, INewAzureHDInsightClusterBase
    {
        PSCredential RdpCredential { get; set; }

        DateTime? RdpAccessExpiry { get; set; }

        ICollection<AzureHDInsightStorageAccount> AdditionalStorageAccounts { get; }

        ICollection<AzureHDInsightConfigAction> ConfigActions { get; }

        ConfigValuesCollection CoreConfiguration { get; set; }

        ConfigValuesCollection YarnConfiguration { get; set; }

        ConfigValuesCollection HdfsConfiguration { get; set; }

        HiveConfiguration HiveConfiguration { get; set; }

        AzureHDInsightMetastore HiveMetastore { get; set; }

        MapReduceConfiguration MapReduceConfiguration { get; set; }

        OozieConfiguration OozieConfiguration { get; set; }

        AzureHDInsightMetastore OozieMetastore { get; set; }

        ClusterState State { get; }

        string Location { get; set; }

        string HeadNodeSize { get; set; }

        string DataNodeSize { get; set; }

        string ZookeeperNodeSize { get; set; }

        ClusterType ClusterType { get; set; }

        string VirtualNetworkId { get; set; }

        string SubnetName { get; set; }

        OSType OSType { get; set; }

        PSCredential SshCredential { get; set; }

        string SshPublicKey { get; set; }

        ConfigValuesCollection StormConfiguration { get; set; }

        ConfigValuesCollection SparkConfiguration { get; set; }

        HBaseConfiguration HBaseConfiguration { get; set; }
    }
}
