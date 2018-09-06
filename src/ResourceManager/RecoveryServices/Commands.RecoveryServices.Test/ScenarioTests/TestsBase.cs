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
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using InternalRmNS = Microsoft.Azure.Management.Internal.Resources;
using LegacyTest = Microsoft.Azure.Test;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using System.Diagnostics;
using Microsoft.Azure.Management.Internal.Resources;

namespace Microsoft.Azure.Commands.RecoveryServices.Test.ScenarioTests
{
    public class TestController
    {
        EnvironmentSetupHelper helper;

        public RecoveryServicesClient RsClient { get; private set; }

        public InternalRmNS.ResourceManagementClient InternalRmClient { get; private set; }

        public static TestController NewInstance
        {
            get
            {
                return new TestController();
            }
        }

        public TestController()
        {
            this.helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(RestTestFramework.MockContext context)
        {
            RsClient = GetRsClient(context);
            InternalRmClient = GetInternalRmClient(context);

            helper.SetupManagementClients(
                RsClient,
                InternalRmClient);
        }

        private InternalRmNS.ResourceManagementClient GetInternalRmClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<InternalRmNS.ResourceManagementClient>(
                RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private ResourceManagementClient GetRmRestClient(
            RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(
                RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        public void RunPsTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            helper.TracingInterceptor = logger;

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
            Action<object> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            Dictionary<string, string> providers = new Dictionary<string, string>();
            providers.Add("Microsoft.Resources", null);
            providers.Add("Microsoft.Features", null);
            providers.Add("Microsoft.Authorization", null);
            providers.Add("Microsoft.Compute", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            providersToIgnore.Add("Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (RestTestFramework.MockContext context = RestTestFramework.MockContext.Start(callingClassType, mockName))
            {
                    initialize?.Invoke(this);
                
                SetupManagementClients(context);

                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName =
                    callingClassType
                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                string psFile =
                    "ScenarioTests\\" + callingClassName + ".ps1";
                string rmProfileModule = helper.RMProfileModule;
                string rmModulePath = helper.GetRMModulePath("AzureRM.RecoveryServices.psd1");

                List<string> modules = new List<string>();

                modules.Add(psFile);
                modules.Add(rmProfileModule);
                modules.Add(rmModulePath);
                modules.Add("AzureRM.Resources.ps1");

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
                        cleanup.Invoke();
                    }
                }
            }
        }

        private RecoveryServicesClient GetRsClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesClient>(
                RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}