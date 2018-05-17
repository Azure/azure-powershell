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
using Microsoft.Azure.Commands.Common.Authentication;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;

namespace Microsoft.Azure.Commands.ApiManagement.Test.ScenarioTests
{
    using Azure.Test.HttpRecorder;
    using WindowsAzure.Commands.ScenarioTest;
    using WindowsAzure.Commands.Test.Utilities.Common;
    using ResourceManagementClient = Management.Internal.Resources.ResourceManagementClient;
    using Xunit;

    public class ApiManagementTests : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;

        public ApiManagementTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _helper = new EnvironmentSetupHelper
            {
                TracingInterceptor = new XunitTracingInterceptor(output)
            };
            XunitTracingInterceptor.AddToContext(_helper.TracingInterceptor);
        }

        protected void SetupManagementClients(MockContext context)
        {
            var resourceManagementClient = GetResourceManagementClient(context);
            var armStorageManagementClient = GetArmStorageManagementClient(context);

            _helper.SetupSomeOfManagementClients( resourceManagementClient, armStorageManagementClient);
        }

        protected StorageManagementClient GetArmStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrudApiManagement()
        {
            RunPowerShellTest("Test-CrudApiManagement");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version out-of-date: Awaiting Storage.Management.Common")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBackupRestoreApiManagement()
        {
            RunPowerShellTest("Test-BackupRestoreApiManagement");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetApiManagementDeploymentExternalVN()
        {
            RunPowerShellTest("Test-SetApiManagementDeploymentExternalVirtualNetwork");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetApiManagementDeploymentInternalVN()
        {
            RunPowerShellTest("Test-SetApiManagementDeploymentInternalVirtualNetwork");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateApiManagementDeployment()
        {
            RunPowerShellTest("Test-UpdateApiManagementDeployment");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateDeploymentComplex()
        {
            RunPowerShellTest("Test-UpdateApiManagementDeploymentWithHelpersAndPipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestImportApiManagementHostnameCertificate()
        {
            RunPowerShellTest("Test-ImportApiManagementHostnameCertificate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetApiManagementHostnames()
        {
            RunPowerShellTest("Test-SetApiManagementHostnames");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrudApiManagementWithExternalVpn()
        {
            RunPowerShellTest("Test-CrudApiManagementWithExternalVpn");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrudApiManagementWithAdditionalRegions()
        {
            RunPowerShellTest("Test-CrudApiManagementWithAdditionalRegions");
        }

        private void RunPowerShellTest(params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            Dictionary<string, string> d = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + GetType().Name + ".ps1",
                    _helper.RMProfileModule,
                    _helper.RMStorageDataPlaneModule,
                    _helper.GetRMModulePath("AzureRM.ApiManagement.psd1"),
                    "AzureRM.Storage.ps1",
                    "AzureRM.Resources.ps1");

                _helper.RunPowerShellTest(scripts);
            }
        }
    }
}