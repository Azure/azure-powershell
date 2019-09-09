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
using Microsoft.Azure.Commands.ScenarioTest;
using CommonStorage = Microsoft.Azure.Management.Storage.Version2017_10_01;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.SqlVirtualMachine;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Xunit.Abstractions;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Compute;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.Test.ScenarioTests
{
    public class SqlVirtualMachineTestsBase
    {
        protected EnvironmentSetupHelper Helper;
        protected string[] resourceTypesToIgnoreApiVersion;

        public ComputeManagementClient ComputeManagementClient { get; set; }
        public SqlVirtualMachineManagementClient SqlVirtualMachineManagementClient { get; set; }
        public ResourceManagementClient ResourceManagementClient { get; set; }
        public NetworkManagementClient NetworkManagementClient { get; set; }
        public CommonStorage.StorageManagementClient StorageManagementClient { get; set; }
        public SqlVirtualMachineTestsBase(ITestOutputHelper output)
        {
            Helper = new EnvironmentSetupHelper();

            var tracer = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(tracer);
            Helper.TracingInterceptor = tracer;
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;
            
            var d = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null},
                {"Microsoft.Compute", null},
                {"Microsoft.Network", null},
                {"Microsoft.Storage", null},
                {"Microsoft.KeyVault", null},
            };

            var providersToIgnore = new Dictionary<string, string>
            {
                
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithResourceApiExclusion(true, d, providersToIgnore, resourceTypesToIgnoreApiVersion);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            
            // Enable undo functionality as well as mock recording
            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);
               
                Helper.SetupEnvironment(AzureModule.AzureResourceManager);
                var modules = new List<string>
                {
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + GetType().Name + ".ps1",
                    Helper.RMProfileModule,
                    Helper.GetRMModulePath(@"AzureRM.SqlVirtualMachine.psd1"),
                    Helper.GetRMModulePath("AzureRM.Compute.psd1"),
                    Helper.GetRMModulePath("AzureRM.Network.psd1"),
                    "AzureRM.Storage.ps1",
                    "AzureRM.Resources.ps1"
                };
                Helper.SetupModules(AzureModule.AzureResourceManager, modules.ToArray());
                Helper.RunPowerShellTest(scripts);
            }
            
        }

        private void SetupManagementClients(MockContext context)
        {
            ComputeManagementClient = context.GetServiceClient<ComputeManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            SqlVirtualMachineManagementClient = context.GetServiceClient<SqlVirtualMachineManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            ResourceManagementClient = context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            NetworkManagementClient = context.GetServiceClient<NetworkManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            StorageManagementClient = context.GetServiceClient<CommonStorage.StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());

            Helper.SetupSomeOfManagementClients(ComputeManagementClient, 
                SqlVirtualMachineManagementClient, 
                ResourceManagementClient,
                NetworkManagementClient,
                StorageManagementClient
            );
        }
    }
}