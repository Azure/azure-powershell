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

using System;
using System.IO;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace RecoveryServices.SiteRecovery.Test
{
    public class AsrVmwareCbtTests : AsrTestsBase
    {
        public XunitTracingInterceptor _logger;

        public AsrVmwareCbtTests(
            ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            this.VaultSettingsFilePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "VmwareCbt", "VmwareCbt.VaultCredentials");
            this.PowershellFile = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "VmwareCbt", "AsrVmwareCbtTests.ps1");
            this.Initialize();
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void VmwareCbtFabricTests()
        {
            this.RunPowerShellTest(
               _logger,
             Constants.NewModel,
             "Test-SiteRecoveryFabricTest -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void VmwareCbtPCMappingTest()
        {
            this.RunPowerShellTest(
                _logger,
             Constants.NewModel,
             "Test-PCM -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void VmwareCbtPCTest()
        {
            this.RunPowerShellTest(
                _logger,
             Constants.NewModel,
             "Test-PC -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void VmwareCbtPolicyTest()
        {
            this.RunPowerShellTest(
                _logger,
             Constants.NewModel,
             "Test-SiteRecoveryPolicy -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VmwareCbtCreateRMI()
        {
            this.RunPowerShellTest(
                _logger,
             Constants.NewModel,
             "V2ACreateRMI -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VmwareCbtTestMigrateJob()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "VmwareCbtTestMigrateJob -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VmwareCbtMigrateJob()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "VmwareCbtMigrateJob -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }
    }
}
