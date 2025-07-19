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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;

namespace Microsoft.Azure.Commands.Resources.Test
{
    public class GetAzureResourceCommandTests : RMTestBase
    {
        private GetAzureResourceCmdlet cmdlet;

        private Mock<ResourceManagerSdkClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private readonly string resourceGroupName = "myResourceGroup";
        private readonly string provider = "myProvider";
        private readonly string resourceTypeName = "myResourceType";
        private readonly string resourceName = "myResouce";
        private readonly string location = "West US";
        private readonly string kind = "myKindOfResource";

        private readonly string subscriptionId;
        private readonly string resourceGroupId;
        private readonly string resourceType;
        private readonly string resourceId; 
        private readonly IDictionary<string, string> tags;

        public GetAzureResourceCommandTests(ITestOutputHelper output)
        {
            subscriptionId = Guid.NewGuid().ToString(); // some tests have used a non GUID string value for this; but given it's always a GUID value in reality, this feels cleaner
            resourceGroupId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}";
            resourceType = $"{provider}/{resourceTypeName}";
            resourceId = $"{resourceGroupId}/providers/{resourceType}/{resourceName}";
            tags = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) { { "Environment", "Test" }, { "Application", "PowerShell" } };
            resourcesClientMock = new Mock<ResourceManagerSdkClient>();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureResourceCmdlet()
            {
                CommandRuntime = commandRuntimeMock.Object,
                ResourceManagerSdkClient = resourcesClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsResourcesById()
        {
            var pipeline = new List<PSResource>();

            var gr = new GenericResource(resourceId, resourceName, resourceType, location, tags, null, null, kind, null, null, null);
            var expected = new PSResource(gr);
            resourcesClientMock.Setup(f => f.GetById(resourceId, Constants.ResourcesApiVersion)).Returns(expected);
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSResource>())).Callback<object>(resource => pipeline.Add((PSResource)resource));
            cmdlet.ResourceId = resourceId;
            cmdlet.ExecuteCmdlet();
            Assert.Single(pipeline);
            var actual = pipeline[0];
            Assert.Equal(resourceId, actual.Id);
            Assert.Equal(resourceId, actual.ResourceId);
            Assert.Equal(subscriptionId, actual.SubscriptionId);
            Assert.Equal(resourceGroupName, actual.ResourceGroupName);
            Assert.Equal(resourceType, actual.ResourceType);
            Assert.Equal(resourceType, actual.Type);
            Assert.Equal(resourceName, actual.Name);
            Assert.Equal(location, actual.Location);
            Assert.Equal(kind, actual.Kind);
            Assert.Equal(tags, actual.Tags);
        }
    }
}
