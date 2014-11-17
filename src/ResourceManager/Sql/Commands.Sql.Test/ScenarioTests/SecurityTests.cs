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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.Azure.Commands.ScenarioTest.SqlTests
{
    public class SecurityTests : SqlTestsBase
    {
        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-DatabaseUpdatePolicyWithStorage");
        }

        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-ServerUpdatePolicyWithStorage");
        }

        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseUpdatePolicyWithEventTypes()
        {
            RunPowerShellTest("Test-DatabaseUpdatePolicyWithEventTypes");
        }

        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerUpdatePolicyWithEventTypes()
        {
            RunPowerShellTest("Test-ServerUpdatePolicyWithEventTypes");
        }

        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableDatabaseAuditing()
        {
            RunPowerShellTest("Test-DisableDatabaseAuditing");
        }

        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableServerAuditing()
        {
            RunPowerShellTest("Test-DisableServerAuditing");
        }

        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseDisableEnableKeepProperties()
        {
            RunPowerShellTest("Test-DatabaseDisableEnableKeepProperties");
        }

        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerDisableEnableKeepProperties()
        {
            RunPowerShellTest("Test-ServerDisableEnableKeepProperties");
        }

        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUseServerDefault()
        {
            RunPowerShellTest("Test-UseServerDefault");
        }

        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailedDatabaseUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-FailedDatabaseUpdatePolicyWithNoStorage");
        }

        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailedServerUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-FailedServerUpdatePolicyWithNoStorage");
        }

        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailedUseServerDefault()
        {
            RunPowerShellTest("Test-FailedUseServerDefault");
        }

        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseUpdatePolicyWithEventTypeShortcuts()
        {
            RunPowerShellTest("Test-DatabaseUpdatePolicyWithEventTypeShortcuts");
        }

        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerUpdatePolicyWithEventTypeShortcuts()
        {
            RunPowerShellTest("Test-ServerUpdatePolicyWithEventTypeShortcuts");
        }

        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-DatabaseUpdatePolicyKeepPreviousStorage");
        }

        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-ServerUpdatePolicyKeepPreviousStorage");
        }

        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailWithBadDatabaseIndentity()
        {
            RunPowerShellTest("Test-FailWithBadDatabaseIndentity");
        }

        [Fact(Skip = "Skip for the version header upgrade on Storage library.")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailWithBadServerIndentity()
        {
            RunPowerShellTest("Test-FailWithBadServerIndentity");
        }
    }
}
