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
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class ManagedInstanceProtectorTests : SqlTestRunner
    {
        public ManagedInstanceProtectorTests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorCI()
        {
            TestRunner.RunTestScript("Test-SetGetManagedInstanceEncryptionProtectorCI");
        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorByokFailsWithoutKeyId()
        {
            TestRunner.RunTestScript("Test-SetGetManagedInstanceEncryptionProtectorByokFailsWithoutKeyId");
        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorServiceManaged()
        {
            TestRunner.RunTestScript("Test-SetGetManagedInstanceEncryptionProtectorServiceManaged");
        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorServiceManagedInputObject()
        {
            TestRunner.RunTestScript("Test-SetGetManagedInstanceEncryptionProtectorServiceManagedInputObject");
        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorServiceManagedResourceId()
        {
            TestRunner.RunTestScript("Test-SetGetManagedInstanceEncryptionProtectorServiceManagedResourceId");
        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorServiceManagedPiping()
        {
            TestRunner.RunTestScript("Test-SetGetManagedInstanceEncryptionProtectorServiceManagedPiping");
        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorByok()
        {
            TestRunner.RunTestScript("Test-SetGetManagedInstanceEncryptionProtectorByok");
        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorByokInputObject()
        {
            TestRunner.RunTestScript("Test-SetGetManagedInstanceEncryptionProtectorByokInputObject");
        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorByokResourceId()
        {
            TestRunner.RunTestScript("Test-SetGetManagedInstanceEncryptionProtectorByokResourceId");
        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorByokPiping()
        {
            TestRunner.RunTestScript("Test-SetGetManagedInstanceEncryptionProtectorByokPiping");
        }
    }
}
