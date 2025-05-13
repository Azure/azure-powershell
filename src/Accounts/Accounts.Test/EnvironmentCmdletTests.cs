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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using Moq;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;

using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class EnvironmentCmdletTests : RMTestBase
    {
        private MemoryDataStore dataStore;

        public EnvironmentCmdletTests(ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            if (!AzureSession.Instance.TryGetComponent(nameof(AuthenticationTelemetry), out AuthenticationTelemetry authenticationTelemetry))
            {
                AzureSession.Instance.RegisterComponent<AuthenticationTelemetry>(nameof(AuthenticationTelemetry), () => new AuthenticationTelemetry());
            }
        }

        private void Cleanup()
        {
            currentProfile = null;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddsAzureEnvironment()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal"
            };
            var dict = new Dictionary<string, object>
            {
                { "PublishSettingsFileUrl", "http://microsoft.com" },
                { "ServiceEndpoint", "https://endpoint.net" },
                { "ManagementPortalUrl", "http://management.portal.url" },
                { "StorageEndpoint", "http://endpoint.net" },
                { "GalleryEndpoint", "http://galleryendpoint.com" },

            };

            cmdlet.SetBoundParameters(dict);
            cmdlet.SetParameterSet("Name");
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            var profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>());
            IAzureEnvironment env = AzureRmProfileProvider.Instance.Profile.Environments.First((e) => string.Equals(e.Name, "KaTaL", StringComparison.OrdinalIgnoreCase));
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.Equal(env.GetEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl), dict["PublishSettingsFileUrl"]);
            Assert.Equal(env.GetEndpoint(AzureEnvironment.Endpoint.ServiceManagement), dict["ServiceEndpoint"]);
            Assert.Equal(env.GetEndpoint(AzureEnvironment.Endpoint.ManagementPortalUrl), dict["ManagementPortalUrl"]);
            Assert.Equal("http://galleryendpoint.com", env.GetEndpoint(AzureEnvironment.Endpoint.Gallery));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddsAzureEnvironmentUsingAPublicRMEndpoint()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                ARMEndpoint = "https://management.azure.com/"
            };

            Mock<EnvironmentHelper> envHelperMock = new Mock<EnvironmentHelper>();

#if NETSTANDARD
            envHelperMock.Setup(f => f.RetrieveMetaDataEndpoints(It.IsAny<string>(), It.IsAny<IHttpOperationsFactory>())).ReturnsAsync(() => null);
#else
            envHelperMock.Setup(f => f.RetrieveMetaDataEndpoints(It.IsAny<string>(), It.IsAny<IHttpOperationsFactory>())).ReturnsAsync(null);
#endif
            envHelperMock.Setup(f => f.RetrieveDomain(It.IsAny<string>())).Returns("domain");
            cmdlet.EnvHelper = envHelperMock.Object;
            cmdlet.SetParameterSet("ARMEndpoint");
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            IAzureEnvironment env = AzureRmProfileProvider.Instance.Profile.GetEnvironment("Katal");
            var oracle = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.Equal(oracle.ResourceManagerUrl, env.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager));
            Assert.Equal(oracle.ActiveDirectoryAuthority, env.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectory));
            Assert.Equal(oracle.ActiveDirectoryServiceEndpointResourceId, env.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId));
            envHelperMock.Verify(f => f.RetrieveDomain(It.IsAny<string>()), Times.Never);
            envHelperMock.Verify(f => f.RetrieveMetaDataEndpoints(It.IsAny<string>(), It.IsAny<IHttpOperationsFactory>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddsAzureEnvironmentUsingARMEndpoint()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Stack",
                ARMEndpoint = "https://management.local.azurestack.external/"
            };

            Mock<EnvironmentHelper> envHelperMock = new Mock<EnvironmentHelper>();
            MetadataResponse metadataEndpoints = new MetadataResponse
            {
                GalleryEndpoint = "",
                GraphEndpoint = "https://graphendpoint",
                PortalEndpoint = "https://portalendpoint",
                authentication = new Authentication
                {
                    Audiences = new[] { "audience1", "audience2" },
                    LoginEndpoint = "https://loginendpoint"
                }
            };
            envHelperMock.Setup(f => f.RetrieveMetaDataEndpoints(It.IsAny<string>(), It.IsAny<IHttpOperationsFactory>())).ReturnsAsync(metadataEndpoints);
            envHelperMock.Setup(f => f.RetrieveDomain(It.IsAny<string>())).Returns("domain");
            cmdlet.EnvHelper = envHelperMock.Object;
            cmdlet.SetParameterSet("ARMEndpoint");
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            var profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>());
            IAzureEnvironment env = AzureRmProfileProvider.Instance.Profile.GetEnvironment("Stack");
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.Equal(cmdlet.ARMEndpoint, env.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager));
            Assert.Equal("https://loginendpoint/", env.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectory));
            Assert.Equal("audience1", env.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId));
            Assert.Equal("https://graphendpoint", env.GetEndpoint(AzureEnvironment.Endpoint.GraphEndpointResourceId));
            Assert.Null(env.GetEndpoint(AzureEnvironment.Endpoint.Gallery));
            envHelperMock.Verify(f => f.RetrieveDomain(It.IsAny<string>()), Times.Once);
            envHelperMock.Verify(f => f.RetrieveMetaDataEndpoints(It.IsAny<string>(), It.IsAny<IHttpOperationsFactory>()), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddsEnvironmentMultipleTimes()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                PublishSettingsFileUrl = "http://microsoft.com",
                EnableAdfsAuthentication = true,
            };

            var dict = new Dictionary<string, object>();
            dict["PublishSettingsFileUrl"] = "http://microsoft.com";
            dict["EnableAdfsAuthentication"] = true;
            cmdlet.SetBoundParameters(dict);
            cmdlet.SetParameterSet("Name");

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            IAzureEnvironment env = AzureRmProfileProvider.Instance.Profile.GetEnvironment("KaTaL");
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.True(env.OnPremise);
            Assert.Equal(env.GetEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl), cmdlet.PublishSettingsFileUrl);

            // Execute the same without PublishSettingsFileUrl and make sure the first value is preserved
            var cmdlet2 = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                EnableAdfsAuthentication = true,
            };

            dict.Clear();
            dict["EnableAdfsAuthentication"] = true;
            cmdlet2.SetBoundParameters(dict);
            cmdlet2.SetParameterSet("Name");

            cmdlet2.InvokeBeginProcessing();
            cmdlet2.ExecuteCmdlet();
            cmdlet2.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Exactly(2));
            IAzureEnvironment env2 = AzureRmProfileProvider.Instance.Profile.GetEnvironment("KaTaL");
            Assert.Equal(env2.Name, cmdlet2.Name);
            Assert.True(env2.OnPremise);
            Assert.Equal(env2.GetEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl), cmdlet.PublishSettingsFileUrl);

            var cmdlet3 = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
            };
            dict.Clear();
            cmdlet3.SetBoundParameters(dict);
            cmdlet3.SetParameterSet("Name");

            cmdlet3.InvokeBeginProcessing();
            cmdlet3.ExecuteCmdlet();
            cmdlet3.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Exactly(3));
            IAzureEnvironment env3 = AzureRmProfileProvider.Instance.Profile.GetEnvironment("KaTaL");
            Assert.Equal(env3.Name, cmdlet3.Name);
            Assert.Equal(env3.GetEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl), cmdlet.PublishSettingsFileUrl);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddsEnvironmentWithMinimumInformation()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                EnableAdfsAuthentication = true
            };

            var dict = new Dictionary<string, object>();
            dict["EnableAdfsAuthentication"] = true;
            dict["PublishSettingsFileUrl"] = "http://microsoft.com";
            cmdlet.SetBoundParameters(dict);
            cmdlet.SetParameterSet("Name");
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            IAzureEnvironment env = AzureRmProfileProvider.Instance.Profile.GetEnvironment("KaTaL");
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.True(env.OnPremise);
            Assert.Equal("http://microsoft.com", env.GetEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl));
        }
#if !NETSTANDARD
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IgnoresAddingDuplicatedEnvironment()
        {
            var profile = new AzureSMProfile();
            var commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                PublishSettingsFileUrl = "http://microsoft.com",
                ServiceEndpoint = "http://endpoint.net",
                ManagementPortalUrl = "https://management.portal.url",
                StorageEndpoint = "http://endpoint.net"
            };

            var dict = new Dictionary<string, object>();
            dict["PublishSettingsFileUrl"] = "http://microsoft.com";
            dict["ServiceEndpoint"] = "http://endpoint.net";
            dict["ManagementPortalUrl"] = "https://management.portal.url";
            dict["StorageEndpoint"] = "http://endpoint.net";
            cmdlet.SetBoundParameters(dict);
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            ProfileClient client = new ProfileClient(profile);
            int count = client.Profile.Environments.Count();

            // Add again
            cmdlet.Name = "kAtAl";
            cmdlet.ExecuteCmdlet();
            IAzureEnvironment env = AzureRmProfileProvider.Instance.Profile.GetEnvironment("KaTaL");
            Assert.Equal("Katal", env.Name);
        }
#endif
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IgnoresAddingPublicEnvironment()
        {
            var commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = EnvironmentName.AzureCloud,
                PublishSettingsFileUrl = "http://microsoft.com"
            };

            Assert.Throws<InvalidOperationException>(() => cmdlet.ExecuteCmdlet());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddsEnvironmentWithStorageEndpoint()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            PSAzureEnvironment actual = null;
            commandRuntimeMock.Setup(f => f.WriteObject(It.IsAny<object>()))
                .Callback((object output) => actual = (PSAzureEnvironment)output);
            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                PublishSettingsFileUrl = "http://microsoft.com",
                StorageEndpoint = "core.windows.net",
            };

            cmdlet.SetParameterSet("Name");
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            IAzureEnvironment env = AzureRmProfileProvider.Instance.Profile.GetEnvironment("KaTaL");
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.Equal(env.GetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix), actual.StorageEndpointSuffix);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateEnvironmentWithAllProperties()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            PSAzureEnvironment actual = null;
            commandRuntimeMock.Setup(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()))
                .Callback((object output) => actual = (PSAzureEnvironment)output);
            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                ActiveDirectoryEndpoint = "https://ActiveDirectoryEndpoint",
                AdTenant = "AdTenant",
                AzureKeyVaultDnsSuffix = "AzureKeyVaultDnsSuffix",
                ActiveDirectoryServiceEndpointResourceId = "https://ActiveDirectoryServiceEndpointResourceId",
                AzureKeyVaultServiceEndpointResourceId = "https://AzureKeyVaultServiceEndpointResourceId",
                EnableAdfsAuthentication = true,
                GalleryEndpoint = "https://GalleryEndpoint",
                GraphEndpoint = "https://GraphEndpoint",
                ManagementPortalUrl = "https://ManagementPortalUrl",
                PublishSettingsFileUrl = "https://PublishSettingsFileUrl",
                ResourceManagerEndpoint = "https://ResourceManagerEndpoint",
                ServiceEndpoint = "https://ServiceEndpoint",
                StorageEndpoint = "https://StorageEndpoint",
                SqlDatabaseDnsSuffix = "SqlDatabaseDnsSuffix",
                TrafficManagerDnsSuffix = "TrafficManagerDnsSuffix",
                GraphAudience = "GaraphAudience",
                BatchEndpointResourceId = "BatchResourceId",
                DataLakeAudience = "DataLakeAudience",
                AzureOperationalInsightsEndpointResourceId = "AzureOperationalInsightsEndpointResourceId",
                AzureOperationalInsightsEndpoint = "https://AzureOperationalInsights",
                AzureAttestationServiceEndpointResourceId = "AzureAttestationServiceEndpointResourceId",
                AzureAttestationServiceEndpointSuffix = "https://AzureAttestationService",
                AzureSynapseAnalyticsEndpointResourceId = "AzureSynapseAnalyticsEndpointResourceId",
                AzureSynapseAnalyticsEndpointSuffix = "https://AzureSynapseAnalytics",
            };

            var dict = new Dictionary<string, object>();
            dict["ActiveDirectoryEndpoint"] = "https://ActiveDirectoryEndpoint";
            dict["AdTenant"] = "AdTenant";
            dict["AzureKeyVaultDnsSuffix"] = "AzureKeyVaultDnsSuffix";
            dict["ActiveDirectoryServiceEndpointResourceId"] = "https://ActiveDirectoryServiceEndpointResourceId";
            dict["AzureKeyVaultServiceEndpointResourceId"] = "https://AzureKeyVaultServiceEndpointResourceId";
            dict["EnableAdfsAuthentication"] = true;
            dict["GalleryEndpoint"] = "https://GalleryEndpoint";
            dict["GraphEndpoint"] = "https://GraphEndpoint";
            dict["ManagementPortalUrl"] = "https://ManagementPortalUrl";
            dict["PublishSettingsFileUrl"] = "https://PublishSettingsFileUrl";
            dict["ResourceManagerEndpoint"] = "https://ResourceManagerEndpoint";
            dict["ServiceEndpoint"] = "https://ServiceEndpoint";
            dict["StorageEndpoint"] = "https://StorageEndpoint";
            dict["SqlDatabaseDnsSuffix"] = "SqlDatabaseDnsSuffix";
            dict["TrafficManagerDnsSuffix"] = "TrafficManagerDnsSuffix";
            dict["GraphAudience"] = "GaraphAudience";
            dict["BatchEndpointResourceId"] = "BatchResourceId";
            dict["DataLakeAudience"] = "DataLakeAudience";
            dict["AzureOperationalInsightsEndpointResourceId"] = "AzureOperationalInsightsEndpointResourceId";
            dict["AzureOperationalInsightsEndpoint"] = "https://AzureOperationalInsights";
            dict["AzureAttestationServiceEndpointResourceId"] = "AzureAttestationServiceEndpointResourceId";
            dict["AzureAttestationServiceEndpointSuffix"] = "https://AzureAttestationService";
            dict["AzureSynapseAnalyticsEndpointResourceId"] = "AzureSynapseAnalyticsEndpointResourceId";
            dict["AzureSynapseAnalyticsEndpointSuffix"] = "https://AzureSynapseAnalytics";
            cmdlet.SetBoundParameters(dict);
            cmdlet.SetParameterSet("Name");

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.Equal(cmdlet.Name, actual.Name);
            Assert.Equal(cmdlet.EnableAdfsAuthentication.ToBool(), actual.EnableAdfsAuthentication);
            Assert.Equal(cmdlet.ActiveDirectoryEndpoint + "/", actual.ActiveDirectoryAuthority, StringComparer.OrdinalIgnoreCase);
            Assert.Equal(cmdlet.ActiveDirectoryServiceEndpointResourceId,
                actual.ActiveDirectoryServiceEndpointResourceId);
            Assert.Equal(cmdlet.AdTenant, actual.AdTenant);
            Assert.Equal(cmdlet.AzureKeyVaultDnsSuffix, actual.AzureKeyVaultDnsSuffix);
            Assert.Equal(cmdlet.AzureKeyVaultServiceEndpointResourceId, actual.AzureKeyVaultServiceEndpointResourceId);
            Assert.Equal(cmdlet.GalleryEndpoint, actual.GalleryUrl);
            Assert.Equal(cmdlet.GraphEndpoint, actual.GraphUrl);
            Assert.Equal(cmdlet.ManagementPortalUrl, actual.ManagementPortalUrl);
            Assert.Equal(cmdlet.PublishSettingsFileUrl, actual.PublishSettingsFileUrl);
            Assert.Equal(cmdlet.ResourceManagerEndpoint, actual.ResourceManagerUrl);
            Assert.Equal(cmdlet.ServiceEndpoint, actual.ServiceManagementUrl);
            Assert.Equal(cmdlet.StorageEndpoint, actual.StorageEndpointSuffix);
            Assert.Equal(cmdlet.SqlDatabaseDnsSuffix, actual.SqlDatabaseDnsSuffix);
            Assert.Equal(cmdlet.TrafficManagerDnsSuffix, actual.TrafficManagerDnsSuffix);
            Assert.Equal(cmdlet.GraphAudience, actual.GraphEndpointResourceId);
            Assert.Equal(cmdlet.BatchEndpointResourceId, actual.BatchEndpointResourceId);
            Assert.Equal(cmdlet.DataLakeAudience, actual.DataLakeEndpointResourceId);
            Assert.Equal(cmdlet.AzureOperationalInsightsEndpointResourceId, actual.AzureOperationalInsightsEndpointResourceId);
            Assert.Equal(cmdlet.AzureOperationalInsightsEndpoint, actual.AzureOperationalInsightsEndpoint);
            Assert.Equal(cmdlet.AzureAttestationServiceEndpointResourceId, actual.AzureAttestationServiceEndpointResourceId);
            Assert.Equal(cmdlet.AzureAttestationServiceEndpointSuffix, actual.AzureAttestationServiceEndpointSuffix);
            Assert.Equal(cmdlet.AzureSynapseAnalyticsEndpointResourceId, actual.AzureSynapseAnalyticsEndpointResourceId);
            Assert.Equal(cmdlet.AzureSynapseAnalyticsEndpointSuffix, actual.AzureSynapseAnalyticsEndpointSuffix);
            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            IAzureEnvironment env = AzureRmProfileProvider.Instance.Profile.GetEnvironment("KaTaL");
            Assert.Equal(env.Name, cmdlet.Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ThrowsForInvalidUrl()
        {
            var commandRuntimeMock = new Mock<ICommandRuntime>();
            PSAzureEnvironment actual = null;
            commandRuntimeMock.Setup(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()))
                .Callback((object output) => actual = (PSAzureEnvironment)output);

            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "katal",
                ARMEndpoint = "foobar.com"
            };

            SetupConfirmation(commandRuntimeMock);
            cmdlet.SetParameterSet("ARMEndpoint");

            Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateEnvironmentWithTrailingSlashInActiveDirectory()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            PSAzureEnvironment actual = null;
            commandRuntimeMock.Setup(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()))
                .Callback((object output) => actual = (PSAzureEnvironment)output);
            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                ActiveDirectoryEndpoint = "https://ActiveDirectoryEndpoint/"
            };

            var dict = new Dictionary<string, object>();
            dict["ActiveDirectoryEndpoint"] = "https://ActiveDirectoryEndpoint/";
            cmdlet.SetBoundParameters(dict);
            cmdlet.SetParameterSet("Name");

            SetupConfirmation(commandRuntimeMock);
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.Equal(cmdlet.ActiveDirectoryEndpoint, actual.ActiveDirectoryAuthority, StringComparer.OrdinalIgnoreCase);
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsAzureEnvironments()
        {
            List<PSAzureEnvironment> environments = null;
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            commandRuntimeMock.Setup(c => c.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback<object, bool>((e, _) => environments = (List<PSAzureEnvironment>)e);

            var cmdlet = new GetAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            Assert.Equal(3, environments.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsAzureEnvironment()
        {
            List<PSAzureEnvironment> environments = null;
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            commandRuntimeMock.Setup(c => c.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback<object, bool>((e, _) => environments = (List<PSAzureEnvironment>)e);

            var cmdlet = new GetAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = EnvironmentName.AzureChinaCloud
            };

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            Assert.Single(environments);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsAllAzureEnvironments()
        {
            List<PSAzureEnvironment> environments = null;
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            commandRuntimeMock.Setup(c => c.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback<object, bool>((e, _) => environments = (List<PSAzureEnvironment>)e);

            var cmdlet = new GetAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            Assert.Equal(3, environments.Count);

            var publicEnvironmentRef = EnvironmentCmdletTestsExtension.GetAzureCloudEndpoints();
            var publicEnvironment = environments.Where(x => 0 == string.Compare(x.Name, "AzureCloud")).First();
            Assert.True(publicEnvironment.IsAbsolutelyEqual(publicEnvironmentRef));

            //fixme:jinlei
            var chinaEnvironmentRef = EnvironmentCmdletTestsExtension.GetAzureChinaCloudEndpoints();
            var chinaEnvironment = environments.Where(x => 0 == string.Compare(x.Name, "AzureChinaCloud")).First();
            Assert.True(chinaEnvironment.IsAbsolutelyEqual(chinaEnvironmentRef));

            var usEnvironmentRef = EnvironmentCmdletTestsExtension.GetAzureUSGovernmentEndpoints();
            var usEnvironment = environments.Where(x => 0 == string.Compare(x.Name, "AzureUSGovernment")).First();
            Assert.True(usEnvironment.IsAbsolutelyEqual(usEnvironmentRef));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ThrowsWhenSettingPublicEnvironment()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            var profile = new AzureRmProfile();
            foreach (var env in AzureEnvironment.PublicEnvironments)
            {
                Assert.True(profile.GetEnvironment(env.Key) != null, string.Format("Key: {0} produces null environment.  From profile {1}", env.Key, profile.ToString()));
                var cmdlet = new SetAzureRMEnvironmentCommand
                {
                    CommandRuntime = commandRuntimeMock.Object,
                    Name = env.Key,
                    PublishSettingsFileUrl = "http://microsoft.com",
                    DefaultProfile = profile
                };
                var savedValue = env.Value.PublishSettingsFileUrl;
                cmdlet.InvokeBeginProcessing();
                Assert.Throws<InvalidOperationException>(() => cmdlet.ExecuteCmdlet());
                var environment = profile.GetEnvironment(env.Key);
                Assert.True(environment != null, string.Format("Key: {0} produces null environment.  From profile {1}", env.Key, profile.ToString()));
                Assert.Equal(savedValue, environment.PublishSettingsFileUrl);
                Assert.NotEqual(cmdlet.PublishSettingsFileUrl, environment.PublishSettingsFileUrl);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetEnvironmentWithOnPremise()
        {
            // Setup a new environment
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);

            var cmdlet = new SetAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                PublishSettingsFileUrl = "http://microsoft.com",
                EnableAdfsAuthentication = false
            };

            cmdlet.MyInvocation.BoundParameters.Add("Name", "Katal");
            cmdlet.MyInvocation.BoundParameters.Add("PublishSettingsFileUrl", "http://microsoft.com");
            cmdlet.MyInvocation.BoundParameters.Add("EnableAdfsAuthentication", false);

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            IAzureEnvironment env = AzureRmProfileProvider.Instance.Profile.GetEnvironment("KaTaL");
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.Equal(env.GetEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl), cmdlet.PublishSettingsFileUrl);
            Assert.False(env.OnPremise);

            // Update onpremise to true
            var cmdlet2 = new SetAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                EnableAdfsAuthentication = true
            };

            cmdlet2.MyInvocation.BoundParameters.Add("Name", "Katal");
            cmdlet2.MyInvocation.BoundParameters.Add("EnableAdfsAuthentication", true);

            cmdlet2.InvokeBeginProcessing();
            cmdlet2.ExecuteCmdlet();
            cmdlet2.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Exactly(2));
            IAzureEnvironment env2 = AzureRmProfileProvider.Instance.Profile.GetEnvironment("KaTaL");
            Assert.Equal(env2.Name, cmdlet2.Name);
            Assert.Equal(env2.GetEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl), cmdlet.PublishSettingsFileUrl);
            Assert.True(env2.OnPremise);

            // Update gallery endpoint
            var cmdlet3 = new SetAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                GalleryEndpoint = "",
            };

            cmdlet3.MyInvocation.BoundParameters.Add("Name", "Katal");
            cmdlet3.MyInvocation.BoundParameters.Add("GalleryEndpoint", "");

            cmdlet3.InvokeBeginProcessing();
            cmdlet3.ExecuteCmdlet();
            cmdlet3.InvokeEndProcessing();

            // Ensure gallery endpoint is updated and OnPremise value is preserved
            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Exactly(3));
            IAzureEnvironment env3 = AzureRmProfileProvider.Instance.Profile.GetEnvironment("KaTaL");
            Assert.Equal(env3.Name, cmdlet3.Name);
            Assert.Equal(env3.GetEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl), cmdlet.PublishSettingsFileUrl);
            Assert.True(env3.OnPremise);
            Assert.Null(env3.GetEndpoint(AzureEnvironment.Endpoint.Gallery));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetEnvironmentForStack()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            var cmdlet = new SetAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Stack",
                ARMEndpoint = "https://management.local.azurestack.external/"
            };

            Mock<EnvironmentHelper> envHelperMock = new Mock<EnvironmentHelper>();
            MetadataResponse metadataEndpoints = new MetadataResponse
            {
                GalleryEndpoint = "http://galleryendpoint.com",
                GraphEndpoint = "https://graphendpoint",
                PortalEndpoint = "https://portalendpoint",
                authentication = new Authentication
                {
                    Audiences = new[] { "audience1", "audience2" },
                    LoginEndpoint = "https://loginendpoint"
                }
            };
            envHelperMock.Setup(f => f.RetrieveMetaDataEndpoints(It.IsAny<string>(), It.IsAny<IHttpOperationsFactory>())).ReturnsAsync(metadataEndpoints);
            envHelperMock.Setup(f => f.RetrieveDomain(It.IsAny<string>())).Returns("domain");
            cmdlet.EnvHelper = envHelperMock.Object;
            cmdlet.SetParameterSet("ARMEndpoint");
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            IAzureEnvironment env = AzureRmProfileProvider.Instance.Profile.GetEnvironment("Stack");
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.Equal(cmdlet.ARMEndpoint, env.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager));
            Assert.Equal("https://loginendpoint/", env.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectory));
            Assert.Equal("audience1", env.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId));
            Assert.Equal("https://graphendpoint", env.GetEndpoint(AzureEnvironment.Endpoint.GraphEndpointResourceId));
            Assert.Equal("http://galleryendpoint.com", env.GetEndpoint(AzureEnvironment.Endpoint.Gallery));
            envHelperMock.Verify(f => f.RetrieveDomain(It.IsAny<string>()), Times.Once);
            envHelperMock.Verify(f => f.RetrieveMetaDataEndpoints(It.IsAny<string>(), It.IsAny<IHttpOperationsFactory>()), Times.Once);

            // Update onpremise to true
            var cmdlet2 = new SetAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Stack",
                EnableAdfsAuthentication = true
            };

            cmdlet2.MyInvocation.BoundParameters.Add("Name", "Stack");
            cmdlet2.MyInvocation.BoundParameters.Add("EnableAdfsAuthentication", true);

            cmdlet2.InvokeBeginProcessing();
            cmdlet2.ExecuteCmdlet();
            cmdlet2.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Exactly(2));
            IAzureEnvironment env2 = AzureRmProfileProvider.Instance.Profile.GetEnvironment("stack");
            Assert.Equal(env2.Name, cmdlet2.Name);
            Assert.Equal(env2.GetEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl), cmdlet.PublishSettingsFileUrl);
            Assert.True(env2.OnPremise);

            // Update gallery endpoint
            var cmdlet3 = new SetAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Stack",
                GalleryEndpoint = "",
            };

            cmdlet3.MyInvocation.BoundParameters.Add("Name", "stack");
            cmdlet3.MyInvocation.BoundParameters.Add("GalleryEndpoint", "");

            cmdlet3.InvokeBeginProcessing();
            cmdlet3.ExecuteCmdlet();
            cmdlet3.InvokeEndProcessing();

            // Ensure gallery endpoint is updated and OnPremise value is preserved
            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Exactly(3));
            IAzureEnvironment env3 = AzureRmProfileProvider.Instance.Profile.GetEnvironment("stack");
            Assert.Equal(env3.Name, cmdlet3.Name);
            Assert.Equal(env3.GetEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl), cmdlet.PublishSettingsFileUrl);
            Assert.True(env3.OnPremise);
            Assert.Equal("http://galleryendpoint.com", env3.GetEndpoint(AzureEnvironment.Endpoint.Gallery));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetEnvironmentForMultipleContexts()
        {
            // Add new environment
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                ARMEndpoint = "https://management.azure.com/",
                AzureKeyVaultDnsSuffix = "vault.local.azurestack.external",
                AzureKeyVaultServiceEndpointResourceId = "https://vault.local.azurestack.external"

            };
            var dict = new Dictionary<string, object>
            {
                { "ARMEndpoint", "https://management.azure.com/" },
                { "AzureKeyVaultDnsSuffix", "vault.local.azurestack.external" },
                { "AzureKeyVaultServiceEndpointResourceId", "https://vault.local.azurestack.external" }
            };

            cmdlet.SetBoundParameters(dict);
            cmdlet.SetParameterSet("ARMEndpoint");
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            var profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>());
            IAzureEnvironment env = AzureRmProfileProvider.Instance.Profile.Environments.First((e) => string.Equals(e.Name, "KaTaL", StringComparison.OrdinalIgnoreCase));
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.Equal(env.GetEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix), dict["AzureKeyVaultDnsSuffix"]);
            Assert.Equal(env.GetEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId), dict["AzureKeyVaultServiceEndpointResourceId"]);

            // Create contexts using the new environment
            var profile = new AzureRmProfile();
            string contextName1;
            var context1 = (new AzureContext { Environment = env })
                .WithAccount(new AzureAccount { Id = "user1@contoso.com" })
                .WithTenant(new AzureTenant { Id = Guid.NewGuid().ToString(), Directory = "contoso.com" })
                .WithSubscription(new AzureSubscription { Id = Guid.NewGuid().ToString(), Name = "Contoso Subscription 1" });
            profile.TryAddContext(context1, out contextName1);
            string contextName2;
            var context2 = (new AzureContext { Environment = env })
                .WithAccount(new AzureAccount { Id = "user2@contoso.cn" })
                .WithTenant(new AzureTenant { Id = Guid.NewGuid().ToString(), Directory = "contoso.cn" })
                .WithSubscription(new AzureSubscription { Id = Guid.NewGuid().ToString(), Name = "Contoso Subscription 2" });
            profile.TryAddContext(context2, out contextName2);
            profile.TrySetDefaultContext(context1);
            AzureRmProfileProvider.Instance.Profile = profile;

            // Update the environment with new endpoints
            commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            var cmdlet2 = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                ARMEndpoint = "https://management.azure.com/",
                AzureKeyVaultDnsSuffix = "adminvault.local.azurestack.external",
                AzureKeyVaultServiceEndpointResourceId = "https://adminvault.local.azurestack.external"
            };

            dict.Clear();
            dict = new Dictionary<string, object>
            {
                { "ARMEndpoint", "https://management.azure.com/" },
                { "AzureKeyVaultDnsSuffix", "adminvault.local.azurestack.external" },
                { "AzureKeyVaultServiceEndpointResourceId", "https://adminvault.local.azurestack.external" }
            };

            cmdlet2.SetBoundParameters(dict);
            cmdlet2.SetParameterSet("ARMEndpoint");
            cmdlet2.InvokeBeginProcessing();
            cmdlet2.ExecuteCmdlet();
            cmdlet2.InvokeEndProcessing();

            profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>());
            env = AzureRmProfileProvider.Instance.Profile.Environments.First((e) => string.Equals(e.Name, "KaTaL", StringComparison.OrdinalIgnoreCase));
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.Equal(env.GetEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix), dict["AzureKeyVaultDnsSuffix"]);
            Assert.Equal(env.GetEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId), dict["AzureKeyVaultServiceEndpointResourceId"]);

            // Validate that the endpoints were updated in the contexts
            profile = (AzureRmProfile)AzureRmProfileProvider.Instance.Profile;
            Assert.NotNull(profile);
            Assert.NotNull(profile.Contexts);
            Assert.NotEmpty(profile.Contexts);
            foreach (var context in profile.Contexts.Values)
            {
                Assert.NotNull(context);
                Assert.NotNull(context.Environment);
                Assert.Equal(context.Environment.Name, env.Name);
                Assert.Equal(context.Environment.AzureKeyVaultDnsSuffix, env.AzureKeyVaultDnsSuffix);
                Assert.Equal(context.Environment.AzureKeyVaultServiceEndpointResourceId, env.AzureKeyVaultServiceEndpointResourceId);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemovesAzureEnvironment()
        {
            var commandRuntimeMock = new Mock<ICommandRuntime>();
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            const string name = "test";
            RMProfileClient client = new RMProfileClient(AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>());
            client.AddOrSetEnvironment(new AzureEnvironment
            {
                Name = name
            });

            var cmdlet = new RemoveAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = name
            };

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            Assert.False(AzureRmProfileProvider.Instance.Profile.HasEnvironment(name));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ThrowsForUnknownEnvironment()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var cmdlet = new RemoveAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "test2",
            };

            cmdlet.InvokeBeginProcessing();
            Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ThrowsForPublicEnvironment()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);

            foreach (string name in AzureEnvironment.PublicEnvironments.Keys)
            {
                var cmdlet = new RemoveAzureRMEnvironmentCommand()
                {
                    CommandRuntime = commandRuntimeMock.Object,
                    Name = name
                };

                cmdlet.InvokeBeginProcessing();
                Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetEnvironmentUsingHttpOperationsFactory()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            var cmdlet = new SetAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Test",
                ARMEndpoint = "https://management.local.azuretest.external/"
            };

            MetadataResponse metadataEndpoints = new MetadataResponse
            {
                GalleryEndpoint = "http://galleryendpoint.com",
                GraphEndpoint = "https://graphendpoint",
                PortalEndpoint = "https://portalendpoint",
                authentication = new Authentication
                {
                    Audiences = new[] { "audience1", "audience2" },
                    LoginEndpoint = "https://loginendpoint"
                }
            };

            var contentSuccess = JsonConvert.SerializeObject(metadataEndpoints);
            var httpFactoryMocker = new Mock<IHttpOperationsFactory>();
            httpFactoryMocker.Setup(f => f.ReadAsStringAsync(It.IsAny<Uri>())).ReturnsAsync(contentSuccess);

            AzureSession.Instance.TryGetComponent(HttpClientOperationsFactory.Name, out IHttpOperationsFactory factoryOrigin);
            AzureSession.Instance.RegisterComponent(HttpClientOperationsFactory.Name, () => httpFactoryMocker.Object, true);
            cmdlet.SetParameterSet("ARMEndpoint");
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            IAzureEnvironment env = AzureRmProfileProvider.Instance.Profile.GetEnvironment("Test");
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.Equal(cmdlet.ARMEndpoint, env.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager));
            Assert.Equal("https://loginendpoint/", env.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectory));
            Assert.Equal("audience1", env.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId));
            Assert.Equal("https://graphendpoint", env.GetEndpoint(AzureEnvironment.Endpoint.GraphEndpointResourceId));
            Assert.Equal("http://galleryendpoint.com", env.GetEndpoint(AzureEnvironment.Endpoint.Gallery));
            httpFactoryMocker.Verify(f => f.ReadAsStringAsync(It.IsAny<Uri>()), Times.Once);

            AzureSession.Instance.RegisterComponent(HttpClientOperationsFactory.Name, () => factoryOrigin, true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetEnvironmentAndHttpOperationsFactoryReturnFailure()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            var cmdlet = new SetAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Test",
                ARMEndpoint = "https://management.local.azuretest.external/"
            };

            var httpFactoryMocker = new Mock<IHttpOperationsFactory>();
            httpFactoryMocker.Setup(f => f.ReadAsStringAsync(It.IsAny<Uri>())).Throws<HttpRequestException>();

            AzureSession.Instance.TryGetComponent(HttpClientOperationsFactory.Name, out IHttpOperationsFactory factoryOrigin);
            AzureSession.Instance.RegisterComponent(HttpClientOperationsFactory.Name, () => httpFactoryMocker.Object, true);
            cmdlet.SetParameterSet("ARMEndpoint");
            cmdlet.InvokeBeginProcessing();
            Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());
            cmdlet.InvokeEndProcessing();

            IAzureEnvironment env = AzureRmProfileProvider.Instance.Profile.GetEnvironment("Test");
            httpFactoryMocker.Verify(f => f.ReadAsStringAsync(It.IsAny<Uri>()), Times.Once);

            AzureSession.Instance.RegisterComponent(HttpClientOperationsFactory.Name, () => factoryOrigin, true);
        }

        private void Dispose()
        {
            Cleanup();
        }
    }
}
