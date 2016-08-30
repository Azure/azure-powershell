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
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class NewClusterTests : HDInsightTestBase
    {
        private NewAzureHDInsightClusterCommand cmdlet;
        private const string StorageName = "giyerwestus1.blob.core.windows.net";
        private const string StorageKey = "O9EQvp3A3AjXq/W27rst1GQfLllhp01qlJMJfSU1hVW2K42gUeiUUn2D8zX2lU3taiXSSfqkZlcPv+nQcYUxYw==";
        private const int ClusterSize = 4;

        private readonly PSCredential _httpCred, _sshCred;

        public NewClusterTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
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
            cmdlet.DefaultStorageAccountName = StorageName;
            cmdlet.DefaultStorageAccountKey = StorageKey;
            cmdlet.ClusterType = ClusterType;

            var cluster = new Cluster
            {
                Id = "id",
                Name = ClusterName,
                Location = Location,
                Properties = new ClusterGetProperties
                {
                    ClusterVersion = "3.1",
                    ClusterState = "Running",
                    ClusterDefinition = new ClusterDefinition
                    {
                        ClusterType = ClusterType
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

            var getresponse = new ClusterGetResponse { Cluster = cluster };

            hdinsightManagementMock.Setup(c => c.CreateNewCluster(ResourceGroupName, ClusterName, It.Is<ClusterCreateParameters>(
                parameters =>
                    parameters.ClusterSizeInNodes == ClusterSize &&
                    parameters.DefaultStorageAccountName == StorageName &&
                    parameters.DefaultStorageAccountKey == StorageKey &&
                    parameters.Location == Location &&
                    parameters.UserName == _httpCred.UserName &&
                    parameters.Password == _httpCred.Password.ConvertToString() &&
                    parameters.ClusterType == ClusterType &&
                    parameters.OSType == OSType.Windows)))
            .Returns(getresponse)
            .Verifiable();

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<AzureHDInsightCluster>(
                clusterout =>
                    clusterout.ClusterState == "Running" &&
                    clusterout.ClusterType == ClusterType &&
                    clusterout.ClusterVersion == "3.1" &&
                    clusterout.CoresUsed == 24 &&
                    clusterout.Location == Location &&
                    clusterout.Name == ClusterName &&
                    clusterout.OperatingSystemType == OSType.Windows)),
                    Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateNewHDInsightCluster_Linux()
        {
            cmdlet.ClusterName = ClusterName;
            cmdlet.ResourceGroupName = ResourceGroupName;
            cmdlet.ClusterSizeInNodes = ClusterSize;
            cmdlet.Location = Location;
            cmdlet.HttpCredential = _httpCred;
            cmdlet.DefaultStorageAccountName = StorageName;
            cmdlet.DefaultStorageAccountKey = StorageKey;
            cmdlet.ClusterType = ClusterType;
            cmdlet.SshCredential = _sshCred;
            cmdlet.OSType = OSType.Linux;

            var cluster = new Cluster
            {
                Id = "id",
                Name = ClusterName,
                Location = Location,
                Properties = new ClusterGetProperties
                {
                    ClusterVersion = "3.1",
                    ClusterState = "Running",
                    ClusterDefinition = new ClusterDefinition
                    {
                        ClusterType = ClusterType
                    },
                    QuotaInfo = new QuotaInfo
                    {
                        CoresUsed = 24
                    },
                    OperatingSystemType = OSType.Linux
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

            var getresponse = new ClusterGetResponse { Cluster = cluster };

            hdinsightManagementMock.Setup(c => c.CreateNewCluster(ResourceGroupName, ClusterName, It.Is<ClusterCreateParameters>(
                parameters =>
                    parameters.ClusterSizeInNodes == ClusterSize &&
                    parameters.DefaultStorageAccountName == StorageName &&
                    parameters.DefaultStorageAccountKey == StorageKey &&
                    parameters.Location == Location &&
                    parameters.UserName == _httpCred.UserName &&
                    parameters.Password == _httpCred.Password.ConvertToString() &&
                    parameters.ClusterType == ClusterType &&
                    parameters.OSType == OSType.Linux &&
                    parameters.SshUserName == _sshCred.UserName &&
                    parameters.SshPassword == _sshCred.Password.ConvertToString())))
            .Returns(getresponse)
            .Verifiable();

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<AzureHDInsightCluster>(
                clusterout =>
                    clusterout.ClusterState == "Running" &&
                    clusterout.ClusterType == ClusterType &&
                    clusterout.ClusterVersion == "3.1" &&
                    clusterout.CoresUsed == 24 &&
                    clusterout.Location == Location &&
                    clusterout.Name == ClusterName &&
                    clusterout.OperatingSystemType == OSType.Linux)),
                    Times.Once);
        }
    }
}
