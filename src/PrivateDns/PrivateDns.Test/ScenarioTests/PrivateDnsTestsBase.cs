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

namespace Microsoft.Azure.Commands.PrivateDns.Test.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Management.PrivateDns;
    using Microsoft.Azure.Management.Internal.Resources;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.ServiceManagement.Common.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
    using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;

    public class PrivateDnsTestsBase : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public PrivateDnsManagementClient PrivateDnsClient { get; private set; }

        public NetworkManagementClient NetworkManagementClient { get; private set; }

        public static PrivateDnsTestsBase NewInstance => new PrivateDnsTestsBase();

        protected PrivateDnsTestsBase()
        {
            _helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(MockContext context)
        {
            ResourceManagementClient = GetResourceManagementClient(context);
            PrivateDnsClient = GetFeatureClient(context);
            NetworkManagementClient = GetNetworkManagementClient(context);

            _helper.SetupManagementClients(
                ResourceManagementClient,
                PrivateDnsClient,
                NetworkManagementClient);
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
                {"Microsoft.Resources", null}, {"Microsoft.Features", null}, {"Microsoft.Authorization", null}
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

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();

                _helper.SetupModules(AzureModule.AzureResourceManager, "ScenarioTests\\Common.ps1", "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath("AzureRM.PrivateDns.psd1"),
                    _helper.GetRMModulePath("AzureRM.Network.psd1"),
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

        protected ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected NetworkManagementClient GetNetworkManagementClient(MockContext context)
        {
            return context.GetServiceClient<NetworkManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static PrivateDnsManagementClient GetFeatureClient(MockContext context)
        {
            return context.GetServiceClient<PrivateDnsManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
