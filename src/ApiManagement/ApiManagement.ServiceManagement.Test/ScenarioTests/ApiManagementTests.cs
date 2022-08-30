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

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Test.ScenarioTests
{
    public class ApiManagementTests : ApiManagementTestRunner
    {
        public string Location { get; set; }
        public string ResourceGroupName { get; set; }
        public string ApiManagementServiceName { get; set; }

        public ApiManagementTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
            using (var context = MockContext.Start("ApiManagementTests", "CreateApiManagementService"))
            {
                var resourceManagementClient = ApiManagementHelper.GetResourceManagementClient(context);
                ResourceGroupName = "Apim-NetSdk-20210801";
                Location = "CentralUSEUAP";

                if (string.IsNullOrWhiteSpace(ResourceGroupName))
                {
                    ResourceGroupName = TestUtilities.GenerateName("Api-Default");
                    resourceManagementClient.TryRegisterResourceGroup(Location, ResourceGroupName);
                }

                ApiManagementServiceName = "powershellsdkservicetest";
                ApiManagementHelper.GetApiManagementClient(context).TryCreateApiService(ResourceGroupName, ApiManagementServiceName, Location);
            }
        }

        public string[] ConvertScriptName(params string[] scripts)
        {
            return scripts.Select(s => s + $" {ResourceGroupName} {ApiManagementServiceName}").ToArray();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiCrudGraphQLTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Api-CrudGraphQlTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiCrudWebSocketTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Api-CrudWebSocketTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Api-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiCloneCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("ApiClone-Test"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiImportExportWadlTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Api-ImportExportWadlTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiImportExportSwaggerTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Api-ImportExportSwaggerTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiImportExportWsdlTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Api-ImportExportWsdlTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiImportExportOpenApiTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Api-ImportExportOpenApiTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiImportExportOpenApiJsonTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Api-ImportExportOpenApiJsonTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiSchemaCrudOnSwaggerApiTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("ApiSchema-SwaggerCRUDTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiSchemaCrudOnWsdlApiTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("ApiSchema-WsdlCRUDTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void OperationsCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Operations-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ProductCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Product-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionOldModelCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("SubscriptionOldModel-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionNewModelCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("SubscriptionNewModel-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UserCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("User-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GroupCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Group-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PolicyCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Policy-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CertificateCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Certificate-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AuthorizationServerCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("AuthorizationServer-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoggerCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Logger-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GatewayCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Gateway-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PropertiesCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Properties-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void OpenIdConnectProviderCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("OpenIdConnectProvider-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IdentityProviderAadB2CCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("IdentityProvider-AadB2C-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IdentityProviderCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("IdentityProvider-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TenantGitConfCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("TenantGitConfiguration-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TenantAccessConfCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("TenantAccessConfiguration-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BackendCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Backend-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BackendServiceFabricCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("BackendServiceFabric-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiVersionSetImportCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("ApiVersionSet-ImportCrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiVersionSetCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("ApiVersionSet-SetCrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiRevisionCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("ApiRevision-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CacheCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Cache-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DiagnosticCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("Diagnostic-CrudTest"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApiDiagnosticCrudTest()
        {
            TestRunner.RunTestScript(ConvertScriptName("ApiDiagnostic-CrudTest"));
        }
    }
}