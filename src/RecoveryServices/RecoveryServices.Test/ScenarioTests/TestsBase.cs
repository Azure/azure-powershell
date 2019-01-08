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
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.ServiceManagement.Common.Models;
using System.Diagnostics;
using Microsoft.Azure.Management.Internal.Resources;

namespace Microsoft.Azure.Commands.RecoveryServices.Test.ScenarioTests
{
    public class TestController
    {
        private readonly EnvironmentSetupHelper _helper;

        public RecoveryServicesClient RsClient { get; private set; }

        public ResourceManagementClient InternalRmClient { get; private set; }

        public static TestController NewInstance => new TestController();

        public TestController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(RestTestFramework.MockContext context)
        {
            RsClient = GetRsClient(context);
            InternalRmClient = GetInternalRmClient(context);

            _helper.SetupManagementClients(RsClient, InternalRmClient);
        }

        public void RunPsTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            _helper.TracingInterceptor = logger;

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
            var providers = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null},
                {"Microsoft.Compute", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                {"Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient", "2016-02-01"}
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = RestTestFramework.MockContext.Start(callingClassType, mockName))
            {
                    initialize?.Invoke(this);
                
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                var psFile = "ScenarioTests\\" + callingClassName + ".ps1";
                var rmProfileModule = _helper.RMProfileModule;
                var rmModulePath = _helper.GetRMModulePath("AzureRM.RecoveryServices.psd1");

                var modules = new List<string> {psFile, rmProfileModule, rmModulePath, "AzureRM.Resources.ps1"};

                _helper.SetupModules(AzureModule.AzureResourceManager, modules.ToArray());

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

        private static ResourceManagementClient GetInternalRmClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private static RecoveryServicesClient GetRsClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}