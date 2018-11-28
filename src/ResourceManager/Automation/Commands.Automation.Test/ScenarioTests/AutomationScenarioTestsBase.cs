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
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Automation;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ResourceManagementClient = Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient;
using Microsoft.Azure.Management.Storage.Version2017_10_01;

namespace Microsoft.Azure.Commands.Automation.Test
{
    public abstract class AutomationScenarioTestsBase : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;

        protected AutomationScenarioTestsBase()
        {
            _helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(MockContext context)
        {
            var resourceManagementClient = GetResourceManagementClient(context);
            var armStorageManagementClient = GetArmStorageManagementClient(context);
            var automationManagementClient = GetAutomationManagementClient(context);
            _helper.SetupSomeOfManagementClients(resourceManagementClient, armStorageManagementClient, automationManagementClient);
        }

        protected void RunPowerShellTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            HttpMockServer.RecordsDirectory = GetSessionRecordsDirectory();
            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                var callingClassName = callingClassType ?
                    .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                    .Last();

                var scriptLocation = Path.Combine("ScenarioTests", callingClassName + ".ps1");
                _helper.SetupModules(
                    scriptLocation,
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath(@"AzureRM.Automation.psd1"), "AzureRM.Resources.ps1");
                _helper.RunPowerShellTest(scripts);
            }
        }

        protected StorageManagementClient GetArmStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected AutomationClient GetAutomationManagementClient(MockContext context)
        {
            return context.GetServiceClient<AutomationClient>
                (Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private string GetSessionRecordsDirectory()
        {
            // Note: if you are developing new tests, set the recording directory to a local path.
            //       this is the location where the json files will be created.
            var recordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            return recordsDirectory;
        }
    }
}