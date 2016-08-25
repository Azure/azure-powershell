namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Test.ScenarioTests
{
    using Azure.Management.ApiManagement;
    using Microsoft.Azure.Management.ApiManagement.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Management;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;

    public class TestsFixture : TestBase
    {
        public TestsFixture()
        {
            // place any initialization like environment settings here
#if DEBUG
            //Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Record");

            //Environment.SetEnvironmentVariable(
            //    "TEST_CSM_ORGID_AUTHENTICATION",
            //    "SubscriptionId=;Environment=Prod");

            //Environment.SetEnvironmentVariable(
            //    "TEST_ORGID_AUTHENTICATION",
            //    "SubscriptionId=;Environment=Prod");
#endif

            TestUtilities.StartTest();
            try
            {
                UndoContext.Current.Start();

                var resourceManagementClient = ApiManagementHelper.GetResourceManagementClient();
                resourceManagementClient.TryRegisterSubscriptionForResource();
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        public void Dispose()
        {
            Cleanup();
        }

        protected void Cleanup()
        {
            UndoContext.Current.UndoAll();
        }
    }

    public static class ApiManagementHelper
    {
        public static ApiManagementClient GetApiManagementClient()
        {
            return TestBase.GetServiceClient<ApiManagementClient>(new CSMTestEnvironmentFactory());
        }

        public static ResourceManagementClient GetResourceManagementClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
        }

        public static ManagementClient GetManagementClient()
        {
            return TestBase.GetServiceClient<ManagementClient>();
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
            SkuType skuType = SkuType.Developer)
        {
            client.ResourceProvider.CreateOrUpdate(
                resourceGroupName,
                apiServiceName,
                new ApiServiceCreateOrUpdateParameters
                {
                    Location = location,
                    Properties = new ApiServiceProperties
                    {
                        SkuProperties = new ApiServiceSkuProperties
                        {
                            Capacity = 1,
                            SkuType = skuType
                        },
                        AddresserEmail = "foo@live.com",
                        PublisherEmail = "foo@live.com",
                        PublisherName = "apimgmt"
                    }
                });

            var response = client.ResourceProvider.Get(resourceGroupName, apiServiceName);
            ThrowIfTrue(!response.Value.Name.Equals(apiServiceName), string.Format("ApiService name is not equal to {0}", apiServiceName));
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