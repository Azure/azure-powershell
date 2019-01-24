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
using Microsoft.Azure.Management.DataLake.Analytics;
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NewResourceManagementClient = Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient;
using StorageManagementClient = Microsoft.Azure.Management.Storage.Version2017_10_01.StorageManagementClient;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System.IO;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Sku = Microsoft.Azure.Management.Storage.Version2017_10_01.Models.Sku;
using SkuName = Microsoft.Azure.Management.Storage.Version2017_10_01.Models.SkuName;
using StorageAccountCreateParameters = Microsoft.Azure.Management.Storage.Version2017_10_01.Models.StorageAccountCreateParameters;

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Test.ScenarioTests
{
    public class AdlaTestsBase : RMTestBase
    {
        internal string ResourceGroupName { get; set; }
        internal string AzureBlobStoreName { get; set; }
        internal string AzureBlobStoreAccessKey { get; set; }
        internal const string ResourceGroupLocation = "eastus2";

        private readonly EnvironmentSetupHelper _helper;

        public NewResourceManagementClient NewResourceManagementClient { get; private set; }

        public DataLakeStoreAccountManagementClient DataLakeStoreAccountManagementClient { get; private set; }

        public DataLakeAnalyticsAccountManagementClient DataLakeAnalyticsAccountManagementClient { get; private set; }

        public DataLakeAnalyticsJobManagementClient DataLakeAnalyticsJobManagementClient { get; private set; }

        public DataLakeAnalyticsCatalogManagementClient DataLakeAnalyticsCatalogManagementClient { get; private set; }

        public StorageManagementClient StorageManagementClient { get; private set; }

        public static AdlaTestsBase NewInstance => new AdlaTestsBase();

        protected AdlaTestsBase()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(bool createWasbAccount, XunitTracingInterceptor logger, params string[] scripts)
        {
            _helper.TracingInterceptor = logger;
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            RunPsTestWorkflow(createWasbAccount,
                () => scripts,
                // no custom cleanup
                null,
                callingClassType,
                mockName);
        }


        public void RunPsTestWorkflow(bool createWasbAccount,
            Func<string[]> scriptBuilder,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            var d = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                // register the namespace.
                _helper.SetupEnvironment(AzureModule.AzureResourceManager);
                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(
                    AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath(@"AzureRM.DataLakeAnalytics.psd1"),
                    _helper.GetRMModulePath(@"AzureRM.DataLakeStore.psd1"),
                    "AzureRM.Resources.ps1");

                if (createWasbAccount)
                {
                    ResourceGroupName = TestUtilities.GenerateName("abarg1");
                    TryCreateResourceGroup(ResourceGroupName, ResourceGroupLocation);
                    AzureBlobStoreName = TestUtilities.GenerateName("azureblob01");
                    AzureBlobStoreAccessKey = TryCreateStorageAccount(ResourceGroupName,
                        AzureBlobStoreName,
                        "DataLakeAnalyticsTestStorage", "DataLakeAnalyticsTestStorageDescription", ResourceGroupLocation, out _);
                }

                try
                {
                    var psScripts = scriptBuilder?.Invoke();

                    if (psScripts == null) return;
                    // inject the access key into the script if necessary.
                    for (var i = 0; i < psScripts.Length; i++)
                    {
                        if (psScripts[i].Contains("-blobAccountKey") && createWasbAccount)
                        {
                            psScripts[i] = psScripts[i].Replace("-blobAccountKey",
                                string.Format("-blobAccountName {0} -blobAccountKey '{1}'", AzureBlobStoreName, AzureBlobStoreAccessKey));
                        }
                    }

                    _helper.RunPowerShellTest(psScripts);
                }
                finally
                {
                    if (createWasbAccount)
                    {
                        try
                        {
                            NewResourceManagementClient.ResourceGroups.DeleteWithHttpMessagesAsync(ResourceGroupName).Wait();
                        }
                        catch
                        {
                            // best effort cleanup.
                        }
                    }

                    cleanup?.Invoke();
                }
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            DataLakeStoreAccountManagementClient = GetDataLakeStoreAccountManagementClient(context);
            DataLakeAnalyticsAccountManagementClient = GetDataLakeAnalyticsAccountManagementClient(context);
            DataLakeAnalyticsJobManagementClient = GetDataLakeAnalyticsJobManagementClient(context);
            DataLakeAnalyticsCatalogManagementClient = GetDataLakeAnalyticsCatalogManagementClient(context);
            StorageManagementClient = GetStorageManagementClient(context);
            NewResourceManagementClient = GetNewResourceManagementClient(context);
            _helper.SetupManagementClients(
                NewResourceManagementClient,
                DataLakeAnalyticsAccountManagementClient,
                DataLakeAnalyticsJobManagementClient,
                DataLakeAnalyticsCatalogManagementClient,
                DataLakeStoreAccountManagementClient,
                StorageManagementClient
                );
        }

        #region client creation helpers
        private static StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static NewResourceManagementClient GetNewResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<NewResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static DataLakeStoreAccountManagementClient GetDataLakeStoreAccountManagementClient(MockContext context)
        {
            return context.GetServiceClient<DataLakeStoreAccountManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static DataLakeAnalyticsAccountManagementClient GetDataLakeAnalyticsAccountManagementClient(MockContext context)
        {
            return context.GetServiceClient<DataLakeAnalyticsAccountManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static DataLakeAnalyticsJobManagementClient GetDataLakeAnalyticsJobManagementClient(MockContext context)
        {
            var currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            var toReturn = context.GetServiceClient<DataLakeAnalyticsJobManagementClient>(currentEnvironment, true);
            toReturn.AdlaJobDnsSuffix =
                currentEnvironment.Endpoints.DataLakeAnalyticsJobAndCatalogServiceUri.OriginalString.Replace("https://", "");
            return toReturn;
        }

        private static DataLakeAnalyticsCatalogManagementClient GetDataLakeAnalyticsCatalogManagementClient(MockContext context)
        {
            var currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            var toReturn = context.GetServiceClient<DataLakeAnalyticsCatalogManagementClient>(currentEnvironment, true);
            toReturn.AdlaCatalogDnsSuffix =
                currentEnvironment.Endpoints.DataLakeAnalyticsJobAndCatalogServiceUri.OriginalString.Replace("https://", "");
            return toReturn;
        }
        #endregion

        #region private helper methods

        private void TryCreateResourceGroup(string resourceGroupName, string location)
        {
            NewResourceManagementClient.ResourceGroups.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, new ResourceGroup { Location = location }).Wait();
            var newlyCreatedGroup = NewResourceManagementClient.ResourceGroups.GetWithHttpMessagesAsync(resourceGroupName).Result;
            ThrowIfTrue(newlyCreatedGroup == null, "resourceManagementClient.ResourceGroups.Get returned null.");
            ThrowIfTrue(!resourceGroupName.Equals(newlyCreatedGroup?.Body.Name), string.Format("resourceGroupName is not equal to {0}", resourceGroupName));
        }

        public string TryCreateStorageAccount(string resourceGroupName, string storageAccountName, string label, string description, string location, out string storageAccountSuffix)
        {
            var stoInput = new StorageAccountCreateParameters
            {
                Location = location,
                Sku = new Sku { Name = SkuName.StandardGRS }
            };

            // retrieve the storage account
            StorageManagementClient.StorageAccounts.CreateWithHttpMessagesAsync(resourceGroupName, storageAccountName, stoInput).Wait();

            // retrieve the storage account primary access key
            var accessKey = StorageManagementClient.StorageAccounts.ListKeysWithHttpMessagesAsync(resourceGroupName, storageAccountName).Result.Body.Keys.First().Value;
            ThrowIfTrue(string.IsNullOrEmpty(accessKey), "storageManagementClient.StorageAccounts.ListKeys returned null.");

            // set the storage account suffix
            var getResponse = StorageManagementClient.StorageAccounts.GetPropertiesWithHttpMessagesAsync(resourceGroupName, storageAccountName).Result;
            storageAccountSuffix = getResponse.Body.PrimaryEndpoints.Blob;
            storageAccountSuffix = storageAccountSuffix.Replace("https://", "").TrimEnd('/');
            storageAccountSuffix = storageAccountSuffix.Replace(storageAccountName, "").TrimStart('.');

            return accessKey;
        }

        private static void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }
        #endregion
    }
}
