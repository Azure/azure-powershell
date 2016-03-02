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

using System.Reflection;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.DataLake.StoreFileSystem;

namespace Microsoft.Azure.Commands.DataLakeStore.Test.ScenarioTests
{
    using System;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.Azure.Test;
    using Microsoft.Azure.Management.DataLake.Store;
    using ServiceManagemenet.Common;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using System.Net;

    public abstract class AdlsTestsBase : TestBase, IDisposable
    {
        internal string resourceGroupName { get; set; }
        internal string dataLakeAccountName { get; set; }
        internal const string resourceGroupLocation = "East US 2";

        private EnvironmentSetupHelper helper;

        private DataLakeStoreManagementClient dataLakeStoreManagementClient;

        private DataLakeStoreFileSystemManagementClient dataLakeStoreFileSystemManagementClient;

        private ResourceManagementClient resourceManagementClient;

        protected AdlsTestsBase()
        {
            helper = new EnvironmentSetupHelper();
            dataLakeStoreManagementClient = GetDataLakeStoreManagementClient();
            dataLakeStoreFileSystemManagementClient = GetDataLakeStoreFileSystemManagementClient();
            resourceManagementClient = GetResourceManagementClient();
            this.resourceGroupName = TestUtilities.GenerateName("datalakerg1");
            this.dataLakeAccountName = TestUtilities.GenerateName("testdatalake1");
        }

        protected void SetupManagementClients()
        {
            helper.SetupManagementClients(dataLakeStoreManagementClient, dataLakeStoreFileSystemManagementClient, resourceManagementClient);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2));
                try
                {
                    SetupManagementClients();

                    // Create the resource group
                    this.TryRegisterSubscriptionForResource();
                    this.TryCreateResourceGroup(this.resourceGroupName, AdlsTestsBase.resourceGroupLocation);

                    helper.SetupEnvironment(AzureModule.AzureResourceManager);
                    helper.SetupModules(AzureModule.AzureResourceManager, "ScenarioTests\\" + this.GetType().Name + ".ps1",
                    helper.RMProfileModule, helper.GetRMModulePath(@"AzureRM.DataLakeStore.psd1"));

                    helper.RunPowerShellTest(scripts);
                }
                finally
                {
                    context.UndoAll();
                }
            }
        }

        #region client creation helpers
        protected DataLakeStoreManagementClient GetDataLakeStoreManagementClient()
        {
            return TestBase.GetServiceClient<DataLakeStoreManagementClient>(new CSMTestEnvironmentFactory());
        }

        protected DataLakeStoreFileSystemManagementClient GetDataLakeStoreFileSystemManagementClient()
        {
            return GetDataLakeStoreFileSystemServiceClient<DataLakeStoreFileSystemManagementClient>(new CSMTestEnvironmentFactory());
        }

        protected ResourceManagementClient GetResourceManagementClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
        }
        #endregion

        #region private helper methods
        private static T GetDataLakeStoreFileSystemServiceClient<T>(
            TestEnvironmentFactory factory)
            where T : class
        {
            TestEnvironment currentEnvironment = factory.GetTestEnvironment();
            T client = null;

            ConstructorInfo constructor = typeof(T).GetConstructor(new Type[] 
                    { 
                        typeof(SubscriptionCloudCredentials), 
                        typeof(string) 
                    });
            client = constructor.Invoke(new object[] 
                    { 
                        currentEnvironment.Credentials as SubscriptionCloudCredentials, 
                        // Have to remove the https:// since this is a suffix
                        currentEnvironment.Endpoints.DataLakeStoreServiceUri.OriginalString.Replace("https://","") }) as T;

            return AddMockHandler<T>(ref client);
        }

        private void TryRegisterSubscriptionForResource(string providerName = "Microsoft.DataLakeStore")
        {
            var reg = resourceManagementClient.Providers.Register(providerName);
            ThrowIfTrue(reg == null, "resourceManagementClient.Providers.Register returned null.");
            ThrowIfTrue(reg.StatusCode != HttpStatusCode.OK, string.Format("resourceManagementClient.Providers.Register returned with status code {0}", reg.StatusCode));

            var resultAfterRegister = resourceManagementClient.Providers.Get(providerName);
            ThrowIfTrue(resultAfterRegister == null, "resourceManagementClient.Providers.Get returned null.");
            ThrowIfTrue(string.IsNullOrEmpty(resultAfterRegister.Provider.Id), "Provider.Id is null or empty.");
            ThrowIfTrue(!providerName.Equals(resultAfterRegister.Provider.Namespace), string.Format("Provider name is not equal to {0}.", providerName));
            ThrowIfTrue(ProviderRegistrationState.Registered != resultAfterRegister.Provider.RegistrationState &&
                ProviderRegistrationState.Registering != resultAfterRegister.Provider.RegistrationState,
                string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", resultAfterRegister.Provider.RegistrationState));
            ThrowIfTrue(resultAfterRegister.Provider.ResourceTypes == null || resultAfterRegister.Provider.ResourceTypes.Count == 0, "Provider.ResourceTypes is empty.");
            ThrowIfTrue(resultAfterRegister.Provider.ResourceTypes[0].Locations == null || resultAfterRegister.Provider.ResourceTypes[0].Locations.Count == 0, "Provider.ResourceTypes[0].Locations is empty.");
        }

        private void TryCreateResourceGroup(string resourceGroupName, string location)
        {
            ResourceGroupCreateOrUpdateResult result = resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = location });
            var newlyCreatedGroup = resourceManagementClient.ResourceGroups.Get(resourceGroupName);
            ThrowIfTrue(newlyCreatedGroup == null, "resourceManagementClient.ResourceGroups.Get returned null.");
            ThrowIfTrue(!resourceGroupName.Equals(newlyCreatedGroup.ResourceGroup.Name), string.Format("resourceGroupName is not equal to {0}", resourceGroupName));
        }

        private void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }
        #endregion
        public void Dispose()
        {
        }
    }
}
