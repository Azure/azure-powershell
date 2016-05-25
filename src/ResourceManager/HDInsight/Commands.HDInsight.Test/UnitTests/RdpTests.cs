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
    public class RdpTests : HDInsightTestBase
    {
        private GrantAzureHDInsightRdpServicesAccessCommand grantcmdlet;
        private RevokeAzureHDInsightRdpServicesAccessCommand revokecmdlet;

        private readonly PSCredential _rdpCred;

        public RdpTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTestsForManagement();
            _rdpCred = new PSCredential("rdpuser", string.Format("Password1!").ConvertToSecureString());

            grantcmdlet = new GrantAzureHDInsightRdpServicesAccessCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ClusterName = ClusterName,
                ResourceGroupName = ResourceGroupName,
                RdpCredential = _rdpCred,
                RdpAccessExpiry = new DateTime(2015, 1, 1)
            };
            revokecmdlet = new RevokeAzureHDInsightRdpServicesAccessCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ClusterName = ClusterName,
                ResourceGroupName = ResourceGroupName
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanGrantRdpAccess()
        {
            hdinsightManagementMock.Setup(
                c =>
                    c.ConfigureRdp(ResourceGroupName, ClusterName,
                        It.Is<RDPSettingsParameters>(
                            param =>
                                param.OsProfile.LinuxOperatingSystemProfile == null &&
                                param.OsProfile.WindowsOperatingSystemProfile.RdpSettings.ExpiryDate ==
                                grantcmdlet.RdpAccessExpiry &&
                                param.OsProfile.WindowsOperatingSystemProfile.RdpSettings.UserName == _rdpCred.UserName &&
                                param.OsProfile.WindowsOperatingSystemProfile.RdpSettings.Password ==
                                _rdpCred.Password.ConvertToString())))
                .Returns(new OperationResource
                {
                    ErrorInfo = null,
                    StatusCode = HttpStatusCode.OK,
                    State = AsyncOperationState.Succeeded
                })
                .Verifiable();

            grantcmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanRevokeRdpAccess()
        {
            hdinsightManagementMock.Setup(
                c =>
                    c.ConfigureRdp(ResourceGroupName, ClusterName,
                        It.Is<RDPSettingsParameters>(
                            param =>
                                param.OsProfile.LinuxOperatingSystemProfile == null &&
                                param.OsProfile.WindowsOperatingSystemProfile.RdpSettings == null)))
                .Returns(new OperationResource
                {
                    ErrorInfo = null,
                    StatusCode = HttpStatusCode.OK,
                    State = AsyncOperationState.Succeeded
                })
                .Verifiable();

            revokecmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
        }
    }
}
