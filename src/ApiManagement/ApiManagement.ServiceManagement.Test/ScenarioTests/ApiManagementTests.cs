//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Test.ScenarioTests
{
    using Microsoft.Azure.ServiceManagement.Common.Models;
    using ApiManagementClient = Management.ApiManagement.ApiManagementClient;

    public class ApiManagementTests : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;
        public string Location { get; set; }
        public string ResourceGroupName { get; set; }
        public string ApiManagementServiceName { get; set; }

        public ApiManagementTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _helper = new EnvironmentSetupHelper
            {
                TracingInterceptor = new XunitTracingInterceptor(output)
            };
            XunitTracingInterceptor.AddToContext(_helper.TracingInterceptor);

            using (var context = MockContext.Start("ApiManagementTests", "CreateApiManagementService"))
            {
                var resourceManagementClient = ApiManagementHelper.GetResourceManagementClient(context);
                ResourceGroupName = "powershelltest";
                Location = "West US";

                if (string.IsNullOrWhiteSpace(ResourceGroupName))
                {
                    ResourceGroupName = TestUtilities.GenerateName("Api-Default");
                    resourceManagementClient.TryRegisterResourceGroup(Location, ResourceGroupName);
                }

                ApiManagementServiceName = "powershellsdkservice";
                ApiManagementHelper.GetApiManagementClient(context).TryCreateApiService(ResourceGroupName, ApiManagementServiceName, Location);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiCrudTest()
        {
            RunPowerShellTest("Api-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiImportExportWadlTest()
        {
            RunPowerShellTest("Api-ImportExportWadlTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiImportExportSwaggerTest()
        {
            RunPowerShellTest("Api-ImportExportSwaggerTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiImportExportWsdlTest()
        {
            RunPowerShellTest("Api-ImportExportWsdlTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void OperationsCrudTest()
        {
            RunPowerShellTest("Operations-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ProductCrudTest()
        {
            RunPowerShellTest("Product-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionCrudTest()
        {
            RunPowerShellTest("Subscription-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UserCrudTest()
        {
            RunPowerShellTest("User-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GroupCrudTest()
        {
            RunPowerShellTest("Group-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PolicyCrudTest()
        {
            RunPowerShellTest("Policy-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CertificateCrudTest()
        {
            RunPowerShellTest("Certificate-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AuthorizationServerCrudTest()
        {
            RunPowerShellTest("AuthorizationServer-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoggerCrudTest()
        {
            RunPowerShellTest("Logger-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PropertiesCrudTest()
        {
            RunPowerShellTest("Properties-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void OpenIdConnectProviderCrudTest()
        {
            RunPowerShellTest("OpenIdConnectProvider-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IdentityProviderCrudTest()
        {
            RunPowerShellTest("IdentityProvider-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TenantGitConfCrudTest()
        {
            RunPowerShellTest("TenantGitConfiguration-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TenantAccessConfCrudTest()
        {
            RunPowerShellTest("TenantAccessConfiguration-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BackendCrudTest()
        {
            RunPowerShellTest("Backend-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BackendServiceFabricCrudTest()
        {
            RunPowerShellTest("BackendServiceFabric-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiVersionSetCrudTest()
        {
            RunPowerShellTest("ApiVersionSet-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiRevisionCrudTest()
        {
            RunPowerShellTest("ApiRevision-CrudTest");
        }

        private void RunPowerShellTest(params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                _helper.SetupSomeOfManagementClients(context.GetServiceClient<ApiManagementClient>(TestEnvironmentFactory.GetTestEnvironment()));

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + GetType().Name + ".ps1",
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath(@"AzureRM.ApiManagement.psd1"));

                scripts = scripts.Select(s => s + $" {ResourceGroupName} {ApiManagementServiceName}").ToArray();
                _helper.RunPowerShellTest(scripts);
            }
        }
    }
}