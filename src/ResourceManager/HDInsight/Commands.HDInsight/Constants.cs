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

namespace Microsoft.Azure.Commands.HDInsight
{
    internal static class Constants
    {
        public const string Hadoop = "Hadoop";

        public static class CommandNames
        {
            public const string AzureHDInsightCluster = "AzureRmHDInsightCluster";
            public const string AzureHDInsightClusterConfig = "AzureRmHDInsightClusterConfig";
            public const string AzureHDInsightClusterSize = "AzureRmHDInsightClusterSize";
            public const string AzureHDInsightHttpServicesAccess = "AzureRmHDInsightHttpServicesAccess";
            public const string AzureHDInsightRdpServicesAccess = "AzureRmHDInsightRdpServicesAccess";
            public const string AzureHDInsightConfigValues = "AzureRmHDInsightConfigValues";
            public const string AzureHDInsightMetastore = "AzureRmHDInsightMetastore";
            public const string AzureHDInsightScriptAction = "AzureRmHDInsightScriptAction";
            public const string AzureHDInsightScriptActionHistory = "AzureRmHDInsightScriptActionHistory";
            public const string AzureHDInsightPersistedScriptAction = "AzureRmHDInsightPersistedScriptAction";
            public const string AzureHDInsightStorage = "AzureRmHDInsightStorage";
            public const string AzureHDInsightProperties = "AzureRmHDInsightProperties";
            public const string AzureHDInsightJob = "AzureRmHDInsightJob";
            public const string AzureHDInsightJobOutput = "AzureRmHDInsightJobOutput";
            public const string AzureHDInsightDefaultStorage = "AzureRmHDInsightDefaultStorage";
            public const string AzureHDInsightHiveJob = "AzureRmHDInsightHiveJob";
            public const string AzureHDInsightClusterIdentity = "AzureRmHDInsightClusterIdentity";
            public const string Hive = "Hive";
        }

        public static class JobDefinitions
        {
            public const string AzureHDInsightHiveJobDefinition = "AzureRmHDInsightHiveJobDefinition";
            public const string AzureHDInsightPigJobDefinition = "AzureRmHDInsightPigJobDefinition";
            public const string AzureHDInsightMapReduceJobDefinition = "AzureRmHDInsightMapReduceJobDefinition";
            public const string AzureHDInsightStreamingMapReduceJobDefinition = "AzureRmHDInsightStreamingMapReduceJobDefinition";
            public const string AzureHDInsightSqoopJobDefinition = "AzureRmHDInsightSqoopJobDefinition";
        }

        public static class ClusterConfiguration
        {
            public const string DefaultStorageAccountNameKey = "fs.defaultFS";
            public const string DefaultStorageAccountNameKeyOld = "fs.default.name";
            public const string StorageAccountKeyPrefix = "fs.azure.account.key.";
        }
    }
}
