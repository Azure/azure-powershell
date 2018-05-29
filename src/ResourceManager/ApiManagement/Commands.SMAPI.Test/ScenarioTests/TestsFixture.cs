// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.


namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Test.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;
    using Azure.Test;
    using Management.ApiManagement;
    using Management.ApiManagement.Models;
    using Management.Resources.Models;
    using Microsoft.Azure.Gallery;
    using Microsoft.Azure.Management.Authorization;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.WindowsAzure.Management;
    using Microsoft.WindowsAzure.Management.Storage;
    using Rest.ClientRuntime.Azure.TestFramework;
    using WindowsAzure.Commands.Test.Utilities.Common;
    using LegacyTest = Microsoft.Azure.Test;


    public class TestsFixture : RMTestBase
    {
        public TestsFixture()
        {
            // Initialize has bug which causes null reference exception
            HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();
            LegacyTest.TestUtilities.StartTest();
            using (MockContext context = MockContext.Start(
                Azure.Test.TestUtilities.GetCallingClass(),
                Azure.Test.TestUtilities.GetCurrentMethodName(2)))
            {
                var resourceManagementClient = ApiManagementHelper.GetResourceManagementClient();
                resourceManagementClient.TryRegisterSubscriptionForResource();
            }
        }
    }

    public static class ApiManagementHelper
    {
        public static ApiManagementClient GetApiManagementClient(MockContext context)
        {
            return context.GetServiceClient<ApiManagementClient>(
                Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        public static ResourceManagementClient GetResourceManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
        }

        public static ManagementClient GetManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<ManagementClient>();
        }

        private static void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }

        public static void TryRegisterSubscriptionForResource(this ResourceManagementClient resourceManagementClient, string providerName = "Microsoft.ApiManagement")
        {
            var reg = resourceManagementClient.Providers.Register(providerName);
            ThrowIfTrue(reg == null, "_client.Providers.Register returned null.");
            ThrowIfTrue(reg.StatusCode != HttpStatusCode.OK, string.Format("_client.Providers.Register returned with status code {0}", reg.StatusCode));

            var resultAfterRegister = resourceManagementClient.Providers.Get(providerName);
            ThrowIfTrue(resultAfterRegister == null, "_client.Providers.Get returned null.");
            ThrowIfTrue(string.IsNullOrEmpty(resultAfterRegister.Provider.Id), "Provider.Id is null or empty.");
            ThrowIfTrue(!providerName.Equals(resultAfterRegister.Provider.Namespace), string.Format("Provider name is not equal to {0}.", providerName));
            ThrowIfTrue(ProviderRegistrationState.Registered != resultAfterRegister.Provider.RegistrationState &&
                        ProviderRegistrationState.Registering != resultAfterRegister.Provider.RegistrationState,
                string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", resultAfterRegister.Provider.RegistrationState));
            ThrowIfTrue(resultAfterRegister.Provider.ResourceTypes == null || resultAfterRegister.Provider.ResourceTypes.Count == 0, "Provider.ResourceTypes is empty.");
            ThrowIfTrue(resultAfterRegister.Provider.ResourceTypes[0].Locations == null || resultAfterRegister.Provider.ResourceTypes[0].Locations.Count == 0, "Provider.ResourceTypes[0].Locations is empty.");
        }

        public static string TryGetResourceGroup(this ResourceManagementClient resourceManagementClient, string location)
        {
            var resourceGroup =
                resourceManagementClient.ResourceGroups
                    .List(new ResourceGroupListParameters()).ResourceGroups
                    .Where(group => string.IsNullOrWhiteSpace(location) || group.Location.Equals(location, StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault(group => group.Name.Contains("Api-Default"));

            return resourceGroup != null
                ? resourceGroup.Name
                : string.Empty;
        }

        public static IEnumerable<ResourceGroupExtended> GetResourceGroups(this ResourceManagementClient resourceManagementClient)
        {
            return resourceManagementClient.ResourceGroups.List(new ResourceGroupListParameters()).ResourceGroups;
        }

        public static void TryRegisterResourceGroup(this ResourceManagementClient resourceManagementClient, string location, string resourceGroupName)
        {
            resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup(location));
        }

        public static string TryGetLocation(this ManagementClient managementClient, string preferedLocationName = null)
        {
            var locations = managementClient.Locations.List().Locations;
            if (!locations.Any())
            {
                return string.Empty;
            }

            var foundLocation = locations.First();
            if (preferedLocationName == null)
            {
                return foundLocation.Name;
            }

            var preferedLocation = locations.FirstOrDefault(location => location.Name.Contains(preferedLocationName));
            if (preferedLocation != null)
            {
                return preferedLocation.Name;
            }

            return foundLocation.Name;
        }

        public static IEnumerable<string> GetLocations(this ManagementClient managementClient)
        {
            return managementClient.Locations.List().Locations.Select(location => location.Name);
        }

        public static void TryCreateApiService(
            this ApiManagementClient client,
            string resourceGroupName,
            string apiServiceName,
            string location,
            string skuType = SkuType.Developer)
        {
            client.ApiManagementService.CreateOrUpdate(
                resourceGroupName,
                apiServiceName,
                new ApiManagementServiceResource
                {
                    Location = location,
                    NotificationSenderEmail = "apimgmt-noreply@mail.windowsazure.com",
                    PublisherEmail = "foo@live.com",
                    PublisherName = "apimgmt",
                    Sku = new ApiManagementServiceSkuProperties
                    {
                        Capacity = 1,
                        Name = skuType
                    },
                });

            var response = client.ApiManagementService.Get(resourceGroupName, apiServiceName);
            ThrowIfTrue(!response.Name.Equals(apiServiceName), string.Format("ApiService name is not equal to {0}", apiServiceName));
        }

        public static Stream ToStream(this XDocument doc)
        {
            var stream = new MemoryStream();
            doc.Save(stream);
            stream.Position = 0;
            return stream;
        }
    }
}