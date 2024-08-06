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

using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Test.ScenarioTests;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using Xunit;
using Xunit.Abstractions;

namespace RecoveryServices.SiteRecovery.Test
{
    public class AsrCommonTests : RecoveryServicesSiteRecoveryTestRunner
    {
        private readonly string _credModule = $"ScenarioTests/Common/Common.VaultCredentials";
        private readonly string _testModule = $"ScenarioTests/Common/AsrTests.ps1";

        public AsrCommonTests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnumerationTests()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-SiteRecoveryEnumerationTests -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

#if NETSTANDARD
        [Fact(Skip = "Linux date encoding issue: https://github.com/Azure/azure-powershell/issues/7506")]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AEvent()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-AsrEvent -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AGetJobTest()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-Job -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AGetNotificationTest()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-NotificationSettings -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CIKTokenValidation()
        {
            DateTime dateTime = new DateTime(636604658296924385, DateTimeKind.Utc);
            PSRecoveryServicesClient.asrVaultCreds = new ASRVaultCreds();
            PSRecoveryServicesClient.asrVaultCreds.ChannelIntegrityKey = "RandomRandom";
            var cikToken = PSRecoveryServicesClient.GenerateAgentAuthenticationHeader(
                  "e5ec3f71-75c6-4688-b557-6ef69d2e7514-2018-04-27 22:43:45Z-Ps",
                   dateTime);
            Assert.Equal(
                "{\"NotBeforeTimestamp\":\"\\/Date(1524865429692)\\/\",\"NotAfterTimestamp\":\"\\/Date(1525470229692)\\/\",\"ClientRequestId\":\"e5ec3f71-75c6-4688-b557-6ef69d2e7514-2018-04-27 22:43:45Z-Ps\",\"HashFunction\":\"HMACSHA256\",\"Hmac\":\"Uyz6emnjzNW/OCLM3Knqrlb1lO4ujjR5M/MXaxbb+QQ=\",\"Version\":\"1.2\",\"PropertyBag\":{}}",
                cikToken);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureMonitorAlertsForSiteRecovery()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-AzureMonitorAlertsForSiteRecovery"
            );
        }
    }
}
