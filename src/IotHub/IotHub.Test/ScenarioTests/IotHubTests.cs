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

namespace Microsoft.Azure.Commands.IotHub.Test.ScenarioTests
{
    public class IotHubTests : IotHubTestRunner
    {
        public IotHubTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Re-record", "ClientRuntime changes")]
        public void TestAzureIotHubLifeCycle()
        {
            TestRunner.RunTestScript("Test-AzureRmIotHubLifecycle");
        }

#if NETSTANDARD
        [Fact(Skip = "Requires New-SelfSignedCertificate, unavailable for PowerShell Core")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Re-record", "ClientRuntime changes")]
        [Trait("Requires", "Elevated Privileges")]
        public void TestAzureIotHubCertificateLifeCycle()
        {
            TestRunner.RunTestScript("Test-AzureRmIotHubCertificateLifecycle");
        }
    }
}
