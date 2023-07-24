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

using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Commands.HDInsight.Models.Management;
using Azure.ResourceManager.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Xunit;
using Azure.ResourceManager.HDInsight;
using Azure.Core;
using Azure.ResourceManager.Models;
using System;
using System.DirectoryServices.AccountManagement;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class NewClusterTests : HDInsightTestBase
    {
        private NewAzureHDInsightClusterCommand cmdlet;
        private const string StorageName = "giyerwestus1.blob.core.windows.net";
        private const string StorageAccountResourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/fakerg/providers/Microsoft.Storage/storageAccounts/giyerwestus1";
        private const string DataLakeStoreName = "giyerwestus1.azuredatalakestore.net";
        private const string DataLakeStoreResourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/fakerg/providers/Microsoft.Storage/storageAccounts/giyerwestus1";
        private const string StorageKey = "O9EQvp3A3AjXq/W27rst1GQfLllhp01qlJMJfSU1hVW2K42gUeiUUn2D8zX2lU3taiXSSfqkZlcPv+nQcYUxYw==";
        private const int ClusterSize = 4;

        private readonly PSCredential _httpCred, _sshCred;

        public NewClusterTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            base.SetupTestsForManagement();
            _httpCred = new PSCredential("hadoopuser", string.Format("Password1!").ConvertToSecureString());
            _sshCred = new PSCredential("sshuser", string.Format("Password1!").ConvertToSecureString());
            cmdlet = new NewAzureHDInsightClusterCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateNewHDInsightCluster()
        {
            cmdlet.ClusterName = ClusterName;
            cmdlet.ResourceGroupName = ResourceGroupName;
            cmdlet.ClusterSizeInNodes = ClusterSize;
            cmdlet.Location = Location;
            cmdlet.HttpCredential = _httpCred;
            cmdlet.StorageAccountResourceId = StorageAccountResourceId;
            cmdlet.StorageAccountKey = StorageKey;
            cmdlet.ClusterType = ClusterType;

            var cluster = ArmHDInsightModelFactory.HDInsightClusterData(id: new ResourceIdentifier("id"), name: ClusterName, location: Location);
            cluster.Properties = new HDInsightClusterProperties(new HDInsightClusterDefinition());

            cluster.Properties.ClusterVersion = "3.6";
            cluster.Properties.ClusterState = "Running";
            cluster.Properties.ClusterDefinition.Kind = ClusterType;
            cluster.Properties.QuotaInfoCoresUsed = 24;
            cluster.Properties.OSType = "Linux";

            var coreConfigs = new Dictionary<string, string>
            {
                {"fs.defaultFS", "wasb://giyertestcsmv2@" + StorageName},
                {
                    "fs.azure.account.key." + StorageName,
                    StorageKey
                }
            };
            var gatewayConfigs = new Dictionary<string, string>
            {
                {"restAuthCredential.isEnabled", "true"},
                {"restAuthCredential.username", _httpCred.UserName},
                {"restAuthCredential.password", _httpCred.Password.ConvertToString()}
            };

            var configurations = new Dictionary<string, Dictionary<string, string>>
            {
                {"core-site", coreConfigs},
                {"gateway", gatewayConfigs}
            };
            var serializedConfig = BinaryData.FromObjectAsJson(configurations);
            cluster.Properties.ClusterDefinition.Configurations = serializedConfig;


            hdinsightManagementMock.Setup(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<HDInsightClusterCreateOrUpdateContent>(
                                         parameters => parameters.Location == Location &&
                                         parameters.Properties.ClusterDefinition.Kind == ClusterType &&
                                         parameters.Properties.OSType == "Linux"
                                         ))
                                         ).Returns(cluster).Verifiable();

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<AzureHDInsightCluster>(
                clusterout =>
                    clusterout.ClusterState == "Running" &&
                    clusterout.ClusterType == ClusterType &&
                    clusterout.ClusterVersion == "3.6" &&
                    clusterout.CoresUsed == 24 &&
                    clusterout.Location == Location &&
                    clusterout.Name == ClusterName &&
                    clusterout.OperatingSystemType.ToString() == "Linux")),
                    Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateNewHDInsightCluster_Linux()
        {
            CreateNewHDInsightCluster();

            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<AzureHDInsightCluster>(
                clusterout =>
                    clusterout.ClusterState == "Running" &&
                    clusterout.ClusterType == ClusterType &&
                    clusterout.ClusterVersion == HdiVersion &&
                    clusterout.CoresUsed == 24 &&
                    clusterout.Location == Location &&
                    clusterout.Name == ClusterName &&
                    clusterout.OperatingSystemType.ToString() == "Linux")),
                Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateNewHDInsightCluster_RServer_Linux()
        {
            ClusterType = "RServer";
            HdiVersion = "3.6";

            CreateNewHDInsightCluster(setEdgeNodeVmSize:true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateNewHDInsightCluster_Secure_Linux()
        {
            cmdlet.SecurityProfile = new AzureHDInsightSecurityProfile()
            {
                DomainResourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/fakerg/providers/Microsoft.AAD/domainServices/domain.com",
                DomainUserCredential = new PSCredential("username", "pass".ConvertToSecureString()),
                OrganizationalUnitDN = "OUDN",
                LdapsUrls = new[]
                {
                    "https://ldapsurl.test"
                },
                ClusterUsersGroupDNs = new[]
                {
                    "userGroupDn"
                }
            };

            CreateNewHDInsightCluster(addSecurityProfileInresponse:true);

            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<AzureHDInsightCluster>(
                clusterout =>
                    clusterout.ClusterState == "Running" &&
                    clusterout.ClusterType == ClusterType &&
                    clusterout.ClusterVersion == HdiVersion &&
                    clusterout.CoresUsed == 24 &&
                    clusterout.Location == Location &&
                    clusterout.Name == ClusterName &&
                    clusterout.OperatingSystemType.ToString() == "Linux" &&
                    clusterout.SecurityProfile.DomainResourceId.Equals(cmdlet.SecurityProfile.DomainResourceId) &&
                    clusterout.SecurityProfile.DomainUserCredential.UserName.Equals(
                        cmdlet.SecurityProfile.DomainUserCredential.UserName) &&
                    clusterout.SecurityProfile.OrganizationalUnitDN.Equals(cmdlet.SecurityProfile.OrganizationalUnitDN) &&
                    clusterout.SecurityProfile.LdapsUrls.ArrayToString("")
                        .Equals(cmdlet.SecurityProfile.LdapsUrls.ArrayToString("")) &&
                    clusterout.SecurityProfile.ClusterUsersGroupDNs.ArrayToString("")
                        .Equals(cmdlet.SecurityProfile.ClusterUsersGroupDNs.ArrayToString("")))),
                Times.Once);
        }

        private void CreateNewHDInsightCluster(
            bool addSecurityProfileInresponse = false, 
            bool setEdgeNodeVmSize = false,
            int workerNodeDataDisks = 0)
        {
            // Assign cmdlet parameters
            cmdlet.ClusterName = ClusterName;
            cmdlet.ResourceGroupName = ResourceGroupName;
            cmdlet.ClusterSizeInNodes = ClusterSize;
            cmdlet.Location = Location;
            cmdlet.HttpCredential = _httpCred;
            cmdlet.StorageAccountResourceId = StorageAccountResourceId;
            cmdlet.StorageAccountKey = StorageKey;
            cmdlet.ClusterType = ClusterType;
            cmdlet.SshCredential = _sshCred;
            cmdlet.DisksPerWorkerNode = workerNodeDataDisks;
            if (setEdgeNodeVmSize)
            {
                cmdlet.EdgeNodeSize = "edgeNodeVmSizeSetTest";
            }

            // Construct cluster Object
            var cluster = ArmHDInsightModelFactory.HDInsightClusterData(id: new ResourceIdentifier("id"), name: ClusterName, location: Location);
            cluster.Properties = new HDInsightClusterProperties(new HDInsightClusterDefinition());
            cluster.Properties.ClusterVersion = HdiVersion;
            cluster.Properties.ClusterState = "Running";
            cluster.Properties.ClusterDefinition.Kind = ClusterType;
            cluster.Properties.QuotaInfoCoresUsed = 24;
            cluster.Properties.OSType = "Linux";

            if (workerNodeDataDisks > 0)
            {
                HDInsightClusterRole role = new HDInsightClusterRole();
                role.Name = "workernode";
                role.DataDisksGroups.Add(new HDInsightClusterDataDiskGroup() { DisksPerNode = workerNodeDataDisks });
                cluster.Properties.ComputeRoles.Add(role);
            }

            if (addSecurityProfileInresponse)
            {
                cluster.Properties.SecurityProfile = new HDInsightSecurityProfile()
                {
                    Domain = "domain.com",
                    DomainUsername = "username",
                    DomainUserPassword = "pass",
                    OrganizationalUnitDN = "OUDN",
                    AaddsResourceId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/fakerg/providers/Microsoft.AAD/domainServices/domain.com")
                };
                cluster.Properties.SecurityProfile.LdapUris.Add(new Uri("https://ldapsurl.test"));
                cluster.Properties.SecurityProfile.ClusterUsersGroupDNs.Add("userGroupDn");
            }

            var coreConfigs = new Dictionary<string, string>
            {
                {"fs.defaultFS", "wasb://giyertestcsmv2@" + StorageName},
                {
                    "fs.azure.account.key." + StorageName,
                    StorageKey
                }
            };
            var gatewayConfigs = new Dictionary<string, string>
            {
                {"restAuthCredential.isEnabled", "true"},
                {"restAuthCredential.username", _httpCred.UserName},
                {"restAuthCredential.password", _httpCred.Password.ConvertToString()}
            };

            var configurations = new Dictionary<string, Dictionary<string, string>>
            {
                {"core-site", coreConfigs},
                {"gateway", gatewayConfigs}
            };
            var serializedConfig = BinaryData.FromObjectAsJson(configurations);
            cluster.Properties.ClusterDefinition.Configurations = serializedConfig;

            // Setup Mocks and verify successfull GET response
            hdinsightManagementMock.Setup(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<HDInsightClusterCreateOrUpdateContent>(
                             parameters => parameters.Location == Location &&
                             parameters.Properties.ClusterDefinition.Kind == ClusterType &&
                             parameters.Properties.OSType == "Linux"
                             ))
                             ).Returns(cluster).Verifiable();

            // Execute Cmdlet and verify output
            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<AzureHDInsightCluster>(
                clusterout =>
                    clusterout.ClusterState == "Running" &&
                    clusterout.ClusterType == ClusterType &&
                    clusterout.ClusterVersion == HdiVersion &&
                    clusterout.CoresUsed == 24 &&
                    clusterout.Location == Location &&
                    clusterout.Name == ClusterName &&
                    clusterout.OperatingSystemType.ToString() == "Linux" &&
                    (workerNodeDataDisks == 0) || (clusterout.WorkerNodeDataDisksGroups.First().DisksPerNode == workerNodeDataDisks))),
                    Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateNewHDInsightCluster_LinuxComponentVersion()
        {
            string sparkClusterType = "Spark";
            var componentVersion = new Dictionary<string, string>
            {
                {"Spark", "2.0"}
            };
            var componentVersionResponse = "[Spark, 2.0]";

            cmdlet.ClusterName = ClusterName;
            cmdlet.ResourceGroupName = ResourceGroupName;
            cmdlet.ClusterSizeInNodes = ClusterSize;
            cmdlet.Location = Location;
            cmdlet.HttpCredential = _httpCred;
            cmdlet.StorageAccountResourceId = StorageAccountResourceId;
            cmdlet.StorageAccountKey = StorageKey;
            cmdlet.ClusterType = "Spark";
            cmdlet.SshCredential = _sshCred;
            cmdlet.ComponentVersion = componentVersion;

            var cluster = ArmHDInsightModelFactory.HDInsightClusterData(id: new ResourceIdentifier("id"), name: ClusterName, location: Location);
            cluster.Properties = new HDInsightClusterProperties(new HDInsightClusterDefinition());

            cluster.Properties.ClusterVersion = "3.6";
            cluster.Properties.ClusterState = "Running";
            cluster.Properties.ClusterDefinition.Kind = sparkClusterType;
            cluster.Properties.QuotaInfoCoresUsed = 24;
            cluster.Properties.OSType = "Linux";
            
            foreach(var item in componentVersion)
            {
                cluster.Properties.ClusterDefinition.ComponentVersion.Add(item.Key,item.Value);
            }
            var coreConfigs = new Dictionary<string, string>
            {
                {"fs.defaultFS", "wasb://giyertestcsmv2@" + StorageName},
                {
                    "fs.azure.account.key." + StorageName,
                    StorageKey
                }
            };
            var gatewayConfigs = new Dictionary<string, string>
            {
                {"restAuthCredential.isEnabled", "true"},
                {"restAuthCredential.username", _httpCred.UserName},
                {"restAuthCredential.password", _httpCred.Password.ConvertToString()}
            };

            var configurations = new Dictionary<string, Dictionary<string, string>>
            {
                {"core-site", coreConfigs},
                {"gateway", gatewayConfigs}
            };
            var serializedConfig = BinaryData.FromObjectAsJson(configurations);
            cluster.Properties.ClusterDefinition.Configurations = serializedConfig;

            hdinsightManagementMock.Setup(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<HDInsightClusterCreateOrUpdateContent>(
                 parameters => parameters.Location == Location &&
                 parameters.Properties.ClusterDefinition.Kind == sparkClusterType &&
                 parameters.Properties.OSType == "Linux"
                 ))
                 ).Returns(cluster).Verifiable();

            hdinsightManagementMock.Setup(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<HDInsightClusterCreateOrUpdateContent>(
                             parameters => parameters.Location == Location &&
                             parameters.Properties.ClusterDefinition.Kind == ClusterType &&
                             parameters.Properties.OSType == "Linux"
                             )))
                .Returns(cluster)
                .Verifiable();

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<AzureHDInsightCluster>(
                clusterout =>
                    clusterout.ClusterState == "Running" &&
                    clusterout.ClusterType == sparkClusterType &&
                    clusterout.ClusterVersion == "3.6" &&
                    clusterout.CoresUsed == 24 &&
                    clusterout.Location == Location &&
                    clusterout.Name == ClusterName &&
                    clusterout.OperatingSystemType == "Linux" &&
                    clusterout.ComponentVersion[0] == componentVersionResponse)),
                    Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateNewHDInsightCluster_Kafka_DataDisks_Linux()
        {
            ClusterType = "Kafka";
            HdiVersion = "3.6";

            CreateNewHDInsightCluster(workerNodeDataDisks: 8);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateNewHDInsightCluster_Disk_Encryption()
        {
            string AssignedIdentity = "/subscriptions/00000000-aaaa-bbbb-cccc-dddddddddddd/resourcegroups/group-unittest/providers/microsoft.managedidentity/userassignedidentities/ami-unittest";
            string EncryptionVaultUri = "https://vault-unittest.vault.azure.net:443";
            string EncryptionKeyVersion = "00000000000000000000000000000000";
            string EncryptionKeyName = "key-unittest";
            string EncryptionAlgorithm = "RSA-OAEP";
            string sparkClusterType = "Spark";

            cmdlet.ClusterName = ClusterName;
            cmdlet.ResourceGroupName = ResourceGroupName;
            cmdlet.ClusterSizeInNodes = ClusterSize;
            cmdlet.Location = Location;
            cmdlet.HttpCredential = _httpCred;
            cmdlet.StorageAccountResourceId = StorageAccountResourceId;
            cmdlet.StorageAccountKey = StorageKey;
            cmdlet.ClusterType = "Spark";
            cmdlet.SshCredential = _sshCred;
            cmdlet.EncryptionAlgorithm = EncryptionAlgorithm;
            cmdlet.EncryptionKeyName = EncryptionKeyName;
            cmdlet.EncryptionKeyVersion = EncryptionKeyVersion;
            cmdlet.EncryptionVaultUri = EncryptionVaultUri;
            cmdlet.AssignedIdentity = AssignedIdentity;

            var ClusterIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            ClusterIdentity.UserAssignedIdentities.Add(new ResourceIdentifier(AssignedIdentity), new UserAssignedIdentity());
            var cluster = ArmHDInsightModelFactory.HDInsightClusterData(id: new ResourceIdentifier("id"), name: ClusterName, location: Location, identity:ClusterIdentity);
            cluster.Properties = new HDInsightClusterProperties(new HDInsightClusterDefinition());

            cluster.Properties.ClusterVersion = "3.6";
            cluster.Properties.ClusterState = "Running";
            cluster.Properties.ClusterDefinition.Kind = sparkClusterType;
            cluster.Properties.QuotaInfoCoresUsed = 24;
            cluster.Properties.OSType = "Linux";

            cluster.Properties.DiskEncryptionProperties = new HDInsightDiskEncryptionProperties();
            cluster.Properties.DiskEncryptionProperties.KeyName = EncryptionKeyName;
            cluster.Properties.DiskEncryptionProperties.KeyVersion = EncryptionKeyVersion;
            cluster.Properties.DiskEncryptionProperties.VaultUri = new Uri(EncryptionVaultUri);
            cluster.Properties.DiskEncryptionProperties.EncryptionAlgorithm = EncryptionAlgorithm;
            cluster.Properties.DiskEncryptionProperties.MsiResourceId = new ResourceIdentifier(AssignedIdentity);

            var coreConfigs = new Dictionary<string, string>
            {
                {"fs.defaultFS", "wasb://giyertestcsmv2@" + StorageName},
                {
                    "fs.azure.account.key." + StorageName,
                    StorageKey
                }
            };
            var gatewayConfigs = new Dictionary<string, string>
            {
                {"restAuthCredential.isEnabled", "true"},
                {"restAuthCredential.username", _httpCred.UserName},
                {"restAuthCredential.password", _httpCred.Password.ConvertToString()}
            };

            var configurations = new Dictionary<string, Dictionary<string, string>>
            {
                {"core-site", coreConfigs},
                {"gateway", gatewayConfigs}
            };
            var serializedConfig = BinaryData.FromObjectAsJson(configurations);
            cluster.Properties.ClusterDefinition.Configurations = serializedConfig;

            hdinsightManagementMock.Setup(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<HDInsightClusterCreateOrUpdateContent>(
                 parameters => parameters.Location == Location &&
                 parameters.Properties.ClusterDefinition.Kind == sparkClusterType &&
                 parameters.Properties.OSType == "Linux"
                 ))
                 ).Returns(cluster).Verifiable();

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<AzureHDInsightCluster>(
                clusterout =>
                    clusterout.ClusterState == "Running" &&
                    clusterout.ClusterType == sparkClusterType &&
                    clusterout.ClusterVersion == "3.6" &&
                    clusterout.CoresUsed == 24 &&
                    clusterout.Location == Location &&
                    clusterout.Name == ClusterName &&
                    clusterout.OperatingSystemType.ToString() == "Linux" &&
                    clusterout.DiskEncryption.KeyName == EncryptionKeyName &&
                    clusterout.DiskEncryption.KeyVersion == EncryptionKeyVersion &&
                    clusterout.DiskEncryption.VaultUri.OriginalString == EncryptionVaultUri &&
                    clusterout.DiskEncryption.EncryptionAlgorithm == EncryptionAlgorithm &&
                    clusterout.DiskEncryption.MsiResourceId == AssignedIdentity &&
                    clusterout.AssignedIdentity.Type == ManagedServiceIdentityType.UserAssigned &&
                    clusterout.AssignedIdentity.UserAssignedIdentities.ContainsKey(new ResourceIdentifier(AssignedIdentity))
                    )),Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageAccountTypeDefaultsToAzureStorage()
        {
            cmdlet.ClusterName = ClusterName;
            cmdlet.ResourceGroupName = ResourceGroupName;
            cmdlet.ClusterSizeInNodes = ClusterSize;
            cmdlet.Location = Location;
            cmdlet.HttpCredential = _httpCred;
            cmdlet.StorageAccountResourceId = StorageAccountResourceId;
            cmdlet.StorageAccountKey = StorageKey;
            cmdlet.ClusterType = ClusterType;

            hdinsightManagementMock.Setup(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<HDInsightClusterCreateOrUpdateContent>(
                             parameters => parameters.Location == Location &&
                             parameters.Properties.ClusterDefinition.Kind == ClusterType &&
                             parameters.Properties.OSType == "Linux"
                             )));

            cmdlet.ExecuteCmdlet();

            hdinsightManagementMock.Verify(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<HDInsightClusterCreateOrUpdateContent>(
                             parameters => parameters.Location == Location &&
                             parameters.Properties.ClusterDefinition.Kind == ClusterType &&
                             parameters.Properties.OSType == "Linux"
                             )),
                Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageAccountTypeAzureStorage()
        {
            cmdlet.ClusterName = ClusterName;
            cmdlet.ResourceGroupName = ResourceGroupName;
            cmdlet.ClusterSizeInNodes = ClusterSize;
            cmdlet.Location = Location;
            cmdlet.HttpCredential = _httpCred;
            cmdlet.StorageAccountResourceId = StorageAccountResourceId;
            cmdlet.StorageAccountKey = StorageKey;
            cmdlet.ClusterType = ClusterType;
            cmdlet.StorageAccountType = StorageType.AzureStorage;

            hdinsightManagementMock.Setup(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<HDInsightClusterCreateOrUpdateContent>(
                             parameters => parameters.Location == Location &&
                             parameters.Properties.ClusterDefinition.Kind == ClusterType &&
                             parameters.Properties.OSType == "Linux"
                             )));

            cmdlet.ExecuteCmdlet();

            hdinsightManagementMock.Verify(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<HDInsightClusterCreateOrUpdateContent>(
                             parameters => parameters.Location == Location &&
                             parameters.Properties.ClusterDefinition.Kind == ClusterType &&
                             parameters.Properties.OSType == "Linux"
                             )),
                Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageAccountTypeAzureDataLakeStore()
        {
            string StorageRootPath = "/Clusters/cluster01";
            cmdlet.ClusterName = ClusterName;
            cmdlet.ResourceGroupName = ResourceGroupName;
            cmdlet.ClusterSizeInNodes = ClusterSize;
            cmdlet.Location = Location;
            cmdlet.HttpCredential = _httpCred;
            cmdlet.StorageAccountResourceId = DataLakeStoreResourceId;
            cmdlet.StorageRootPath = StorageRootPath;
            cmdlet.ClusterType = ClusterType;
            cmdlet.StorageAccountType = StorageType.AzureDataLakeStore;

            hdinsightManagementMock.Setup(c => c.CreateCluster(ResourceGroupName, ClusterName, It.IsAny<HDInsightClusterCreateOrUpdateContent>()));

            cmdlet.ExecuteCmdlet();

            hdinsightManagementMock.Verify(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<HDInsightClusterCreateOrUpdateContent>(
                             parameters => parameters.Location == Location &&
                             parameters.Properties.ClusterDefinition.Kind == ClusterType &&
                             parameters.Properties.OSType == "Linux"
                             )),
                Times.Once);
        }
    }
}
