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

namespace Microsoft.AzureStack.Commands.Admin.Test.Common
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Globalization;
    using System.Linq;
    using Microsoft.Azure.Common.Authentication;
    using Microsoft.Azure.Gallery;
    using Microsoft.Azure.Management.Authorization;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Subscriptions;
    using Microsoft.Azure.Test;
    using Microsoft.AzureStack.Management;
    using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;

    public sealed class AzStackTestRunner
    {
       
        private EnvironmentSetupHelper helper;
        private CSMTestEnvironmentFactory armTestEnvironmentFactory;

        public AzureStackClient azureStackClient;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public SubscriptionClient SubscriptionClient { get; private set; }

        public GalleryClient GalleryClient { get; private set; }

        public string ApiVersion { get; set; }

        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }

        public static AzStackTestRunner NewInstance
        {
            get
            {
                return new AzStackTestRunner() {ApiVersion= "1.0"};
            }
        }

        public AzStackTestRunner()
        {
            helper = new EnvironmentSetupHelper();
        }

        public List<string> SetupCommonModules()
        {
            List<string> modules = new List<string>();
            modules = new List<string>();
            bool aadEnvironement = Convert.ToBoolean(ReadAppSettings("AadEnvironment"), CultureInfo.InvariantCulture);

            // The modules are deployed to the test run directory with the test settings file
            modules.Add(@"AssertResources.psm1");
            modules.Add(@"GlobalVariables.psm1");
            modules.Add(@"AuthOperations.psm1");
            modules.Add(@"CommonOperations.psm1");
            modules.Add(@"ArmOperations.psm1");
            modules.Add(@"Utilities.psm1");
            
            return modules;
        }

        private string[] SetupAzureStackEnvironment(string testScript)
        {
            List<string> scripts =new List<string>();
            string azureStackMachine = "azurestack";
            bool aadEnvironment = Convert.ToBoolean(ReadAppSettings("AadEnvironment"), CultureInfo.InvariantCulture);
            string aadTenantId = ReadAppSettings("AadTenantId", mandatory: false);
            string aadApplicationId = ReadAppSettings("AadApiApplicationId", mandatory: false);
            string armEndpoint = ReadAppSettings("ArmEndpoint", mandatory: false);
            string galleryEndpoint = ReadAppSettings("GalleryEndpoint", mandatory: false);
            string aadGraphUri = ReadAppSettings("AadGraphUri", mandatory: false);
            string aadLoginuri = ReadAppSettings("AadLoginUri", mandatory: false);
            
            string setupAzureStackEnvironmentPs;

            if (aadEnvironment)
            { 
                setupAzureStackEnvironmentPs = string.Format(
                    CultureInfo.InvariantCulture,
                    "Set-AzureStackEnvironment -AzureStackMachineName {0} -AadTenantId {1} -AadApplicationId {2} -ArmEndpoint {3} -GalleryEndpoint {4} -AadGraphUri {5} -AadLoginUri {6}",
                    azureStackMachine,
                    aadTenantId,
                    aadApplicationId,
                    armEndpoint,
                    galleryEndpoint,
                    aadGraphUri,
                    aadLoginuri
                    );
            }
            else
            {
                setupAzureStackEnvironmentPs = "Set-AzureStackEnvironment -AzureStackMachineName " + azureStackMachine;
            }

            scripts.Add(
                string.Format(
                "Import-Module -Force {0}",
                @"F:\gh-bganapa\azure-powershell\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.AzureStackAdmin\AzureRM.AzureStackAdmin.psd1"));

            //string selfSignedCertPs = "Ignore-SelfSignedCert";
            //scripts.Add(selfSignedCertPs);
            scripts.Add(setupAzureStackEnvironmentPs);
            
            scripts.Add(testScript);
            return scripts.ToArray();
        }

        public static string ReadAppSettings(string key, bool mandatory = true)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key, StringComparer.OrdinalIgnoreCase))
            {
                return ConfigurationManager.AppSettings[key];
            }

            if (mandatory)
            {
                throw new ConfigurationErrorsException(string.Format(CultureInfo.InvariantCulture, "The app settings key {0} is missing in the settings file", key));
            }

            return null;
        }

        public void RunPsTest(string testScript)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            RunPsTestWorkflow(
                () => SetupAzureStackEnvironment(testScript),
                // no custom initializer
                null,
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
           Func<string[]> scriptBuilder,
           Action<CSMTestEnvironmentFactory> initialize,
           Action cleanup,
           string callingClassType,
           string mockName)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(callingClassType, mockName);

                this.armTestEnvironmentFactory = new CSMTestEnvironmentFactory();

                if (initialize != null)
                {
                    initialize(this.armTestEnvironmentFactory);
                }

                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                SetupManagementClients();

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();

                List<string> modules = this.SetupCommonModules();
                modules.Add(callingClassName + ".ps1");
                modules.Add(helper.RMProfileModule);
                modules.Add(helper.RMResourceModule);
                helper.SetupModules(AzureModule.AzureResourceManager, modules.ToArray());

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

        private void SetupManagementClients()
        {
            ResourceManagementClient = GetResourceManagementClient();
            SubscriptionClient = GetSubscriptionClient();
            GalleryClient = GetGalleryClient();
            AuthorizationManagementClient = this.GetAuthorizationManagementClient();

            azureStackClient = TestBase.GetServiceClient<AzureStackClient>(this.armTestEnvironmentFactory, this.ApiVersion);

            this.SetupManagementClients(ResourceManagementClient, SubscriptionClient, GalleryClient, AuthorizationManagementClient, azureStackClient);
        }

        /// <summary>
        /// Loads DummyManagementClientHelper with clients and throws exception if any client is missing.
        /// </summary>
        /// <param name="initializedManagementClients"></param>
        public void SetupManagementClients(params object[] initializedManagementClients)
        {
            AzureSession.ClientFactory = new MockClientFactory(initializedManagementClients);
        }

        private ResourceManagementClient GetResourceManagementClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(this.armTestEnvironmentFactory);
        }

        private GalleryClient GetGalleryClient()
        {
            return TestBase.GetServiceClient<GalleryClient>(this.armTestEnvironmentFactory);
        }

        private SubscriptionClient GetSubscriptionClient()
        {
            return TestBase.GetServiceClient<SubscriptionClient>(this.armTestEnvironmentFactory);
        }

        private AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return TestBase.GetServiceClient<AuthorizationManagementClient>(this.armTestEnvironmentFactory);
        }


    }
}
