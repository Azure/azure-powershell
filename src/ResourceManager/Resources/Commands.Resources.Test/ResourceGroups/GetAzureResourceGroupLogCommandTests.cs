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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test
{
    public class GetAzureResourceGroupLogCommandTests
    {
        private GetAzureResourceGroupLogCommand cmdlet;

        private Mock<ResourcesClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetAzureResourceGroupLogCommandTests()
        {
            resourcesClientMock = new Mock<ResourcesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureResourceGroupLogCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                ResourcesClient = resourcesClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureResourceGroupLogOutputsProperties()
        {
            List<PSDeploymentEventData> result = new List<PSDeploymentEventData>();
            result.Add(new PSDeploymentEventData
                {
                    EventId = "ac7d2ab5-698a-4c33-9c19-0a93d3d7f527",
                    EventName = "Start request",
                    EventSource = "Microsoft Resources",
                    Channels = "Operation",
                    Level = "Informational",
                    Timestamp = DateTime.Now,
                    OperationId = "c0f2e85f-efb0-47d0-bf90-f983ec8be91d",
                    OperationName = "Microsoft.Resources/subscriptions/resourcegroups/deployments/write",
                    Status = "Succeeded",
                    SubStatus = "Created",
                    ResourceGroupName = "foo",
                    ResourceProvider = "Microsoft Resources",
                    ResourceUri =
                        "/subscriptions/ffce8037-a374-48bf-901d-dac4e3ea8c09/resourcegroups/foo/deployments/testdeploy",
                    HttpRequest = new PSDeploymentEventDataHttpRequest
                    {
                        Url = "http://path/subscriptions/ffce8037-a374-48bf-901d-dac4e3ea8c09/resourcegroups/foo/deployments/testdeploy",
                        Method = "PUT",
                        ClientId = "1234",
                        ClientIpAddress = "123.123.123.123"
                    },
                    Authorization = new PSDeploymentEventDataAuthorization
                    {
                        Action = "PUT",
                        Condition = "",
                        Role = "Sender",
                        Scope = "None"
                    },
                    Claims = new Dictionary<string, string>
                            {
                                {"aud", "https://management.core.windows.net/"},
                                {"iss", "https://sts.windows.net/123456/"},
                                {"iat", "h123445"}
                            },
                    Properties = new Dictionary<string, string>()
                });

            GetPSResourceGroupLogParameters expected = new GetPSResourceGroupLogParameters();

            resourcesClientMock.Setup(f => f.GetResourceGroupLogs(It.IsAny<GetPSResourceGroupLogParameters>()))
                .Returns(result)
                .Callback((GetPSResourceGroupLogParameters r) => expected = r);

            cmdlet.Name = "foo";

            cmdlet.ExecuteCmdlet();

            Assert.Equal(1, result.Count());
            Assert.Equal("foo", expected.Name);
        }
    }
}
