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
    public class TransparentDataEncryptionCrudTests : SqlTestsBase
    {
        public TransparentDataEncryptionCrudTests(ITestOutputHelper output) : base(output)
        {
            base.resourceTypesToIgnoreApiVersion = new string[] {
                "Microsoft.Sql/servers"
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseTransparentDataEncryptionUpdate()
        {
            RunPowerShellTest("Test-UpdateTransparentDataEncryption");
        }

        [Fact(Skip = "Gets empty status when expecting encrypting")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseTransparentDataEncryptionGet()
        {
            RunPowerShellTest("Test-GetTransparentDataEncryption");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerTransparentDataEncryptionProtectorGet()
        {
            RunPowerShellTest("Test-GetTransparentDataEncryptionProtector");
        }

        [Fact(Skip = "TODO: only works for live mode. Mihymel will fix the test issue for Create-ServerKeyVaultKeyTestEnvironment")]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestServerTransparentDataEncryptionProtectorSet()
        {
            RunPowerShellTest("Test-SetTransparentDataEncryptionProtector");
        }
    }
}
