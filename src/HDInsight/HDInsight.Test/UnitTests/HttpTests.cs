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
using System;
using System.Management.Automation;
using System.Net;
using Xunit;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class HttpTests : HDInsightTestBase
    {
        private SetAzureHDInsightGatewayCredentialCommand setcmdlet;

        private readonly PSCredential _httpCred;

        public HttpTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            base.SetupTestsForManagement();
            _httpCred = new PSCredential("hadoopuser", string.Format("Password1!").ConvertToSecureString());

            setcmdlet = new SetAzureHDInsightGatewayCredentialCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                Name = ClusterName,
                ResourceGroupName = ResourceGroupName,
                HttpCredential = _httpCred
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanSetGatewayCredentialSupportsShouldProcess()
        {
            commandRuntimeMock.Setup(c => c.ShouldProcess(ClusterName, It.IsAny<string>())).Returns(true);

            hdinsightManagementMock.Setup(
                c =>
                    c.UpdateGatewayCredential(ResourceGroupName, ClusterName,
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

            var gatewayCredential = new HttpConnectivitySettings
            {
                HttpPassword = _httpCred.Password.ConvertToString(),
                HttpUserEnabled = true,
                HttpUsername = _httpCred.UserName,
                StatusCode = HttpStatusCode.OK
            };

            hdinsightManagementMock.Setup(c => c.GetGatewaySettings(ResourceGroupName, ClusterName))
                .Returns(gatewayCredential)
                .Verifiable();

            setcmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(gatewayCredential), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanWriteErrorWhenSetGatewayCredentialFailedSupportsProcess()
        {
            var result = new OperationResource
            {
                ErrorInfo = new ErrorInfo { Code = "Ambari Failed Code", Message = "GetAmbariUserFailed" },
                StatusCode = HttpStatusCode.OK,
                State = AsyncOperationState.Failed
            };

            commandRuntimeMock.Setup(c => c.ShouldProcess(ClusterName, It.IsAny<string>())).Returns(true);

            hdinsightManagementMock.Setup(
                c =>
                    c.UpdateGatewayCredential(ResourceGroupName, ClusterName,
                        It.Is<HttpSettingsParameters>(
                            param =>
                                param.HttpUserEnabled && param.HttpUsername == _httpCred.UserName &&
                                param.HttpPassword == _httpCred.Password.ConvertToString())))
                .Returns(result)
                .Verifiable();

            setcmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(
                f =>
                    f.WriteError(It.Is<ErrorRecord>(
                        record =>
                            record.Exception.Message == $"{result.ErrorInfo.Code}: {result.ErrorInfo.Message}" &&
                            string.IsNullOrEmpty(record.FullyQualifiedErrorId) &&
                            record.CategoryInfo.Category == ErrorCategory.InvalidArgument)),
                Times.Once);
        }
    }
}
