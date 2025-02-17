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
using Microsoft.Azure.Management.Resources.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.NewSdkExtensions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;

namespace Microsoft.Azure.Commands.Resources.Test.Resources
{
    public class TestAzureResourceGroupDeploymentCommandTests : RMTestBase
    {
        private TestAzureResourceGroupDeploymentCmdlet cmdlet;

        private Mock<NewResourceManagerSdkClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceGroupName = "myResourceGroup";

        private string templateFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\sampleTemplateFile.json");

        public TestAzureResourceGroupDeploymentCommandTests(ITestOutputHelper output)
        {
            resourcesClientMock = new Mock<NewResourceManagerSdkClient>();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new TestAzureResourceGroupDeploymentCmdlet()
            {
                CommandRuntime = commandRuntimeMock.Object,
                NewResourceManagerSdkClient = resourcesClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidatesPSResourceGroupDeploymentWithUserTemplate()
        {
            PSDeploymentCmdletParameters expectedParameters = new PSDeploymentCmdletParameters()
            {
                TemplateFile = templateFile
            };
            PSDeploymentCmdletParameters actualParameters = new PSDeploymentCmdletParameters();

            List<ErrorDetail> expected = new List<ErrorDetail>()
            {
                new ErrorDetail(code: "202", message: "bad input"),
                new ErrorDetail(code: "203", message: "bad input 2"),
                new ErrorDetail(code: "203", message: "bad input 3")
            };
            TemplateValidationInfo expectedResults = new(errors: expected, diagnostics: new List<DeploymentDiagnosticsDefinition>(), requiredProviders: new List<Provider>());

            var expectedErrors = expected.Select(e => e.ToPSResourceManagerError()).ToList();

            resourcesClientMock.Setup(f => f.ValidateDeployment(
                It.IsAny<PSDeploymentCmdletParameters>()))
                .Returns(expectedResults)
                .Callback((PSDeploymentCmdletParameters p) => { actualParameters = p; });

            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.TemplateFile = expectedParameters.TemplateFile;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(expectedParameters.TemplateFile, actualParameters.TemplateFile);
            Assert.NotNull(actualParameters.TemplateParameterObject);

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<List<PSResourceManagerError>>()), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidatesPSResourceGroupDeploymentWithUserTemplateWithDiagnostics()
        {
            PSDeploymentCmdletParameters expectedParameters = new PSDeploymentCmdletParameters()
            {
                TemplateFile = templateFile
            };
            PSDeploymentCmdletParameters actualParameters = new PSDeploymentCmdletParameters();

            List<DeploymentDiagnosticsDefinition> diagnostics = new List<DeploymentDiagnosticsDefinition>()
            {
                new DeploymentDiagnosticsDefinition(code: "202", message: "bad input", target: "resource1", level: "Warning"),
                new DeploymentDiagnosticsDefinition(code: "203", message: "bad input 2", target: "resource2", level: "Warning"),
                new DeploymentDiagnosticsDefinition(code: "203", message: "bad input 3",  target: "resource3", level: "Error")
            };
            TemplateValidationInfo expectedResults = new(errors: new List<ErrorDetail>(), diagnostics: diagnostics, requiredProviders: new List<Provider>());

            resourcesClientMock.Setup(f => f.ValidateDeployment(
                It.IsAny<PSDeploymentCmdletParameters>()))
                .Returns(expectedResults)
                .Callback((PSDeploymentCmdletParameters p) => { actualParameters = p; });

            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.TemplateFile = expectedParameters.TemplateFile;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(expectedParameters.TemplateFile, actualParameters.TemplateFile);
            Assert.NotNull(actualParameters.TemplateParameterObject);

            string expected = $@"

Diagnostics (3): 
{Color.DarkYellow}(resource1) bad input (202)
{Color.Reset}{Color.DarkYellow}(resource2) bad input 2 (203)
{Color.Reset}{Color.Red}(resource3) bad input 3 (203)
{Color.Reset}"
            .Replace("\r\n", Environment.NewLine);

            JToken expectedToken = new JValue(expected);
            PSObject expectedObject = new PSObject(JTokenExtensions.ConvertPropertyValueForPsObject(propertyValue: expectedToken));

            commandRuntimeMock.Verify(f => f.WriteObject(expectedObject, true), Times.Once());
            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<List<PSResourceManagerError>>()), Times.Never());
        }
    }
}
