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
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Profile;
using Microsoft.WindowsAzure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Test.Environment
{
    public class GetAzureEnvironmentTests : SMTestBase
    {
        private MemoryDataStore dataStore;

        public GetAzureEnvironmentTests()
        {
            dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsAzureEnvironments()
        {
            List<PSAzureEnvironment> environments = null;
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            commandRuntimeMock.Setup(c => c.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback<object, bool>((e, _) => environments = (List<PSAzureEnvironment>)e);

            GetAzureEnvironmentCommand cmdlet = new GetAzureEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };

            AzureSMCmdlet.CurrentProfile = new AzureSMProfile();
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            Assert.Equal(4, environments.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsAzureEnvironment()
        {
            List<PSAzureEnvironment> environments = null;
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            commandRuntimeMock.Setup(c => c.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback<object, bool>((e, _) => environments = (List<PSAzureEnvironment>)e);

            GetAzureEnvironmentCommand cmdlet = new GetAzureEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = EnvironmentName.AzureChinaCloud
            };

            AzureSMCmdlet.CurrentProfile = new AzureSMProfile();
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            Assert.Equal(1, environments.Count);
        }
    }
}