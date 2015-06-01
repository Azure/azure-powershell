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

using System.Collections;
using System.Collections.Generic;
using System.Management.Automation.Runspaces;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class GetAzureHDInsightClusterTests : HDInsightTestBase
    {
        private GetAzureHDInsightCommand cmdlet;
        private const string ClusterName = "hdicluster";

        public GetAzureHDInsightClusterTests()
        {
            base.SetupTest();

            cmdlet = new GetAzureHDInsightCommand
            {
                ClusterName = ClusterName,
                ResourceGroupName = ResourceGroupName,
                CommandRuntime = commandRuntimeMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanGetHDInsightCluster()
        {
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
                        ClusterType = HDInsightClusterType.Hadoop
                    },
                    QuotaInfo = new QuotaInfo
                    {
                        CoresUsed = 24
                    }
                },

            };

            var getresponse = new ClusterGetResponse { Cluster = cluster };
            hdinsightManagementClient.Setup(c => c.Get(ResourceGroupName, ClusterName))
                .Returns(getresponse)
                .Verifiable(); 
            
            var expected = new List<Cluster> { cluster };
            hdinsightManagementClient.Setup(c => c.GetCluster(ResourceGroupName, ClusterName))
                .Returns(expected)
                .Verifiable();
            
            cmdlet.HDInsightManagementClient = hdinsightManagementClient.Object;
            cmdlet.ExecuteCmdlet();

            var expectedOutput = new List<AzureHDInsightCluster> { new AzureHDInsightCluster(cluster) };

            commandRuntimeMock.Verify(f => f.WriteObject(expectedOutput, true), Times.Once);
        }
    }
}
