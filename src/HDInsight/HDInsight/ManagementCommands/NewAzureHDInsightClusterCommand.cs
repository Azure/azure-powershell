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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Commands.HDInsight.Models.Management;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightCluster", DefaultParameterSetName = DefaultParameterSet), OutputType(typeof(AzureHDInsightCluster))]
    public class NewAzureHDInsightClusterCommand : HDInsightCmdletBase
    {
        private Dictionary<string, Dictionary<string, string>> clusterConfigurations;
        private Dictionary<string, string> clusterComponentVersion;
        private Dictionary<string, string> clusterAdditionalStorageAccounts;
        private Dictionary<ClusterNodeType, List<ScriptAction>> clusterScriptActions;
        private const string CertificateFilePathSet = "CertificateFilePath";
        private const string CertificateFileContentsSet = "CertificateFileContents";
        private const string DefaultParameterSet = "Default";

        #region These fields are marked obsolete in ClusterCreateParameters
        private OSType? _osType;
        #endregion

        #region Input Parameter Definitions

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Gets or sets the datacenter location for the cluster.")]
        [LocationCompleter("Microsoft.HDInsight/clusters")]
        public string Location { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the resource group.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the cluster.")]
        public string ClusterName { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            HelpMessage = "Gets or sets the number of workernodes for the cluster.")]
        public int ClusterSizeInNodes { get; set; }

        [Parameter(
            Position = 4,
            Mandatory = true,
            HelpMessage = "Gets or sets the login for the cluster's user.")]
        public PSCredential HttpCredential { get; set; }

        [Parameter(
            Position = 5,
            HelpMessage = "Gets or sets the Storage Resource Id for the Storage Account.")]
        public string StorageAccountResourceId { get; set; }

        [Parameter(
            Position = 6,
            HelpMessage = "Gets or sets the Storage Account Access Key for the Storage Account.")]
        public string StorageAccountKey { get; set; }

        [Parameter(
            HelpMessage = "Gets or sets the type of the storage account.")]
        public StorageType? StorageAccountType { get; set; }

        [Parameter(ValueFromPipeline = true,
            HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster.")]
        public AzureHDInsightConfig Config
        {
            get
            {
                var result = new AzureHDInsightConfig
                {
                    ClusterType = ClusterType,
                    ClusterTier = ClusterTier,
                    StorageAccountType = StorageAccountType ?? StorageType.AzureStorage,
                    StorageAccountResourceId = StorageAccountResourceId,
                    StorageAccountKey = StorageAccountKey,
                    WorkerNodeSize = WorkerNodeSize,
                    HeadNodeSize = HeadNodeSize,
                    EdgeNodeSize = EdgeNodeSize,
                    ZookeeperNodeSize = ZookeeperNodeSize,
                    HiveMetastore = HiveMetastore,
                    OozieMetastore = OozieMetastore,
                    AmbariDatabase = AmbariDatabase,
                    ObjectId = ObjectId,
                    ApplicationId = ApplicationId,
                    AADTenantId = AadTenantId,
                    CertificateFileContents = CertificateFileContents,
                    CertificateFilePath = CertificateFilePath,
                    CertificatePassword = CertificatePassword,
                    SecurityProfile = SecurityProfile,
                    DisksPerWorkerNode = DisksPerWorkerNode,
                    MinSupportedTlsVersion = MinSupportedTlsVersion,
                    AssignedIdentity = AssignedIdentity,
                    EncryptionAlgorithm = EncryptionAlgorithm,
                    EncryptionKeyName = EncryptionKeyName,
                    EncryptionKeyVersion = EncryptionKeyVersion,
                    EncryptionVaultUri = EncryptionVaultUri,
                    EncryptionInTransit = EncryptionInTransit,
                    EncryptionAtHost = EncryptionAtHost
                };
                foreach (
                    var storageAccount in
                        clusterAdditionalStorageAccounts.Where(
                            storageAccount => !result.AdditionalStorageAccounts.ContainsKey(storageAccount.Key)))
                {
                    result.AdditionalStorageAccounts.Add(storageAccount.Key, storageAccount.Value);
                }
                foreach (var val in clusterConfigurations.Where(val => !result.Configurations.ContainsKey(val.Key)))
                {
                    result.Configurations.Add(val.Key, DictionaryToHashtable(val.Value));
                }
                foreach (var action in clusterScriptActions.Where(action => !result.ScriptActions.ContainsKey(action.Key)))
                {
                    result.ScriptActions.Add(action.Key, action.Value.Select(a => new AzureHDInsightScriptAction(a)).ToList());
                }
                foreach (var component in clusterComponentVersion.Where(component => !result.ComponentVersion.ContainsKey(component.Key)))
                {
                    result.ComponentVersion.Add(component.Key, component.Value);
                }

                return result;
            }
            set
            {
                ClusterType = value.ClusterType;
                ClusterTier = value.ClusterTier;
                if (StorageAccountType == null)
                {
                    StorageAccountType = value.StorageAccountType;
                }
                if (string.IsNullOrWhiteSpace(StorageAccountResourceId))
                {
                    StorageAccountResourceId = value.StorageAccountResourceId;
                }
                if (string.IsNullOrWhiteSpace(StorageAccountKey))
                {
                    StorageAccountKey = value.StorageAccountKey;
                }
                WorkerNodeSize = value.WorkerNodeSize;
                HeadNodeSize = value.HeadNodeSize;
                EdgeNodeSize = value.EdgeNodeSize;
                ZookeeperNodeSize = value.ZookeeperNodeSize;
                HiveMetastore = value.HiveMetastore;
                OozieMetastore = value.OozieMetastore;
                AmbariDatabase = value.AmbariDatabase;
                CertificateFileContents = value.CertificateFileContents;
                CertificateFilePath = value.CertificateFilePath;
                AadTenantId = value.AADTenantId;
                ObjectId = value.ObjectId;
                ApplicationId = value.ApplicationId;
                CertificatePassword = value.CertificatePassword;
                SecurityProfile = value.SecurityProfile;
                DisksPerWorkerNode = value.DisksPerWorkerNode;
                MinSupportedTlsVersion = value.MinSupportedTlsVersion;
                AssignedIdentity = value.AssignedIdentity;
                EncryptionAlgorithm = value.EncryptionAlgorithm;
                EncryptionKeyName = value.EncryptionKeyName;
                EncryptionKeyVersion = value.EncryptionKeyVersion;
                EncryptionVaultUri = value.EncryptionVaultUri;
                EncryptionInTransit = value.EncryptionInTransit;
                EncryptionAtHost = value.EncryptionAtHost;

                foreach (
                    var storageAccount in
                        value.AdditionalStorageAccounts.Where(
                            storageAccount => !clusterAdditionalStorageAccounts.ContainsKey(storageAccount.Key)))
                {
                    clusterAdditionalStorageAccounts.Add(storageAccount.Key, storageAccount.Value);
                }
                foreach (var val in value.Configurations.Where(val => !clusterConfigurations.ContainsKey(val.Key)))
                {
                    clusterConfigurations.Add(val.Key, HashtableToDictionary(val.Value));
                }
                foreach (var action in value.ScriptActions.Where(action => !clusterScriptActions.ContainsKey(action.Key)))
                {
                    clusterScriptActions.Add(action.Key, action.Value.Select(a => a.GetScriptActionFromPSModel()).ToList());
                }
                foreach (var component in value.ComponentVersion.Where(component => !clusterComponentVersion.ContainsKey(component.Key)))
                {
                    clusterComponentVersion.Add(component.Key, component.Value);
                }
            }
        }

        [Parameter(HelpMessage = "Gets or sets the database to store the metadata for Oozie.")]
        public AzureHDInsightMetastore OozieMetastore { get; set; }

        [Parameter(HelpMessage = "Gets or sets the database to store the metadata for Hive.")]
        public AzureHDInsightMetastore HiveMetastore { get; set; }

        [Parameter(HelpMessage = "Gets or sets the database for ambari.")]
        public AzureHDInsightMetastore AmbariDatabase { get; set; }

        [Parameter(HelpMessage = "Gets additional Azure Storage Account that you want to enable access to.")]
        public Dictionary<string, string> AdditionalStorageAccounts { get; private set; }

        [Parameter(HelpMessage = "Gets the configurations of this HDInsight cluster.")]
        public Dictionary<string, Dictionary<string, string>> Configurations { get; private set; }

        [Parameter(HelpMessage = "Gets config actions for the cluster.")]
        public Dictionary<ClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions { get; private set; }

        [Parameter(HelpMessage = "Gets or sets the StorageContainer name for the default Azure Storage Account")]
        public string StorageContainer { get; set; }

        [Parameter(HelpMessage = "Gets or sets the path to the root of the cluster in the default Data Lake Store Account.")]
        public string StorageRootPath { get; set; }

        [Parameter(HelpMessage = "Gets or sets the file system for the default Azure Data Lake Storage Gen2 account.")]
        public string StorageFileSystem { get; set; }

        [Parameter(HelpMessage = "Gets or sets the version of the HDInsight cluster.")]
        public string Version { get; set; }

        [Parameter(HelpMessage = "Gets or sets the size of the Head Node.")]
        public string HeadNodeSize { get; set; }

        [Parameter(HelpMessage = "Gets or sets the size of the Data Node.")]
        public string WorkerNodeSize { get; set; }

        [Parameter(HelpMessage = "Gets or sets the size of the Edge Node if available for the cluster type.")]
        public string EdgeNodeSize { get; set; }

        [Parameter(HelpMessage = "Gets or sets the size of the Kafka Management Node.")]
        public string KafkaManagementNodeSize { get; set; }

        [Parameter(HelpMessage = "Gets or sets the size of the Zookeeper Node.")]
        public string ZookeeperNodeSize { get; set; }

        [Parameter(HelpMessage = "Gets or sets the flavor for a cluster.")]
        public string ClusterType { get; set; }

        [Parameter(HelpMessage = "Gets or sets the version for a service in the cluster.")]
        public Dictionary<string, string> ComponentVersion { get; set; }

        [Parameter(HelpMessage = "Gets or sets the virtual network guid for this HDInsight cluster.")]
        public string VirtualNetworkId { get; set; }

        [Parameter(HelpMessage = "Gets or sets the subnet name for this HDInsight cluster.")]
        public string SubnetName { get; set; }

        [Parameter(HelpMessage = "Gets or sets the type of operating system installed on cluster nodes.")]
        public OSType OSType
        {
            get { return _osType ?? OSType.Linux; }
            set { _osType = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the cluster tier for this HDInsight cluster.")]
        public Tier ClusterTier { get; set; }

        [Parameter(HelpMessage = "Gets or sets SSH credential.")]
        public PSCredential SshCredential { get; set; }

        [Parameter(HelpMessage = "Gets or sets the public key to be used for SSH.")]
        public string SshPublicKey { get; set; }

        [CmdletParameterBreakingChange("RdpCredential", ChangeDescription = "This parameter is being deprecated.")]
        [Parameter(HelpMessage = "Gets or sets the credential for RDP access to the cluster.")]
        public PSCredential RdpCredential { get; set; }

        [CmdletParameterBreakingChange("RdpAccessExpiry", ChangeDescription = "This parameter is being deprecated.")]
        [Parameter(HelpMessage = "Gets or sets the expiry DateTime for RDP access on the cluster.")]
        public DateTime RdpAccessExpiry { get; set; }

        [Parameter(HelpMessage = "Gets or sets the Service Principal Object Id for accessing Azure Data Lake.")]
        public Guid ObjectId { get; set; }

        [Parameter(HelpMessage = "Gets or sets the Service Principal Application Id for accessing Azure Data Lake.")]
        public Guid ApplicationId { get; set; }

        [Parameter(HelpMessage = "Gets or sets the Service Principal Certificate file path for accessing Azure Data Lake.",
            ParameterSetName = CertificateFilePathSet)]
        public string CertificateFilePath { get; set; }

        [Parameter(HelpMessage = "Gets or sets the Service Principal Certificate file contents for accessing Azure Data Lake.",
            ParameterSetName = CertificateFileContentsSet)]
        public byte[] CertificateFileContents { get; set; }

        [Parameter(HelpMessage = "Gets or sets the Service Principal Certificate Password for accessing Azure Data Lake.")]
        public string CertificatePassword { get; set; }

        [Parameter(HelpMessage = "Gets or sets the Service Principal AAD Tenant Id for accessing Azure Data Lake.")]
        public Guid AadTenantId { get; set; }

        [Parameter(HelpMessage = "Gets or sets Security Profile which is used for creating secure cluster.")]
        public AzureHDInsightSecurityProfile SecurityProfile { get; set; }

        [Parameter(HelpMessage = "Gets or sets the number of disks for worker node role in the cluster.")]
        public int DisksPerWorkerNode { get; set; }

        [Parameter(HelpMessage = "Gets or sets the minimal supported TLS version.")]
        public string MinSupportedTlsVersion { get; set; }

        [Parameter(HelpMessage = "Gets or sets the cluster assigned identity.")]
        public string AssignedIdentity { get; set; }

        [Parameter(HelpMessage = "Gets or sets the storage account managed identity.")]
        public string StorageAccountManagedIdentity { get; set; }

        [Parameter(HelpMessage = "Gets or sets the encryption algorithm.")]
        [ValidateSet(JsonWebKeyEncryptionAlgorithm.RSAOAEP, JsonWebKeyEncryptionAlgorithm.RSAOAEP256, JsonWebKeyEncryptionAlgorithm.RSA15)]
        public string EncryptionAlgorithm { get; set; }

        [Parameter(HelpMessage = "Gets or sets the encryption key name.")]
        public string EncryptionKeyName { get; set; }

        [Parameter(HelpMessage = "Gets or sets the encryption key version.")]
        public string EncryptionKeyVersion { get; set; }

        [Parameter(HelpMessage = "Gets or sets the encryption vault uri.")]
        public string EncryptionVaultUri { get; set; }

        [Parameter(HelpMessage = "Gets or sets the flag which indicates whether enable encryption in transit or not.")]
        public bool? EncryptionInTransit { get; set; }

        [Parameter(HelpMessage = "Gets or sets the flag which indicates whether enable encryption at host or not.")]
        public bool? EncryptionAtHost { get; set; }

        [Parameter(HelpMessage = "Gets or sets the autoscale configuration")]
        public AzureHDInsightAutoscale AutoscaleConfiguration { get; set; }

        [Parameter(HelpMessage = "Enables HDInsight Identity Broker feature.")]
        public SwitchParameter EnableIDBroker { get; set; }

        [Parameter(HelpMessage = "Gets or sets the client group id for Kafka Rest Proxy access.")]
        public string KafkaClientGroupId { get; set; }

        [Parameter(HelpMessage = "Gets or sets the client group name for Kafka Rest Proxy access.")]
        public string KafkaClientGroupName { get; set; }

        [Parameter(HelpMessage = "Gets or sets the resource provider connection type.")]
        [ValidateSet(Management.HDInsight.Models.ResourceProviderConnection.Inbound, Management.HDInsight.Models.ResourceProviderConnection.Outbound)]
        public string ResourceProviderConnection { get; set; }

        [Parameter(HelpMessage = "Gets or sets the private link type.")]
        [ValidateSet(Management.HDInsight.Models.PrivateLink.Enabled, Management.HDInsight.Models.PrivateLink.Disabled)]
        public string PrivateLink { get; set; }

        [Parameter(HelpMessage = "Enables HDInsight compute isolation feature.")]
        public SwitchParameter EnableComputeIsolation { get; set; }

        [Parameter(HelpMessage = "Gets or sets the dedicated host sku for compute isolation.")]
        public string ComputeIsolationHostSku { get; set; }


        #endregion

        public NewAzureHDInsightClusterCommand()
        {
            AdditionalStorageAccounts = new Dictionary<string, string>();
            clusterAdditionalStorageAccounts = new Dictionary<string, string>();
            Configurations = new Dictionary<string, Dictionary<string, string>>();
            clusterConfigurations = new Dictionary<string, Dictionary<string, string>>();
            ScriptActions = new Dictionary<ClusterNodeType, List<AzureHDInsightScriptAction>>();
            clusterScriptActions = new Dictionary<ClusterNodeType, List<ScriptAction>>();
            ComponentVersion = new Dictionary<string, string>();
            clusterComponentVersion = new Dictionary<string, string>();
        }

        public override void ExecuteCmdlet()
        {
            foreach (var component in ComponentVersion.Where(component => !clusterComponentVersion.ContainsKey(component.Key)))
            {
                clusterComponentVersion.Add(component.Key, component.Value);
            }
            // Construct Configurations
            foreach (var config in Configurations.Where(config => !clusterConfigurations.ContainsKey(config.Key)))
            {
                clusterConfigurations.Add(config.Key, config.Value);
            }

            // Add cluster username/password to gateway config.
            ClusterCreateHelper.AddClusterCredentialToGatewayConfig(HttpCredential, clusterConfigurations);

            // Construct OS Profile
            OsProfile osProfile = ClusterCreateHelper.CreateOsProfile(SshCredential, SshPublicKey);

            // Construct Virtual Network Profile
            VirtualNetworkProfile vnetProfile = ClusterCreateHelper.CreateVirtualNetworkProfile(VirtualNetworkId, SubnetName);

            // Handle storage account
            StorageProfile storageProfile = new StorageProfile() { Storageaccounts = new List<StorageAccount> { } };

            if (StorageAccountType == null || StorageAccountType == StorageType.AzureStorage)
            {
                var azureStorageAccount = ClusterCreateHelper.CreateAzureStorageAccount(ClusterName, StorageAccountResourceId, StorageAccountKey, StorageContainer, this.DefaultContext.Environment.StorageEndpointSuffix);
                storageProfile.Storageaccounts.Add(azureStorageAccount);
            }
            else if (StorageAccountType == StorageType.AzureDataLakeStore)
            {
                ClusterCreateHelper.AddAzureDataLakeStorageGen1ToCoreConfig(StorageAccountResourceId, StorageRootPath, this.DefaultContext.Environment.AzureDataLakeStoreFileSystemEndpointSuffix, clusterConfigurations);
            }
            else if (StorageAccountType == StorageType.AzureDataLakeStorageGen2)
            {
                var adlsgen2Account = ClusterCreateHelper.CreateAdlsGen2StorageAccount(ClusterName, StorageAccountResourceId, StorageAccountKey, StorageFileSystem, StorageAccountManagedIdentity, this.DefaultContext.Environment.StorageEndpointSuffix);
                storageProfile.Storageaccounts.Add(adlsgen2Account);
            }

            // Handle additional storage accounts
            foreach (
                var storageAccount in
                    AdditionalStorageAccounts.Where(
                        storageAccount => !clusterAdditionalStorageAccounts.ContainsKey(storageAccount.Key)))
            {
                clusterAdditionalStorageAccounts.Add(storageAccount.Key, storageAccount.Value);
            }
            ClusterCreateHelper.AddAdditionalStorageAccountsToCoreConfig(clusterAdditionalStorageAccounts, clusterConfigurations);

            // Handle script action
            foreach (var action in ScriptActions.Where(action => clusterScriptActions.ContainsKey(action.Key)))
            {
                clusterScriptActions.Add(action.Key,
                    action.Value.Select(a => a.GetScriptActionFromPSModel()).ToList());
            }

            // Handle metastore
            if (OozieMetastore != null)
            {
                ClusterCreateHelper.AddOozieMetastoreToConfigurations(OozieMetastore, clusterConfigurations);
            }
            if (HiveMetastore != null)
            {
                ClusterCreateHelper.AddHiveMetastoreToConfigurations(HiveMetastore, clusterConfigurations);
            }

            // Handle Custom Ambari Database
            if (AmbariDatabase != null)
            {
                ClusterCreateHelper.AddCustomAmbariDatabaseToConfigurations(AmbariDatabase, clusterConfigurations);
            }

            // Handle ADLSGen1 identity
            if (!string.IsNullOrEmpty(CertificatePassword))
            {
                if (!string.IsNullOrEmpty(CertificateFilePath))
                {
                    CertificateFileContents = File.ReadAllBytes(CertificateFilePath);
                }

                ClusterCreateHelper.AddDataLakeStorageGen1IdentityToIdentityConfig(
                    GetApplicationId(ApplicationId), GetTenantId(AadTenantId), CertificateFileContents, CertificatePassword, clusterConfigurations,
                    this.DefaultContext.Environment.ActiveDirectoryAuthority, this.DefaultContext.Environment.DataLakeEndpointResourceId);
            }

            // Handle Kafka Rest Proxy
            KafkaRestProperties kafkaRestProperties = null;
            if (KafkaClientGroupId != null && KafkaClientGroupName != null)
            {
                kafkaRestProperties = new KafkaRestProperties()
                {
                    ClientGroupInfo = new ClientGroupInfo(KafkaClientGroupName, KafkaClientGroupId)
                };
            }

            // Compute profile contains headnode, workernode, zookeepernode, edgenode, kafkamanagementnode, idbrokernode, etc.
            ComputeProfile computeProfile = ClusterCreateHelper.CreateComputeProfile(osProfile, vnetProfile, clusterScriptActions, ClusterType, ClusterSizeInNodes, HeadNodeSize, WorkerNodeSize, ZookeeperNodeSize, EdgeNodeSize, KafkaManagementNodeSize, EnableIDBroker.IsPresent);

            // Handle SecurityProfile
            SecurityProfile securityProfile = ClusterCreateHelper.ConvertAzureHDInsightSecurityProfileToSecurityProfile(SecurityProfile, AssignedIdentity);

            // Handle DisksPerWorkerNode feature
            Role workerNode = Utils.ExtractRole(ClusterNodeType.WorkerNode.ToString(), computeProfile);
            if (DisksPerWorkerNode > 0)
            {
                workerNode.DataDisksGroups = new List<DataDisksGroups>()
                {
                    new DataDisksGroups()
                    {
                        DisksPerNode = DisksPerWorkerNode
                    }
                };
            }

            // Handle ClusterIdentity
            ClusterIdentity clusterIdentity = null;
            if (AssignedIdentity != null || StorageAccountManagedIdentity != null)
            {
                clusterIdentity = new ClusterIdentity
                {
                    Type = ResourceIdentityType.UserAssigned,
                    UserAssignedIdentities = new Dictionary<string, ClusterIdentityUserAssignedIdentitiesValue>()
                };
                if (AssignedIdentity != null)
                {
                    clusterIdentity.UserAssignedIdentities.Add(AssignedIdentity, new ClusterIdentityUserAssignedIdentitiesValue());
                }
                if (StorageAccountManagedIdentity != null)
                {
                    clusterIdentity.UserAssignedIdentities.Add(StorageAccountManagedIdentity, new ClusterIdentityUserAssignedIdentitiesValue());
                }
            }

            // Handle CMK feature
            DiskEncryptionProperties diskEncryptionProperties = null;
            if (EncryptionKeyName != null && EncryptionKeyVersion != null && EncryptionVaultUri != null)
            {
                diskEncryptionProperties = new DiskEncryptionProperties()
                {
                    KeyName = EncryptionKeyName,
                    KeyVersion = EncryptionKeyVersion,
                    VaultUri = EncryptionVaultUri,
                    EncryptionAlgorithm = EncryptionAlgorithm != null ? EncryptionAlgorithm : JsonWebKeyEncryptionAlgorithm.RSAOAEP,
                    MsiResourceId = AssignedIdentity
                };
            }

            // Handle encryption at host feature
            if (EncryptionAtHost != null)
            {
                if (diskEncryptionProperties != null)
                {
                    diskEncryptionProperties.EncryptionAtHost = EncryptionAtHost;
                }
                else
                {
                    diskEncryptionProperties = new DiskEncryptionProperties()
                    {
                        EncryptionAtHost = EncryptionAtHost
                    };
                }
            }

            // Handle autoscale featurer
            Autoscale autoscaleParameter = null;
            if (AutoscaleConfiguration != null)
            {
                autoscaleParameter = AutoscaleConfiguration.ToAutoscale();
                workerNode.AutoscaleConfiguration = autoscaleParameter;
            }

            // Handle relay outound and private link feature
            NetworkProperties networkProperties = null;
            if (ResourceProviderConnection != null || PrivateLink != null)
            {
                networkProperties = new NetworkProperties(ResourceProviderConnection, PrivateLink);
            }

            // Handle compute isolation properties
            ComputeIsolationProperties computeIsolationProperties = null;
            if (EnableComputeIsolation.IsPresent)
            {
                computeIsolationProperties = new ComputeIsolationProperties(EnableComputeIsolation.IsPresent, ComputeIsolationHostSku);
            }

            // Construct cluster create parameter
            ClusterCreateParametersExtended createParams = new ClusterCreateParametersExtended
            {
                Location = Location,
                //Tags = Tags,  //To Do add this Tags parameter
                Properties = new ClusterCreateProperties
                {
                    Tier = ClusterTier,
                    ClusterDefinition = new ClusterDefinition
                    {
                        Kind = ClusterType ?? "Hadoop",
                        ComponentVersion = clusterComponentVersion,
                        Configurations = clusterConfigurations
                    },
                    ClusterVersion = Version ?? "default",
                    KafkaRestProperties = kafkaRestProperties,
                    ComputeProfile = computeProfile,
                    OsType = OSType,
                    SecurityProfile = securityProfile,
                    StorageProfile = storageProfile,
                    DiskEncryptionProperties = diskEncryptionProperties,
                    //handle Encryption In Transit feature
                    EncryptionInTransitProperties = EncryptionInTransit != null ? new EncryptionInTransitProperties()
                    {
                        IsEncryptionInTransitEnabled = EncryptionInTransit
                    } : null,
                    MinSupportedTlsVersion = MinSupportedTlsVersion,
                    NetworkProperties = networkProperties,
                    ComputeIsolationProperties= computeIsolationProperties

                },
                Identity = clusterIdentity
            };

            var cluster = HDInsightManagementClient.CreateCluster(ResourceGroupName, ClusterName, createParams);

            if (cluster != null)
            {
                WriteObject(new AzureHDInsightCluster(cluster));
            }
        }

        private static Hashtable DictionaryToHashtable(Dictionary<string, string> dictionary)
        {
            return new Hashtable(dictionary);
        }

        private static Dictionary<string, string> HashtableToDictionary(Hashtable table)
        {
            return table
              .Cast<DictionaryEntry>()
              .ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value);
        }

        // Get TenantId for the subscription if user doesn't provide this parameter
        private Guid GetTenantId(Guid tenantId)
        {
            if (tenantId != Guid.Empty)
            {
                return tenantId;
            }

            var tenantIdStr = DefaultProfile.DefaultContext.Subscription.GetPropertyAsArray(AzureSubscription.Property.Tenants).FirstOrDefault();
            return new Guid(tenantIdStr);
        }

        // Get ApplicationId of Service Principal if user doesn't provide this parameter
        private Guid GetApplicationId(Guid applicationId)
        {
            if (applicationId != Guid.Empty)
            {
                return applicationId;
            }

            GraphRbacManagementClient graphClient = AzureSession.Instance.ClientFactory.CreateArmClient<GraphRbacManagementClient>(
                DefaultProfile.DefaultContext, AzureEnvironment.Endpoint.Graph);

            graphClient.TenantID = DefaultProfile.DefaultContext.Tenant.Id.ToString();

            Microsoft.Azure.Graph.RBAC.Version1_6.Models.ServicePrincipal sp = null;
            try
            {
                sp = graphClient.ServicePrincipals.Get(ObjectId.ToString());
            }
            catch (Microsoft.Azure.Graph.RBAC.Version1_6.Models.GraphErrorException e)
            {
                string errorMessage = e.Message + ". Please specify Application Id explicitly by providing ApplicationId parameter and retry.";
                throw new Microsoft.Azure.Graph.RBAC.Version1_6.Models.GraphErrorException(errorMessage);
            }

            var spApplicationId = Guid.Empty;
            Guid.TryParse(sp.AppId, out spApplicationId);
            Debug.Assert(spApplicationId != Guid.Empty);
            return spApplicationId;
        }
    }
}
