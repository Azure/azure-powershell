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
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using Microsoft.Azure.Management.Internal.Resources;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Commands.Management.CognitiveServices.Test.ScenarioTests
{
    public class TestController
    {
        private readonly EnvironmentSetupHelper _helper;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public CognitiveServicesManagementClient CognitiveServicesClient { get; private set; }

        public NetworkManagementClient NetworkClient { get; private set; }

        public string UserDomain { get; private set; }

        public static TestController NewInstance => new TestController();

        public TestController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(XunitTracingInterceptor traceInterceptor, params string[] scripts)
        {
            _helper.TracingInterceptor = traceInterceptor;
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

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
                {"Microsoft.Authorization", null},
                {"Microsoft.Network", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = RestTestFramework.MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.RMNetworkModule,
                    "AzureRM.Resources.ps1",
                    _helper.GetRMModulePath("AzureRM.CognitiveServices.psd1")
                );

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

        private void SetupManagementClients(RestTestFramework.MockContext context)
        {
            ResourceManagementClient = GetResourceManagementClient(context);
            NetworkClient = GetNetworkClient(context);
            CognitiveServicesClient = GetCognitiveServicesManagementClient(context);

            _helper.SetupManagementClients(
                ResourceManagementClient,
                NetworkClient,
                CognitiveServicesClient);
        }

        private static ResourceManagementClient GetResourceManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private static CognitiveServicesManagementClient GetCognitiveServicesManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<CognitiveServicesManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        protected NetworkManagementClient GetNetworkClient(RestTestFramework.MockContext context)
        {
            NetworkManagementClient client =
                context.GetServiceClient<NetworkManagementClient>(
                    RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
            return client;
        }
    }
}
