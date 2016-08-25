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
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Subscriptions;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using LegacyTest = Microsoft.Azure.Test;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using TestUtilities = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities;
using NewResourceManagementClient = Microsoft.Azure.Management.ResourceManager.ResourceManagementClient;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System.IO;

namespace Microsoft.Azure.Commands.DataLakeStore.Test.ScenarioTests
{
    public class AdlsTestsBase : RMTestBase
    {
        private LegacyTest.CSMTestEnvironmentFactory csmTestFactory;
        private EnvironmentSetupHelper helper;
        private const string AuthorizationApiVersion = "2014-07-01-preview";
        internal const string resourceGroupLocation = "East US 2";

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public NewResourceManagementClient NewResourceManagementClient { get; private set; }

        public SubscriptionClient SubscriptionClient { get; private set; }

        public DataLakeStoreAccountManagementClient DataLakeStoreAccountManagementClient { get; private set; }

        public DataLakeStoreFileSystemManagementClient DataLakeStoreFileSystemManagementClient { get; private set; }

        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }

        public GalleryClient GalleryClient { get; private set; }

        public static AdlsTestsBase NewInstance
        {
            get
            {
                return new AdlsTestsBase();
            }
        }


        public AdlsTestsBase()
        {
            helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            RunPsTestWorkflow(
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }


        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action<LegacyTest.CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Features", null);
            d.Add("Microsoft.Authorization", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                this.csmTestFactory = new LegacyTest.CSMTestEnvironmentFactory();
                if (initialize != null)
                {
                    initialize(this.csmTestFactory);
                }

                SetupManagementClients(context);

                // register the namespace.
                this.TryRegisterSubscriptionForResource();
                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                helper.SetupModules(AzureModule.AzureResourceManager, "ScenarioTests\\Common.ps1", "ScenarioTests\\" + callingClassName + ".ps1",
                helper.RMProfileModule, helper.RMResourceModule, helper.GetRMModulePath(@"AzureRM.DataLakeStore.psd1"), "AzureRM.Resources.ps1");

                try
                {
                    if (scriptBuilder != null)
                    {
                        var psScripts = scriptBuilder();

                        if (psScripts != null)
                        {
                            helper.RunPowerShellTest(psScripts);
                        }
                    }
                }
                finally
                {
                    if (cleanup != null)
                    {
                        cleanup();
                    }
                }
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            ResourceManagementClient = GetResourceManagementClient();
            SubscriptionClient = GetSubscriptionClient();
            DataLakeStoreAccountManagementClient = GetDataLakeStoreAccountManagementClient(context);
            DataLakeStoreFileSystemManagementClient = GetDataLakeStoreFileSystemManagementClient(context);
            AuthorizationManagementClient = GetAuthorizationManagementClient();
            GalleryClient = GetGalleryClient();
            NewResourceManagementClient = GetNewResourceManagementClient(context);
            helper.SetupManagementClients(ResourceManagementClient,
                NewResourceManagementClient,
                SubscriptionClient,
                DataLakeStoreFileSystemManagementClient,
                DataLakeStoreAccountManagementClient,
                AuthorizationManagementClient,
                GalleryClient
                );
        }


        private AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<AuthorizationManagementClient>(this.csmTestFactory);
        }

        private ResourceManagementClient GetResourceManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<ResourceManagementClient>(this.csmTestFactory);
        }

        private SubscriptionClient GetSubscriptionClient()
        {
            return LegacyTest.TestBase.GetServiceClient<SubscriptionClient>(this.csmTestFactory);
        }

        #region client creation helpers

        private NewResourceManagementClient GetNewResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<NewResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private DataLakeStoreAccountManagementClient GetDataLakeStoreAccountManagementClient(MockContext context)
        {
            return context.GetServiceClient<DataLakeStoreAccountManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private DataLakeStoreFileSystemManagementClient GetDataLakeStoreFileSystemManagementClient(MockContext context)
        {
            var currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            var toReturn = context.GetServiceClient<DataLakeStoreFileSystemManagementClient>(currentEnvironment, true);
            toReturn.AdlsFileSystemDnsSuffix =
                currentEnvironment.Endpoints.DataLakeStoreServiceUri.OriginalString.Replace("https://", "");
            return toReturn;
        }

        private GalleryClient GetGalleryClient()
        {
            return LegacyTest.TestBase.GetServiceClient<GalleryClient>(this.csmTestFactory);
        }

        #endregion

        #region private helper methods

        private void TryRegisterSubscriptionForResource(string providerName = "Microsoft.DataLakeStore")
        {
            var reg = ResourceManagementClient.Providers.Register(providerName);
            ThrowIfTrue(reg == null, "resourceManagementClient.Providers.Register returned null.");
            ThrowIfTrue(reg.StatusCode != HttpStatusCode.OK, string.Format("resourceManagementClient.Providers.Register returned with status code {0}", reg.StatusCode));

            var resultAfterRegister = ResourceManagementClient.Providers.Get(providerName);
            ThrowIfTrue(resultAfterRegister == null, "resourceManagementClient.Providers.Get returned null.");
            ThrowIfTrue(string.IsNullOrEmpty(resultAfterRegister.Provider.Id), "Provider.Id is null or empty.");
            ThrowIfTrue(!providerName.Equals(resultAfterRegister.Provider.Namespace), string.Format("Provider name is not equal to {0}.", providerName));
            ThrowIfTrue(ProviderRegistrationState.Registered != resultAfterRegister.Provider.RegistrationState &&
                ProviderRegistrationState.Registering != resultAfterRegister.Provider.RegistrationState,
                string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", resultAfterRegister.Provider.RegistrationState));
            ThrowIfTrue(resultAfterRegister.Provider.ResourceTypes == null || resultAfterRegister.Provider.ResourceTypes.Count == 0, "Provider.ResourceTypes is empty.");
        }

        private void TryCreateResourceGroup(string resourceGroupName, string location)
        {
            ResourceGroupCreateOrUpdateResult result = ResourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = location });
            var newlyCreatedGroup = ResourceManagementClient.ResourceGroups.Get(resourceGroupName);
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

    }
}
