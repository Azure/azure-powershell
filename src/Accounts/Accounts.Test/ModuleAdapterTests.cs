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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class ModuleAdapterTests
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
            Assert.Equal(expected, checkValue.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPatchHostNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => EnvironmentExtensions.PatchHost(null, null));
            Assert.Throws<ArgumentOutOfRangeException>(() => EnvironmentExtensions.PatchHost(null, "  "));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Uri("https://manage.windowsazure.com/subscriptions").PatchHost("  "));
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
        [InlineData(EnvironmentName.AzureGermanCloud)]
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

        [Theory]
        [InlineData(EnvironmentName.AzureChinaCloud)]
        [InlineData(EnvironmentName.AzureGermanCloud)]
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

        [Theory]
        [InlineData(EnvironmentName.AzureChinaCloud)]
        [InlineData(EnvironmentName.AzureGermanCloud)]
        [InlineData(EnvironmentName.AzureUSGovernment)]
        [InlineData(EnvironmentName.AzureCloud)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public static void TestEndpointAndAudienceUpdate(string environmentName)
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

        static Uri CreateUri(string baseString)
        {
            Uri outValue = null;
            if (!Uri.TryCreate(baseString, UriKind.Absolute, out outValue))
            {
                Uri.TryCreate(baseString, UriKind.Relative, out outValue);
            }

            return outValue;
        }
    }
}
