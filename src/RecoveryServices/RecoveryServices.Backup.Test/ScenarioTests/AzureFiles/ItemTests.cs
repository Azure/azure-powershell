﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.ScenarioTests
{
    public partial class ItemTests : RMTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureFS)]
        public void TestAzureFSItem()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.AzureFiles, "Test-AzureFSItem");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureFS)]
        public void TestAzureFSBackup()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.AzureFiles, "Test-AzureFSBackup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureFS)]
        public void TestAzureFSGetRPs()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.AzureFiles, "Test-AzureFSGetRPs");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureFS)]
        public void TestAzureFSProtection()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.AzureFiles, "Test-AzureFSProtection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureFS)]
        public void TestAzureFSFullRestore()
        {
            TestController.NewInstance.RunPsTest(
                _logger, PsBackupProviderTypes.AzureFiles, "Test-AzureFSFullRestore");
        }
    }
}
