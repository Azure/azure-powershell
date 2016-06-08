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
    using Xunit;

    public class AdlsTests : AdlsTestsBase
    {
        public AdlsTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsAccount()
        {
            NewInstance.RunPsTest(string.Format("Test-DataLakeStoreAccount -location '{0}'", AdlsTestsBase.resourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsFileSystem()
        {
            NewInstance.RunPsTest(string.Format("Test-DataLakeStoreFileSystem -fileToCopy '{0}' -location '{1}'", ".\\ScenarioTests\\" + this.GetType().Name + ".ps1", AdlsTestsBase.resourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlsFileSystemPermissions()
        {
            NewInstance.RunPsTest(string.Format("Test-DataLakeStoreFileSystemPermissions -location '{0}'", AdlsTestsBase.resourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNegativeAdlsAccount()
        {
            NewInstance.RunPsTest(string.Format("Test-NegativeDataLakeStoreAccount -location '{0}'", AdlsTestsBase.resourceGroupLocation));
        }
    }
}
