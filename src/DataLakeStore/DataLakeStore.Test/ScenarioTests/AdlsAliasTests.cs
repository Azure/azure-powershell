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

using System;

namespace Microsoft.Azure.Commands.DataLakeStore.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using ServiceManagement.Common.Models;
    using System.IO;
    using System.Reflection;
    using Xunit;

    public class AdlsAliasTests : AdlsTestsBase
    {
        public XunitTracingInterceptor _logger;

        public AdlsAliasTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsAccount()
        {
            NewInstance.RunPsTest(_logger, string.Format("Test-DataLakeStoreAccount -location '{0}'", AdlsTestsBase.ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsAccountTiers()
        {
            NewInstance.RunPsTest(_logger, string.Format("Test-DataLakeStoreAccountTiers -location '{0}'", AdlsTestsBase.ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsFirewallRules()
        {
            NewInstance.RunPsTest(_logger, string.Format("Test-DataLakeStoreFirewall -location '{0}'", AdlsTestsBase.ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsVirtualNetworkRules()
        {
            NewInstance.RunPsTest(_logger, string.Format("Test-DataLakeStoreVirtualNetwork -location '{0}'", AdlsTestsBase.ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsTrustedIdProvider()
        {
            NewInstance.RunPsTest(_logger, string.Format("Test-DataLakeStoreTrustedIdProvider -location '{0}'", AdlsTestsBase.ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsFileSystem()
        {
            var workingPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            var testLocation = Path.Combine(workingPath, "ScenarioTests", (this.GetType().Name + ".ps1"));
            NewInstance.RunPsTest(_logger, string.Format("Test-DataLakeStoreFileSystem -fileToCopy '{0}' -location '{1}'", testLocation, AdlsTestsBase.ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsFileSystemPermissions()
        {
            NewInstance.RunPsTest(_logger, string.Format("Test-DataLakeStoreFileSystemPermissions -location '{0}'", AdlsTestsBase.ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNegativeAdlsAccount()
        {
            NewInstance.RunPsTest(_logger, string.Format("Test-NegativeDataLakeStoreAccount -location '{0}'", AdlsTestsBase.ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsEnumerateAndRestoreDeletedItem()
        {
            NewInstance.RunPsTest(_logger, string.Format("Test-AdlsEnumerateAndRestoreDeletedItem -location '{0}'", AdlsTestsBase.ResourceGroupLocation));
        }
    }
}
