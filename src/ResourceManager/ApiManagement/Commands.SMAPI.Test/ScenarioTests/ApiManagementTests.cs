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

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Test.ScenarioTests
{
    using System;
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

    public class ApiManagementTests : RMTestBase, IClassFixture<ApiManagementTestsFixture>
    {
        private readonly EnvironmentSetupHelper _helper;
        private ApiManagementTestsFixture _fixture;

        public ApiManagementTests(ApiManagementTestsFixture fixture)
        {
            _fixture = fixture;
            _helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(MockContext context)
        {            
            var apiManagementManagementClient = GetApiManagementManagementClient(context);
            var resourceManagementClient = GetResourceManagementClient();
            var galaryClient = GetGalleryClient();
            var authorizationManagementClient = GetAuthorizationManagementClient();
            var managementClient = GetManagementClient();
            var armStorageManagementClient = GetArmStorageManagementClient();

            _helper.SetupManagementClients(
                apiManagementManagementClient,
                resourceManagementClient,
                galaryClient,
                authorizationManagementClient,
                managementClient,
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
            return LegacyTest.TestBase.GetServiceClient<ManagementClient>(new RDFETestEnvironmentFactory());
        }

        private AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<AuthorizationManagementClient>(new CSMTestEnvironmentFactory());
        }

        private GalleryClient GetGalleryClient()
        {
            return LegacyTest.TestBase.GetServiceClient<GalleryClient>(new CSMTestEnvironmentFactory());
        }

        private ResourceManagementClient GetResourceManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
        }

        private ApiManagementClient GetApiManagementManagementClient(MockContext context)
        {
            return context.GetServiceClient<ApiManagementClient>(
                Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory.GetTestEnvironment());
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
        public void TenantGitConfigurationCrudTest()
        {
            RunPowerShellTest("TenantGitConfiguration-CrudTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TenantAccessConfigurationCrudTest()
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
            for (int i = 0; i < scripts.Length; i++)
            {
                scripts[i] = scripts[i] + string.Format(" {0} {1}", _fixture.ResourceGroupName, _fixture.ApiManagementServiceName);
            }

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
                    _helper.GetRMModulePath(@"AzureRM.ApiManagement.psd1"));

                _helper.RunPowerShellTest(scripts);
            }
        }
    }
}