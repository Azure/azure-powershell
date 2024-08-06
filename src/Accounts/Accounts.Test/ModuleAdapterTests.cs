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

using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Profile.CommonModule;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class ModuleAdapterTests : RMTestBase
    {
        [Theory]
        [InlineData("https://manage.windowsazure.com/subscriptions", "https://manage.windowsazure.cn", "https://manage.windowsazure.cn/subscriptions")]
        [InlineData("https://manage.windowsazure.com/subscriptions", "https://manage.windowsazure.gov/basePath", "https://manage.windowsazure.gov/basePath/subscriptions")]
        [InlineData("https://manage.windowsazure.com/subscriptions?api-version=2018-06-08#start", "https://manage.windowsazure.de/", "https://manage.windowsazure.de/subscriptions?api-version=2018-06-08#start")]
        [InlineData("/subscriptions?api-version=2018-06-08#start", "https://manage.windowsazure.de/", "https://manage.windowsazure.de/subscriptions?api-version=2018-06-08#start")]
        [InlineData("subscriptions?api-version=2018-06-08#start", "https://manage.windowsazure.de/", "https://manage.windowsazure.de/subscriptions?api-version=2018-06-08#start")]
        [InlineData(null, "https://manage.windowsazure.de/", "https://manage.windowsazure.de/")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPatchHost(string baseUri, string patchbase, string expected)
        {
            var checkValue = CreateUri(baseUri).PatchHost(patchbase);
            Assert.Equal(expected, checkValue.GetComponents(UriComponents.AbsoluteUri, UriFormat.Unescaped));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPatchHostNegative()
        {
            Assert.Null(EnvironmentExtensions.PatchHost(null, null));
            Assert.Null(EnvironmentExtensions.PatchHost(null, "  "));
            Assert.Equal(new Uri("https://manage.windowsazure.com/subscriptions"), new Uri("https://manage.windowsazure.com/subscriptions").PatchHost("  "));
        }

        [Theory]
        [InlineData("https://mystorage.blob.core.windows.net/mycontainer/myblob", "blob.core.windows.cn", "https://mystorage.blob.core.windows.cn/mycontainer/myblob")]
        [InlineData("https://mystorage.blob.core.windows.net/mycontainer/myblob", ".blob.core.windows.cn", "https://mystorage.blob.core.windows.cn/mycontainer/myblob")]
        [InlineData("https://mystorage.blob.core.windows.net:2443/mycontainer/myblob", "blob.core.windows.cn", "https://mystorage.blob.core.windows.cn:2443/mycontainer/myblob")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPatchDnsSuffix(string baseUri, string suffix, string expected)
        {
            var checkValue = CreateUri(baseUri).PatchDnsSuffix(suffix);
            Assert.Equal(expected, checkValue.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPatchDnsSuffixNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => EnvironmentExtensions.PatchDnsSuffix(null, null));
            Assert.Throws<ArgumentOutOfRangeException>(() => EnvironmentExtensions.PatchDnsSuffix(new Uri("/", UriKind.Relative), "  "));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Uri("https://manage.windowsazure.com/subscriptions").PatchDnsSuffix("  "));
        }

        [Theory]
        [InlineData(EnvironmentName.AzureChinaCloud)]
        [InlineData(EnvironmentName.AzureUSGovernment)]
        [InlineData(EnvironmentName.AzureCloud)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointUpdate(string environmentName)
        {
            var newEnv = AzureEnvironment.PublicEnvironments[environmentName];
            var baseEnv = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
            Assert.Equal(new Uri($"{newEnv.ResourceManagerUrl}/subscriptions"), newEnv.GetUriFromBaseRequestUri(new Uri($"{baseEnv.ResourceManagerUrl}/subscriptions")));
            Assert.Equal(new Uri($"{newEnv.GraphUrl}/tenants"), newEnv.GetUriFromBaseRequestUri(new Uri($"{baseEnv.GraphUrl}/tenants")));
            Assert.Equal(new Uri($"{newEnv.ServiceManagementUrl}/subscriptions"),
                newEnv.GetUriFromBaseRequestUri(new Uri($"{baseEnv.ServiceManagementUrl}/subscriptions")));
            Assert.Equal(new Uri($"https://mystorage.{newEnv.StorageEndpointSuffix}/containers"),
                newEnv.GetUriFromBaseRequestUri(new Uri($"https://mystorage.{baseEnv.StorageEndpointSuffix}/containers")));
            Assert.Equal(new Uri($"https://myvault.{newEnv.AzureKeyVaultDnsSuffix}/keys"),
                newEnv.GetUriFromBaseRequestUri(new Uri($"https://myvault.{baseEnv.AzureKeyVaultDnsSuffix}/keys")));
            Assert.Equal(new Uri($"https://myazsql{newEnv.SqlDatabaseDnsSuffix}/databases"),
                newEnv.GetUriFromBaseRequestUri(new Uri($"https://myazsql{baseEnv.SqlDatabaseDnsSuffix}/databases")));
            Assert.Equal(new Uri($"https://mytm.{newEnv.TrafficManagerDnsSuffix}/packets"),
                newEnv.GetUriFromBaseRequestUri(new Uri($"https://mytm.{baseEnv.TrafficManagerDnsSuffix}/packets")));

            // endpoint only available in Azure
            Assert.Equal(new Uri($"https://myadl.{newEnv.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix ?? baseEnv.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix}/jobs"),
                newEnv.GetUriFromBaseRequestUri(new Uri($"https://myadl.{baseEnv.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix}/jobs")));
            Assert.Equal(new Uri($"https://myadfs.{newEnv.AzureDataLakeStoreFileSystemEndpointSuffix ?? baseEnv.AzureDataLakeStoreFileSystemEndpointSuffix}/files"),
                newEnv.GetUriFromBaseRequestUri(new Uri($"https://myadfs.{baseEnv.AzureDataLakeStoreFileSystemEndpointSuffix}/files")));

            var expected = newEnv.ExtendedProperties.ContainsKey(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint)
                ? new Uri($"{newEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint]}/alerts")
                : new Uri($"{baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint]}/alerts");
            // extended endpoints
            Assert.Equal(
                expected,
                newEnv.GetUriFromBaseRequestUri(new Uri($"{baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint]}/alerts")));
            Assert.Equal(new Uri($"https://myazas.{newEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix]}/analyzers"),
                newEnv.GetUriFromBaseRequestUri(new Uri($"https://myazas.{baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix]}/analyzers")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCustomEnvironmentEndpointUpdate()
        {
            var baseEnv = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
            var newEnv = new AzureEnvironment
            {
                ActiveDirectoryAuthority = "https://authority.activedirectory.microsoft.com/",
                ActiveDirectoryServiceEndpointResourceId = "https://custom.windowsazure.com/",
                AzureKeyVaultDnsSuffix = ".custom.value.windows.net",
                AzureKeyVaultServiceEndpointResourceId = "https://custom.vault.core.windows.net/",
                AdTenant = "Common",
                GraphEndpointResourceId = "https://customgraph.windows.net/",
                GraphUrl = "https://customgraph.windows.net/",
                OnPremise = false,
                ResourceManagerUrl = "https://customresourcemanager.azure.com/",
                StorageEndpointSuffix = ".custom.core.windows.net"
            };

            Assert.Equal(new Uri($"{newEnv.ResourceManagerUrl}/subscriptions"), newEnv.GetUriFromBaseRequestUri(new Uri($"{baseEnv.ResourceManagerUrl}/subscriptions")));
            Assert.Equal(new Uri($"{newEnv.GraphUrl}/tenants"), newEnv.GetUriFromBaseRequestUri(new Uri($"{baseEnv.GraphUrl}/tenants")));
            Assert.Equal(new Uri($"https://mystorage{newEnv.StorageEndpointSuffix}/containers"),
                newEnv.GetUriFromBaseRequestUri(new Uri($"https://mystorage.{baseEnv.StorageEndpointSuffix}/containers")));
            Assert.Equal(new Uri($"https://myvault{newEnv.AzureKeyVaultDnsSuffix}/keys"),
                newEnv.GetUriFromBaseRequestUri(new Uri($"https://myvault.{baseEnv.AzureKeyVaultDnsSuffix}/keys")));

            //missing endpoints
            Assert.Equal(new Uri($"{baseEnv.ServiceManagementUrl}/subscriptions"),
                newEnv.GetUriFromBaseRequestUri(new Uri($"{baseEnv.ServiceManagementUrl}/subscriptions")));
            Assert.Equal(new Uri($"https://myazsql{baseEnv.SqlDatabaseDnsSuffix}/databases"),
                newEnv.GetUriFromBaseRequestUri(new Uri($"https://myazsql{baseEnv.SqlDatabaseDnsSuffix}/databases")));
            Assert.Equal(new Uri($"https://mytm.{baseEnv.TrafficManagerDnsSuffix}/packets"),
                newEnv.GetUriFromBaseRequestUri(new Uri($"https://mytm.{baseEnv.TrafficManagerDnsSuffix}/packets")));

            // endpoint only available in Azure
            Assert.Equal(new Uri($"https://myadl.{baseEnv.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix}/jobs"),
                newEnv.GetUriFromBaseRequestUri(new Uri($"https://myadl.{baseEnv.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix}/jobs")));
            Assert.Equal(new Uri($"https://myadfs.{baseEnv.AzureDataLakeStoreFileSystemEndpointSuffix}/files"),
                newEnv.GetUriFromBaseRequestUri(new Uri($"https://myadfs.{baseEnv.AzureDataLakeStoreFileSystemEndpointSuffix}/files")));

            var expected = new Uri($"{baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint]}/alerts");
            // extended endpoints
            Assert.Equal(
                expected,
                newEnv.GetUriFromBaseRequestUri(new Uri($"{baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint]}/alerts")));
            Assert.Equal(new Uri($"https://myazas.{baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix]}/analyzers"),
                newEnv.GetUriFromBaseRequestUri(new Uri($"https://myazas.{baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix]}/analyzers")));
        }



        [Theory]
        [InlineData(EnvironmentName.AzureChinaCloud)]
        [InlineData(EnvironmentName.AzureUSGovernment)]
        [InlineData(EnvironmentName.AzureCloud)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAudienceUpdate(string environmentName)
        {
            var newEnv = AzureEnvironment.PublicEnvironments[environmentName];
            var baseEnv = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];

            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"{baseEnv.ResourceManagerUrl}/subscriptions")));
            Assert.Equal(newEnv.GraphEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"{baseEnv.GraphUrl}/tenants")));
            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"{baseEnv.ServiceManagementUrl}/subscriptions")));
            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"https://mystorage.{baseEnv.StorageEndpointSuffix}/containers")));
            Assert.Equal(newEnv.AzureKeyVaultServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"https://myvault.{baseEnv.AzureKeyVaultDnsSuffix}/keys")));
            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"https://myazsql{baseEnv.SqlDatabaseDnsSuffix}/databases")));
            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"https://mytm.{baseEnv.TrafficManagerDnsSuffix}/packets")));

            // endpoint only available in Azure
            Assert.Equal(newEnv.DataLakeEndpointResourceId ?? baseEnv.DataLakeEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"https://myadl.{baseEnv.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix}/jobs")));
            Assert.Equal(newEnv.DataLakeEndpointResourceId ?? baseEnv.DataLakeEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"https://myadfs.{baseEnv.AzureDataLakeStoreFileSystemEndpointSuffix}/files")));

            var expected = newEnv.ExtendedProperties.ContainsKey(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId)
                ? newEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId]
                : baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId];
            // extended endpoints
            Assert.Equal(expected,
                newEnv.GetAudienceFromRequestUri(new Uri($"{baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint]}/alerts")));
            Assert.Equal(newEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointResourceId],
            newEnv.GetAudienceFromRequestUri(new Uri($"https://myazas.{baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix]}/analyzers")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCustomEnvironmentAudienceUpdate()
        {
            var baseEnv = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
            var newEnv = new AzureEnvironment
            {
                ActiveDirectoryAuthority = "https://authority.activedirectory.microsoft.com/",
                ActiveDirectoryServiceEndpointResourceId = "https://custom.windowsazure.com/",
                AzureKeyVaultDnsSuffix = ".custom.value.windows.net",
                AzureKeyVaultServiceEndpointResourceId = "https://custom.vault.core.windows.net/",
                AdTenant = "Common",
                GraphEndpointResourceId = "https://customgraph.windows.net/",
                GraphUrl = "https://customgraph.windows.net/",
                OnPremise = false,
                ResourceManagerUrl = "https://customresourcemanager.azure.com/",
                StorageEndpointSuffix = ".custom.core.windows.net"
            };

            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"{baseEnv.ResourceManagerUrl}/subscriptions")));
            Assert.Equal(newEnv.GraphEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"{baseEnv.GraphUrl}/tenants")));
            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"{baseEnv.ServiceManagementUrl}/subscriptions")));
            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"https://mystorage.{baseEnv.StorageEndpointSuffix}/containers")));
            Assert.Equal(newEnv.AzureKeyVaultServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"https://myvault.{baseEnv.AzureKeyVaultDnsSuffix}/keys")));
            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"https://myazsql{baseEnv.SqlDatabaseDnsSuffix}/databases")));
            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"https://mytm.{baseEnv.TrafficManagerDnsSuffix}/packets")));

            // endpoint only available in Azure
            Assert.Equal(baseEnv.DataLakeEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"https://myadl.{baseEnv.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix}/jobs")));
            Assert.Equal(baseEnv.DataLakeEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(new Uri($"https://myadfs.{baseEnv.AzureDataLakeStoreFileSystemEndpointSuffix}/files")));

            var expected = baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId];
            // extended endpoints
            Assert.Equal(expected,
                newEnv.GetAudienceFromRequestUri(new Uri($"{baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint]}/alerts")));
            Assert.Equal(baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointResourceId],
            newEnv.GetAudienceFromRequestUri(new Uri($"https://myazas.{baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix]}/analyzers")));
        }


        [Theory]
        [InlineData(EnvironmentName.AzureChinaCloud)]
        [InlineData(EnvironmentName.AzureUSGovernment)]
        [InlineData(EnvironmentName.AzureCloud)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointAndAudienceUpdate(string environmentName)
        {
            var newEnv = AzureEnvironment.PublicEnvironments[environmentName];
            var baseEnv = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];

            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"{baseEnv.ResourceManagerUrl}/subscriptions"))));
            Assert.Equal(newEnv.GraphEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"{baseEnv.GraphUrl}/tenants"))));
            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"{baseEnv.ServiceManagementUrl}/subscriptions"))));
            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"https://mystorage.{baseEnv.StorageEndpointSuffix}/containers"))));
            Assert.Equal(newEnv.AzureKeyVaultServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"https://myvault.{baseEnv.AzureKeyVaultDnsSuffix}/keys"))));
            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"https://myazsql{baseEnv.SqlDatabaseDnsSuffix}/databases"))));
            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"https://mytm.{baseEnv.TrafficManagerDnsSuffix}/packets"))));

            // endpoint only available in Azure
            Assert.Equal(newEnv.DataLakeEndpointResourceId ?? baseEnv.DataLakeEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"https://myadl.{baseEnv.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix}/jobs"))));
            Assert.Equal(newEnv.DataLakeEndpointResourceId ?? baseEnv.DataLakeEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"https://myadfs.{baseEnv.AzureDataLakeStoreFileSystemEndpointSuffix}/files"))));

            var expected = newEnv.ExtendedProperties.ContainsKey(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId)
                ? newEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId]
                : baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId];
            // extended endpoints
            Assert.Equal(expected,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"{baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint]}/alerts"))));
            Assert.Equal(newEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointResourceId],
            newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"https://myazas.{baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix]}/analyzers"))));

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCustomEnvironmentEndpointAndAudience()
        {
            var baseEnv = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];

            var newEnv = new AzureEnvironment
            {
                ActiveDirectoryAuthority = "https://authority.activedirectory.microsoft.com/",
                ActiveDirectoryServiceEndpointResourceId = "https://custom.windowsazure.com/",
                AzureKeyVaultDnsSuffix = ".custom.value.windows.net",
                AzureKeyVaultServiceEndpointResourceId  = "https://custom.vault.core.windows.net/",
                AdTenant = "Common",
                GraphEndpointResourceId = "https://customgraph.windows.net/",
                GraphUrl = "https://customgraph.windows.net/",
                OnPremise = false,
                ResourceManagerUrl = "https://customresourcemanager.azure.com/",
                StorageEndpointSuffix = ".custom.core.windows.net"
            };

            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"{baseEnv.ResourceManagerUrl}/subscriptions"))));
            Assert.Equal(newEnv.GraphEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"{baseEnv.GraphUrl}/tenants"))));
            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"https://mystorage.{baseEnv.StorageEndpointSuffix}/containers"))));
            Assert.Equal(newEnv.AzureKeyVaultServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"https://myvault.{baseEnv.AzureKeyVaultDnsSuffix}/keys"))));

            // missing endpoints
            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"{baseEnv.ServiceManagementUrl}/subscriptions"))));
            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"https://myazsql{baseEnv.SqlDatabaseDnsSuffix}/databases"))));
            Assert.Equal(newEnv.ActiveDirectoryServiceEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"https://mytm.{baseEnv.TrafficManagerDnsSuffix}/packets"))));


            // endpoint only available in Azure
            Assert.Equal(baseEnv.DataLakeEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"https://myadl.{baseEnv.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix}/jobs"))));
            Assert.Equal(baseEnv.DataLakeEndpointResourceId,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"https://myadfs.{baseEnv.AzureDataLakeStoreFileSystemEndpointSuffix}/files"))));

            var expected = baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId];
            // extended endpoints
            Assert.Equal(expected,
                newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"{baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint]}/alerts"))));
            Assert.Equal(baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointResourceId],
            newEnv.GetAudienceFromRequestUri(newEnv.GetUriFromBaseRequestUri(new Uri($"https://myazas.{baseEnv.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix]}/analyzers"))));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExceptionHandler()
        {
            // setup
            var store = new EventStore();
            var provider = MockTelemetryProvider.Create(store) as MockTelemetryProvider;
            var module = new AzModule(new MockCommandRuntime(), store, provider);
            var signalEvents = new List<EventArgs>();

            // No headers in response
            string id = Guid.NewGuid().ToString();
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            var request = new HttpRequestMessage { Method = HttpMethod.Get, RequestUri = new Uri("https://microsoft.azure.com/subscriptions") };
            var data = new EventData { Id = Events.CmdletProcessRecordAsyncStart, RequestMessage = request, ResponseMessage = response };
            module.OnProcessRecordAsyncStart(Events.CmdletProcessRecordAsyncStart, CancellationToken.None, () => data, 
                (nid, token, getEventData) => ProcessSignal(signalEvents, nid, token, getEventData), id, null, "", id).GetAwaiter().GetResult();
            data.Id = Events.CmdletException;
            module.OnCmdletException(Events.CmdletException, CancellationToken.None, () => data, 
                (nid, token, getEventData) => ProcessSignal(signalEvents, nid, token, getEventData), id, new HttpRequestException("Sample exception")).GetAwaiter().GetResult();
            Assert.True(provider.ContainsKey(id));
            var qos = provider[id];
            Assert.NotNull(qos);
            Assert.NotNull(qos.Exception);
            Assert.Equal("Sample exception", qos.Exception.Message);
            Assert.False(qos.IsSuccess);
            provider.Clear();
        }

        [Theory]
        [InlineData("x-ms-client-request-id")]
        [InlineData("client-request-id")]
        [InlineData("x-ms-request-id")]
        [InlineData("request-id")]
        [InlineData("X-MS-CLIENT-REQUEST-ID")]
        [InlineData("CLIENT-REQUEST-ID")]
        [InlineData("X-MS-REQUEST-ID")]
        [InlineData("REQUEST-ID")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestClientRequestHandler(string headerName)
        {
            var store = new EventStore();
            var provider = MockTelemetryProvider.Create(store) as MockTelemetryProvider;
            var module = new AzModule(new MockCommandRuntime(), store, provider);
            string id = Guid.NewGuid().ToString();
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            var request = new HttpRequestMessage { Method = HttpMethod.Get, RequestUri = new Uri("https://microsoft.azure.com/subscriptions") };
            request.Headers.Add(headerName, id);
            var data = new EventData { Id = Events.CmdletProcessRecordAsyncStart, RequestMessage = request, ResponseMessage = response };
            var signalEvents = new List<EventArgs>();
            // Create a QOS record
            module.OnProcessRecordAsyncStart(Events.CmdletProcessRecordAsyncStart, CancellationToken.None, () => data, 
                (nid, token, getEventData) => ProcessSignal(signalEvents, nid, token, getEventData), id, null, "", id).GetAwaiter().GetResult();
            data.Id = Events.BeforeCall;
            module.OnBeforeCall(Events.BeforeCall, CancellationToken.None, () => data, (nid, token, getEventData) => ProcessSignal(signalEvents, nid, token, getEventData), id).GetAwaiter().GetResult();
            Assert.True(provider.ContainsKey(id));
            var qos = provider[id];
            Assert.NotNull(qos);
            Assert.Equal(id, qos.ClientRequestId);
            provider.Clear();
        }


        [Theory]
        [InlineData("x-ms-client-request-id")]
        [InlineData("client-request-id")]
        [InlineData("x-ms-request-id")]
        [InlineData("request-id")]
        [InlineData("X-MS-CLIENT-REQUEST-ID")]
        [InlineData("CLIENT-REQUEST-ID")]
        [InlineData("X-MS-REQUEST-ID")]
        [InlineData("REQUEST-ID")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResponseCreatedHandler(string headerName)
        {
            var store = new EventStore();
            var provider = MockTelemetryProvider.Create(store) as MockTelemetryProvider;
            var module = new AzModule(new MockCommandRuntime(), store, provider);
            string id = Guid.NewGuid().ToString();
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            response.Headers.Add(headerName, id);
            var request = new HttpRequestMessage { Method = HttpMethod.Get, RequestUri = new Uri("https://microsoft.azure.com/subscriptions")};
            request.Headers.Add(headerName, id);
            var data = new EventData { Id = Events.CmdletProcessRecordAsyncStart, RequestMessage =  request, ResponseMessage = response};
            var signalEvents = new List<EventArgs>();
            // Create a QOS record
            module.OnProcessRecordAsyncStart(Events.CmdletProcessRecordAsyncStart, CancellationToken.None, () => data, 
                (nid, token, getEventData) => ProcessSignal(signalEvents, nid, token, getEventData), id, null, "", id).GetAwaiter().GetResult();
            data.Id = Events.ResponseCreated;
            module.OnResponseCreated(Events.ResponseCreated, CancellationToken.None, () => data, 
                (nid, token, getEventData) => ProcessSignal(signalEvents, nid, token, getEventData), id).GetAwaiter().GetResult();
            Assert.True(provider.ContainsKey(id));
            var qos = provider[id];
            Assert.NotNull(qos);
            Assert.Equal(id, qos.ClientRequestId);
            provider.Clear();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResponseCreatedNegative()
        {
            // setup
            var store = new EventStore();
            var provider = MockTelemetryProvider.Create(store) as MockTelemetryProvider;
            var module = new AzModule(new MockCommandRuntime(), store, provider);
            var signalEvents = new List<EventArgs>();

            // No headers in response
            string id = Guid.NewGuid().ToString();
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            var request = new HttpRequestMessage { Method = HttpMethod.Get, RequestUri = new Uri("https://microsoft.azure.com/subscriptions") };
            var data = new EventData { Id = Events.CmdletProcessRecordAsyncStart, RequestMessage = request, ResponseMessage = response };
            module.OnProcessRecordAsyncStart(id, CancellationToken.None, () => data, 
                (nid, token, getEventData) => ProcessSignal(signalEvents, nid, token, getEventData), id, null, "", id).GetAwaiter().GetResult();
            data.Id = Events.ResponseCreated;
            module.OnResponseCreated(Events.ResponseCreated, CancellationToken.None, () => data, 
                (nid, token, getEventData) => ProcessSignal(signalEvents, nid, token, getEventData), id).GetAwaiter().GetResult();
            Assert.True(provider.ContainsKey(id));
            var qos = provider[id];
            Assert.NotNull(qos);
            Assert.Null(qos.ClientRequestId);
            provider.Clear();

            // unrecognized headers in response
            id = Guid.NewGuid().ToString();
            response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            response.Headers.Add("x-ms-test-header", id);
            request = new HttpRequestMessage { Method = HttpMethod.Get, RequestUri = new Uri("https://microsoft.azure.com/subscriptions") };
            data = new EventData { Id = Events.CmdletProcessRecordAsyncStart, RequestMessage = request, ResponseMessage = response };
            module.OnProcessRecordAsyncStart(id, CancellationToken.None, () => data, 
                (nid, token, getEventData) => ProcessSignal(signalEvents, nid, token, getEventData), id, null, "", id).GetAwaiter().GetResult();
            data.Id = Events.ResponseCreated;
            module.OnResponseCreated(Events.ResponseCreated, CancellationToken.None, () => data, 
                (nid, token, getEventData) => ProcessSignal(signalEvents, nid, token, getEventData), id).GetAwaiter().GetResult();
            Assert.True(provider.ContainsKey(id));
            qos = provider[id];
            Assert.NotNull(qos);
            Assert.Null(qos.ClientRequestId);
            provider.Clear();

            // No request or response
            id = Guid.NewGuid().ToString();
            data = new EventData { Id = Events.CmdletProcessRecordAsyncStart, Message = "Simple message"};
            module.OnProcessRecordAsyncStart(id, CancellationToken.None, () => data, 
                (nid, token, getEventData) => ProcessSignal(signalEvents, nid, token, getEventData), id, null, "", id).GetAwaiter().GetResult();
            data.Id = Events.ResponseCreated;
            module.OnResponseCreated(Events.ResponseCreated, CancellationToken.None, () => data, 
                (nid, token, getEventData) => ProcessSignal(signalEvents, nid, token, getEventData), id).GetAwaiter().GetResult();
            Assert.True(provider.ContainsKey(id));
            qos = provider[id];
            Assert.NotNull(qos);
            Assert.Null(qos.ClientRequestId);
            provider.Clear();
        }

        static Task ProcessSignal(List<EventArgs> eventStore, string id, CancellationToken token, Func<EventArgs> getEventData)
        {
            return Task.Run(() => eventStore.Add(getEventData()));
        }

        static Uri CreateUri(string baseString)
        {
            Uri outValue = null;
            if (!Uri.TryCreate(baseString, UriKind.Absolute, out outValue))
            {
                Uri.TryCreate(baseString, UriKind.Relative, out outValue);
            }

            return outValue;
        }

        internal class MockTelemetryProvider: TelemetryProvider
        {
            protected MockTelemetryProvider(AzurePSDataCollectionProfile profile, MetricHelper helper, Action<string> warningLogger, Action<string> debugLogger) : base(profile, helper, warningLogger, debugLogger)
            {
            }

            internal static TelemetryProvider Create(IEventStore store)
            {
                var profile = new AzurePSDataCollectionProfile(false);
                return new MockTelemetryProvider(profile, new MetricHelper(profile), store.GetWarningLogger(), store.GetDebugLogger());
            }

            public override void LogEvent(string key)
            {
            }
        }
    }
}
