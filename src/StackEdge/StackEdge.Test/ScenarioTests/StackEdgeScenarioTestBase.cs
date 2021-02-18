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
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using ResourceManagementClient = Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient;
using StorageManagementClient = Microsoft.Azure.Management.Storage.Version2017_10_01.StorageManagementClient;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using StackEdgeManagementClient = Microsoft.Azure.Management.DataBoxEdge.DataBoxEdgeManagementClient;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Test.ScenarioTests
{
    public class StackEdgeScenarioTestBase : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;

        protected StackEdgeScenarioTestBase()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public StackEdgeManagementClient StackEdgeManagementClient { get; private set; }

        public StorageManagementClient StorageManagementClient { get; private set; }
        public static StackEdgeScenarioTestBase NewInstance => new StackEdgeScenarioTestBase();


        
        /// <summary>
        /// Methods for invoking PowerShell scripts
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="scripts"></param>
        public void RunPowerShellTest(ServiceManagement.Common.Models.XunitTracingInterceptor logger,
            params string[] scripts)
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

        private void RunPsTestWorkflow(
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
                {"Microsoft.Compute", null}
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

                var callingClassName =
                    callingClassType.Split(new[] {"."}, StringSplitOptions.RemoveEmptyEntries).Last();
                
                var azStackEdgeModulePath = _helper.GetRMModulePath("Az.StackEdge.psd1");
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    _helper.RMProfileModule,
                    azStackEdgeModulePath,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    "AzureRM.Storage.ps1",
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


        protected void SetupManagementClients(MockContext context)
        {
            var stackEdgeManagementClient = GetStackEdgeManagementClient(context);
            var resourceManagementClient = GetResourceManagementClient(context);
            var storageManagementClient = GetStorageManagementClient(context);

            _helper.SetupManagementClients(
                stackEdgeManagementClient,
                resourceManagementClient,
                storageManagementClient);
        }


        protected StackEdgeManagementClient GetStackEdgeManagementClient(MockContext context)
        {
            return context.GetServiceClient<StackEdgeManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}