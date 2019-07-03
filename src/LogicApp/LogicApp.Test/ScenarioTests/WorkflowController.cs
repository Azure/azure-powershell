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

using Microsoft.Azure.Management.Internal.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Logic;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.IO;
using Microsoft.Azure.ServiceManagement.Common.Models;

namespace Microsoft.Azure.Commands.LogicApp.Test.ScenarioTests
{
    public class WorkflowController
    {
        private readonly EnvironmentSetupHelper _helper;
        private const string AuthorizationApiVersion = "2014-07-01-preview";

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public Management.ResourceManager.ResourceManagementClient OldResourceManagementClient { get; private set; }

        public LogicManagementClient LogicManagementClient { get; private set; }

        public static WorkflowController NewInstance => new WorkflowController();

        public WorkflowController()
        {
            _helper = new EnvironmentSetupHelper();
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
                {"Microsoft.Authorization", AuthorizationApiVersion},
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null}
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

                var callingClassName = callingClassType.Split(new[] {"."}, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath(@"Az.LogicApp.psd1"),
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
            LogicManagementClient = GetLogicManagementClient(context);
            OldResourceManagementClient = GetOldResourceManagementClient(context);
            _helper.SetupManagementClients(OldResourceManagementClient, ResourceManagementClient, LogicManagementClient);
        }

        private static Management.ResourceManager.ResourceManagementClient GetOldResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<Management.ResourceManager.ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static LogicManagementClient GetLogicManagementClient(MockContext context)
        {
            return context.GetServiceClient<LogicManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}