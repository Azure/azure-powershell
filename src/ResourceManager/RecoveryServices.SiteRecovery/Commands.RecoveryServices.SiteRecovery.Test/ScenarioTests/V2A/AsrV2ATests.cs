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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace RecoveryServices.SiteRecovery.Test
{
    public class AsrV2ATests : AsrTestsBase
    {
        public AsrV2ATests(
            ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            this.vaultSettingsFilePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests\\V2A\\V2A.VaultCredentials");
            this.powershellFile = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests\\V2A\\AsrV2ATests.ps1");
            this.initialize();
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2AEvent()
        {
            this.RunPowerShellTest(
             Constants.NewModel,
             "Test-AsrEvent -vaultSettingsFilePath \"" + this.vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AvCenterTest()
        {
            this.RunPowerShellTest(
              Constants.NewModel,
              "Test-vCenter -vaultSettingsFilePath \"" + this.vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2AFabricTests()
        {
            this.RunPowerShellTest(
             Constants.NewModel,
             "Test-SiteRecoveryFabricTest -vaultSettingsFilePath \"" + this.vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2AGetJobTest()
        {
            this.RunPowerShellTest(
             Constants.NewModel,
             "Test-Job -vaultSettingsFilePath \"" + this.vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2AGetNotificationTest()
        {
            this.RunPowerShellTest(
             Constants.NewModel,
             "Test-NotificationSettings -vaultSettingsFilePath \"" + this.vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2APCMappingTest()
        {
            this.RunPowerShellTest(
             Constants.NewModel,
             "Test-PCM -vaultSettingsFilePath \"" + this.vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2APCTest()
        {
            this.RunPowerShellTest(
             Constants.NewModel,
             "Test-PC -vaultSettingsFilePath \"" + this.vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2APolicyTest()
        {
            this.RunPowerShellTest(
             Constants.NewModel,
             "Test-SiteRecoveryPolicy -vaultSettingsFilePath \"" + this.vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AAddPI()
        {
            this.RunPowerShellTest(
             Constants.NewModel,
             "Test-V2AAddPI -vaultSettingsFilePath \"" + this.vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2ACreateRPI()
        {
            this.RunPowerShellTest(
             Constants.NewModel,
             "V2ACreateRPI -vaultSettingsFilePath \"" + this.vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
             Category.AcceptanceType,
             Category.CheckIn)]
        public void V2ATestResync()
        {
            this.RunPowerShellTest(
             Constants.NewModel,
             "V2ATestResync -vaultSettingsFilePath \"" + this.vaultSettingsFilePath + "\"");
        }

    }
}
