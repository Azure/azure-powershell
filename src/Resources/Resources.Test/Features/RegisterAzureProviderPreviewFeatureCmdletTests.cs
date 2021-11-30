﻿// ----------------------------------------------------------------------------------
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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Threading;
    using System.Threading.Tasks;
    using WindowsAzure.Commands.Test.Utilities.Common;
    using Xunit;
    using Xunit.Abstractions;
    /// <summary>
    /// Tests the Azure Provider Feature cmdlets
    /// </summary>
    public class RegisterAzureProviderPreviewFeatureCmdletTests : RMTestBase
    {
        /// <summary>
        /// An instance of the cmdlet
        /// </summary>
        private readonly RegisterAzureProviderPreviewFeatureCmdlet cmdlet;

        /// <summary>
        /// A mock of the client
        /// </summary>
        private readonly Mock<ISubscriptionFeatureRegistrationsOperations> featureOperationsMock;

        /// <summary>
        /// A mock of the command runtime
        /// </summary>
        private readonly Mock<ICommandRuntime> commandRuntimeMock;
        private MockCommandRuntime mockRuntime;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAzureProviderFeatureCmdletTests"/> class.
        /// </summary>
        public RegisterAzureProviderPreviewFeatureCmdletTests(ITestOutputHelper output)
        {
            this.featureOperationsMock = new Mock<ISubscriptionFeatureRegistrationsOperations>();
            var featureClient = new Mock<IFeatureClient>();

            featureClient
                .SetupGet(client => client.SubscriptionFeatureRegistrations)
                .Returns(() => this.featureOperationsMock.Object);

            this.commandRuntimeMock = new Mock<ICommandRuntime>();

            this.commandRuntimeMock
              .Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
              .Returns(() => true);

            this.cmdlet = new RegisterAzureProviderPreviewFeatureCmdlet()
            {
                ProviderFeatureClient = new ProviderFeatureClient
                {
                    FeaturesManagementClient = featureClient.Object
                }
            };
            PSCmdletExtensions.SetCommandRuntimeMock(cmdlet, commandRuntimeMock.Object);
            mockRuntime = new MockCommandRuntime();
            commandRuntimeMock.Setup(f => f.Host).Returns(mockRuntime.Host);
        }

        /// <summary>
        /// Validates all Create-AzFeatureRegistration scenarios
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateFeatureRegistrationTests()
        {
            const string ProviderName = "Providers.Test";
            const string FeatureName = "Feature1";

            var registeredFeature = new SubscriptionFeatureRegistration(id: "featureId1", name: $"{ProviderName}/{FeatureName}");
            registeredFeature.Properties = new SubscriptionFeatureRegistrationProperties
            {
                State = ProviderFeatureClient.RegisteredStateName
            };

            this.featureOperationsMock
                .Setup(client => client.CreateOrUpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<SubscriptionFeatureRegistration>(), null, It.IsAny<CancellationToken>()))
                .Callback((string providerName, string featureName, SubscriptionFeatureRegistration subscriptionFeatureRegistrationType, Dictionary<string, List<string>> customHeaders, CancellationToken ignored) =>
                {
                    Assert.Equal(ProviderName, providerName, StringComparer.OrdinalIgnoreCase);
                    Assert.Equal(FeatureName, featureName, StringComparer.OrdinalIgnoreCase);
                })
                .Returns(() => Task.FromResult(new AzureOperationResponse<SubscriptionFeatureRegistration>()
                {
                    Body = registeredFeature
                }));
            
            this.cmdlet.ProviderNamespace = ProviderName;
            this.cmdlet.Name = FeatureName;

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>()))
                .Callback((object obj) =>
                {
                    Assert.IsType<PSSubscriptionFeatureRegistration>(obj);
                    var feature = (PSSubscriptionFeatureRegistration)obj;
                    Assert.Equal(ProviderFeatureClient.RegisteredStateName, feature.Properties.State, StringComparer.OrdinalIgnoreCase);
                    Assert.Equal($"{ProviderName}/{FeatureName}", feature.Name, StringComparer.OrdinalIgnoreCase);
                });

            this.cmdlet.ExecuteCmdlet();

            this.VerifyCallPatternAndReset(succeeded: true);
        }

        /// <summary>
        /// Verifies the right call patterns are made
        /// </summary>
        private void VerifyCallPatternAndReset(bool succeeded)
        {
            this.featureOperationsMock.Verify(f => f.CreateOrUpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<SubscriptionFeatureRegistration>(), null, It.IsAny<CancellationToken>()), Times.Once());
            this.commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<object>()), succeeded ? Times.Once() : Times.Never());

            this.featureOperationsMock.ResetCalls();
            this.commandRuntimeMock.ResetCalls();
        }
    }
}
