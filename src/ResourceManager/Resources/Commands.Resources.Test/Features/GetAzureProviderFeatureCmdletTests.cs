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
    using System.Linq;
    using System.Management.Automation;
    using System.Threading;
    using System.Threading.Tasks;
    using WindowsAzure.Commands.Test.Utilities.Common;
    using Xunit;
    using Xunit.Abstractions;
    /// <summary>
    /// Tests the Azure Provider Feature cmdlets
    /// </summary>
    public class GetAzureProviderFeatureCmdletTests : RMTestBase
    {
        /// <summary>
        /// An instance of the cmdlet
        /// </summary>
        private readonly GetAzureProviderFeatureCmdletTest cmdlet;

        /// <summary>
        /// A mock of the command runtime
        /// </summary>
        private readonly Mock<ICommandRuntime> commandRuntimeMock;
        private MockCommandRuntime mockRuntime;

        /// <summary>
        /// A mock of the client
        /// </summary>
        private readonly Mock<IFeaturesOperations> featureOperationsMock;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAzureProviderFeatureCmdletTests"/> class.
        /// </summary>
        public GetAzureProviderFeatureCmdletTests(ITestOutputHelper output)
        {
            this.featureOperationsMock = new Mock<IFeaturesOperations>();
            var featureClient = new Mock<IFeatureClient>();

            featureClient
                .SetupGet(client => client.Features)
                .Returns(() => this.featureOperationsMock.Object);

            this.commandRuntimeMock = new Mock<ICommandRuntime>();

            this.cmdlet = new GetAzureProviderFeatureCmdletTest
            {
                //CommandRuntime = commandRuntimeMock.Object,
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
        /// Validates all Get-AzureRmResourceProvider parameter combinations
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetProviderFeatureTests()
        {
            // setup return values
            const string Provider1Namespace = "Providers.Test1";
            const string Feature1Name = "feature1";

            const string Provider2Namespace = "Providers.Test2";
            const string Feature2Name = "feature2";

            var provider1RegisteredFeature = new FeatureResult
            {
                Id = "featureId1",
                Name = Provider1Namespace + "/" + Feature1Name,
                Properties = new FeatureProperties
                {
                    State = ProviderFeatureClient.RegisteredStateName,
                },
                Type = "Microsoft.Features/feature"
            };

            var provider1UnregisteredFeature = new FeatureResult
            {
                Id = "featureId1",
                Name = Provider1Namespace + "/" + Feature2Name,
                Properties = new FeatureProperties
                {
                    State = "Unregistered",
                },
                Type = "Microsoft.Features/feature"
            };

            var provider2UnregisteredFeature = new FeatureResult
            {
                Id = "featureId2",
                Name = Provider2Namespace + "/" + Feature1Name,
                Properties = new FeatureProperties
                {
                    State = "Unregistered",
                },
                Type = "Microsoft.Features/feature"
            };

            var pagableResult = new Page<FeatureResult>();
            //var listResult = new[] { provider1RegisteredFeature, provider1UnregisteredFeature, provider2UnregisteredFeature };
            var listResult = new List<FeatureResult>() { provider1RegisteredFeature, provider1UnregisteredFeature, provider2UnregisteredFeature };
            pagableResult.SetItemValue<FeatureResult>(listResult);
            var result = new AzureOperationResponse<IPage<FeatureResult>>()
            {
                Body = pagableResult
            };

            this.featureOperationsMock
                .Setup(f => f.ListAllWithHttpMessagesAsync(null, It.IsAny<CancellationToken>()))
                .Returns(() => Task.FromResult(result));

            // 1. List only registered features of providers
            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>()))
                .Callback((object obj) =>
                {
                    Assert.IsType<PSProviderFeature[]>(obj);

                    var features = (PSProviderFeature[])obj;
                    Assert.Equal(1, features.Length);

                    var provider = features.Single();
                    Assert.Equal(Provider1Namespace, provider.ProviderName, StringComparer.OrdinalIgnoreCase);
                    Assert.Equal(Feature1Name, provider.FeatureName, StringComparer.OrdinalIgnoreCase);
                    Assert.Equal(ProviderFeatureClient.RegisteredStateName, provider.RegistrationState, StringComparer.OrdinalIgnoreCase);
                });

            this.cmdlet.ParameterSetOverride = GetAzureProviderFeatureCmdlet.ListAvailableParameterSet;

            this.cmdlet.ExecuteCmdlet();

            this.VerifyListAllCallPatternAndReset();

            // 2. List all features of all providers
            this.cmdlet.ListAvailable = true;

            this.commandRuntimeMock
              .Setup(m => m.WriteObject(It.IsAny<object>()))
              .Callback((object obj) =>
              {
                  Assert.IsType<PSProviderFeature[]>(obj);
                  var features = (PSProviderFeature[])obj;
                  Assert.Equal(listResult.Count(), features.Length);
              });

            this.cmdlet.ExecuteCmdlet();

            this.VerifyListAllCallPatternAndReset();

            // 3.a. List only registered features of a particular provider - and they exist
            string providerOfChoice = Provider1Namespace;
            this.cmdlet.ListAvailable = false;
            this.cmdlet.ProviderNamespace = providerOfChoice;
            //pagableResult.SetItemValue<FeatureResult>(new List<FeatureResult>() { provider1RegisteredFeature, provider1UnregisteredFeature });

            this.featureOperationsMock
                .Setup(f => f.ListWithHttpMessagesAsync(It.IsAny<string>(), null, It.IsAny<CancellationToken>()))
                .Callback((string providerName, Dictionary<string, List<string>> customHeaders, CancellationToken ignored) => Assert.Equal(providerOfChoice, providerName, StringComparer.OrdinalIgnoreCase))
                .Returns(() => Task.FromResult(
                    new AzureOperationResponse<IPage<FeatureResult>>()
                    {
                        Body = pagableResult
                    }));

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>()))
                .Callback((object obj) =>
                {
                    Assert.IsType<PSProviderFeature[]>(obj);

                    var features = (PSProviderFeature[])obj;
                    Assert.Equal(1, features.Length);

                    var provider = features.Single();
                    Assert.Equal(Provider1Namespace, provider.ProviderName, StringComparer.OrdinalIgnoreCase);
                    Assert.Equal(Feature1Name, provider.FeatureName, StringComparer.OrdinalIgnoreCase);
                    Assert.Equal(ProviderFeatureClient.RegisteredStateName, provider.RegistrationState, StringComparer.OrdinalIgnoreCase);
                });

            this.cmdlet.ParameterSetOverride = GetAzureProviderFeatureCmdlet.GetFeatureParameterSet;

            this.cmdlet.ExecuteCmdlet();

            this.VerifyListProviderFeaturesCallPatternAndReset();

            // 3.b. List only registered features of a particular provider - and they do not exist
            providerOfChoice = Provider2Namespace;
            this.cmdlet.ListAvailable = false;
            this.cmdlet.ProviderNamespace = providerOfChoice;
            //pagableResult.SetItemValue<FeatureResult>(new List<FeatureResult>() { provider2UnregisteredFeature });

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>()))
                .Callback((object obj) =>
                {
                    Assert.IsType<PSProviderFeature[]>(obj);

                    var features = (PSProviderFeature[])obj;
                    Assert.Equal(0, features.Length);
                });

            this.cmdlet.ExecuteCmdlet();

            this.VerifyListProviderFeaturesCallPatternAndReset();

            // 4. List all features of a particular provider
            providerOfChoice = Provider1Namespace;
            this.cmdlet.ProviderNamespace = providerOfChoice;
            this.cmdlet.ListAvailable = true;
            //pagableResult.SetItemValue<FeatureResult>(new List<FeatureResult>() { provider1RegisteredFeature, provider1UnregisteredFeature });

            this.commandRuntimeMock
              .Setup(m => m.WriteObject(It.IsAny<object>()))
              .Callback((object obj) =>
              {
                  Assert.IsType<PSProviderFeature[]>(obj);
                  var features = (PSProviderFeature[])obj;
                  Assert.Equal(2, features.Length);
                  Assert.True(features.Any(feature => string.Equals(feature.FeatureName, Feature1Name, StringComparison.OrdinalIgnoreCase)));
                  Assert.True(features.Any(feature => string.Equals(feature.FeatureName, Feature2Name, StringComparison.OrdinalIgnoreCase)));
                  Assert.True(features.All(feature => string.Equals(feature.ProviderName, Provider1Namespace, StringComparison.OrdinalIgnoreCase)));
              });

            this.cmdlet.ParameterSetOverride = GetAzureProviderFeatureCmdlet.ListAvailableParameterSet;

            this.cmdlet.ExecuteCmdlet();

            this.VerifyListProviderFeaturesCallPatternAndReset();

            // 5. get a single provider feature by name
            this.cmdlet.ProviderNamespace = Provider2Namespace;
            this.cmdlet.FeatureName = Feature1Name;
            this.cmdlet.ListAvailable = false;

            this.featureOperationsMock
              .Setup(f => f.GetWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), null, It.IsAny<CancellationToken>()))
              .Callback((string providerName, string featureName, Dictionary<string, List<string>> customHeaders, CancellationToken ignored) =>
              {
                  Assert.Equal(Provider2Namespace, providerName, StringComparer.OrdinalIgnoreCase);
                  Assert.Equal(Feature1Name, featureName, StringComparer.OrdinalIgnoreCase);
              })
              .Returns(() => Task.FromResult(new AzureOperationResponse<FeatureResult>()
              {
                  Body = provider2UnregisteredFeature
              }));

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>()))
                .Callback((object obj) =>
                {
                    Assert.IsType<PSProviderFeature[]>(obj);
                    var features = (PSProviderFeature[])obj;
                    Assert.Equal(1, features.Length);
                    var feature = features.Single();
                    Assert.Equal(Provider2Namespace, feature.ProviderName, StringComparer.OrdinalIgnoreCase);
                    Assert.Equal(Feature1Name, feature.FeatureName, StringComparer.OrdinalIgnoreCase);
                    Assert.Equal("Unregistered", feature.RegistrationState, StringComparer.OrdinalIgnoreCase);
                });

            this.cmdlet.ParameterSetOverride = GetAzureProviderFeatureCmdlet.GetFeatureParameterSet;

            this.cmdlet.ExecuteCmdlet();

            this.VerifyGetCallPatternAndReset();
        }

        /// <summary>
        /// Resets the calls on the mocks
        /// </summary>
        private void ResetCalls()
        {
            this.featureOperationsMock.ResetCalls();
            this.commandRuntimeMock.ResetCalls();
        }

        /// <summary>
        /// Verifies the right call patterns are made
        /// </summary>
        private void VerifyGetCallPatternAndReset()
        {
            this.featureOperationsMock.Verify(f => f.GetWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), null, It.IsAny<CancellationToken>()), Times.Once());
            this.featureOperationsMock.Verify(f => f.ListWithHttpMessagesAsync(It.IsAny<string>(), null, It.IsAny<CancellationToken>()), Times.Never);
            this.featureOperationsMock.Verify(f => f.ListAllWithHttpMessagesAsync(null, It.IsAny<CancellationToken>()), Times.Never);
            this.featureOperationsMock.Verify(f => f.ListNextWithHttpMessagesAsync(It.IsAny<string>(), null, It.IsAny<CancellationToken>()), Times.Never);
            this.featureOperationsMock.Verify(f => f.ListAllNextWithHttpMessagesAsync(It.IsAny<string>(), null, It.IsAny<CancellationToken>()), Times.Never);
            this.commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<object>(), It.IsAny<bool>()), Times.Once());

            this.ResetCalls();
        }

        /// <summary>
        /// Verifies the right call patterns are made
        /// </summary>
        private void VerifyListAllCallPatternAndReset()
        {
            this.featureOperationsMock.Verify(f => f.ListAllWithHttpMessagesAsync(null, It.IsAny<CancellationToken>()), Times.Once());
            this.featureOperationsMock.Verify(f => f.ListAllNextWithHttpMessagesAsync(It.IsAny<string>(), null, It.IsAny<CancellationToken>()), Times.Never);
            this.commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<object>(), It.IsAny<bool>()), Times.Once());

            this.ResetCalls();
        }

        /// <summary>
        /// Verifies the right call patterns are made
        /// </summary>
        private void VerifyListProviderFeaturesCallPatternAndReset()
        {
            this.featureOperationsMock.Verify(f => f.ListWithHttpMessagesAsync(It.IsAny<string>(), null, It.IsAny<CancellationToken>()), Times.Once());
            this.featureOperationsMock.Verify(f => f.ListNextWithHttpMessagesAsync(It.IsAny<string>(), null, It.IsAny<CancellationToken>()), Times.Never);
            this.commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<object>(), It.IsAny<bool>()), Times.Once());

            this.ResetCalls();
        }

        /// <summary>
        /// Helper class that enables setting the parameter set name
        /// </summary>
        private class GetAzureProviderFeatureCmdletTest : GetAzureProviderFeatureCmdlet
        {
            /// <summary>
            /// Sets the parameter set name to return
            /// </summary>
            public string ParameterSetOverride { private get; set; }

            /// <summary>
            /// Determines the parameter set name based on the <see cref="ParameterSetOverride"/> property
            /// </summary>
            public override string DetermineParameterSetName()
            {
                return this.ParameterSetOverride;
            }
        }
    }
}
