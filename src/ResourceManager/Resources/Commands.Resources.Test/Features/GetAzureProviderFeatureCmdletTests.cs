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
    using System.Linq;
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

        /// <summary>
        /// A mock of the client
        /// </summary>
        private readonly Mock<IFeatures> featureOperationsMock;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAzureProviderFeatureCmdletTests"/> class.
        /// </summary>
        public GetAzureProviderFeatureCmdletTests()
        {
            this.featureOperationsMock = new Mock<IFeatures>();
            var featureClient = new Mock<IFeatureClient>();

            featureClient
                .SetupGet(client => client.Features)
                .Returns(() => this.featureOperationsMock.Object);

            this.commandRuntimeMock = new Mock<ICommandRuntime>();

            this.cmdlet = new GetAzureProviderFeatureCmdletTest
            {
                CommandRuntime = commandRuntimeMock.Object,
                ProviderFeatureClient = new ProviderFeatureClient
                {
                    FeaturesManagementClient = featureClient.Object
                }
            };
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

            var provider1RegisteredFeature = new FeatureResponse
            {
                Id = "featureId1",
                Name = Provider1Namespace + "/" + Feature1Name,
                Properties = new FeatureProperties
                {
                    State = ProviderFeatureClient.RegisteredStateName,
                },
                RequestId = "requestId",
                StatusCode = HttpStatusCode.OK,
                Type = "Microsoft.Features/feature"
            };

            var provider1UnregisteredFeature = new FeatureResponse
            {
                Id = "featureId1",
                Name = Provider1Namespace + "/" + Feature2Name,
                Properties = new FeatureProperties
                {
                    State = "Unregistered",
                },
                RequestId = "requestId",
                StatusCode = HttpStatusCode.OK,
                Type = "Microsoft.Features/feature"
            };

            var provider2UnregisteredFeature = new FeatureResponse
            {
                Id = "featureId2",
                Name = Provider2Namespace + "/" + Feature1Name,
                Properties = new FeatureProperties
                {
                    State = "Unregistered",
                },
                RequestId = "requestId",
                StatusCode = HttpStatusCode.OK,
                Type = "Microsoft.Features/feature"
            };

            var listResult = new FeatureOperationsListResult
            {
                Features = new[] { provider1RegisteredFeature, provider1UnregisteredFeature, provider2UnregisteredFeature },
                NextLink = null,
                RequestId = "requestId",
                StatusCode = HttpStatusCode.OK
            };

            this.featureOperationsMock
                .Setup(f => f.ListAllAsync(It.IsAny<CancellationToken>()))
                .Returns(() => Task.FromResult(listResult));

            // 1. List only registered features of providers
            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>()))
                .Callback((object obj) =>
                {
                    Assert.IsType<PSProviderFeature[]>(obj);

                    var features = (PSProviderFeature[])obj;
                    Assert.Equal(1, features.Length);

                    var provider = features.Single();
                    Assert.Equal(Provider1Namespace, provider.ProviderName, StringComparer.InvariantCultureIgnoreCase);
                    Assert.Equal(Feature1Name, provider.FeatureName, StringComparer.InvariantCultureIgnoreCase);
                    Assert.Equal(ProviderFeatureClient.RegisteredStateName, provider.RegistrationState, StringComparer.InvariantCultureIgnoreCase);
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
                  Assert.Equal(listResult.Features.Count, features.Length);
              });

            this.cmdlet.ExecuteCmdlet();

            this.VerifyListAllCallPatternAndReset();

            // 3.a. List only registered features of a particular provider - and they exist
            string providerOfChoice = Provider1Namespace;
            this.cmdlet.ListAvailable = false;
            this.cmdlet.ProviderNamespace = providerOfChoice;
            listResult.Features = new[] { provider1RegisteredFeature, provider1UnregisteredFeature };

            this.featureOperationsMock
                .Setup(f => f.ListAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Callback((string providerName, CancellationToken ignored) => Assert.Equal(providerOfChoice, providerName, StringComparer.InvariantCultureIgnoreCase))
                .Returns(() => Task.FromResult(listResult));

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>()))
                .Callback((object obj) =>
                {
                    Assert.IsType<PSProviderFeature[]>(obj);

                    var features = (PSProviderFeature[])obj;
                    Assert.Equal(1, features.Length);

                    var provider = features.Single();
                    Assert.Equal(Provider1Namespace, provider.ProviderName, StringComparer.InvariantCultureIgnoreCase);
                    Assert.Equal(Feature1Name, provider.FeatureName, StringComparer.InvariantCultureIgnoreCase);
                    Assert.Equal(ProviderFeatureClient.RegisteredStateName, provider.RegistrationState, StringComparer.InvariantCultureIgnoreCase);
                });

            this.cmdlet.ParameterSetOverride = GetAzureProviderFeatureCmdlet.GetFeatureParameterSet;

            this.cmdlet.ExecuteCmdlet();

            this.VerifyListProviderFeaturesCallPatternAndReset();

            // 3.b. List only registered features of a particular provider - and they do not exist
            providerOfChoice = Provider2Namespace;
            this.cmdlet.ListAvailable = false;
            this.cmdlet.ProviderNamespace = providerOfChoice;
            listResult.Features = new[] { provider2UnregisteredFeature };

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
            listResult.Features = new[] { provider1RegisteredFeature, provider1UnregisteredFeature };

            this.commandRuntimeMock
              .Setup(m => m.WriteObject(It.IsAny<object>()))
              .Callback((object obj) =>
              {
                  Assert.IsType<PSProviderFeature[]>(obj);
                  var features = (PSProviderFeature[])obj;
                  Assert.Equal(2, features.Length);
                  Assert.True(features.Any(feature => string.Equals(feature.FeatureName, Feature1Name, StringComparison.InvariantCultureIgnoreCase)));
                  Assert.True(features.Any(feature => string.Equals(feature.FeatureName, Feature2Name, StringComparison.InvariantCultureIgnoreCase)));
                  Assert.True(features.All(feature => string.Equals(feature.ProviderName, Provider1Namespace, StringComparison.InvariantCultureIgnoreCase)));
              });

            this.cmdlet.ParameterSetOverride = GetAzureProviderFeatureCmdlet.ListAvailableParameterSet;

            this.cmdlet.ExecuteCmdlet();

            this.VerifyListProviderFeaturesCallPatternAndReset();

            // 5. get a single provider feature by name
            this.cmdlet.ProviderNamespace = Provider2Namespace;
            this.cmdlet.FeatureName = Feature1Name;
            this.cmdlet.ListAvailable = false;

            this.featureOperationsMock
              .Setup(f => f.GetAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
              .Callback((string providerName, string featureName, CancellationToken ignored) =>
              {
                  Assert.Equal(Provider2Namespace, providerName, StringComparer.InvariantCultureIgnoreCase);
                  Assert.Equal(Feature1Name, featureName, StringComparer.InvariantCultureIgnoreCase);
              })
              .Returns(() => Task.FromResult(provider2UnregisteredFeature));

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>()))
                .Callback((object obj) =>
                {
                    Assert.IsType<PSProviderFeature[]>(obj);
                    var features = (PSProviderFeature[])obj;
                    Assert.Equal(1, features.Length);
                    var feature = features.Single();
                    Assert.Equal(Provider2Namespace, feature.ProviderName, StringComparer.InvariantCultureIgnoreCase);
                    Assert.Equal(Feature1Name, feature.FeatureName, StringComparer.InvariantCultureIgnoreCase);
                    Assert.Equal("Unregistered", feature.RegistrationState, StringComparer.InvariantCultureIgnoreCase);
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
            this.featureOperationsMock.Verify(f => f.GetAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once());
            this.featureOperationsMock.Verify(f => f.ListAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
            this.featureOperationsMock.Verify(f => f.ListAllAsync(It.IsAny<CancellationToken>()), Times.Never);
            this.featureOperationsMock.Verify(f => f.ListNextAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
            this.featureOperationsMock.Verify(f => f.ListAllNextAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
            this.commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<object>(), It.IsAny<bool>()), Times.Once());

            this.ResetCalls();
        }

        /// <summary>
        /// Verifies the right call patterns are made
        /// </summary>
        private void VerifyListAllCallPatternAndReset()
        {
            this.featureOperationsMock.Verify(f => f.ListAllAsync(It.IsAny<CancellationToken>()), Times.Once());
            this.featureOperationsMock.Verify(f => f.ListAllNextAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
            this.commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<object>(), It.IsAny<bool>()), Times.Once());

            this.ResetCalls();
        }

        /// <summary>
        /// Verifies the right call patterns are made
        /// </summary>
        private void VerifyListProviderFeaturesCallPatternAndReset()
        {
            this.featureOperationsMock.Verify(f => f.ListAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once());
            this.featureOperationsMock.Verify(f => f.ListNextAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
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
