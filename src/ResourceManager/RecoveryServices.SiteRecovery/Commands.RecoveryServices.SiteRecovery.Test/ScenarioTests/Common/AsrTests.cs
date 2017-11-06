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

using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;


namespace RecoveryServices.SiteRecovery.Test
{
    public class AsrCommonTests : AsrTestsBase
    {
        public AsrCommonTests(
            ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            this.vaultSettingsFilePath = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests\\Common\\Common.VaultCredentials");
            this.powershellFile = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests\\Common\\AsrTests.ps1");
            this.initialize();
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void EnumerationTests()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-SiteRecoveryEnumerationTests -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
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
    }
}
