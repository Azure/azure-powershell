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

using System.Management.Automation;
using Hyak.Common;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Moq;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class HDInsightTestBase
    {
        protected const string ClusterName = "hdicluster";
        protected const string ResourceGroupName = "hdi-rg1";
        protected const string Location = "west us";

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
            var cred = new BasicAuthenticationCloudCredentials {Username = "username", Password = "Password1!"};
            hdinsightJobManagementMock = new Mock<AzureHdInsightJobManagementClient>(ClusterName, cred);
            commandRuntimeMock = new Mock<ICommandRuntime>();
        }
    }
}
