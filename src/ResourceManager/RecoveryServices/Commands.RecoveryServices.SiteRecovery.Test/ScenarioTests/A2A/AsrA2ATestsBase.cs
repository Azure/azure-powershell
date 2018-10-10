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

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Internal.Subscriptions;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04;

namespace RecoveryServices.SiteRecovery.Test
{
    public abstract class AsrA2ATestsBase : RMTestBase
    {
        protected string vaultSettingsFilePath;
        protected string powershellFile;
        protected string powershellHelperFile;
        private CSMTestEnvironmentFactory csmTestFactory;
        private EnvironmentSetupHelper helper;

        protected AsrA2ATestsBase()
        {
        }

        protected void initialize()
        {
            this.helper = new EnvironmentSetupHelper();
        }

        public ResourceManagementClient RmRestClient { get; private set; }
        
        
        public RecoveryServicesClient RecoveryServicesMgmtClient { get; private set; }
        public SiteRecoveryManagementClient SiteRecoveryMgmtClient { get; private set; }

        public ComputeManagementClient ComputeManagementClient { get; private set; }
        public Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient ResourceManagementRestClient { get; private set; }

        public void RunPowerShellTest(
             XunitTracingInterceptor logger,
             string scenario,
            params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            this.RunPsTestWorkflow(
                scenario,
                () => scripts,

                // no custom initializer
                null,

                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
            string scenario,
            Func<string[]> scriptBuilder,
            Action<CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            var providers = new Dictionary<string, string>();
            providers.Add("Microsoft.Resources", null);
            providers.Add("Microsoft.Features", null);
            providers.Add("Microsoft.Authorization", null);

            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient", "2016-09-01");

            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(
                true,
                providers,
                providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "SessionRecords");

            using (var context = RestTestFramework.MockContext.Start(
                callingClassType,
                mockName))
            {
                this.csmTestFactory = new CSMTestEnvironmentFactory();

                if (initialize != null)
                {
                    initialize.Invoke(this.csmTestFactory);
                }

                this.SetupManagementClients(context);

                this.helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var rmProfileModule = this.helper.RMProfileModule;
                this.helper.SetupModules(
                    AzureModule.AzureResourceManager,
                    powershellFile,
                    powershellHelperFile,
                    rmProfileModule,
                    this.helper.RMResourceModule,
                    this.helper.GetRMModulePath("AzureRM.RecoveryServices.psd1"),
                    this.helper.GetRMModulePath("AzureRM.RecoveryServices.SiteRecovery.psd1"),
                    "AzureRm.Resources.ps1");

                try
                {
                    if (scriptBuilder != null)
                    {
                        var psScripts = scriptBuilder();

                        if (psScripts != null)
                        {
                            this.helper.RunPowerShellTest(psScripts);
                        }
                    }
                }
                finally
                {
                    if (cleanup != null)
                    {
                        cleanup.Invoke();
                    }
                }
            }
        }

        protected void SetupManagementClients(
            RestTestFramework.MockContext context)
        {
            this.RmRestClient = this.GetRmRestClient(context);
            this.ResourceManagementRestClient = this.GetResourceManagementClientRestClient(context);
            this.RecoveryServicesMgmtClient = this.GetRecoveryServicesManagementClient(context);
            this.SiteRecoveryMgmtClient = this.GetSiteRecoveryManagementClient(context);
            
            this.helper.SetupManagementClients(
                this.RmRestClient,
                this.RecoveryServicesMgmtClient,
                this.SiteRecoveryMgmtClient,
                this.ResourceManagementRestClient);
        }

        private RecoveryServicesClient GetRecoveryServicesManagementClient(
            RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesClient>(
                RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private ResourceManagementClient GetRmRestClient(
            RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(
                RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private ResourceManagementClient GetResourceManagementClient(
            RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(
                RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient GetResourceManagementClientRestClient(
            RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient>(
                RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private SiteRecoveryManagementClient GetSiteRecoveryManagementClient(
            string scenario,
            RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<SiteRecoveryManagementClient>(
                RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private SiteRecoveryManagementClient GetSiteRecoveryManagementClient(
            RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<SiteRecoveryManagementClient>(
                RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }
        
        private static bool IgnoreCertificateErrorHandler(
            object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
