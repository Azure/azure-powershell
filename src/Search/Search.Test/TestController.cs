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
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Search;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Storage;

namespace Microsoft.Azure.Commands.Management.Search.Test.ScenarioTests
{
    public class TestController
    {
        private readonly EnvironmentSetupHelper _helper;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public SearchManagementClient SearchClient { get; private set; }

        public StorageManagementClient StorageManagementClient { get; private set; }

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
            var providersToInclude = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null},
                {"Microsoft.Storage", null}
            };

            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providersToInclude, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);
                _helper.SetupEnvironment(AzureModule.AzureResourceManager);
                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath("AzureRM.Search.psd1"),
                    _helper.GetRMModulePath("AzureRM.Storage.psd1"),
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
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
            SearchClient = GetAzureSearchManagementClient(context);
            StorageManagementClient = GetStorageManagementClient(context);

            _helper.SetupManagementClients(
                ResourceManagementClient,
                SearchClient,
                StorageManagementClient);
        }

        private StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static SearchManagementClient GetAzureSearchManagementClient(MockContext context)
        {
            return context.GetServiceClient<SearchManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
