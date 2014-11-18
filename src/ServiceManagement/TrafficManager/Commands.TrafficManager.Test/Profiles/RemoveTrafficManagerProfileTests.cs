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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.TrafficManager.Profile;
using Microsoft.WindowsAzure.Commands.TrafficManager.Utilities;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.TrafficManager.Profiles
{
    [TestClass]
    public class RemoveTrafficManagerProfileTests
    {
        private const string ProfileName = "my-profile";

        private MockCommandRuntime mockCommandRuntime;

        private RemoveAzureTrafficManagerProfile cmdlet;

        private Mock<ITrafficManagerClient> clientMock;

        [TestInitialize]
        public void TestSetup()
        {
            mockCommandRuntime = new MockCommandRuntime();
            clientMock = new Mock<ITrafficManagerClient>();
        }

        [TestMethod]
        public void ProcessRemoveProfileTest()
        {
            // Setup
            cmdlet = new RemoveAzureTrafficManagerProfile
            {
                Name = ProfileName,
                CommandRuntime = mockCommandRuntime,
                TrafficManagerClient = clientMock.Object,
            };

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            clientMock.Verify(c => c.RemoveTrafficManagerProfile(ProfileName), Times.Once());
        }
    }
}
