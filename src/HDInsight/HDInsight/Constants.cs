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
        public const string deprecateByAzVersion = "11.0.0";
        public const string deprecateByVersion = "7.0.0";
        public const string diskEncryptionChangeInfo = "The type of property 'DiskEncryption' of type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster' will change from 'Microsoft.Azure.Management.HDInsight.Models.DiskEncryptionProperties' to 'Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties'.";
        public const string workerNodeDataDisksGroupsChangeInfo = "The type of property 'WorkerNodeDataDisksGroups' will change from 'List<Microsoft.Azure.Management.HDInsight.Models.DataDisksGroups>' to 'List<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>'.";

        public static class CommandNames
        {
            public const string AzureHDInsightCluster = "AzureRmHDInsightCluster";
            public const string AzureHDInsightClusterConfig = "AzureRmHDInsightClusterConfig";
            public const string AzureHDInsightClusterSize = "AzureRmHDInsightClusterSize";
            public const string AzureHDInsightHttpServicesAccess = "AzureRmHDInsightHttpServicesAccess";
            public const string AzureHDInsightConfigValues = "AzureRmHDInsightConfigValues";
            public const string AzureHDInsightMetastore = "AzureRmHDInsightMetastore";
            public const string AzureHDInsightScriptAction = "AzureRmHDInsightScriptAction";
            public const string AzureHDInsightScriptActionHistory = "AzureRmHDInsightScriptActionHistory";
            public const string AzureHDInsightSecurityProfile = "AzureRmHDInsightSecurityProfile";
            public const string AzureHDInsightPersistedScriptAction = "AzureRmHDInsightPersistedScriptAction";
            public const string AzureHDInsightStorage = "AzureRmHDInsightStorage";
            public const string AzureHDInsightProperties = "AzureRmHDInsightProperties";
            public const string AzureHDInsightJob = "AzureRmHDInsightJob";
            public const string AzureHDInsightJobOutput = "AzureRmHDInsightJobOutput";
            public const string AzureHDInsightDefaultStorage = "AzureRmHDInsightDefaultStorage";
            public const string AzureHDInsightHiveJob = "AzureRmHDInsightHiveJob";
            public const string AzureHDInsightClusterIdentity = "AzureRmHDInsightClusterIdentity";
            public const string AzureHDInsightComponentVersion = "AzureRmHDInsightComponentVersion";
            public const string AzureHDInsightMonitoring = "AzureRmHDInsightMonitoring";
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

        public static class GatewayConfigurations
        {
            public const string CredentialIsEnabledKey = "restAuthCredential.isEnabled";
            public const string UserNameKey = "restAuthCredential.username";
            public const string PasswordKey = "restAuthCredential.password";
        }

        public static class StorageConfigurations
        {
            public const string BlobStorageSuffixValueFormat = ".blob.{0}";
            public const string Adlsgen2StorageSuffixValueFormat = ".dfs.{0}";
            public const string DefaultFsKey = "fs.defaultFS";
            public const string WasbStorageAccountKeyFormat = "fs.azure.account.key.{0}";
            public const string AdlHostNameKey = "dfs.adls.home.hostname";
            public const string AdlMountPointKey = "dfs.adls.home.mountpoint";

            public const string DefaultFsWasbValueFormat = "wasb://{0}@{1}";
            public const string DefaultFsAdlValue = "adl://home";
        }

        public static class DataLakeConfigurations
        {
            public const string ApplicationIdKey = "clusterIdentity.applicationId";
            public const string TenantIdKey = "clusterIdentity.aadTenantId";
            public const string CertificateKey = "clusterIdentity.certificate";
            public const string CertificatePasswordKey = "clusterIdentity.certificatePassword";
            public const string ResourceUriKey = "clusterIdentity.resourceUri";
        }

        public static class MetastoreConfigurations
        {
            public const string ConnectionUrlFormat =
                "jdbc:sqlserver://{0};database={1};encrypt=true;trustServerCertificate=true;create=false;loginTimeout=300;sendStringParametersAsUnicode=true;prepareSQL=0";

            public const string DatabaseValue = "Existing MSSQL Server database with SQL authentication";
            public const string DatabaseTypeValue = "mssql";

            public static class HiveSite
            {
                public const string ConnectionUrlKey = "javax.jdo.option.ConnectionURL";
                public const string ConnectionUserNameKey = "javax.jdo.option.ConnectionUserName";
                public const string ConnectionPasswordKey = "javax.jdo.option.ConnectionPassword";
                public const string ConnectionDriverNameKey = "javax.jdo.option.ConnectionDriverName";

                public const string ConnectionDriverNameValue = "com.microsoft.sqlserver.jdbc.SQLServerDriver";
            }

            public static class HiveEnv
            {
                public const string DatabaseKey = "hive_database";
                public const string DatabaseNameKey = "hive_database_name";
                public const string DatabaseTypeKey = "hive_database_type";
                public const string ExistingDatabaseKey = "hive_existing_mssql_server_database";
                public const string ExistingHostKey = "hive_existing_mssql_server_host";
                public const string HostNameKey = "hive_hostname";
            }

            public static class OozieSite
            {
                public const string UrlKey = "oozie.service.JPAService.jdbc.url";
                public const string UserNameKey = "oozie.service.JPAService.jdbc.username";
                public const string PasswordKey = "oozie.service.JPAService.jdbc.password";
                public const string DriverKey = "oozie.service.JPAService.jdbc.driver";
                public const string SchemaKey = "oozie.db.schema.name";

                public const string DriverValue = "com.microsoft.sqlserver.jdbc.SQLServerDriver";
                public const string SchemaValue = "oozie";
            }

            public static class OozieEnv
            {
                public const string DatabaseKey = "oozie_database";
                public const string DatabaseNameKey = "oozie_database_name";
                public const string DatabaseTypeKey = "oozie_database_type";
                public const string ExistingDatabaseKey = "oozie_existing_mssql_server_database";
                public const string ExistingHostKey = "oozie_existing_mssql_server_host";
                public const string HostNameKey = "oozie_hostname";
            }
        }

        public static class Errors
        {
            public static string ERROR_INPUT_CANNOT_BE_EMPTY = "Input cannot be empty";
            public static string ERROR_SCHEME_SPECIFIED_IN_STORAGE_FQDN = "Please specify fully qualified storage endpoint without the scheme";
        }

        public static class ConfigurationKey
        {
            /// <summary>
            /// The constant for Core site configs.
            /// </summary>
            public const string CoreSite = "core-site";

            /// <summary>
            /// The constant for Hive site configs.
            /// </summary>
            public const string HiveSite = "hive-site";

            /// <summary>
            /// The constant for hive environment configs.
            /// </summary>
            public const string HiveEnv = "hive-env";

            /// <summary>
            /// The constant for Oozie site configs.
            /// </summary>
            public const string OozieSite = "oozie-site";

            /// <summary>
            /// The constant for Oozie environment configs.
            /// </summary>
            public const string OozieEnv = "oozie-env";

            /// <summary>
            /// The constant for WebHCAT site configs.
            /// </summary>
            public const string WebHCatSite = "webhcat-site";

            /// <summary>
            /// The constant for HBase environment configs.
            /// </summary>
            public const string HBaseEnv = "hbase-env";

            /// <summary>
            /// The constant for HBase site configs.
            /// </summary>
            public const string HBaseSite = "hbase-site";

            /// <summary>
            /// The constant for Storm site configs.
            /// </summary>
            public const string StormSite = "storm-site";

            /// <summary>
            /// The constant for Yarn site configs.
            /// </summary>
            public const string YarnSite = "yarn-site";

            /// <summary>
            /// The constant for MapRed site configs.
            /// </summary>
            public const string MapRedSite = "mapred-site";

            /// <summary>
            /// The constant for Tez site configs.
            /// </summary>
            public const string TezSite = "tez-site";

            /// <summary>
            /// The constant for HDFS site configs.
            /// </summary>
            public const string HdfsSite = "hdfs-site";

            /// <summary>
            /// The constant for Gateway configs.
            /// </summary>
            public const string Gateway = "gateway";

            /// <summary>
            /// The constant for cluster identity configs.
            /// </summary>
            public const string ClusterIdentity = "clusterIdentity";

            /// <summary>
            /// The constant for Spark-Defaults configs.
            /// </summary>
            public const string SparkDefaults = "spark-defaults";

            /// <summary>
            /// The constant for Spark-Thrift-SparkConf configs.
            /// </summary>
            public const string SparkThriftConf = "spark-thrift-sparkconf";

            /// <summary>
            /// The constant for Spark2-Defaults configs.
            /// </summary>
            public const string Spark2Defaults = "spark2-defaults";

            /// <summary>
            /// The constant for Spark2-Thrift-SparkConf configs.
            /// </summary>
            public const string Spark2ThriftConf = "spark2-thrift-sparkconf";

            /// <summary>
            /// The constant for custom ambari db configs.
            /// </summary>
            public const string AmbariConf = "ambari-conf";
        }

        public static class AmbariConfiguration
        {
            public const string SqlServerKey = "database-server";
            public const string DatabaseNameKey = "database-name";
            public const string DatabaseUserKey = "database-user-name";
            public const string DatabasePasswordKey = "database-user-password";
        }

        public static class ClusterRoleType
        {
            public const string HeadNodeRole = "HEADNODEROLE";
            public const string WorkerNodeRole = "WORKERNODEROLE";
            public const string ZookeeperNodeRole = "ZOOKEEPERROLE";
            public const string EdgeNodeRole = "EDGENODEROLE";
            public const string KafkaManagementNodeRole = "KAFKAMANAGEMENTNODEROLE";
            public const string HIBNodeRole = "HIBROLE";
            public const string AllRole = "*";
        }

        public static class ClusterType
        {
            public const string Hadoop = "HADOOP";
            public const string Spark = "SPARK";
            public const string Kafka = "KAFKA";
            public const string Storm = "STORM";
            public const string MLService = "MLSERVICE";
            public const string LLAP = "LLAP";
            public const string InterActiveHive = "INTERACTIVEHIVE";
            public const string AllClusterType = "*";
        }
    }
}
