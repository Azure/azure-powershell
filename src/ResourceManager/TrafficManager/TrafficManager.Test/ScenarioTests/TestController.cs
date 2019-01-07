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
using Microsoft.Azure.Test.HttpRecorder;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.TrafficManager;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using System;
using System.IO;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.TrafficManager.Test.ScenarioTests
{
    public class TestController : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public TrafficManagerManagementClient TrafficManagerManagementClient { get; private set; }

        public static TestController NewInstance => new TestController();

        protected TestController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(RestTestFramework.MockContext context)
        {
            ResourceManagementClient = GetResourceManagementClient(context);
            TrafficManagerManagementClient = GetFeatureClient(context);

            _helper.SetupManagementClients(
                ResourceManagementClient,
                TrafficManagerManagementClient);
        }

        public void RunPowerShellTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            _helper.TracingInterceptor = logger;

            RunPsTestWorkflow(
                () => scripts,
                // no custom cleanup
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
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
            using (var context = RestTestFramework.MockContext.Start(callingClassType, mockName))
            {
                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                SetupManagementClients(context);

                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();

                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath(@"AzureRM.TrafficManager.psd1"),
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

        protected ResourceManagementClient GetResourceManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private static TrafficManagerManagementClient GetFeatureClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<TrafficManagerManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
