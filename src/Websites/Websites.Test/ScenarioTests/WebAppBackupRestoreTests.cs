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

using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class WebAppBackupRestoreTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public WebAppBackupRestoreTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
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
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-CreateNewWebAppBackup");
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
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-CreateNewWebAppBackupPiping");
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
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-GetWebAppBackup");
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
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-GetWebAppBackupList");
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
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-EditAndGetWebAppBackupConfiguration");
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
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-EditAndGetWebAppBackupConfigurationPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebAppSnapshot()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-GetWebAppSnapshot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreWebAppSnapshot()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-RestoreWebAppSnapshot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetDeletedWebApp()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-GetDeletedWebApp");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreDeletedWebAppToExisting()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-RestoreDeletedWebAppToExisting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreDeletedWebAppToNew()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-RestoreDeletedWebAppToNew");
        }
    }
}
