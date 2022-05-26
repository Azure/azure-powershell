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

using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class TransparentDataEncryptionCrudTests : SqlTestRunner
    {
        public TransparentDataEncryptionCrudTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseTransparentDataEncryptionUpdate()
        {
            TestRunner.RunTestScript("Test-UpdateTransparentDataEncryption");
        }

        [Fact(Skip = "Gets empty status when expecting encrypting")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseTransparentDataEncryptionGet()
        {
            TestRunner.RunTestScript("Test-GetTransparentDataEncryption");
        }

        [Fact(Skip = "TODO: Skipping as the model got updated from Legacy Sdk")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerTransparentDataEncryptionProtectorGet()
        {
            TestRunner.RunTestScript("Test-GetTransparentDataEncryptionProtector");
        }

        [Fact(Skip = "TODO: only works for live mode. Mihymel will fix the test issue for Create-ServerKeyVaultKeyTestEnvironment")]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestServerTransparentDataEncryptionProtectorSet()
        {
            TestRunner.RunTestScript("Test-SetTransparentDataEncryptionProtector");
        }
    }
}
