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

namespace Microsoft.Azure.Commands.Attestation.Test.ScenarioTests
{
    public class AttstationPolicyTests : AttestationTestRunner
    {
        public AttstationPolicyTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestGetAttestationPolicy()
        {
            TestRunner.RunTestScript("Test-GetAttestationPolicy");
        }

        /// <summary>
        /// The data plane cmdlets use the Azure.Security.Attestation SDK, whose requests the test framework
        /// does not record, so the data plane tests run live only.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestGetDefaultProviderPolicy()
        {
            TestRunner.RunTestScript("Test-GetDefaultProviderPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestResetAttestationPolicy()
        {
            TestRunner.RunTestScript("Test-ResetAttestationPolicy");
        }

        /// <summary>
        /// Set-AzAttestationPolicy validates the signed token the service returns, so a recording fails
        /// validation once the recorded token expires.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestSetAttestationPolicy()
        {
            TestRunner.RunTestScript("Test-SetAttestationPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestSetAttestationPolicyLegacyFormats()
        {
            TestRunner.RunTestScript("Test-SetAttestationPolicyLegacyFormats");
        }
    }
}
