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

using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Management.Automation;
using System.Net;
using Xunit;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class HttpTests : HDInsightTestBase
    {
        private GrantAzureHDInsightHttpServicesAccessCommand grantcmdlet;
        private RevokeAzureHDInsightHttpServicesAccessCommand revokecmdlet;

        private readonly PSCredential _httpCred;

        public HttpTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTestsForManagement();
            _httpCred = new PSCredential("hadoopuser", string.Format("Password1!").ConvertToSecureString());

            grantcmdlet = new GrantAzureHDInsightHttpServicesAccessCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ClusterName = ClusterName,
                ResourceGroupName = ResourceGroupName,
                HttpCredential = _httpCred
            };
            revokecmdlet = new RevokeAzureHDInsightHttpServicesAccessCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ClusterName = ClusterName,
                ResourceGroupName = ResourceGroupName
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanGrantHttpAccess()
        {
            hdinsightManagementMock.Setup(
                c =>
                    c.ConfigureHttp(ResourceGroupName, ClusterName,
                        It.Is<HttpSettingsParameters>(
                            param =>
                                param.HttpUserEnabled && param.HttpUsername == _httpCred.UserName &&
                                param.HttpPassword == _httpCred.Password.ConvertToString())))
                .Returns(new OperationResource
                {
                    ErrorInfo = null,
                    StatusCode = HttpStatusCode.OK,
                    State = AsyncOperationState.Succeeded
                })
                .Verifiable();

            var connectivitysettings = new HttpConnectivitySettings
            {
                HttpPassword = _httpCred.Password.ConvertToString(),
                HttpUserEnabled = true,
                HttpUsername = _httpCred.UserName,
                StatusCode = HttpStatusCode.OK
            };

            hdinsightManagementMock.Setup(c => c.GetConnectivitySettings(ResourceGroupName, ClusterName))
                .Returns(connectivitysettings)
                .Verifiable();

            grantcmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(connectivitysettings), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanRevokeHttpAccess()
        {
            hdinsightManagementMock.Setup(
                c =>
                    c.ConfigureHttp(ResourceGroupName, ClusterName,
                        It.Is<HttpSettingsParameters>(
                            param =>
                                !param.HttpUserEnabled &&
                                string.IsNullOrEmpty(param.HttpPassword) &&
                                string.IsNullOrEmpty(param.HttpUsername))))
                .Returns(new OperationResource
                {
                    ErrorInfo = null,
                    StatusCode = HttpStatusCode.OK,
                    State = AsyncOperationState.Succeeded
                })
                .Verifiable();

            var connectivitysettings = new HttpConnectivitySettings
            {
                HttpUserEnabled = false,
                StatusCode = HttpStatusCode.OK
            };

            hdinsightManagementMock.Setup(c => c.GetConnectivitySettings(ResourceGroupName, ClusterName))
                .Returns(connectivitysettings)
                .Verifiable();

            revokecmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(connectivitysettings), Times.Once);
        }
    }
}
