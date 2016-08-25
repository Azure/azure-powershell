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
namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.PSCmdlets
{
    internal class AzureHdInsightPowerShellConstants
    {
        public const string AliasArguments = "Args";
        public const string AliasCert = "Cert";
        public const string AliasCloudServiceName = "CloudServiceName";
        public const string AliasClassName = "Class";
        public const string AliasClusterName = "ClusterName";
        public const string AliasCredentials = "Cred";
        public const string AliasDnsName = "DnsName";
        public const string AliasEndpoint = "Endpoint";
        public const string AliasInput = "Input";
        public const string AliasInputFormat = "InputFormat";
        public const string AliasInputReader = "InputReader";
        public const string AliasJarFile = "Jar";
        public const string AliasJobName = "Name";
        public const string AliasLoc = "Loc";
        public const string AliasNodes = "Nodes";
        public const string AliasOutput = "Output";
        public const string AliasOutputFormat = "OutputFormat";
        public const string AliasParameters = "Params";
        public const string AliasPartitioner = "Partitioner";
        public const string AliasQuery = "QueryText";
        public const string AliasQueryFile = "QueryFile";
        public const string AliasSize = "Size";
        public const string AliasStorageAccount = "StorageAccount";
        public const string AliasStorageContainer = "StorageContainer";
        public const string AliasStorageKey = "StorageKey";
        public const string AliasSub = "Sub";
        public const string AliasSubscription = "Subscription";
        public const string AliasTaskLogsDirectory = "LogsDir";
        public const string AliasVersion = "Ver";
        public const string AliasClusterType = "ClusterType";
        public const string AliasVirtualNetworkId = "VirtualNetworkId";
        public const string AliasSubnetName = "SubnetName";
        public const string AzureHDInsightCluster = "AzureHDInsightCluster";
        public const string AzureHDInsightClusterConfig = "AzureHDInsightClusterConfig";
        public const string AzureHDInsightConfigValues = "AzureHDInsightConfigValues";
        public const string AzureHDInsightDefaultStorage = "AzureHDInsightDefaultStorage";
        public const string AzureHDInsightHiveJobDefinition = "AzureHDInsightHiveJobDefinition";
        public const string AzureHDInsightHttpServicesAccess = "AzureHDInsightHttpServicesAccess";
        public const string AzureHdinsightRdpAccess = "AzureHDInsightRdpAccess";
        public const string AzureHDInsightJobOutput = "AzureHDInsightJobOutput";
        public const string AzureHDInsightJobs = "AzureHDInsightJob";
        public const string AzureHDInsightMapReduceJobDefinition = "AzureHDInsightMapReduceJobDefinition";
        public const string AzureHDInsightMetastore = "AzureHDInsightMetastore";
        public const string AzureHDInsightPigJobDefinition = "AzureHDInsightPigJobDefinition";
        public const string AzureHDInsightScriptAction = "AzureHDInsightScriptAction";
        public const string AzureHDInsightProperties = "AzureHDInsightProperties";
        public const string AzureHDInsightSqoopJobDefinition = "AzureHDInsightSqoopJobDefinition";
        public const string AzureHDInsightStorage = "AzureHDInsightStorage";
        public const string AzureHDInsightStreamingMapReduceJobDefinition = "AzureHDInsightStreamingMapReduceJobDefinition";
        public const string Exec = "Exec";
        public const string FromDateTime = "From";
        public const string Hive = "AzureHDInsightHiveJob";
        public const string HiveCmdExecute = "execute";
        public const string HiveCmdExecuteAlias = "e";

        public const string JobDefinition = "jobDetails";
        public const string JobId = "Id";
        public const string Jobs = "Jobs";
        public const string MapReduce = "MapReduce";

        public const string ParameterSetAddMetastore = "Add Metastore";
        public const string ParameterSetAddStorageAccount = "Add Storage Account";
        public const string ParameterSetAddScriptAction = "Add Script Action";

        public const string ParameterSetClusterByConfigWithSpecificSubscriptionCredentials =
            "Cluster By Config (with Specific Subscription Credential)";

        public const string ParameterSetClusterByNameWithSpecificSubscriptionCredentials = "Cluster By Name (with Specific Subscription Credential)";
        public const string ParameterSetConfigClusterSizeInNodesOnly = "Config ClusterSizeInNodes Only";
        public const string ParameterSetDefaultStorageAccount = "Set Default Storage Account";
        public const string ParameterSetJobHistoryByName = "Get jobDetails History of a HDInsight Cluster";
        public const string ParameterSetJobHistoryByNameAndJobId = "Get jobDetails History for a specific jobDetails in a HDInsight Cluster";

        public const string ParameterSetResizingWithName = "Set cluster size in nodes with name.";
        public const string ParameterSetResizingWithPiping = "Set cluster size in nodes with cluster from pipeline.";

        public const string ParameterSetJobHistoryByNameWithSpecificSubscriptionCredentials =
            "Get jobDetails History of a HDInsight Cluster (with Specific Subscription Credential)";

        public const string ParameterSetStartJobByName = "Start jobDetails on an HDInsight Cluster";

        public const string ParameterSetStartJobByNameWithSpecificSubscriptionCredentials =
            "Start jobDetails on an HDInsight Cluster (with Specific Subscription Credential)";

        public const string ParameterSetWaitJobById = "Wait Job with JobId on an HDInsight Cluster";
        public const string ParameterSetWaitJobByJob = "Wait Job with Job on an HDInsight Cluster";
        public const string Show = "Show";
        public const string Skip = "Skip";
        public const string ToDateTime = "To";

        public const string AsmWarning =
            "The Azure Service Management (ASM) cmdlets for HDInsight are deprecated and will be removed in January 2017. " +
            "Please use the ARM version of this cmdlet instead: {0}" +
            "\nFor more information, go to http://go.microsoft.com/fwlink/p/?LinkID=785086";
    }
}
