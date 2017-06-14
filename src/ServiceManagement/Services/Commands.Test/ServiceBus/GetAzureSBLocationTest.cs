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
using System.Linq;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ServiceBus;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.ServiceBus;
using Microsoft.WindowsAzure.Management.ServiceBus.Models;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.ServiceBus
{
    
    public class GetAzureSBLocationTests : SMTestBase
    {
        public GetAzureSBLocationTests()
        {
            new FileSystemHelper(this).CreateAzureSdkDirectoryAndImportPublishSettings();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureSBLocationSuccessfull()
        {
            // Setup
            Mock<ServiceBusClientExtensions> client = new Mock<ServiceBusClientExtensions>();
            MockCommandRuntime mockCommandRuntime = new MockCommandRuntime();
            string name = "test";
            GetAzureSBLocationCommand cmdlet = new GetAzureSBLocationCommand()
            {
                CommandRuntime = mockCommandRuntime,
                Client = client.Object
            };
            List<ServiceBusLocation> expected = new List<ServiceBusLocation>();
            expected.Add(new ServiceBusLocation { Code = name, FullName = name });
            client.Setup(f => f.GetServiceBusRegions()).Returns(expected);

            // Test
            cmdlet.ExecuteCmdlet();

            // Assert
            IEnumerable<ServiceBusLocation> actual = 
                System.Management.Automation.LanguagePrimitives.GetEnumerable(mockCommandRuntime.OutputPipeline).Cast<ServiceBusLocation>();

            Assert.Equal<int>(expected.Count, actual.Count());

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.True(actual.Any((account) => account.Code == expected[i].Code));
                Assert.True(actual.Any((account) => account.FullName ==  expected[i].FullName));
            }
        }
    }
}