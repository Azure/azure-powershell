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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class ManagedInstanceProtectorTests : SqlTestsBase
    {
        public ManagedInstanceProtectorTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorCI()
        {
            RunPowerShellTest("Test-SetGetManagedInstanceEncryptionProtectorCI");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorByokFailsWithoutKeyId()
        {
            RunPowerShellTest("Test-SetGetManagedInstanceEncryptionProtectorByokFailsWithoutKeyId");
        }

        //[Fact]
        //"Skipped based on azure team's recommendation to reduce CI build time"
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorServiceManaged()
        {
            RunPowerShellTest("Test-SetGetManagedInstanceEncryptionProtectorServiceManaged");
        }

        //[Fact]
        //"Skipped based on azure team's recommendation to reduce CI build time"
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorServiceManagedInputObject()
        {
            RunPowerShellTest("Test-SetGetManagedInstanceEncryptionProtectorServiceManagedInputObject");
        }

        //[Fact]
        //"Skipped based on azure team's recommendation to reduce CI build time"
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorServiceManagedResourceId()
        {
            RunPowerShellTest("Test-SetGetManagedInstanceEncryptionProtectorServiceManagedResourceId");
        }

        //[Fact]
        //"Skipped based on azure team's recommendation to reduce CI build time"
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorServiceManagedPiping()
        {
            RunPowerShellTest("Test-SetGetManagedInstanceEncryptionProtectorServiceManagedPiping");
        }

        //[Fact]
        //"Skipped based on azure team's recommendation to reduce CI build time"
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorByok()
        {
            RunPowerShellTest("Test-SetGetManagedInstanceEncryptionProtectorByok");
        }

        //[Fact]
        //"Skipped based on azure team's recommendation to reduce CI build time"
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorByokInputObject()
        {
            RunPowerShellTest("Test-SetGetManagedInstanceEncryptionProtectorByokInputObject");
        }

        //[Fact]
        //"Skipped based on azure team's recommendation to reduce CI build time"
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorByokResourceId()
        {
            RunPowerShellTest("Test-SetGetManagedInstanceEncryptionProtectorByokResourceId");
        }

        //[Fact]
        //"Skipped based on azure team's recommendation to reduce CI build time"
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetManagedInstanceEncryptionProtectorByokPiping()
        {
            RunPowerShellTest("Test-SetGetManagedInstanceEncryptionProtectorByokPiping");
        }
    }
}
