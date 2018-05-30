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


namespace Microsoft.Azure.Commands.ApiManagement.Test.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Azure.Test;
    using Management.ApiManagement;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Gallery;
    using Microsoft.Azure.Management.Authorization;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Management;
    using Microsoft.WindowsAzure.Management.Storage;
    using Rest.ClientRuntime.Azure.TestFramework;
    using WindowsAzure.Commands.Test.Utilities.Common;
    using Xunit;
    using LegacyTest = Microsoft.Azure.Test;

    public class ApiManagementTests : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;

        public ApiManagementTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _helper = new EnvironmentSetupHelper();
            _helper.TracingInterceptor = new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output);
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(_helper.TracingInterceptor);
        }

        protected void SetupManagementClients(MockContext context)
        {            
            var apiManagementManagementClient = GetApiManagementManagementClient(context);
            var resourceManagementClient = GetResourceManagementClient();
            var galaryClient = GetGalleryClient();
            var authorizationManagementClient = GetAuthorizationManagementClient();
            var managementClient = GetManagementClient();
            var newResourceManagementClient = GetResourceManagementClient(context);
            var armStorageManagementClient = GetArmStorageManagementClient();

            _helper.SetupManagementClients(
                apiManagementManagementClient,
                resourceManagementClient,
                galaryClient,
                authorizationManagementClient,
                managementClient,
                newResourceManagementClient,
                armStorageManagementClient);
        }

        protected StorageManagementClient GetStorageManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<StorageManagementClient>(new RDFETestEnvironmentFactory());
        }

        protected Management.Storage.StorageManagementClient GetArmStorageManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<Management.Storage.StorageManagementClient>(new CSMTestEnvironmentFactory());
        }

        private ManagementClient GetManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<ManagementClient>(new LegacyTest.RDFETestEnvironmentFactory());
        }

        private AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<AuthorizationManagementClient>(new CSMTestEnvironmentFactory());
        }

        private GalleryClient GetGalleryClient()
        {
            return LegacyTest.TestBase.GetServiceClient<GalleryClient>(new LegacyTest.CSMTestEnvironmentFactory());
        }

        private ResourceManagementClient GetResourceManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<ResourceManagementClient>(new LegacyTest.CSMTestEnvironmentFactory());
        }

        private Management.Internal.Resources.ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<Management.Internal.Resources.ResourceManagementClient>(
                Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private ApiManagementClient GetApiManagementManagementClient(MockContext context)
        {
            return context.GetServiceClient<ApiManagementClient>(
                Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrudApiManagement()
        {
            RunPowerShellTest("Test-CrudApiManagement");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBackupRestoreApiManagement()
        {
            RunPowerShellTest("Test-BackupRestoreApiManagement");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateApiManagementDeployment()
        {
            RunPowerShellTest("Test-UpdateApiManagementDeployment");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetApiManagementHostnames()
        {
            RunPowerShellTest("Test-SetApiManagementHostnames");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestApiManagementHostnamesCrud()
        {
            RunPowerShellTest("Test-ApiManagementHostnamesCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrudApiManagementWithVirtualNetwork()
        {
            RunPowerShellTest("Test-ApiManagementVirtualNetworkCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrudApiManagementWithAdditionalRegions()
        {
            RunPowerShellTest("Test-ApiManagementWithAdditionalRegionsCRUD");
        }

        private void RunPowerShellTest(params string[] scripts)
        {           
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Features", null);
            d.Add("Microsoft.Authorization", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (MockContext context = MockContext.Start(
                Azure.Test.TestUtilities.GetCallingClass(),
                Azure.Test.TestUtilities.GetCurrentMethodName(2)))
            {
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + GetType().Name + ".ps1",
                    _helper.RMProfileModule,
                    _helper.RMResourceModule,
                    _helper.RMStorageDataPlaneModule,
                    _helper.GetRMModulePath("AzureRM.ApiManagement.psd1"),
                    "AzureRM.Storage.ps1",
                    "AzureRM.Resources.ps1");

                _helper.RunPowerShellTest(scripts);
            }
        }
    }
}