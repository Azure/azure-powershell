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

namespace Microsoft.Azure.Commands.Resources.Test
{
    using System;
    using System.Management.Automation;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.Resources.Models.ProviderFeatures;
    using Microsoft.Azure.Commands.Resources.ProviderFeatures;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Moq;
    using WindowsAzure.Commands.Test.Utilities.Common;
    using Xunit;

    /// <summary>
    /// Tests the Azure Provider Feature cmdlets
    /// </summary>
    public class RegisterAzureProviderFeatureCmdletTests : RMTestBase
    {
        /// <summary>
        /// An instance of the cmdlet
        /// </summary>
        private readonly RegisterAzureProviderFeatureCmdlet cmdlet;

        /// <summary>
        /// A mock of the client
        /// </summary>
        private readonly Mock<IFeatures> featureOperationsMock;

        /// <summary>
        /// A mock of the command runtime
        /// </summary>
        private readonly Mock<ICommandRuntime> commandRuntimeMock;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAzureProviderFeatureCmdletTests"/> class.
        /// </summary>
        public RegisterAzureProviderFeatureCmdletTests()
        {
            this.featureOperationsMock = new Mock<IFeatures>();
            var featureClient = new Mock<IFeatureClient>();

            featureClient
                .SetupGet(client => client.Features)
                .Returns(() => this.featureOperationsMock.Object);

            this.commandRuntimeMock = new Mock<ICommandRuntime>();

            this.commandRuntimeMock
              .Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
              .Returns(() => true);

            this.cmdlet = new RegisterAzureProviderFeatureCmdlet()
            {
                CommandRuntime = commandRuntimeMock.Object,
                ProviderFeatureClient = new ProviderFeatureClient
                {
                    FeaturesManagementClient = featureClient.Object
                }
            };
        }

        /// <summary>
        /// Validates all Register-AzureRmResourceProvider scenarios
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RegisterResourceProviderFeatureTests()
        {
            const string ProviderName = "Providers.Test";
            const string FeatureName = "Feature1";

            var registeredFeature = new FeatureResponse
            {
                Id = "featureId1",
                Name = ProviderName + "/" + FeatureName,
                Properties = new FeatureProperties
                {
                    State = ProviderFeatureClient.RegisteredStateName,
                },
                RequestId = "requestId",
                StatusCode = HttpStatusCode.OK,
                Type = "Microsoft.Features/feature"
            };

            this.featureOperationsMock
                .Setup(client => client.RegisterAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Callback((string providerName, string featureName, CancellationToken ignored) =>
                {
                    Assert.Equal(ProviderName, providerName, StringComparer.InvariantCultureIgnoreCase);
                    Assert.Equal(FeatureName, featureName, StringComparer.InvariantCultureIgnoreCase);
                })
                .Returns(() => Task.FromResult(registeredFeature));

            this.cmdlet.Force = true;
            this.cmdlet.ProviderNamespace = ProviderName;
            this.cmdlet.FeatureName = FeatureName;

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>()))
                .Callback((object obj) =>
                {
                    Assert.IsType<PSProviderFeature>(obj);
                    var feature = (PSProviderFeature)obj;
                    Assert.Equal(ProviderName, feature.ProviderName, StringComparer.InvariantCultureIgnoreCase);
                    Assert.Equal(FeatureName, feature.FeatureName, StringComparer.InvariantCultureIgnoreCase);
                });

            this.cmdlet.ExecuteCmdlet();

            this.VerifyCallPatternAndReset(succeeded: true);
        }

        /// <summary>
        /// Verifies the right call patterns are made
        /// </summary>
        private void VerifyCallPatternAndReset(bool succeeded)
        {
            this.featureOperationsMock.Verify(f => f.RegisterAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once());
            this.commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<object>()), succeeded ? Times.Once() : Times.Never());

            this.featureOperationsMock.ResetCalls();
            this.commandRuntimeMock.ResetCalls();
        }
    }
}
