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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.DataBox;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using ResourceManagementClient = Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient;
using StorageManagementClient = Microsoft.Azure.Management.Storage.Version2017_10_01.StorageManagementClient;
using Microsoft.Azure.ServiceManagement.Common.Models;

namespace Microsoft.Azure.Commands.DataBox.Test
{
    public abstract class DataBoxScenarioTestBase : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;

        protected DataBoxScenarioTestBase()
        { 
            _helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(MockContext context)
        {
            var dataPipelineManagementClient = GetDataPipelineManagementClient(context);
            var resourceManagementClient = GetResourceManagementClient(context);
            var storageManagementClient = GetStorageManagementClient(context);

            _helper.SetupManagementClients(dataPipelineManagementClient, resourceManagementClient, storageManagementClient);
        }

        protected void RunPowerShellTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            _helper.TracingInterceptor = logger;

            var d = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Storage", null },
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null}
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
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + GetType().Name + ".ps1",
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath("Az.DataBox.psd1"),
                    "AzureRM.Resources.ps1", "AzureRM.Storage.ps1");

                _helper.RunPowerShellTest(scripts);
            }
        }

        protected DataBoxManagementClient GetDataPipelineManagementClient(MockContext context)
        {
            var testEnv = TestEnvironmentFactory.GetTestEnvironment();
            //testEnv.SubscriptionId = "05b5dd1c-793d-41de-be9f-6f9ed142f695";
            return context.GetServiceClient<DataBoxManagementClient>(testEnv);
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
