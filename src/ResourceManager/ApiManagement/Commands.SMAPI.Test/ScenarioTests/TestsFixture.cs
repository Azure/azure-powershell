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


using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Azure.Test;
using System;
using System.Linq;
using System.Net;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using TestUtilities = Microsoft.Azure.Test.TestUtilities;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using TestBase = Microsoft.Azure.Test.TestBase;

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Test.ScenarioTests
{
    using ApiManagementClient = Management.ApiManagement.ApiManagementClient;

    public class TestsFixture : RMTestBase
    {
        public TestsFixture()
        {
            // Initialize has bug which causes null reference exception
            HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();
            TestUtilities.StartTest();
            using (MockContext context = MockContext.Start(TestUtilities.GetCallingClass(), TestUtilities.GetCurrentMethodName(2)))
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
            return context.GetServiceClient<ApiManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        public static ResourceManagementClient GetResourceManagementClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
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
            ThrowIfTrue(reg.StatusCode != HttpStatusCode.OK, $"_client.Providers.Register returned with status code {reg.StatusCode}");

            var resultAfterRegister = resourceManagementClient.Providers.Get(providerName);
            ThrowIfTrue(resultAfterRegister == null, "_client.Providers.Get returned null.");
            ThrowIfTrue(string.IsNullOrEmpty(resultAfterRegister.Provider.Id), "Provider.Id is null or empty.");
            ThrowIfTrue(!providerName.Equals(resultAfterRegister.Provider.Namespace), $"Provider name is not equal to {providerName}.");
            ThrowIfTrue(ProviderRegistrationState.Registered != resultAfterRegister.Provider.RegistrationState &&
                        ProviderRegistrationState.Registering != resultAfterRegister.Provider.RegistrationState,
                $"Provider registration state was not 'Registered' or 'Registering', instead it was '{resultAfterRegister.Provider.RegistrationState}'");
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

        public static void TryRegisterResourceGroup(this ResourceManagementClient resourceManagementClient, string location, string resourceGroupName)
        {
            resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup(location));
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
    }
}