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
    using Microsoft.Azure.Test;
    using Xunit;

    public class AdlsTests : AdlsTestsBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsAccount()
        {
            RunPowerShellTest(string.Format("Test-DataLakeStoreAccount -resourceGroupName {0} -accountName {1} -location '{2}'", this.resourceGroupName, this.dataLakeAccountName, AdlsTestsBase.resourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsFileSystem()
        {
            RunPowerShellTest(string.Format("Test-DataLakeStoreFileSystem -resourceGroupName {0} -accountName {1} -fileToCopy '{2}' -location '{3}'", this.resourceGroupName, this.dataLakeAccountName, ".\\ScenarioTests\\" + this.GetType().Name + ".ps1", AdlsTestsBase.resourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsFileSystemPermissions()
        {
            RunPowerShellTest(string.Format("Test-DataLakeStoreFileSystemPermissions -resourceGroupName {0} -accountName {1} -location '{2}'", this.resourceGroupName, this.dataLakeAccountName, AdlsTestsBase.resourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNegativeAdlsAccount()
        {
            RunPowerShellTest(string.Format("Test-NegativeDataLakeStoreAccount -resourceGroupName {0} -accountName {1} -location '{2}'", this.resourceGroupName, this.dataLakeAccountName, AdlsTestsBase.resourceGroupLocation));
        }
    }
}
