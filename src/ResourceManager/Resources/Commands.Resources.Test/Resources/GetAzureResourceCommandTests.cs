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

using System.Collections.Generic;
using System.Management.Automation;
using System.Runtime.Serialization.Formatters;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test
{
    public class GetAzureResourceCommandTests
    {
        private GetAzureResourceCommand cmdlet;

        private Mock<ResourcesClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceName = "myResource";

        private string resourceGroupName = "myResourceGroup";

        private string resourceType = "Microsoft.Web/sites";

        private string resourceGroupLocation = "West US";

        private Dictionary<string, object> properties;

        private string serializedProperties;

        public GetAzureResourceCommandTests()
        {
            resourcesClientMock = new Mock<ResourcesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureResourceCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                ResourcesClient = resourcesClientMock.Object
            };
            properties = new Dictionary<string, object>
                {
                    {"name", "site1"},
                    {"siteMode", "Standard"},
                    {"computeMode", "Dedicated"},
                    {"misc", new Dictionary<string, object>
                        {
                            {"key1", "value1"},
                            {"key2", "value2"}
                        }}
                };
            serializedProperties = JsonConvert.SerializeObject(properties, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsResourcesGroups()
        {
            List<Resource> result = new List<Resource>();
            Resource expected = new Resource()
            {
                Id = "/subscriptions/aaaa/resourceGroups/foo/providers/Microsoft.Web/serverFarms/" + resourceName,
                Name = resourceName,
                Location = resourceGroupLocation,
                Type = resourceType,
                ProvisioningState = "Running",
                Properties = serializedProperties
            };
            FilterResourcesOptions inputParameters = new FilterResourcesOptions
                {
                    Name = resourceName,
                    ResourceType = resourceType,
                    ResourceGroup = resourceGroupName,
                };
            result.Add(expected);
            resourcesClientMock.Setup(f => f.FilterResources(inputParameters)).Returns(result);

            cmdlet.ResourceGroupName = resourceGroupName;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(1, result.Count);
            Assert.Equal(resourceGroupLocation, result[0].Location);
            Assert.Equal(resourceType, result[0].Type);
            Assert.Equal("Running", result[0].ProvisioningState);
            Assert.Equal(serializedProperties, result[0].Properties);
        }
    }
}
