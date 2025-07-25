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

using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class HDInsightTestBase : RMTestBase
    {
        protected const string ClusterName = "hdicluster";
        protected const string ResourceGroupName = "hdi-rg1";
        protected const string Location = "west us";

        protected string ClusterType = "Hadoop";
        protected string HdiVersion = "3.1";

        protected Mock<AzureHdInsightManagementClient> hdinsightManagementMock;
        protected Mock<AzureHdInsightJobManagementClient> hdinsightJobManagementMock;
        protected Mock<ICommandRuntime> commandRuntimeMock;

        public virtual void SetupTestsForManagement()
        {
            hdinsightManagementMock = new Mock<AzureHdInsightManagementClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
        }

        public virtual void SetupTestsForData()
        {
            //This is because job test need to use ClientFactory,however scenario test will create a MockClientFactory
            AzureSession.Instance.ClientFactory = new ClientFactory();

            hdinsightManagementMock = new Mock<AzureHdInsightManagementClient>();
            var cred = new BasicAuthenticationCloudCredentials { Username = "username", Password = "Password1!" };
            hdinsightJobManagementMock = new Mock<AzureHdInsightJobManagementClient>(ClusterName, cred);
            commandRuntimeMock = new Mock<ICommandRuntime>();
        }

        public virtual void SetupManagementClientForJobTests()
        {
            // Update HDInsight Management properties for Job.
            var cluster1 = new Cluster(
                id: $"/subscriptions/{Guid.NewGuid()}/resourceGroups/{ResourceGroupName}/providers/Microsoft.HDInsight/clusters/{ClusterName}",
                name: ClusterName, location: Location)
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
                    OsType = "Linux",
                    ConnectivityEndpoints = new List<ConnectivityEndpoint> { new ConnectivityEndpoint { Location = ClusterName, Name = "HTTPS" } }
                }
            };

            var listresponse = new[] { cluster1 };
            hdinsightManagementMock.Setup(c => c.ListClusters())
                .Returns(listresponse)
                .Verifiable();

            hdinsightManagementMock.Setup(c => c.GetCluster(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<Cluster> { cluster1 })
                .Verifiable();

            var configurationResponse = new Dictionary<string, string>();
            configurationResponse.Add("fs.defaultFS", "wasb://tempstorageaccount@xyz.blob.core.windows.net");
            configurationResponse.Add("fs.azure.account.key.xyz.blob.core.windows.net", "tempkey");

            hdinsightManagementMock.Setup(c => c.GetClusterConfigurations(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(configurationResponse)
                .Verifiable();

            var listConfigurationsResponse = new ClusterConfigurations
            {
                Configurations = new Dictionary<string, IDictionary<string, string>>
                {
                    {
                        "core-site", configurationResponse
                    }
                }
            };

            hdinsightManagementMock.Setup(c => c.ListConfigurations(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(listConfigurationsResponse)
                .Verifiable();
        }
    }
}
