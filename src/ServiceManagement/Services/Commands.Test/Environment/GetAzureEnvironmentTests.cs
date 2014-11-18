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
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Profile;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Test.Environment
{
    public class GetAzureEnvironmentTests : TestBase
    {
        private MockDataStore dataStore;

        public GetAzureEnvironmentTests()
        {
            dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
        }

        [Fact]
        public void GetsAzureEnvironments()
        {
            List<PSObject> environments = null;
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            commandRuntimeMock.Setup(c => c.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback<object, bool>((e, _) => environments = (List<PSObject>)e);

            GetAzureEnvironmentCommand cmdlet = new GetAzureEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            Assert.Equal(2, environments.Count);
        }

        [Fact]
        public void GetsAzureEnvironment()
        {
            List<PSObject> environments = null;
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            commandRuntimeMock.Setup(c => c.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback<object, bool>((e, _) => environments = (List<PSObject>)e);

            GetAzureEnvironmentCommand cmdlet = new GetAzureEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = EnvironmentName.AzureChinaCloud
            };

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            Assert.Equal(1, environments.Count);
        }
    }
}