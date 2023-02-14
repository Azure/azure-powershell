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

namespace Microsoft.Azure.Commands.DataLakeStore.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using ServiceManagement.Common.Models;
    using System;
    using System.Reflection;
    using Xunit;
    using System.IO;
    using Microsoft.Azure.Commands.DataLake.Test.ScenarioTests;

    public class AdlsTests : DataLakeStoreTestRunner
    {
        private readonly string ResourceGroupLocation = "westus";
        private readonly string TestFileSystemPermissionResourceGroupLocation = "ukwest";
        private readonly string TestFileSystemResourceGroupLocation = "ukwest";

        public AdlsTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsFirewallRules()
        {
            TestRunner.RunTestScript($"Test-DataLakeStoreFirewall -location '{ResourceGroupLocation}'");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsVirtualNetworkRules()
        {
            TestRunner.RunTestScript($"Test-DataLakeStoreVirtualNetwork -location '{ResourceGroupLocation}'");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsTrustedIdProvider()
        {
            TestRunner.RunTestScript($"Test-DataLakeStoreTrustedIdProvider -location '{ResourceGroupLocation}'");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsAccount()
        {
            TestRunner.RunTestScript($"Test-DataLakeStoreAccount -location '{ResourceGroupLocation}'");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsAccountTiers()
        {
            TestRunner.RunTestScript($"Test-DataLakeStoreAccountTiers -location '{ResourceGroupLocation}'");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsFileSystem()
        {
            var workingPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            var testLocation = Path.Combine(workingPath, "ScenarioTests", (this.GetType().Name + ".ps1"));
            TestRunner.RunTestScript($"Test-DataLakeStoreFileSystem -fileToCopy '{testLocation}' -location '{TestFileSystemResourceGroupLocation}'");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsFileSystemPermissions()
        {
            TestRunner.RunTestScript($"Test-DataLakeStoreFileSystemPermissions -location '{TestFileSystemPermissionResourceGroupLocation}'");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNegativeAdlsAccount()
        {
            TestRunner.RunTestScript($"Test-NegativeDataLakeStoreAccount -location '{ResourceGroupLocation}'");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsEnumerateAndRestoreDeletedItem()
        {
            TestRunner.RunTestScript($"Test-EnumerateAndRestoreDataLakeStoreDeletedItem -location '{ResourceGroupLocation}'");
        }
    }
}
