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

namespace Microsoft.Azure.Commands.TrafficManager.Test.UnitTests
{
    using Microsoft.Azure.Commands.TrafficManager.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using ServiceManagemenet.Common.Models;
    using System.Collections.Generic;
    using System.Management.Automation;
    using WindowsAzure.Commands.Test.Utilities.Common;
    using Xunit;
    using Xunit.Abstractions;
    public class AddAzureTrafficManagerEndpointConfigTests : RMTestBase
    {
        public AddAzureTrafficManagerEndpointConfigTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddAzureTrafficManagerEndpointConfig_ThrowsExceptionIfAddingExistingEndpoint()
        {
            var cmdlet = new AddAzureTrafficManagerEndpointConfig
            {
                TrafficManagerProfile = new TrafficManagerProfile
                {
                    Endpoints = new List<TrafficManagerEndpoint>
                    {
                        new TrafficManagerEndpoint
                        {
                            Name = "Name"
                        }
                    }
                },
                EndpointName = "Name"
            };

            var exception = Assert.Throws<PSArgumentException>(() => cmdlet.ExecuteCmdlet());
            Assert.Equal("There is already an existing endpoint with name 'Name'.", exception.Message);
        }
    }
}
