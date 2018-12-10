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

using System.Diagnostics;
using Microsoft.Azure.Management.Internal.Resources;

namespace Microsoft.Azure.Commands.IotCentral.Test.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using ServiceManagement.Common.Models;
    using Microsoft.Azure.Management.IotCentral;
    using TestEnvironmentFactory = Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;

    public sealed class IotCentralController
    {
        private readonly EnvironmentSetupHelper _helper;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public IotCentralClient IotCentralClient { get; private set; }

        public static IotCentralController NewInstance => new IotCentralController();

        public IotCentralController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            RunPsTestWorkflow(
                logger,
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup
                null,
                callingClassType,
                mockName);
        }


        public void RunPsTestWorkflow(
            XunitTracingInterceptor logger,
            Func<string[]> scriptBuilder,
            Action initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            _helper.TracingInterceptor = logger;
            var d = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                {"Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2017-05-10"},
                {"Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient", "2016-09-01"}
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                SetupManagementClients(context);
                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath(@"AzureRM.IotCentral.psd1"),
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

        private void SetupManagementClients(MockContext context)
        {
            ResourceManagementClient = GetResourceManagementClient(context);
            IotCentralClient = GetIotCentralClient(context);

            _helper.SetupManagementClients(ResourceManagementClient,IotCentralClient);
        }

        private static ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static IotCentralClient GetIotCentralClient(MockContext context)
        {
            return context.GetServiceClient<IotCentralClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
