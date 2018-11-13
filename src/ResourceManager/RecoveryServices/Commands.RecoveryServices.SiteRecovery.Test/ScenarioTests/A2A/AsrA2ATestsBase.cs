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
using System.Diagnostics;
using System.IO;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04;

namespace RecoveryServices.SiteRecovery.Test
{
    public abstract class AsrA2ATestsBase : RMTestBase
    {
        protected string VaultSettingsFilePath;
        protected string PowershellFile;
        protected string PowershellHelperFile;
        private EnvironmentSetupHelper _helper;

        protected void Initialize()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public ResourceManagementClient RmRestClient { get; private set; }
        public RecoveryServicesClient RecoveryServicesMgmtClient { get; private set; }
        public SiteRecoveryManagementClient SiteRecoveryMgmtClient { get; private set; }
        public ComputeManagementClient ComputeManagementClient { get; private set; }
        public ResourceManagementClient ResourceManagementRestClient { get; private set; }

        public void RunPowerShellTest(XunitTracingInterceptor logger, string scenario, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            RunPsTestWorkflow(
                scenario,
                () => scripts,
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
            string scenario,
            Func<string[]> scriptBuilder,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            var providers = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null}
            };

            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient", "2016-09-01"}
            };

            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = RestTestFramework.MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var rmProfileModule = _helper.RMProfileModule;
                _helper.SetupModules(
                    AzureModule.AzureResourceManager,
                    PowershellFile,
                    PowershellHelperFile,
                    rmProfileModule,
                    _helper.RMResourceModule,
                    _helper.GetRMModulePath("AzureRM.RecoveryServices.psd1"),
#if !NETSTANDARD
                    _helper.GetRMModulePath("AzureRM.RecoveryServices.SiteRecovery.psd1"),
#endif
                    "AzureRM.Resources.ps1");

                try
                {
                    var psScripts = scriptBuilder?.Invoke();
                    if (psScripts != null)
                    {
                        _helper.RunPowerShellTest(psScripts);
                    }
                }
                finally
                {
                    cleanup?.Invoke();
                }
            }
        }

        protected void SetupManagementClients(
            RestTestFramework.MockContext context)
        {
            RmRestClient = GetRmRestClient(context);
            ResourceManagementRestClient = GetResourceManagementClientRestClient(context);
            RecoveryServicesMgmtClient = GetRecoveryServicesManagementClient(context);
            SiteRecoveryMgmtClient = GetSiteRecoveryManagementClient(context);
            
            _helper.SetupManagementClients(
                RmRestClient,
                RecoveryServicesMgmtClient,
                SiteRecoveryMgmtClient,
                ResourceManagementRestClient);
        }

        private static RecoveryServicesClient GetRecoveryServicesManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ResourceManagementClient GetRmRestClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ResourceManagementClient GetResourceManagementClientRestClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private static SiteRecoveryManagementClient GetSiteRecoveryManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<SiteRecoveryManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
