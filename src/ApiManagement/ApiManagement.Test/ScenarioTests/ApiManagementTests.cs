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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.ApiManagement.Test.ScenarioTests
{
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

#if NETSTANDARD
        [Fact(Skip = "Storage version out-of-date: Awaiting Storage.Management.Common")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBackupRestoreApiManagementUsingManagedIdentity()
        {
            TestRunner.RunTestScript("Test-BackupRestoreApiManagementUsingManagedIdentity");
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
        public void TestCrudApiManagementVirtualNetworkStv2CRUD()
        {
            TestRunner.RunTestScript("Test-ApiManagementVirtualNetworkStv2CRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrudApiManagementWithAdditionalRegions()
        {
            TestRunner.RunTestScript("Test-ApiManagementWithAdditionalRegionsCRUD");
        }
    }
}