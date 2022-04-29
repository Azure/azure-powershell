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
using Microsoft.Azure.Management.Storage.Version2017_10_01;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using ResourceManagementClient = Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient;
using Xunit;
using Microsoft.Azure.Commands.TestFx;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ApiManagement.Test.ScenarioTests
{
    using ApiManagementClient = Management.ApiManagement.ApiManagementClient;

    public class ApiManagementTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected ApiManagementTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance (output)
                .WithNewPsScriptFilename ($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests ("ScenarioTests")
                .WithCommonPsScripts (new[]
                {
                    @"Common.ps1",
                    @"../AzureRM.Storage.ps1",
                    @"../AzureRM.Resources.ps1"
                })
                .WithNewRmModules (helper => new[]
                {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("Az.ApiManagement.psd1")
                })
                .WithNewRecordMatcherArguments (
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null}
                    }
                ).WithManagementClients(
                    GetResourceManagementClient,
                    GetArmStorageManagementClient,
                    GetApiManagementManagementClient
                )
                .Build();
        }

        private static StorageManagementClient GetArmStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ApiManagementClient GetApiManagementManagementClient(MockContext context)
        {
            return context.GetServiceClient<ApiManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }

    public class ApiManagementTests : ApiManagementTestRunner
    {
        public ApiManagementTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrudApiManagement()
        {
            TestRunner.RunTestScript("Test-CrudApiManagement");
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
            TestRunner.RunTestScript("Test-BackupRestoreApiManagement");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestApiManagementHostnamesCrud()
        {
            TestRunner.RunTestScript("Test-ApiManagementHostnamesCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrudApiManagementWithVirtualNetwork()
        {
            TestRunner.RunTestScript("Test-ApiManagementVirtualNetworkCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrudApiManagementWithAdditionalRegions()
        {
            TestRunner.RunTestScript("Test-ApiManagementWithAdditionalRegionsCRUD");
        }
    }
}