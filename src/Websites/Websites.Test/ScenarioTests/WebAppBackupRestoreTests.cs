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
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class WebAppBackupRestoreTests : WebsitesTestRunner
    {
        public WebAppBackupRestoreTests(ITestOutputHelper output)
            : base(output)
        {
        }

#if NETSTANDARD
        [Fact]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewWebAppBackup()
        {
            TestRunner.RunTestScript("Test-CreateNewWebAppBackup");
        }

#if NETSTANDARD
        [Fact]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewWebAppBackupPiping()
        {
            TestRunner.RunTestScript("Test-CreateNewWebAppBackupPiping");
        }

#if NETSTANDARD
        [Fact]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebAppBackup()
        {
            TestRunner.RunTestScript("Test-GetWebAppBackup");
        }

#if NETSTANDARD
        [Fact]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebAppBackupList()
        {
            TestRunner.RunTestScript("Test-GetWebAppBackupList");
        }

#if NETSTANDARD
        [Fact]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEditAndGetWebAppBackupConfiguration()
        {
            TestRunner.RunTestScript("Test-EditAndGetWebAppBackupConfiguration");
        }

#if NETSTANDARD
        [Fact]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEditAndGetWebAppBackupConfigurationPiping()
        {
            TestRunner.RunTestScript("Test-EditAndGetWebAppBackupConfigurationPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebAppSnapshot()
        {
            TestRunner.RunTestScript("Test-GetWebAppSnapshot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreWebAppSnapshot()
        {
            TestRunner.RunTestScript("Test-RestoreWebAppSnapshot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetDeletedWebApp()
        {
            TestRunner.RunTestScript("Test-GetDeletedWebApp");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreDeletedWebAppToExisting()
        {
            TestRunner.RunTestScript("Test-RestoreDeletedWebAppToExisting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreDeletedWebAppToNew()
        {
            TestRunner.RunTestScript("Test-RestoreDeletedWebAppToNew");
        }
    }
}
