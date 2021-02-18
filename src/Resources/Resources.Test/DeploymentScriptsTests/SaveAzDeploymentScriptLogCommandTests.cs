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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Resources.Test
{
    public class SaveAzDeploymentScriptLogCommandTests : RMTestBase
    {
        private SaveAzDeploymentScriptLog cmdlet;

        private Mock<DeploymentScriptsSdkClient> deploymentScriptsMockClient;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceGroupName = "myResourceGroup";

        private string deploymentScriptName = "myDeploymentScript";

        public SaveAzDeploymentScriptLogCommandTests(ITestOutputHelper output)
        {
            deploymentScriptsMockClient = new Mock<DeploymentScriptsSdkClient>();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();

            cmdlet = new SaveAzDeploymentScriptLog()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DeploymentScriptsSdkClient = deploymentScriptsMockClient.Object,
                
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveDeploymentScriptLogToDisk()
        {
            PsDeploymentScriptLog expected = new PsDeploymentScriptLog
            {
                Id = $"subscriptions/00000000-dead-beef-48e9-000000000000/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/deploymentScripts/{deploymentScriptName}/logs/default",
                Log = "This is the log content",
                Name = "default"
            };

            var TestLogPath = "TestLogPath";
            var expectedOutputPath = Path.Combine(TestLogPath, $"{deploymentScriptName}.txt");

            deploymentScriptsMockClient
                .Setup(f => f.GetDeploymentScriptLog(deploymentScriptName, resourceGroupName, 0))
                .Returns(expected);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var dataStore = new MockDataStore();
            AzureSession.Instance.DataStore = dataStore;

            dataStore.CreateDirectory(TestLogPath);
            // Read should not throw
            Assert.True(dataStore.DirectoryExists(TestLogPath));

            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.Name = deploymentScriptName;
            cmdlet.OutputPath = TestLogPath;
            cmdlet.Tail = 0;
            cmdlet.SetParameterSet("SaveDeploymentScriptLogByName");

            // Test
            cmdlet.ExecuteCmdlet();

            //Assert
            Assert.Equal(expected.DeploymentScriptName, deploymentScriptName);
            Assert.Equal(expected.Log, dataStore.ReadFileAsText(expectedOutputPath));
            Assert.True(dataStore.FileExists(expectedOutputPath));
        }
    }
}