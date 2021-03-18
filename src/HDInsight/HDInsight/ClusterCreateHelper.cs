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

using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public static class ClusterCreateHelper
    {
        public static void AddClusterCredentialToGatewayConfig(PSCredential httpCredential, IDictionary<string, Dictionary<string, string>> configurations)
        {
            Dictionary<string, string> gatewayConfig = GetExistingConfigurationsForType(configurations, Constants.ConfigurationKey.Gateway);
            if (!string.IsNullOrEmpty(httpCredential?.UserName))
            {
                gatewayConfig[Constants.GatewayConfigurations.CredentialIsEnabledKey] = "true";
                gatewayConfig[Constants.GatewayConfigurations.UserNameKey] = httpCredential?.UserName;
                gatewayConfig[Constants.GatewayConfigurations.PasswordKey] = httpCredential?.Password?.ConvertToString();
            }
            else
            {
                gatewayConfig[Constants.GatewayConfigurations.CredentialIsEnabledKey] = "false";
            }

            configurations[Constants.ConfigurationKey.Gateway] = gatewayConfig;
        }

        public static void AddAzureDataLakeStorageGen1ToCoreConfig(string storageResourceId, string storageRootPath, string defaultAzureDataLakeStoreFileSystemEndpointSuffix, IDictionary<string, Dictionary<string, string>> configurations)
        {
            string storageAccountName = Utils.GetResourceNameFromResourceId(storageResourceId);

            // For public the defaultAzureDataLakeStoreFileSystemEndpointSuffix is "azuredatalakestore.net"
            if (string.IsNullOrWhiteSpace(storageRootPath))
            {
                throw new ArgumentException(Constants.Errors.ERROR_INPUT_CANNOT_BE_EMPTY, "storageRootPath");
            }

            if (!storageAccountName.Contains("."))
            {
                storageAccountName = string.Format("{0}.{1}", storageAccountName, defaultAzureDataLakeStoreFileSystemEndpointSuffix);
            }

            // Get existing core configs.
            Dictionary<string, string> coreConfig = GetExistingConfigurationsForType(configurations, Constants.ConfigurationKey.CoreSite);

            // Add configurations for default ADL storage.
            coreConfig[Constants.StorageConfigurations.DefaultFsKey] = Constants.StorageConfigurations.DefaultFsAdlValue;
            coreConfig[Constants.StorageConfigurations.AdlHostNameKey] = storageAccountName;
            coreConfig[Constants.StorageConfigurations.AdlMountPointKey] = storageRootPath;

            configurations[Constants.ConfigurationKey.CoreSite] = coreConfig;
        }

        public static void AddAdditionalStorageAccountsToCoreConfig(Dictionary<string, string> additionalStorageAccounts, IDictionary<string, Dictionary<string, string>> configurations)
        {
            // Get existing core configs.
            Dictionary<string, string> coreConfig = GetExistingConfigurationsForType(configurations, Constants.ConfigurationKey.CoreSite);

            foreach (KeyValuePair<string, string> storageAccount in additionalStorageAccounts)
            {
                string configKey = string.Format(Constants.StorageConfigurations.WasbStorageAccountKeyFormat, storageAccount.Key);
                coreConfig[configKey] = storageAccount.Value;
            }

            configurations[Constants.ConfigurationKey.CoreSite] = coreConfig;
        }

        public static void AddDataLakeStorageGen1IdentityToIdentityConfig(Guid applicationId, Guid aadTenantId, byte[] certificateFileBytes, string certificatePassword,
            IDictionary<string, Dictionary<string, string>> configurations, string cloudAadAuthority = default(string), string dataLakeEndpointResourceId = default(string))
        {
            Dictionary<string, string> datalakeConfig = new Dictionary<string, string>
            {
                {Constants.DataLakeConfigurations.ApplicationIdKey, applicationId.ToString()},
                {
                    // Converting the Tenant ID to URI as RP expects this to be URI.
                    Constants.DataLakeConfigurations.TenantIdKey, string.Format("{0}{1}", cloudAadAuthority, aadTenantId)
                },
                {Constants.DataLakeConfigurations.CertificateKey, Convert.ToBase64String(certificateFileBytes)},
                {Constants.DataLakeConfigurations.CertificatePasswordKey, certificatePassword},
                {Constants.DataLakeConfigurations.ResourceUriKey, dataLakeEndpointResourceId}
            };

            configurations[Constants.ConfigurationKey.ClusterIdentity] = datalakeConfig;
        }

        public static StorageAccount CreateAzureStorageAccount(string clusterName, string storageResourceId, string storageAccountkey, string storageContainer, string defaultStorageSuffix)
        {
            storageContainer = storageContainer ?? clusterName.ToLower();
            string storageAccountName = Utils.GetResourceNameFromResourceId(storageResourceId);
            storageAccountName = storageAccountName + string.Format(Constants.StorageConfigurations.BlobStorageSuffixValueFormat, defaultStorageSuffix);

            return new StorageAccount()
            {
                Name = storageAccountName,
                IsDefault = true,
                Container = storageContainer,
                Key = storageAccountkey,
                ResourceId = storageResourceId
            };
        }

        public static StorageAccount CreateAdlsGen2StorageAccount(string clusterName, string storageResourceId, string storageAccountkey, string storageFileSystem, string msiResourceId, string defaultStorageSuffix)
        {
            storageFileSystem = storageFileSystem ?? clusterName.ToLower();

            string storageAccountName = Utils.GetResourceNameFromResourceId(storageResourceId);
            storageAccountName = storageAccountName + string.Format(Constants.StorageConfigurations.Adlsgen2StorageSuffixValueFormat, defaultStorageSuffix);

            return new StorageAccount()
            {
                Name = storageAccountName,
                IsDefault = true,
                FileSystem = storageFileSystem,
                Key = storageAccountkey,
                MsiResourceId = msiResourceId,
                ResourceId = storageResourceId
            };
        }

        public static void AddHiveMetastoreToConfigurations(AzureHDInsightMetastore hiveMetastore, IDictionary<string, Dictionary<string, string>> configurations)
        {
            if (!hiveMetastore.SqlAzureServerName.Contains("."))
            {
                throw new ArgumentException("Please provide the fully qualified metastore name.");
            }

            string connectionUrl =
                string.Format(Constants.MetastoreConfigurations.ConnectionUrlFormat, hiveMetastore.SqlAzureServerName, hiveMetastore.DatabaseName);

            configurations.AddOrCombineConfigurations(Constants.ConfigurationKey.HiveSite, new Dictionary<string, string>
                {
                    {Constants.MetastoreConfigurations.HiveSite.ConnectionUrlKey, connectionUrl},
                    {Constants.MetastoreConfigurations.HiveSite.ConnectionUserNameKey, hiveMetastore.Credential.UserName},
                    {Constants.MetastoreConfigurations.HiveSite.ConnectionPasswordKey, hiveMetastore.Credential.Password.ConvertToString()},
                    {Constants.MetastoreConfigurations.HiveSite.ConnectionDriverNameKey, Constants.MetastoreConfigurations.HiveSite.ConnectionDriverNameValue}
                });

            configurations.AddOrCombineConfigurations(Constants.ConfigurationKey.HiveEnv, new Dictionary<string, string>
                {
                    {Constants.MetastoreConfigurations.HiveEnv.DatabaseKey, Constants.MetastoreConfigurations.DatabaseValue},
                    {Constants.MetastoreConfigurations.HiveEnv.DatabaseNameKey, hiveMetastore.DatabaseName},
                    {Constants.MetastoreConfigurations.HiveEnv.DatabaseTypeKey, Constants.MetastoreConfigurations.DatabaseTypeValue},
                    {Constants.MetastoreConfigurations.HiveEnv.ExistingDatabaseKey, hiveMetastore.DatabaseName},
                    {Constants.MetastoreConfigurations.HiveEnv.ExistingHostKey, hiveMetastore.SqlAzureServerName},
                    {Constants.MetastoreConfigurations.HiveEnv.HostNameKey, hiveMetastore.SqlAzureServerName}
                });
        }

        public static void AddOozieMetastoreToConfigurations(AzureHDInsightMetastore oozieMetastore, IDictionary<string, Dictionary<string, string>> configurations)
        {
            if (Uri.CheckHostName(oozieMetastore.SqlAzureServerName) != UriHostNameType.Dns)
            {
                throw new ArgumentException("Please provide the fully qualified metastore name.");
            }
            string connectionUrl = string.Format(Constants.MetastoreConfigurations.ConnectionUrlFormat, oozieMetastore.SqlAzureServerName, oozieMetastore.DatabaseName);

            configurations.AddOrCombineConfigurations(Constants.ConfigurationKey.OozieSite, new Dictionary<string, string>
                {
                    {Constants.MetastoreConfigurations.OozieSite.UrlKey, connectionUrl},
                    {Constants.MetastoreConfigurations.OozieSite.UserNameKey, oozieMetastore.Credential.UserName},
                    {Constants.MetastoreConfigurations.OozieSite.PasswordKey, oozieMetastore.Credential.Password.ConvertToString()},
                    {Constants.MetastoreConfigurations.OozieSite.DriverKey, Constants.MetastoreConfigurations.OozieSite.DriverValue},
                    {Constants.MetastoreConfigurations.OozieSite.SchemaKey, Constants.MetastoreConfigurations.OozieSite.SchemaValue}
                });

            configurations.AddOrCombineConfigurations(Constants.ConfigurationKey.OozieEnv, new Dictionary<string, string>
                {
                    {Constants.MetastoreConfigurations.OozieEnv.DatabaseKey, Constants.MetastoreConfigurations.DatabaseValue},
                    {Constants.MetastoreConfigurations.OozieEnv.DatabaseNameKey, oozieMetastore.DatabaseName},
                    {Constants.MetastoreConfigurations.OozieEnv.DatabaseTypeKey, Constants.MetastoreConfigurations.DatabaseTypeValue},
                    {Constants.MetastoreConfigurations.OozieEnv.ExistingDatabaseKey, oozieMetastore.DatabaseName},
                    {Constants.MetastoreConfigurations.OozieEnv.ExistingHostKey, oozieMetastore.SqlAzureServerName},
                    {Constants.MetastoreConfigurations.OozieEnv.HostNameKey, oozieMetastore.SqlAzureServerName}
                });
        }

        public static void AddCustomAmbariDatabaseToConfigurations(AzureHDInsightMetastore ambariDatabase, IDictionary<string, Dictionary<string, string>> configurations)
        {
            if (Uri.CheckHostName(ambariDatabase.SqlAzureServerName) != UriHostNameType.Dns)
            {
                throw new ArgumentException("Please provide the fully qualified sql server name.");
            }

            configurations.AddOrCombineConfigurations(Constants.ConfigurationKey.AmbariConf, new Dictionary<string, string>
                {
                    {Constants.AmbariConfiguration.SqlServerKey, ambariDatabase.SqlAzureServerName},
                    {Constants.AmbariConfiguration.DatabaseNameKey, ambariDatabase.DatabaseName},
                    {Constants.AmbariConfiguration.DatabaseUserKey, ambariDatabase.Credential.UserName},
                    {Constants.AmbariConfiguration.DatabasePasswordKey, ambariDatabase.Credential.Password.ConvertToString()}
                });
        }

        public static VirtualNetworkProfile CreateVirtualNetworkProfile(string virtualNetworkId, string subnetName)
        {
            if (string.IsNullOrEmpty(virtualNetworkId) && string.IsNullOrEmpty(subnetName))
            {
                return null;
            }

            VirtualNetworkProfile vnetProfile = new VirtualNetworkProfile(virtualNetworkId, string.Format("{0}/subnets/{1}", virtualNetworkId, subnetName));
            return vnetProfile;
        }

        public static OsProfile CreateOsProfile(PSCredential sshCredential, string sshPublicKey)
        {
            string sshUserName = sshCredential?.UserName;
            string sshPassword = sshCredential?.Password?.ConvertToString();
            List<SshPublicKey> sshPublicKeys = new List<SshPublicKey>();
            if (!string.IsNullOrEmpty(sshPublicKey))
            {
                sshPublicKeys.Add(new SshPublicKey
                {
                    CertificateData = sshPublicKey
                });
            }

            SshProfile sshProfile = null;
            if (sshPublicKeys.Count > 0)
            {
                sshProfile = new SshProfile
                {
                    PublicKeys = sshPublicKeys.ToArray()
                };
            }

            return new OsProfile
            {
                LinuxOperatingSystemProfile = new LinuxOperatingSystemProfile
                {
                    SshProfile = sshProfile,
                    Password = sshPassword,
                    Username = sshUserName
                }
            };
        }

        public static ComputeProfile CreateComputeProfile(OsProfile osProfile, VirtualNetworkProfile vnetProfile, Dictionary<ClusterNodeType, List<ScriptAction>> clusterScriptActions, string clusterType, int workerNodeCount, string headNodeSize, string workerNodeSize, string zookeeperNodeSize = null, string edgeNodeSize = null, bool isKafakaRestProxyEnable=false, string kafkaManagementNodeSize = null, bool isIDBrokerEnable = false, Dictionary<string, Dictionary<string, string>> defaultVmSizeConfigurations=null)
        {
            List<Role> roles = new List<Role>();

            // Create head node
            headNodeSize = headNodeSize ?? GetNodeSize(clusterType, Constants.ClusterRoleType.HeadNodeRole, defaultVmSizeConfigurations);
            List<ScriptAction> headNodeScriptActions = GetScriptActionsForRoleType(clusterScriptActions, ClusterNodeType.HeadNode);
            Role headNode = CreateHeadNodeRole(osProfile, vnetProfile, headNodeScriptActions, headNodeSize);
            roles.Add(headNode);

            // Create worker node
            workerNodeSize = workerNodeSize ?? GetNodeSize(clusterType, Constants.ClusterRoleType.WorkerNodeRole, defaultVmSizeConfigurations);
            List<ScriptAction> workerNodeScriptActions = GetScriptActionsForRoleType(clusterScriptActions, ClusterNodeType.WorkerNode);
            Role workerNode = CreateWorkerNodeRole(osProfile, vnetProfile, workerNodeScriptActions, workerNodeCount, workerNodeSize);
            roles.Add(workerNode);

            // Create Zookeeper Node
            zookeeperNodeSize= zookeeperNodeSize?? GetNodeSize(clusterType, Constants.ClusterRoleType.ZookeeperNodeRole, defaultVmSizeConfigurations);
            List<ScriptAction> zookeeperNodeScriptActions = GetScriptActionsForRoleType(clusterScriptActions, ClusterNodeType.ZookeeperNode);
            Role zookeeperNode = CreateZookeeperNodeRole(osProfile, vnetProfile, zookeeperNodeScriptActions, zookeeperNodeSize);
            roles.Add(zookeeperNode);

            // RServer & MLServices clusters contain an additional edge node. Return here for all other types.
            if (new[] { "RServer", "MLServices" }.Contains(clusterType, StringComparer.OrdinalIgnoreCase))
            {
                // Set up edgenode and add to collection.
                const int edgeNodeCount = 1;
                edgeNodeSize = edgeNodeSize ?? GetNodeSize(clusterType, Constants.ClusterRoleType.EdgeNodeRole, defaultVmSizeConfigurations); ;
                Role edgeNode = CreateEdgeNodeRole(osProfile, vnetProfile, null, edgeNodeCount, edgeNodeSize);
                roles.Add(edgeNode);
            }

            // Create Id Broker Node
            if (isIDBrokerEnable)
            {
                string idBrokerNodeSize= GetNodeSize(clusterType, Constants.ClusterRoleType.HIBNodeRole, defaultVmSizeConfigurations);
                Role idBrokerNode = CreateIdBrokerNodeRole(osProfile, vnetProfile, idBrokerNodeSize);
                roles.Add(idBrokerNode);
            }

            // Create Kafka Management Node
            if (isKafakaRestProxyEnable)
            {
                kafkaManagementNodeSize = kafkaManagementNodeSize?? GetNodeSize(clusterType, Constants.ClusterRoleType.KafkaManagementNodeRole, defaultVmSizeConfigurations);
                Role kafkaManagementNode = CreateKafkaManagementNode(osProfile, vnetProfile, kafkaManagementNodeSize);
                roles.Add(kafkaManagementNode);
            }
            return new ComputeProfile(roles);
        }

        public static Role CreateHeadNodeRole(OsProfile osProfile, VirtualNetworkProfile vnetProfile, List<ScriptAction> headNodeScriptActions, string headNodeSize)
        {
            const int headNodeCount = 2;
            return CreateCommonRole(osProfile, vnetProfile, AzureHDInsightClusterNodeType.HeadNode, headNodeScriptActions, headNodeCount, headNodeSize);
        }

        public static Role CreateWorkerNodeRole(OsProfile osProfile, VirtualNetworkProfile vnetProfile, List<ScriptAction> workerNodeScriptActions, int workerNodeCount, string workerNodeSize)
        {
            return CreateCommonRole(osProfile, vnetProfile, AzureHDInsightClusterNodeType.WorkerNode, workerNodeScriptActions, workerNodeCount, workerNodeSize);
        }

        public static Role CreateZookeeperNodeRole(OsProfile osProfile, VirtualNetworkProfile vnetProfile, List<ScriptAction> zookeeperNodeScriptActions, string zookeeperNodeSize)
        {
            const int zookeeperNodeCount = 3;
            return CreateCommonRole(osProfile, vnetProfile, AzureHDInsightClusterNodeType.ZookeeperNode, zookeeperNodeScriptActions, zookeeperNodeCount, zookeeperNodeSize);
        }

        public static Role CreateEdgeNodeRole(OsProfile osProfile, VirtualNetworkProfile vnetProfile, List<ScriptAction> edgeNodeScriptActions, int edgeNodeCount, string edgeNodeSize)
        {
            return CreateCommonRole(osProfile, vnetProfile, AzureHDInsightClusterNodeType.EdgeNode, edgeNodeScriptActions, edgeNodeCount, edgeNodeSize);
        }

        public static Role CreateIdBrokerNodeRole(OsProfile osProfile, VirtualNetworkProfile vnetProfile,string idBrokerNodeSize)
        {
            const int idBrokerNodeCount = 2;
            return CreateCommonRole(null, vnetProfile, AzureHDInsightClusterNodeType.IdBrokerNode, null, idBrokerNodeCount, idBrokerNodeSize);
        }

        public static Role CreateKafkaManagementNode(OsProfile osProfile, VirtualNetworkProfile vnetProfile, string kafkaManagementNodeSize)
        {
            const int kafkaManagementNodeCount = 2;
            return CreateCommonRole(osProfile, vnetProfile, AzureHDInsightClusterNodeType.KafkaManagementNode, null, kafkaManagementNodeCount, kafkaManagementNodeSize);
        }

        private static Role CreateCommonRole(OsProfile osProfile, VirtualNetworkProfile vnetProfile, AzureHDInsightClusterNodeType nodeType, List<ScriptAction> scriptActions, int instanceCount,
            string vmSize)
        {
            return new Role
            {
                Name = nodeType.ToString().ToLower(),
                TargetInstanceCount = instanceCount,
                HardwareProfile = vmSize != null ? new HardwareProfile
                {
                    VmSize = vmSize
                } : null,
                VirtualNetworkProfile = vnetProfile,
                OsProfile = osProfile,
                ScriptActions = scriptActions
            };
        }

        public static string GetNodeSize(string clusterType, string nodeRoleType)
        {
            switch (nodeRoleType)
            {
                case Constants.ClusterRoleType.HeadNodeRole:
                    return DefaultVmSizes.HeadNode.GetSize(clusterType);
                case Constants.ClusterRoleType.WorkerNodeRole:
                    return DefaultVmSizes.WorkerNode.GetSize(clusterType);
                case Constants.ClusterRoleType.ZookeeperNodeRole:
                    return DefaultVmSizes.ZookeeperNode.GetSize(clusterType);
                case Constants.ClusterRoleType.EdgeNodeRole:
                    return DefaultVmSizes.EdgeNode.GetSize(clusterType);
                case Constants.ClusterRoleType.KafkaManagementNodeRole:
                    return DefaultVmSizes.KafkaManagementNode.GetSize(clusterType);
                case Constants.ClusterRoleType.HIBNodeRole:
                    return DefaultVmSizes.IdBrokerNode.GetSize(clusterType);
                default:
                    throw new ArgumentOutOfRangeException("nodeType");
            }
        }

        public static string GetNodeSize(string clusterType, string nodeRoleType, Dictionary<string, Dictionary<string, string>> defaultVmSizeConfigurations)
        {
            string vmSize=GetDefaultVmSizeFromDictionary(clusterType.ToUpper(), nodeRoleType, defaultVmSizeConfigurations);
            if (vmSize == null)
            {
                vmSize = GetNodeSize(clusterType, nodeRoleType);
            }
            return vmSize;
        }

        public static SecurityProfile ConvertAzureHDInsightSecurityProfileToSecurityProfile(AzureHDInsightSecurityProfile azureHDInsightSecurityProfile, string assignedIdentity)
        {
            if (azureHDInsightSecurityProfile == null) return null;

            SecurityProfile securityProfile = new SecurityProfile(DirectoryType.ActiveDirectory);
            securityProfile.Domain = Utils.GetResourceNameFromResourceId(azureHDInsightSecurityProfile.DomainResourceId);
            securityProfile.OrganizationalUnitDN = azureHDInsightSecurityProfile.OrganizationalUnitDN;
            securityProfile.LdapsUrls = azureHDInsightSecurityProfile.LdapsUrls;
            if (azureHDInsightSecurityProfile.DomainUserCredential != null)
            {
                securityProfile.DomainUsername = azureHDInsightSecurityProfile.DomainUserCredential.UserName;
                securityProfile.DomainUserPassword = azureHDInsightSecurityProfile.DomainUserCredential.Password?.ConvertToString();
            }
            securityProfile.ClusterUsersGroupDNs = azureHDInsightSecurityProfile.ClusterUsersGroupDNs;
            securityProfile.AaddsResourceId = azureHDInsightSecurityProfile.DomainResourceId;
            securityProfile.MsiResourceId = assignedIdentity;

            return securityProfile;
        }

        private static List<ScriptAction> GetScriptActionsForRoleType(Dictionary<ClusterNodeType, List<ScriptAction>> clusterScriptActions, ClusterNodeType nodeType)
        {
            if (clusterScriptActions == null) return null;
            List<ScriptAction> scriptActions;
            clusterScriptActions.TryGetValue(nodeType, out scriptActions);
            return scriptActions;
        }

        public static Dictionary<string, string> GetExistingConfigurationsForType(IDictionary<string, Dictionary<string, string>> configurations, string configurationType)
        {
            Dictionary<string, string> config;
            if (!configurations.TryGetValue(configurationType, out config))
            {
                config = new Dictionary<string, string>();
            }

            return config;
        }

        public static bool CheckEnableKafkaRestProxy(NetworkProperties networkProperties)
        {
            return networkProperties != null;
        }

        private static void AddOrCombineConfigurations(this IDictionary<string, Dictionary<string, string>> configurations, string configKey, Dictionary<string, string> newConfigurations)
        {
            if (configurations.ContainsKey(configKey))
            {
                IEnumerable<string> duplicateConfigs = newConfigurations.Keys.Intersect(configurations[configKey].Keys);
                if (duplicateConfigs.Any())
                {
                    throw new ArgumentException(string.Format($"Configuration already specified: {string.Join(", ", duplicateConfigs)}"));
                }
                configurations[configKey] = MergedDictionaries(configurations[configKey], newConfigurations);
            }
            else
            {
                configurations.Add(configKey, newConfigurations);
            }
        }

        private static Dictionary<TKey, TValue> MergedDictionaries<TKey, TValue>(IDictionary<TKey, TValue> dict1, IDictionary<TKey, TValue> dict2)
        {
            return dict1.Union(dict2).ToDictionary(p => p.Key, p => p.Value);
        }

        private static string GetDefaultVmSizeFromDictionary(string clusterType, string nodeType, Dictionary<string, Dictionary<string, string>> defaultVmSizeConfiguration)
        {
            string vmSize = null;
            if (defaultVmSizeConfiguration != null && defaultVmSizeConfiguration.TryGetValue(nodeType, out var clusterTypeAndVmSizeDict))
            {
                if (!clusterTypeAndVmSizeDict.TryGetValue(clusterType, out vmSize))
                {
                    // backend will use the string "*" to stand for it is applicable for all clsuter type.
                    clusterTypeAndVmSizeDict.TryGetValue(Constants.ClusterType.AllClusterType, out vmSize);
                }
            }
            return vmSize;
        }
    }
}
