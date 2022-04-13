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
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Xunit;

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

            var cluster = new Cluster(id: "id", name: ClusterName, location: Location)
            {
                Location = Location,
                Properties = new ClusterGetProperties
                {
                    ClusterVersion = "3.6",
                    ClusterState = "Running",
                    ClusterDefinition = new ClusterDefinition
                    {
                        Kind = ClusterType
                    },
                    QuotaInfo = new QuotaInfo
                    {
                        CoresUsed = 24
                    },
                    OsType = "Linux"
                }
            };
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
            var serializedConfig = JsonConvert.SerializeObject(configurations);
            cluster.Properties.ClusterDefinition.Configurations = serializedConfig;

            hdinsightManagementMock.Setup(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<ClusterCreateParametersExtended>(
                                         parameters => parameters.Location == Location &&
                                         parameters.Properties.ClusterDefinition.Kind == ClusterType &&
                                         parameters.Properties.OsType == "Linux"
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
                    "ldapsurl"
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
            var cluster = new Cluster(id: "id", name: ClusterName, location: Location)
            {
                Location = Location,
                Properties = new ClusterGetProperties
                {
                    ClusterVersion = HdiVersion,
                    ClusterState = "Running",
                    ClusterDefinition = new ClusterDefinition
                    {
                        Kind = ClusterType
                    },
                    QuotaInfo = new QuotaInfo
                    {
                        CoresUsed = 24
                    },
                    OsType = "Linux",
                    ComputeProfile = new ComputeProfile()
                    {
                        Roles = new List<Role>()
                    }
                }
            };

            if (workerNodeDataDisks > 0)
            {
                cluster.Properties.ComputeProfile.Roles.Add(new Role()
                {
                    Name = "workernode",
                    DataDisksGroups = new List<DataDisksGroups>()
                    {
                        new DataDisksGroups()
                        {
                            DisksPerNode = workerNodeDataDisks
                        }
                    }
                });
            }

            if (addSecurityProfileInresponse)
            {
                cluster.Properties.SecurityProfile = new SecurityProfile()
                {
                    Domain = "domain.com",
                    DomainUsername = "username",
                    DomainUserPassword = "pass",
                    OrganizationalUnitDN = "OUDN",
                    LdapsUrls = new[]
                    {
                        "ldapsurl"
                    },
                    ClusterUsersGroupDNs = new[]
                    {
                        "userGroupDn"
                    },
                    AaddsResourceId= "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/fakerg/providers/Microsoft.AAD/domainServices/domain.com"
                };
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
            var serializedConfig = JsonConvert.SerializeObject(configurations);
            cluster.Properties.ClusterDefinition.Configurations = serializedConfig;

            // Setup Mocks and verify successfull GET response
            hdinsightManagementMock.Setup(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<ClusterCreateParametersExtended>(
                             parameters => parameters.Location == Location &&
                             parameters.Properties.ClusterDefinition.Kind == ClusterType &&
                             parameters.Properties.OsType == "Linux"
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

            var cluster = new Cluster(id: "id", name: ClusterName, location: Location)
            {
                Location = Location,
                Properties = new ClusterGetProperties
                {
                    ClusterVersion = "3.6",
                    ClusterState = "Running",
                    ClusterDefinition = new ClusterDefinition
                    {
                        Kind = sparkClusterType
                    },
                    QuotaInfo = new QuotaInfo
                    {
                        CoresUsed = 24
                    },
                    OsType = "Linux"
                }
            };

            
            cluster.Properties.ClusterDefinition.ComponentVersion = componentVersion;
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
            var serializedConfig = JsonConvert.SerializeObject(configurations);
            cluster.Properties.ClusterDefinition.Configurations = serializedConfig;

            hdinsightManagementMock.Setup(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<ClusterCreateParametersExtended>(
                 parameters => parameters.Location == Location &&
                 parameters.Properties.ClusterDefinition.Kind == sparkClusterType &&
                 parameters.Properties.OsType == "Linux"
                 ))
                 ).Returns(cluster).Verifiable();

            hdinsightManagementMock.Setup(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<ClusterCreateParametersExtended>(
                             parameters => parameters.Location == Location &&
                             parameters.Properties.ClusterDefinition.Kind == ClusterType &&
                             parameters.Properties.OsType == "Linux"
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
                    clusterout.OperatingSystemType.ToString() == "Linux" &&
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

            var ClusterIdentity = new ClusterIdentity
            {
                Type = ResourceIdentityType.UserAssigned,
                UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>
                    {
                        {
                            AssignedIdentity, new UserAssignedIdentity(principalId:"PrincipalId",clientId:"ClientId")
                        }
                    }
            };

            var cluster = new Cluster(id: "id", name: ClusterName, identity:ClusterIdentity, location: Location)
            {
                Location = Location,
                Properties = new ClusterGetProperties
                {
                    ClusterVersion = "3.6",
                    ClusterState = "Running",
                    ClusterDefinition = new ClusterDefinition
                    {
                        Kind = sparkClusterType
                    },
                    QuotaInfo = new QuotaInfo
                    {
                        CoresUsed = 24
                    },
                    OsType = "Linux",
                    DiskEncryptionProperties = new DiskEncryptionProperties()
                    {
                        KeyName = EncryptionKeyName,
                        KeyVersion = EncryptionKeyVersion,
                        VaultUri = EncryptionVaultUri,
                        EncryptionAlgorithm = EncryptionAlgorithm,
                        MsiResourceId = AssignedIdentity
                    },
                },
            };

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
            var serializedConfig = JsonConvert.SerializeObject(configurations);
            cluster.Properties.ClusterDefinition.Configurations = serializedConfig;

            hdinsightManagementMock.Setup(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<ClusterCreateParametersExtended>(
                 parameters => parameters.Location == Location &&
                 parameters.Properties.ClusterDefinition.Kind == sparkClusterType &&
                 parameters.Properties.OsType == "Linux"
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
                    clusterout.DiskEncryption.VaultUri == EncryptionVaultUri &&
                    clusterout.DiskEncryption.EncryptionAlgorithm == EncryptionAlgorithm &&
                    clusterout.DiskEncryption.MsiResourceId == AssignedIdentity &&
                    clusterout.AssignedIdentity.Type == ResourceIdentityType.UserAssigned &&
                    clusterout.AssignedIdentity.UserAssignedIdentities[AssignedIdentity].ClientId == "ClientId" &&
                    clusterout.AssignedIdentity.UserAssignedIdentities[AssignedIdentity].PrincipalId == "PrincipalId"
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

            hdinsightManagementMock.Setup(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<ClusterCreateParametersExtended>(
                             parameters => parameters.Location == Location &&
                             parameters.Properties.ClusterDefinition.Kind == ClusterType &&
                             parameters.Properties.OsType == "Linux"
                             )));

            cmdlet.ExecuteCmdlet();

            hdinsightManagementMock.Verify(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<ClusterCreateParametersExtended>(
                             parameters => parameters.Location == Location &&
                             parameters.Properties.ClusterDefinition.Kind == ClusterType &&
                             parameters.Properties.OsType == "Linux"
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

            hdinsightManagementMock.Setup(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<ClusterCreateParametersExtended>(
                             parameters => parameters.Location == Location &&
                             parameters.Properties.ClusterDefinition.Kind == ClusterType &&
                             parameters.Properties.OsType == "Linux"
                             )));

            cmdlet.ExecuteCmdlet();

            hdinsightManagementMock.Verify(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<ClusterCreateParametersExtended>(
                             parameters => parameters.Location == Location &&
                             parameters.Properties.ClusterDefinition.Kind == ClusterType &&
                             parameters.Properties.OsType == "Linux"
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

            hdinsightManagementMock.Setup(c => c.CreateCluster(ResourceGroupName, ClusterName, It.IsAny<ClusterCreateParametersExtended>()));

            cmdlet.ExecuteCmdlet();

            hdinsightManagementMock.Verify(c => c.CreateCluster(ResourceGroupName, ClusterName, It.Is<ClusterCreateParametersExtended>(
                             parameters => parameters.Location == Location &&
                             parameters.Properties.ClusterDefinition.Kind == ClusterType &&
                             parameters.Properties.OsType == "Linux"
                             )),
                Times.Once);
        }
    }
}
