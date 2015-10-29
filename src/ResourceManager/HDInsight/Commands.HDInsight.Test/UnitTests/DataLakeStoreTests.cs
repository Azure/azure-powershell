﻿// ----------------------------------------------------------------------------------
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
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.HDInsight;
using Microsoft.Azure.Commands.HDInsight.ManagementCommands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Commands.HDInsight.Test;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Commands.HDInsight.Test.UnitTests
{
    public class DataLakeStoreTests : HDInsightTestBase
    {
        private NewAzureHDInsightClusterCommand cmdlet;
        private const string StorageName = "dummystorage.blob.core.windows.net";
        private const string StorageKey = "O9EQvp3A3AjXq/W27rst1GQfLllhp01qlJMJfSU1hVW2K42gUeiUUn2D8zX2lU3taiXSSfqkZlcPv+nQcYYwUx==";
        private const int ClusterSize = 4;
        private Guid ObjectId = new Guid("11111111-1111-1111-1111-111111111111");
        private Guid AadTenantId = new Guid("11111111-1111-1111-1111-111111111111");
        private string Certificate = "";
        private string CertificatePassword = "";

        private readonly PSCredential _httpCred;

        public DataLakeStoreTests()
        {
            base.SetupTestsForManagement();
            _httpCred = new PSCredential("hadoopuser", string.Format("Password1!").ConvertToSecureString());
            cmdlet = new NewAzureHDInsightClusterCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateNewHDInsightDataLakeStoreCluster()
        {
            cmdlet.ClusterName = ClusterName;
            cmdlet.ResourceGroupName = ResourceGroupName;
            cmdlet.ClusterSizeInNodes = ClusterSize;
            cmdlet.Location = Location;
            cmdlet.HttpCredential = _httpCred;
            cmdlet.DefaultStorageAccountName = StorageName;
            cmdlet.DefaultStorageAccountKey = StorageKey;
            cmdlet.AadTenantId = AadTenantId;
            cmdlet.ObjectId = ObjectId;
            cmdlet.CertificateFilePath = Certificate;
            cmdlet.CertificatePassword = CertificatePassword;

            var cluster = new Cluster
            {
                Id = "id",
                Name = ClusterName,
                Location = Location,
                Properties = new ClusterGetProperties
                {
                    ClusterVersion = "3.2",
                    ClusterState = "Running",
                    ClusterDefinition = new ClusterDefinition
                    {
                        ClusterType = "Hadoop"
                    },
                    QuotaInfo = new QuotaInfo
                    {
                        CoresUsed = 24
                    },
                    OperatingSystemType = OSType.Windows
                }
            };
            var coreConfigs = new Dictionary<string, string>
            {
                {"fs.defaultFS", "wasb://dummycsmv2@" + StorageName},
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
            var datalakeStoreConfigs = new Dictionary<string, string>
            {
                {"clusterIdentity.applicationId", ObjectId.ToString()},
                {"clusterIdentity.certificate", Certificate},
                {"clusterIdentity.certificatePassword", CertificatePassword},
                {"clusterIdentity.aadTenantId", AadTenantId.ToString()}
            };
            var configurations = new Dictionary<string, Dictionary<string, string>>
            {
                {"core-site", coreConfigs},
                {"gateway", gatewayConfigs},
                {"clusterIdentity", datalakeStoreConfigs}
            };
            var serializedConfig = JsonConvert.SerializeObject(configurations);
            cluster.Properties.ClusterDefinition.Configurations = serializedConfig;

            var getresponse = new ClusterGetResponse {Cluster = cluster};

            hdinsightManagementMock.Setup(
                c => c.CreateNewCluster(ResourceGroupName, ClusterName, It.Is<ClusterCreateParameters>(
                    parameters =>
                        parameters.ClusterSizeInNodes == ClusterSize &&
                        parameters.DefaultStorageAccountName == StorageName &&
                        parameters.DefaultStorageAccountKey == StorageKey &&
                        parameters.Location == Location &&
                        parameters.UserName == _httpCred.UserName &&
                        parameters.Password == _httpCred.Password.ConvertToString() &&
                        parameters.ClusterType == HDInsightClusterType.Hadoop &&
                        parameters.OSType == OSType.Windows)))
                .Returns(getresponse)
                .Verifiable();

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<AzureHDInsightCluster>(
                clusterout =>
                    clusterout.ClusterState == "Running" &&
                    clusterout.ClusterType == HDInsightClusterType.Hadoop &&
                    clusterout.ClusterVersion == "3.2" &&
                    clusterout.CoresUsed == 24 &&
                    clusterout.Location == Location &&
                    clusterout.Name == ClusterName &&
                    clusterout.OperatingSystemType == OSType.Windows)),
                Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateClusterConfigWithDataLakeStoreParameters()
        {
            var newclusteridentitycmdlet = new NewAzureHDInsightClusterConfigCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                CertificateFilePath = Certificate,
                ObjectId = ObjectId,
                AadTenantId = AadTenantId,
                CertificatePassword = CertificatePassword
            };

            newclusteridentitycmdlet.ExecuteCmdlet();
            commandRuntimeMock.Verify(
                f =>
                    f.WriteObject(
                        It.Is<AzureHDInsightConfig>(
                            c =>
                                c.AADTenantId == AadTenantId &&
                                c.CertificatePassword == CertificatePassword &&
                                c.ObjectId == ObjectId &&
                                c.CertificateFilePath == Certificate
                                )),
                Times.Once); 
        }
    }
}

