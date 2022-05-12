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
    using System.Collections.Generic;
    using System;
    using System.Reflection;
    using Xunit;
    using System.IO;

    public class AdlsTests : DataLakeStoreTestRunner
    {
        internal const string ResourceGroupLocation = "westus";
        internal const string TestFileSystemPermissionResourceGroupLocation = "ukwest";
        internal const string TestFileSystemResourceGroupLocation = "ukwest";

        public AdlsTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        public string[] NewScripts(params string[] scripts)
        {
            var newScripts = new List<string>(scripts);
            newScripts.Insert(0, "$ProgressPreference=\"SilentlyContinue\"");
            return newScripts.ToArray();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsFirewallRules()
        {
            TestRunner.RunTestScript(NewScripts(string.Format("Test-DataLakeStoreFirewall -location '{0}'", ResourceGroupLocation)));
            ReSetDataLakeStoreFileSystemManagementClient();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsVirtualNetworkRules()
        {
            TestRunner.RunTestScript(NewScripts(string.Format("Test-DataLakeStoreVirtualNetwork -location '{0}'", ResourceGroupLocation)));
            ReSetDataLakeStoreFileSystemManagementClient();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsTrustedIdProvider()
        {
            TestRunner.RunTestScript(NewScripts(string.Format("Test-DataLakeStoreTrustedIdProvider -location '{0}'", ResourceGroupLocation)));
            ReSetDataLakeStoreFileSystemManagementClient();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsAccount()
        {
            TestRunner.RunTestScript(NewScripts(string.Format("Test-DataLakeStoreAccount -location '{0}'", ResourceGroupLocation)));
            ReSetDataLakeStoreFileSystemManagementClient();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsAccountTiers()
        {
            TestRunner.RunTestScript(NewScripts(string.Format("Test-DataLakeStoreAccountTiers -location '{0}'", ResourceGroupLocation)));
            ReSetDataLakeStoreFileSystemManagementClient();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsFileSystem()
        {
            var workingPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            var testLocation = Path.Combine(workingPath, "ScenarioTests", (this.GetType().Name + ".ps1"));
            TestRunner.RunTestScript(NewScripts(string.Format("Test-DataLakeStoreFileSystem -fileToCopy '{0}' -location '{1}'", testLocation, TestFileSystemResourceGroupLocation)));
            ReSetDataLakeStoreFileSystemManagementClient();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsFileSystemPermissions()
        {
            TestRunner.RunTestScript(NewScripts(string.Format("Test-DataLakeStoreFileSystemPermissions -location '{0}'", TestFileSystemPermissionResourceGroupLocation)));
            ReSetDataLakeStoreFileSystemManagementClient();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNegativeAdlsAccount()
        {
            TestRunner.RunTestScript(NewScripts(string.Format("Test-NegativeDataLakeStoreAccount -location '{0}'", ResourceGroupLocation)));
            ReSetDataLakeStoreFileSystemManagementClient();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsEnumerateAndRestoreDeletedItem()
        {
            TestRunner.RunTestScript(NewScripts(string.Format("Test-EnumerateAndRestoreDataLakeStoreDeletedItem -location '{0}'", ResourceGroupLocation)));
            ReSetDataLakeStoreFileSystemManagementClient();
        }
    }
}
