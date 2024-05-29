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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.ServiceManagement.Common.Models;
using System.Linq;
using System.Collections;
using FluentAssertions;
using ProvisioningState = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.ProvisioningState;
using Microsoft.Azure.Management.Resources;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Resources.Test
{
    public class NewAzureResourceGroupDeploymentCommandTests : RMTestBase
    {
        private NewAzureResourceGroupDeploymentCmdlet cmdlet;

        private Mock<NewResourceManagerSdkClient> resourcesClientMock;

        private Mock<ITemplateSpecsClient> templateSpecsClientMock;

        private Mock<ITemplateSpecVersionsOperations> templateSpecsVersionOperationsMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceGroupName = "myResourceGroup";

        private string deploymentName = "fooDeployment";

        private string lastDeploymentName = "oldfooDeployment";

        private string queryString = "foo";

        private Dictionary<string, string> deploymentTags = Enumerable.Range(0, 2).ToDictionary(i => $"tagname{i}", i => $"tagvalue{i}");

        private string templateFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\sampleTemplateFile.json");

        private string templateUri = "http://mytemplate.com";

        public NewAzureResourceGroupDeploymentCommandTests(ITestOutputHelper output)
        {
            resourcesClientMock = new Mock<NewResourceManagerSdkClient>();

            templateSpecsClientMock = new Mock<ITemplateSpecsClient>();
            templateSpecsClientMock.SetupAllProperties();
            templateSpecsVersionOperationsMock = new Mock<ITemplateSpecVersionsOperations>();
            templateSpecsClientMock.Setup(m => m.TemplateSpecVersions).Returns(templateSpecsVersionOperationsMock.Object);

            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            cmdlet = new NewAzureResourceGroupDeploymentCmdlet()
            {
                CommandRuntime = commandRuntimeMock.Object,
                NewResourceManagerSdkClient = resourcesClientMock.Object,
                TemplateSpecsClient = templateSpecsClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreatesNewPSResourceGroupDeploymentWithUserTemplate()
        {
            PSDeploymentCmdletParameters expectedParameters = new PSDeploymentCmdletParameters()
            {
                TemplateFile = templateFile,
                DeploymentName = deploymentName,
                Tags = new Dictionary<string, string>(this.deploymentTags)
            };
            PSDeploymentCmdletParameters actualParameters = new PSDeploymentCmdletParameters();
            PSResourceGroupDeployment expected = new PSResourceGroupDeployment()
            {
                Mode = DeploymentMode.Incremental,
                DeploymentName = deploymentName,
                CorrelationId = "123",
                Outputs = new Dictionary<string, DeploymentVariable>()
                {
                    { "Variable1", new DeploymentVariable() { Value = "true", Type = "bool" } },
                    { "Variable2", new DeploymentVariable() { Value = "10", Type = "int" } },
                    { "Variable3", new DeploymentVariable() { Value = "hello world", Type = "string" } }
                },
                Parameters = new Dictionary<string, DeploymentVariable>()
                {
                    { "Parameter1", new DeploymentVariable() { Value = "true", Type = "bool" } },
                    { "Parameter2", new DeploymentVariable() { Value = "10", Type = "int" } },
                    { "Parameter3", new DeploymentVariable() { Value = "hello world", Type = "string" } }
                },
                ProvisioningState = ProvisioningState.Succeeded.ToString(),
                ResourceGroupName = resourceGroupName,
                TemplateLink = new TemplateLink()
                {
                    ContentVersion = "1.0",
                    Uri = "http://mytemplate.com"
                },
                Timestamp = new DateTime(2014, 2, 13)
            };
            resourcesClientMock.Setup(f => f.ExecuteResourceGroupDeployment(
                It.IsAny<PSDeploymentCmdletParameters>()))
                .Returns(expected)
                .Callback((PSDeploymentCmdletParameters p) => { actualParameters = p; });

            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.Name = expectedParameters.DeploymentName;
            cmdlet.TemplateFile = expectedParameters.TemplateFile;
            cmdlet.Tag = new Hashtable(this.deploymentTags);

            cmdlet.ExecuteCmdlet();

            actualParameters.DeploymentName.Should().Equals(expectedParameters.DeploymentName);
            actualParameters.TemplateFile.Should().Equals(expectedParameters.TemplateFile);
            actualParameters.TemplateParameterObject.Should().NotBeNull();
            actualParameters.OnErrorDeployment.Should().BeNull();
            actualParameters.Tags.Should().NotBeNull();

            var differenceTags = actualParameters.Tags
                .Where(entry => expectedParameters.Tags[entry.Key] != entry.Value);
            differenceTags.Should().BeEmpty();

            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreatesNewPSResourceGroupDeploymentWithUserTemplateSpecificRollback()
        {
            PSDeploymentCmdletParameters expectedParameters = new PSDeploymentCmdletParameters()
            {
                TemplateFile = templateFile,
                DeploymentName = deploymentName,
                Tags = new Dictionary<string, string>(this.deploymentTags),
                OnErrorDeployment = new OnErrorDeployment
                {
                    Type = OnErrorDeploymentType.SpecificDeployment,
                    DeploymentName = lastDeploymentName
                }
            };
            PSDeploymentCmdletParameters actualParameters = new PSDeploymentCmdletParameters();
            PSResourceGroupDeployment expected = new PSResourceGroupDeployment()
            {
                Mode = DeploymentMode.Incremental,
                DeploymentName = deploymentName,
                CorrelationId = "123",
                Outputs = new Dictionary<string, DeploymentVariable>()
                {
                    { "Variable1", new DeploymentVariable() { Value = "true", Type = "bool" } },
                    { "Variable2", new DeploymentVariable() { Value = "10", Type = "int" } },
                    { "Variable3", new DeploymentVariable() { Value = "hello world", Type = "string" } }
                },
                Parameters = new Dictionary<string, DeploymentVariable>()
                {
                    { "Parameter1", new DeploymentVariable() { Value = "true", Type = "bool" } },
                    { "Parameter2", new DeploymentVariable() { Value = "10", Type = "int" } },
                    { "Parameter3", new DeploymentVariable() { Value = "hello world", Type = "string" } }
                },
                ProvisioningState = ProvisioningState.Succeeded.ToString(),
                ResourceGroupName = resourceGroupName,
                TemplateLink = new TemplateLink()
                {
                    ContentVersion = "1.0",
                    Uri = "http://mytemplate.com"
                },
                Timestamp = new DateTime(2014, 2, 13),
                OnErrorDeployment = new OnErrorDeploymentExtended
                {
                    Type = OnErrorDeploymentType.SpecificDeployment,
                    DeploymentName = lastDeploymentName
                }
            };
            resourcesClientMock.Setup(f => f.ExecuteResourceGroupDeployment(
                It.IsAny<PSDeploymentCmdletParameters>()))
                .Returns(expected)
                .Callback((PSDeploymentCmdletParameters p) => { actualParameters = p; });

            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.Name = expectedParameters.DeploymentName;
            cmdlet.TemplateFile = expectedParameters.TemplateFile;
            cmdlet.RollBackDeploymentName = lastDeploymentName;
            cmdlet.Tag = new Hashtable(this.deploymentTags);
            cmdlet.ExecuteCmdlet();

            actualParameters.DeploymentName.Should().Equals(expectedParameters.DeploymentName);
            actualParameters.TemplateFile.Should().Equals(expectedParameters.TemplateFile);
            actualParameters.TemplateParameterObject.Should().NotBeNull();
            actualParameters.OnErrorDeployment.Should().NotBeNull();
            actualParameters.OnErrorDeployment.Type.Should().Equals(expectedParameters.OnErrorDeployment.Type);
            actualParameters.OnErrorDeployment.DeploymentName.Should().Equals(expectedParameters.OnErrorDeployment.DeploymentName);
            actualParameters.Tags.Should().NotBeNull();

            var differenceTags = actualParameters.Tags
                .Where(entry => expectedParameters.Tags[entry.Key] != entry.Value);
            differenceTags.Should().BeEmpty();

            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreatesNewPSResourceGroupDeploymentWithUserTemplateEmptyRollback()
        {
            PSDeploymentCmdletParameters expectedParameters = new PSDeploymentCmdletParameters()
            {
                TemplateFile = templateFile,
                DeploymentName = deploymentName,
                Tags = new Dictionary<string, string>(this.deploymentTags),
                OnErrorDeployment = new OnErrorDeployment
                {
                    Type = OnErrorDeploymentType.LastSuccessful,
                }
            };
            PSDeploymentCmdletParameters actualParameters = new PSDeploymentCmdletParameters();
            PSResourceGroupDeployment expected = new PSResourceGroupDeployment()
            {
                Mode = DeploymentMode.Incremental,
                DeploymentName = deploymentName,
                CorrelationId = "123",
                Outputs = new Dictionary<string, DeploymentVariable>()
                {
                    { "Variable1", new DeploymentVariable() { Value = "true", Type = "bool" } },
                    { "Variable2", new DeploymentVariable() { Value = "10", Type = "int" } },
                    { "Variable3", new DeploymentVariable() { Value = "hello world", Type = "string" } }
                },
                Parameters = new Dictionary<string, DeploymentVariable>()
                {
                    { "Parameter1", new DeploymentVariable() { Value = "true", Type = "bool" } },
                    { "Parameter2", new DeploymentVariable() { Value = "10", Type = "int" } },
                    { "Parameter3", new DeploymentVariable() { Value = "hello world", Type = "string" } }
                },
                ProvisioningState = ProvisioningState.Succeeded.ToString(),
                ResourceGroupName = resourceGroupName,
                TemplateLink = new TemplateLink()
                {
                    ContentVersion = "1.0",
                    Uri = "http://mytemplate.com"
                },
                Timestamp = new DateTime(2014, 2, 13),
                OnErrorDeployment = new OnErrorDeploymentExtended
                {
                    Type = OnErrorDeploymentType.LastSuccessful,
                }
            };
            resourcesClientMock.Setup(f => f.ExecuteResourceGroupDeployment(
                It.IsAny<PSDeploymentCmdletParameters>()))
                .Returns(expected)
                .Callback((PSDeploymentCmdletParameters p) => { actualParameters = p; });

            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.Name = expectedParameters.DeploymentName;
            cmdlet.TemplateFile = expectedParameters.TemplateFile;
            cmdlet.RollbackToLastDeployment = true;
            cmdlet.Tag = new Hashtable(this.deploymentTags);
            cmdlet.ExecuteCmdlet();

            actualParameters.DeploymentName.Should().Equals(expectedParameters.DeploymentName);
            actualParameters.TemplateFile.Should().Equals(expectedParameters.TemplateFile);
            actualParameters.TemplateParameterObject.Should().NotBeNull();
            actualParameters.OnErrorDeployment.Should().NotBeNull();
            actualParameters.OnErrorDeployment.Type.Should().Equals(expectedParameters.OnErrorDeployment.Type);
            actualParameters.OnErrorDeployment.DeploymentName.Should().Equals(expectedParameters.OnErrorDeployment.DeploymentName);
            actualParameters.Tags.Should().NotBeNull();

            var differenceTags = actualParameters.Tags
                .Where(entry => expectedParameters.Tags[entry.Key] != entry.Value);
            differenceTags.Should().BeEmpty();

            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }

        /// <summary>
        /// When deployments are created using a template spec, the dynamic parameters are
        /// resolved by reading the parameters from the template spec version's template body. 
        /// Previously a bug was present that prevented successful dynamic parameter resolution
        /// if the template spec existed in a subscription outside the current subscription 
        /// context. This test validates dynamic parameter resolution works for deployments using
        /// cross-subscription template specs.
        /// </summary>

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolvesDynamicParametersWithCrossSubTemplateSpec()
        {
            const string templateSpecSubscriptionId = "10000000-0000-0000-0000-000000000000";
            const string templateSpecRGName = "someRG";
            const string templateSpecName = "myTemplateSpec";
            const string templateSpecVersion = "v1";

            string templateSpecId = $"/subscriptions/{templateSpecSubscriptionId}/" +
                $"resourceGroups/{templateSpecRGName}/providers/Microsoft.Resources/" +
                $"templateSpecs/{templateSpecName }/versions/{templateSpecVersion}";

            // Ensure our template file path is normalized for the current system:
            var normalizedTemplateFilePath = (Path.DirectorySeparatorChar != '\\')
                ? templateFile.Replace('\\', Path.DirectorySeparatorChar) // Other/Unix based
                : templateFile; // Windows based (already valid)

            var templateContentForTest = File.ReadAllText(normalizedTemplateFilePath);
            var template = templateContentForTest.FromJson<TemplateFile>();

            templateSpecsVersionOperationsMock.Setup(f => f.GetWithHttpMessagesAsync(
                    templateSpecRGName,
                    templateSpecName,
                    templateSpecVersion,
                    null,
                    new CancellationToken()))
                .Returns(() => {

                    // We should only be getting this template spec from the expected subscription:
                    Assert.Equal(templateSpecSubscriptionId, templateSpecsClientMock.Object.SubscriptionId);

                    var versionToReturn = new TemplateSpecVersion(
                        location: "westus2",
                        id: templateSpecId,
                        name: templateSpecVersion,
                        type: "Microsoft.Resources/templateSpecs/versions",
                        mainTemplate: JObject.Parse(templateContentForTest)
                    );

                    return Task.Factory.StartNew(() =>
                        new AzureOperationResponse<TemplateSpecVersion>()
                        {
                            Body = versionToReturn
                        }
                    );
                });

            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.Name = deploymentName;
            cmdlet.TemplateSpecId = templateSpecId;

            var dynamicParams = cmdlet.GetDynamicParameters() as RuntimeDefinedParameterDictionary;

            dynamicParams.Should().NotBeNull();
            dynamicParams.Count().Should().Be(template.Parameters.Count);
            dynamicParams.Keys.Should().Contain(template.Parameters.Keys);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreatesNewDeploymentUsingQueryStringParam()
        {
            PSDeploymentCmdletParameters expectedParameters = new PSDeploymentCmdletParameters()
            {
                TemplateFile = templateUri,
                DeploymentName = deploymentName,
                QueryString = queryString,
                Tags = new Dictionary<string, string>(this.deploymentTags)
            };
            PSDeploymentCmdletParameters actualParameters = new PSDeploymentCmdletParameters();
            PSResourceGroupDeployment expected = new PSResourceGroupDeployment()
            {
                Mode = DeploymentMode.Incremental,
                DeploymentName = deploymentName,
                CorrelationId = "123",
                Outputs = new Dictionary<string, DeploymentVariable>()
                {
                    { "Variable1", new DeploymentVariable() { Value = "true", Type = "bool" } },
                    { "Variable2", new DeploymentVariable() { Value = "10", Type = "int" } },
                    { "Variable3", new DeploymentVariable() { Value = "hello world", Type = "string" } }
                },
                Parameters = new Dictionary<string, DeploymentVariable>()
                {
                    { "Parameter1", new DeploymentVariable() { Value = "true", Type = "bool" } },
                    { "Parameter2", new DeploymentVariable() { Value = "10", Type = "int" } },
                    { "Parameter3", new DeploymentVariable() { Value = "hello world", Type = "string" } }
                },
                ProvisioningState = ProvisioningState.Succeeded.ToString(),
                ResourceGroupName = resourceGroupName,
                TemplateLink = new TemplateLink()
                {
                    ContentVersion = "1.0",
                    Uri = "http://mytemplate.com",
                    QueryString = "foo"
                },
                Timestamp = new DateTime(2014, 2, 13)
            };
            resourcesClientMock.Setup(f => f.ExecuteResourceGroupDeployment(
                It.IsAny<PSDeploymentCmdletParameters>()))
                .Returns(expected)
                .Callback((PSDeploymentCmdletParameters p) => { actualParameters = p; });

            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.Name = expectedParameters.DeploymentName;
            cmdlet.TemplateUri = expectedParameters.TemplateFile;
            cmdlet.QueryString = expectedParameters.QueryString;
            cmdlet.Tag = new Hashtable(this.deploymentTags);

            cmdlet.ExecuteCmdlet();

            actualParameters.DeploymentName.Should().Equals(expectedParameters.DeploymentName);
            actualParameters.TemplateFile.Should().Equals(expectedParameters.TemplateFile);
            actualParameters.QueryString.Should().Equals(expectedParameters.QueryString);
            actualParameters.TemplateParameterObject.Should().NotBeNull();
            actualParameters.OnErrorDeployment.Should().BeNull();
            actualParameters.Tags.Should().NotBeNull();

            var differenceTags = actualParameters.Tags
                .Where(entry => expectedParameters.Tags[entry.Key] != entry.Value);
            differenceTags.Should().BeEmpty();

            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }
    }
}
