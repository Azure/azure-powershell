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
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Azure.Management.SignalR;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.PrivateDns;

namespace Microsoft.Azure.Commands.SignalR.Test
{
    internal class TestController : RMTestBase
    {
        public static TestController NewInstance => new TestController();

        private readonly EnvironmentSetupHelper _helper = new EnvironmentSetupHelper();

        public ResourceManagementClient InternalResourceManagementClient { get; private set; }

        public SignalRManagementClient SignalRManagementClient { get; private set; }

        public NetworkManagementClient NetworkManagementClient { get; private set; }

        public PrivateDnsManagementClient PrivateDnsManagementClient { get; private set; }

        public void RunPowerShellTest(ServiceManagement.Common.Models.XunitTracingInterceptor logger, params string[] scripts)
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

            var providers = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);
                _helper.SetupEnvironment(AzureModule.AzureResourceManager);
                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(
                    AzureModule.AzureResourceManager,
                    _helper.RMProfileModule,
                    _helper.RMNetworkModule,
                    _helper.GetRMModulePath("AzureRM.SignalR.psd1"),
                    _helper.GetRMModulePath("AzureRM.PrivateDns.psd1"),
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    "AzureRM.Resources.ps1",
                    "ScenarioTests\\Common.ps1"); ;
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

        protected void SetupManagementClients(MockContext context)
        {
            InternalResourceManagementClient = GetResourceManagementClientInternal(context);
            SignalRManagementClient = GetSignalRManagementClient(context);
            NetworkManagementClient = GetNetworkManagementClient(context);
            PrivateDnsManagementClient = GetPrivateDnsManagementClient(context);
            _helper.SetupManagementClients(InternalResourceManagementClient, SignalRManagementClient,
                NetworkManagementClient,PrivateDnsManagementClient);
        }

        private static ResourceManagementClient GetResourceManagementClientInternal(MockContext context)
            => context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());

        private static SignalRManagementClient GetSignalRManagementClient(MockContext context)
            => context.GetServiceClient<SignalRManagementClient>(TestEnvironmentFactory.GetTestEnvironment());

        private static NetworkManagementClient GetNetworkManagementClient(MockContext context)
            => context.GetServiceClient<NetworkManagementClient>(TestEnvironmentFactory.GetTestEnvironment());

        private static PrivateDnsManagementClient GetPrivateDnsManagementClient(MockContext context)
            => context.GetServiceClient<PrivateDnsManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
    }
}
