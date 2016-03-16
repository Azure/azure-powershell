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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Profile;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System.IO;
using Microsoft.Azure.ServiceManagemenet.Common;

namespace Microsoft.WindowsAzure.Commands.Test.Profile
{
    
    public class GetAzurePublishSettingsFileTests
    {
        [Fact (Skip = "Consider removing these.")]
        public void GetsPublishSettingsFileUrl()
        {
            // Setup
            AzureSession.DataStore = new MemoryDataStore();
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            GetAzurePublishSettingsFileCommand cmdlet = new GetAzurePublishSettingsFileCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                PassThru = true,
                Environment = EnvironmentName.AzureCloud,
                Realm = "microsoft.com"
            };
            cmdlet.ProfileClient = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile)));

            // Test
            cmdlet.ExecuteCmdlet();

            // Assert
            commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Once());
        }
    }
}